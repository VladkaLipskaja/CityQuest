//-----------------------------------------------------------------------
// <copyright file="ITopicService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using CityQuest.Entities.Models;

namespace CityQuest.Services
{
    /// <summary>
    /// Topic service interface
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// Gets the topics asynchronous.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        /// The array of topics.
        /// </returns>
        Task<Topic[]> GetTopicsAsync(string search);
    }
}
