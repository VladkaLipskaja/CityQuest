//-----------------------------------------------------------------------
// <copyright file="TopicsController.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CityQuest.Entities.Models;
using CityQuest.Extensions;
using CityQuest.Models.Exceptions;
using CityQuest.Models.Topic;
using CityQuest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityQuest.Controllers
{
    /// <summary>
    /// The topics controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        /// <summary>
        /// The topic service
        /// </summary>
        private ITopicService _topicService;

        /// <summary>
        /// The quest service
        /// </summary>
        private IQuestService _questService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicsController" /> class.
        /// </summary>
        /// <param name="topicService">The topic service.</param>
        /// <param name="questService">The quest service.</param>
        public TopicsController(ITopicService topicService, IQuestService questService)
        {
            _topicService = topicService;
            _questService = questService;
        }

        /// <summary>
        /// Gets the topics.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        /// The array of topics.
        /// </returns>
        [HttpGet("{search}")]
        public async Task<JsonResult> GetTopics(string search)
        {
            Topic[] topics = await _topicService.GetTopicsAsync(search);

            GetTopicsResponse response = new GetTopicsResponse
            {
                Topics = topics?.Select(t => new GetTopicsResponse.Topic
                {
                    ID = t.ID,
                    Name = t.Name
                }).ToArray()
            };

            return this.JsonApi(response);
        }

        /// <summary>
        /// Gets the topic quests.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The array of quests.
        /// </returns>
        [HttpGet("{id}/quests")]
        public async Task<JsonResult> GetTopicQuests(int id)
        {
            try
            {
                Quest[] quests = await _questService.GetTopicQuestsAsync(id);

                GetTopicQuestsResponse response = new GetTopicQuestsResponse
                {
                    Quests = quests?.Select(q => new GetTopicQuestsResponse.Quest
                    {
                        ID = q.ID,
                        Name = q.Name,
                        Points = q.Points,
                        Price = q.Price
                    }).ToArray()
                };

                return this.JsonApi(response);
            }
            catch (TopicException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
