//-----------------------------------------------------------------------
// <copyright file="QuestsController.cs" company="Dream Team">
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
using CityQuest.Models.Quest;
using CityQuest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityQuest.Controllers
{
    /// <summary>
    /// The quests controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    public class QuestsController : ControllerBase
    {
        /// <summary>
        /// The quest service
        /// </summary>
        private IQuestService _questService;

        /// <summary>
        /// The mission service
        /// </summary>
        private IMissionService _missionService;

        /// <summary>
        /// The security service
        /// </summary>
        private ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestsController" /> class.
        /// </summary>
        /// <param name="questService">The quest service.</param>
        /// <param name="missionService">The mission service.</param>
        /// <param name="securityService">The security service.</param>
        public QuestsController(IQuestService questService, IMissionService missionService, ISecurityService securityService)
        {
            _questService = questService;
            _missionService = missionService;
            _securityService = securityService;
        }

        /// <summary>
        /// Gets the quest missions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The array of missions.
        /// </returns>
        [HttpGet("{id}/missions")]
        public async Task<JsonResult> GetQuestMissions(int id)
        {
            try
            {
                MissionToQuest[] missions = (await _missionService.GetQuestMissionsAsync(id)).ToArray();

                GetQuestMissionsResponse response = new GetQuestMissionsResponse
                {
                    Missions = missions?.Select(t => new GetQuestMissionsResponse.Mission
                    {
                        ID = t.TaskID,
                        Answer = t.Task.Answer,
                        TaskNumber = t.TaskNumber,
                        Text = t.Task.Text,
                        Coordinate1 = t.Task.Coordinate1,
                        Coordinate2 = t.Task.Coordinate2,
                        Coordinate3 = t.Task.Coordinate3,
                        Coordinate4 = t.Task.Coordinate4,
                        Points = t.Task.Points
                    }).ToArray()
                };

                return this.JsonApi(response);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetQuests()
        {
            Quest[] quests = await _questService.GetQuestsAsync();

            GetQuestsResponse response = new GetQuestsResponse
            {
                Quests = quests?.Select(q => new GetQuestsResponse.Quest
                {
                    ID = q.ID,
                    Name = q.Name,
                    Price = q.Price,
                    Points = q.Points
                }).ToArray()
            };

            return this.JsonApi(response);
        }

        [HttpGet("untouched")]
        public async Task<JsonResult> GetUntouchedQuests()
        {
            Quest[] quests = await _questService.GetUntouchedQuestsAsync();

            GetUntouchedQuestsResponse response = new GetUntouchedQuestsResponse
            {
                Quests = quests?.Select(q => new GetUntouchedQuestsResponse.Quest
                {
                    ID = q.ID,
                    Name = q.Name,
                    Price = q.Price,
                    Points = q.Points
                }).ToArray()
            };

            return this.JsonApi(response);
        }

        [HttpGet("user")]
        public async Task<JsonResult> GetUserQuests()
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                Quest[] quests = await _questService.GetUserQuestsAsync(userId);


                GetUserQuestsResponse response = new GetUserQuestsResponse
                {
                    Quests = quests?.Select(q => new GetUserQuestsResponse.Quest
                    {
                        ID = q.ID,
                        Name = q.Name,
                        Price = q.Price
                    }).ToArray()
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpGet("last")]
        public async Task<JsonResult> GetLastQuest()
        {
            try
            {
                Quest quest = await _questService.GetLastQuestAsync();

                GetLastQuestResponse response = new GetLastQuestResponse
                {
                    ID = quest.ID,
                    Name = quest.Name,
                    Points = quest.Points,
                    Price = quest.Price
                };

                return this.JsonApi(response);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpGet("{questId}/is-last")]
        public async Task<JsonResult> QuestTaskIsLast(int questId)
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUserDto = new QuestToUserDto
                {
                    UserId = userId,
                    QuestId = questId
                };

                bool isLast = await _questService.QuestTaskIsLast(questToUserDto);

                QuestTaskIsLastResponse response = new QuestTaskIsLastResponse
                {
                    IsLast = isLast
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
            catch (MissionToQuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpPut("{questId}")]
        public async Task<JsonResult> IncreaseUserQuestTasks(int questId)
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUserDto = new QuestToUserDto
                {
                    UserId = userId,
                    QuestId = questId
                };

                await _questService.IncreaseUserQuestsTaskAsync(questToUserDto);

                return this.JsonApi();
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestToUserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (MissionToQuestException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Adds the quest.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The success indicator.</returns>
        /// <exception cref="System.ArgumentNullException">Invalid request.</exception>
        [HttpPost]
        public async Task<JsonResult> AddQuest([FromBody]AddQuestRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                int userId = _securityService.GetUserId(User);

                QuestDto quest = new QuestDto
                {
                    Name = request.Name,
                    AuthorID = userId,
                    TopicID = request.TopicID,
                    Points = request.Points,
                    Price = request.Price
                };

                int id = await _questService.AddQuestAsync(quest);

                AddQuestResponse response = new AddQuestResponse
                {
                    QuestID = id
                };

                return this.JsonApi(response);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Adds the quest to user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Invalid request.</exception>
        [HttpPost("{questId}/user")]
        public async Task<JsonResult> AddQuestToUser(int questId, [FromBody]AddQuestToUserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUser = new QuestToUserDto
                {
                    QuestId = questId,
                    FinishedTasks = request.FinishedTasks,
                    IsFinished = request.IsFinished,
                    UserId = userId
                };

                await _questService.AddQuestToUserAsync(questToUser);

                return this.JsonApi();
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestToUserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Updates the quest to user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Invalid request.</exception>
        [HttpPut("{id}/user")]
        public async Task<JsonResult> UpdateQuestToUser(UpdateQuestToUserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUser = new QuestToUserDto
                {
                    QuestId = request.QuestId,
                    FinishedTasks = request.FinishedTasks,
                    IsFinished = request.IsFinished,
                    UserId = userId
                };

                await _questService.UpdateQuestToUserAsync(questToUser);

                return this.JsonApi();
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestToUserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Gets the quest tasks done.
        /// </summary>
        /// <param name="questId">The quest identifier.</param>
        /// <returns>
        /// The number of tasks that done.
        /// </returns>
        [HttpGet("{questId}/tasks/done")]
        public async Task<JsonResult> GetQuestTasksDone(int questId)
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                QuestToUserDto questToUser = new QuestToUserDto
                {
                    QuestId = questId,
                    UserId = userId
                };

                TaskToUserDto tasks = await _questService.GetQuestTasksDone(questToUser);

                GetQuestTasksDoneResponse response = new GetQuestTasksDoneResponse
                {
                    Count = tasks.Count,
                    Tasks = tasks.Tasks.Select(t => new GetQuestTasksDoneResponse.Task
                    {
                        Id = t.Id,
                        Points = t.Points,
                        Text = t.Text,
                        Answer = t.Answer
                    }).ToArray()
                };

                return this.JsonApi(response);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestException exception)
            {
                return this.JsonApi(exception);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
            catch (QuestToUserException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
