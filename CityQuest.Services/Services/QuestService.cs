//-----------------------------------------------------------------------
// <copyright file="QuestService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CityQuest.Entities;
using CityQuest.Entities.Models;
using CityQuest.Models.Dtos;
using CityQuest.Models.Enums;
using CityQuest.Models.Exceptions;

namespace CityQuest.Services
{
    /// <summary>
    /// Quest service
    /// </summary>
    /// <seealso cref="CityQuest.Services.IQuestService" />
    public class QuestService : IQuestService
    {
        /// <summary>
        /// The quest repository
        /// </summary>
        private readonly IRepository<Quest> _questRepository;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// The quest to user repository
        /// </summary>
        private readonly IRepository<QuestToUser> _questToUserRepository;

        /// <summary>
        /// The topic repository
        /// </summary>
        private readonly IRepository<Topic> _topicRepository;

        // private readonly IAppLogger<BasketService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestService" /> class.
        /// </summary>
        /// <param name="questRepository">The quest repository.</param>
        /// <param name="questToUserRepository">The quest to user repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="topicRepository">The topic repository.</param>
        public QuestService(IRepository<Quest> questRepository, IRepository<QuestToUser> questToUserRepository, IRepository<User> userRepository, IRepository<Topic> topicRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questToUserRepository = questToUserRepository;
            _topicRepository = topicRepository;
        }

        /// <summary>
        /// Gets the topic quests asynchronous.
        /// </summary>
        /// <param name="topicId">The topic identifier.</param>
        /// <returns>
        /// The array of quests.
        /// </returns>
        /// <exception cref="TopicException">There is no topic with such id.</exception>
        public async Task<Quest[]> GetTopicQuestsAsync(int topicId)
        {
            Topic topic = (await _topicRepository.GetAsync(t => t.ID == topicId)).FirstOrDefault();

            if (topic == null)
            {
                throw new TopicException(TopicErrorCode.NoSuchTopic);
            }

            Quest[] quests = (await _questRepository.GetAsync(q => q.TopicID == topicId)).ToArray();

            return quests;
        }

        /// <summary>
        /// Adds the quest asynchronous.
        /// </summary>
        /// <param name="quest">The quest.</param>
        /// <returns>
        /// The identifier of the new quest.
        /// </returns>
        public async Task<int> AddQuestAsync(QuestDto quest)
        {
            Quest newQuest = new Quest
            {
                Name = quest.Name,
                AuthorID = quest.AuthorID,
                Points = quest.Points,
                Price = quest.Price,
                TopicID = quest.TopicID
            };

            await _questRepository.AddAsync(newQuest);

            return newQuest.ID;
        }

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
        public async Task AddQuestToUserAsync(QuestToUserDto questToUser)
        {
            Quest quest = (await _questRepository.GetAsync(q => q.ID == questToUser.QuestId)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }
                       
            QuestToUser existingQuestToUser = (await _questToUserRepository.GetAsync(q => q.UserID == questToUser.UserId && q.QuestID == questToUser.QuestId)).FirstOrDefault();

            if (existingQuestToUser != null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.AlreadyExists);
            }

            QuestToUser newQuestToUser = new QuestToUser
            {
                QuestID = questToUser.QuestId,
                UserID = questToUser.UserId,
                FinishedTask = questToUser.FinishedTasks,
                IsFinished = questToUser.IsFinished
            };

            await _questToUserRepository.AddAsync(newQuestToUser);
        }

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
        public async Task UpdateQuestToUserAsync(QuestToUserDto questToUser)
        {
            Quest quest = (await _questRepository.GetAsync(q => q.ID == questToUser.QuestId)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            QuestToUser questToUserToUpdate = (await _questToUserRepository.GetAsync(q => q.QuestID == questToUser.QuestId && q.UserID == questToUser.UserId)).FirstOrDefault();

            if (questToUserToUpdate != null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.NotExist);
            }

            questToUserToUpdate.FinishedTask = questToUser.FinishedTasks;
            questToUserToUpdate.IsFinished = questToUser.IsFinished;

            await _questToUserRepository.UpdateAsync(questToUserToUpdate);
        }

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
        public async Task<int> GetQuestTasksDone(QuestToUserDto questToUser)
        {
            Quest quest = (await _questRepository.GetAsync(q => q.ID == questToUser.QuestId)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }            

            QuestToUser existingQuestToUser = (await _questToUserRepository.GetAsync(q => q.QuestID == questToUser.QuestId && q.UserID == questToUser.UserId)).FirstOrDefault();
            
            if (existingQuestToUser == null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.AlreadyExists);
            }

            return existingQuestToUser.FinishedTask;
        }
    }
}
