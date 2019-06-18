//-----------------------------------------------------------------------
// <copyright file="IQuestService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using CityQuest.Entities.Models;
using CityQuest.Models.Dtos;

namespace CityQuest.Services
{
    /// <summary>
    /// Quest service interface
    /// </summary>
    public interface IQuestService
    {
        /// <summary>
        /// Gets the topic quests asynchronous.
        /// </summary>
        /// <param name="topicId">The topic identifier.</param>
        /// <returns>
        /// The array of quests.
        /// </returns>
        /// <exception cref="TopicException">There is no topic with such id.</exception>
        Task<Quest[]> GetTopicQuestsAsync(int topicId);

        /// <summary>
        /// Adds the quest asynchronous.
        /// </summary>
        /// <param name="quest">The quest.</param>
        /// <returns>
        /// The identifier of the new quest.
        /// </returns>
        Task<int> AddQuestAsync(QuestDto quest);

        /// <summary>
        /// Gets the quest tasks done.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>
        /// The number of last finished task.
        /// </returns>
        /// <exception cref="QuestException">There is no quest with such id.</exception>
        /// <exception cref="UserException">There is no user with such id.</exception>
        /// <exception cref="QuestToUserException">There is no quest to user with such id.</exception>
        Task<TaskToUserDto> GetQuestTasksDone(QuestToUserDto questToUser);

        /// <summary>
        /// Adds the quest to user asynchronous.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="QuestException">There is no quest with such id.</exception>
        /// <exception cref="UserException">There is no user with such id.</exception>
        /// <exception cref="QuestToUserException">Such entity already created.</exception>
        Task AddQuestToUserAsync(QuestToUserDto questToUser);
        
        /// <summary>
        /// Updates the quest to user asynchronous.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="QuestException">There is no quest with such id.</exception>
        /// <exception cref="UserException">There is no user with such id.</exception>
        /// <exception cref="QuestToUserException">There is no quest to user with such id.</exception>
        Task UpdateQuestToUserAsync(QuestToUserDto questToUser);

        /// <summary>
        /// Gets the user quests asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The array of user's quests.
        /// </returns>
        Task<Quest[]> GetUserQuestsAsync(int userId);

        /// <summary>
        /// Increases the user quests task asynchronous.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>The method is void.</returns>
        Task IncreaseUserQuestsTaskAsync(QuestToUserDto questToUser);

        /// <summary>
        /// Quests the task is last.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>
        /// The indicator if the quest is last.
        /// </returns>
        Task<bool> QuestTaskIsLast(QuestToUserDto questToUser);

        /// <summary>
        /// Gets the last quest asynchronous.
        /// </summary>
        /// <returns>
        /// The last added quest.
        /// </returns>
        Task<Quest> GetLastQuestAsync();

        /// <summary>
        /// Gets the quests asynchronous.
        /// </summary>
        /// <returns>
        /// The array of quests.
        /// </returns>
        Task<Quest[]> GetQuestsAsync();

        /// <summary>
        /// Gets the untouched quests asynchronous.
        /// </summary>
        /// <returns>
        /// The array of untouched quests.
        /// </returns>
        Task<Quest[]> GetUntouchedQuestsAsync();

        /// <summary>
        /// Deletes the quest asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        Task DeleteQuestAsync(int id);
    }
}
