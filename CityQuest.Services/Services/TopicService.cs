//-----------------------------------------------------------------------
// <copyright file="TopicService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityQuest.Entities;
using CityQuest.Entities.Models;

namespace CityQuest.Services
{
    /// <summary>
    /// Topic service
    /// </summary>
    /// <seealso cref="CityQuest.Services.ITopicService" />
    public class TopicService : ITopicService
    {
        /// <summary>
        /// The topic repository
        /// </summary>
        private readonly IRepository<Topic> _topicRepository;

        // private readonly IAppLogger<BasketService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicService"/> class.
        /// </summary>
        /// <param name="topicRepository">The topic repository.</param>
        public TopicService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }

        /// <summary>
        /// Gets the topics asynchronous.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        /// The array of topics.
        /// </returns>
        public async Task<Topic[]> GetTopicsAsync(string search)
        {
            IReadOnlyList<Topic> topics;

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                topics = await _topicRepository.GetAsync(p => p.Name != null && p.Name.ToLower().Contains(search));
            }
            else
            {
                topics = await _topicRepository.ListAllAsync();
            }

            return topics.ToArray();
        }
    }
}
