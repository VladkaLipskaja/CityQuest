//-----------------------------------------------------------------------
// <copyright file="MissionsController.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Security;
using System.Threading.Tasks;
using CityQuest.Extensions;
using CityQuest.Models.Dtos;
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
        public async Task<JsonResult> AddMission(AddMissionRequest request)
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

                return this.JsonApi(id);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
