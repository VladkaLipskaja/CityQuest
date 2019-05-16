//-----------------------------------------------------------------------
// <copyright file="IMissionService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using CityQuest.Entities.Models;
using CityQuest.Models.Dtos;

namespace CityQuest.Services
{
    /// <summary>
    /// Mission service interface
    /// </summary>
    public interface IMissionService
    {
        /// <summary>
        /// Gets the quest missions asynchronous.
        /// </summary>
        /// <param name="questId">The quest identifier.</param>
        /// <returns>
        /// The array of missions.
        /// </returns>
        /// <exception cref="QuestException">
        /// There is no quest with such id.
        /// </exception>
        Task<MissionToQuest[]> GetQuestMissionsAsync(int questId);

        /// <summary>
        /// Adds the mission asynchronous.
        /// </summary>
        /// <param name="mission">The mission.</param>
        /// <returns>
        /// The identifier of the new mission.
        /// </returns>
        Task<int> AddMissionAsync(MissionDto mission);
    }
}
