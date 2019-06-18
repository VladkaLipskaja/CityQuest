//-----------------------------------------------------------------------
// <copyright file="MissionsController.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CityQuest.Entities.Models;
using CityQuest.Extensions;
using CityQuest.Models.Dtos;
using CityQuest.Models.Exceptions;
using CityQuest.Models.Mission;
using CityQuest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityQuest.Controllers
{
    /// <summary>
    /// The missions controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {
        /// <summary>
        /// The mission service
        /// </summary>
        private IMissionService _missionService;

        /// <summary>
        /// The security service
        /// </summary>
        private ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MissionsController" /> class.
        /// </summary>
        /// <param name="missionService">The mission service.</param>
        /// <param name="securityService">The security service.</param>
        public MissionsController(IMissionService missionService, ISecurityService securityService)
        {
            _missionService = missionService;
            _securityService = securityService;
        }

        /// <summary>
        /// Adds the mission.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Invalid request.</exception>
        [HttpPost]
        public async Task<JsonResult> AddMission([FromBody]AddMissionRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                int userId = _securityService.GetUserId(User);

                MissionDto quest = new MissionDto
                {
                    Answer = request.Answer,
                    Coordinate1 = request.Coordinate1,
                    Coordinate2 = request.Coordinate2,
                    Coordinate3 = request.Coordinate3,
                    Coordinate4 = request.Coordinate4,
                    Points = request.Points,
                    QuestId = request.QuestID,
                    TaskNumber = request.TaskNumber,
                    Text = request.Text
                };

                int id = await _missionService.AddMissionAsync(quest);

                AddMissionResponse response = new AddMissionResponse
                {
                    MissionID = id
                };

                return this.JsonApi(response);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Adds the mission to quest.
        /// </summary>
        /// <param name="missionId">The mission identifier.</param>
        /// <param name="questId">The quest identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        /// <exception cref="ArgumentNullException">Request is null.</exception>
        [HttpPost("{missionId}/quest/{questId}")]
        public async Task<JsonResult> AddMissionToQuest(int missionId, int questId, [FromBody]AddMissionToQuestRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                MissionToQuestDto missionToQuest = new MissionToQuestDto
                {
                    QuestID = questId,
                    TaskID = missionId,
                    TaskNumber = request.TaskNumber
                };

                await _missionService.AddMissionToQuestAsync(missionToQuest);

                return this.JsonApi();
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
            catch (MissionException exception)
            {
                return this.JsonApi(exception);
            }
        }
        
        /// <summary>
        /// Gets the missions.
        /// </summary>
        /// <returns>
        /// A list of missions.
        /// </returns>
        [HttpGet]
        public async Task<JsonResult> GetMissions()
        {
            Mission[] missions = await _missionService.GetMissions();

            GetMissionsResponse response = new GetMissionsResponse
            {
                Missions = missions.Select(m => new GetMissionsResponse.Mission
                {
                    Answer = m.Answer,
                    Coordinate1 = m.Coordinate1,
                    Coordinate2 = m.Coordinate2,
                    Coordinate3 = m.Coordinate3,
                    Coordinate4 = m.Coordinate4,
                    Text = m.Text,
                    ID = m.ID,
                    Points = m.Points
                }).ToArray()
            };

            return this.JsonApi(response);
        }

        /// <summary>
        /// Gets the untouched missions.
        /// </summary>
        /// <returns>
        /// A list of untouched missions.
        /// </returns>
        [HttpGet("untouched")]
        public async Task<JsonResult> GetUntouchedMissions()
        {
            Mission[] missions = await _missionService.GetUntouchedMissions();

            GetUntouchedMissionsResponse response = new GetUntouchedMissionsResponse
            {
                Missions = missions.Select(m => new GetUntouchedMissionsResponse.Mission
                {
                    Answer = m.Answer,
                    Coordinate1 = m.Coordinate1,
                    Coordinate2 = m.Coordinate2,
                    Coordinate3 = m.Coordinate3,
                    Coordinate4 = m.Coordinate4,
                    Text = m.Text,
                    ID = m.ID,
                    Points = m.Points
                }).ToArray()
            };

            return this.JsonApi(response);
        }

        /// <summary>
        /// Gets the last quest tasks.
        /// </summary>
        /// <param name="questId">The quest identifier.</param>
        /// <returns>
        /// A list of last missions.
        /// </returns>
        [HttpGet("quest/{questId}")]
        public async Task<JsonResult> GetLastQuestTasks(int questId)
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUserDto = new QuestToUserDto
                {
                    UserId = userId,
                    QuestId = questId
                };

                Mission[] missions = await _missionService.GetLastDoneMissions(questToUserDto);

                GetLastQuestTasksResponse response = new GetLastQuestTasksResponse
                {
                    Missions = missions.Select(m => new GetLastQuestTasksResponse.Mission
                    {
                        Answer = m.Answer,
                        Coordinate1 = m.Coordinate1,
                        Coordinate2 = m.Coordinate2,
                        Coordinate3 = m.Coordinate3,
                        Coordinate4 = m.Coordinate4,
                        Text = m.Text,
                        ID = m.ID,
                        Points = m.Points
                    }).ToArray()
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestToUserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Deletes the mission.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteMission(int id)
        {
            try
            {
                await _missionService.DeleteMission(id);

                return this.JsonApi();
            }
            catch (MissionException exception)
            {
                return this.JsonApi(exception);
            }
            catch (Exception exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
