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

        /// <summary>
        /// The mission repository
        /// </summary>
        private readonly IRepository<Mission> _missionRepository;

        /// <summary>
        /// The mission to quest repository
        /// </summary>
        private readonly IRepository<MissionToQuest> _missionToQuestRepository;

        // private readonly IAppLogger<BasketService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestService" /> class.
        /// </summary>
        /// <param name="questRepository">The quest repository.</param>
        /// <param name="questToUserRepository">The quest to user repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="topicRepository">The topic repository.</param>
        /// <param name="missionToQuestRepository">The mission to quest repository.</param>
        /// <param name="missionRepository">The mission repository.</param>
        public QuestService(IRepository<Quest> questRepository, IRepository<QuestToUser> questToUserRepository, IRepository<User> userRepository, IRepository<Topic> topicRepository, IRepository<MissionToQuest> missionToQuestRepository, IRepository<Mission> missionRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questToUserRepository = questToUserRepository;
            _topicRepository = topicRepository;
            _missionToQuestRepository = missionToQuestRepository;
            _missionRepository = missionRepository;
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
        /// Gets the quests asynchronous.
        /// </summary>
        /// <returns>
        /// The array of quests.
        /// </returns>
        public async Task<Quest[]> GetQuestsAsync()
        {
            Quest[] quests = (await _questRepository.ListAllAsync()).ToArray();

            return quests;
        }

        /// <summary>
        /// Gets the untouched quests asynchronous.
        /// </summary>
        /// <returns>
        /// The array of untouched quests.
        /// </returns>
        public async Task<Quest[]> GetUntouchedQuestsAsync()
        {
            int[] touchedQuestIds = (await _questToUserRepository.ListAllAsync()).Select(q => q.QuestID).ToArray();

            Quest[] quests = (await _questRepository.GetAsync(q => !touchedQuestIds.Contains(q.ID))).ToArray();

            return quests;
        }

        /// <summary>
        /// Gets the last quest asynchronous.
        /// </summary>
        /// <returns>
        /// The last quest.
        /// </returns>
        /// <exception cref="QuestException">Invalid questId.</exception>
        public async Task<Quest> GetLastQuestAsync()
        {
            Quest quest = (await _questRepository.ListAllAsync()).OrderByDescending(q => q.ID).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            return quest;
        }

        /// <summary>
        /// Gets the user quests asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The array of user's quests.
        /// </returns>
        /// <exception cref="UserException">Invalid userId.</exception>
        public async Task<Quest[]> GetUserQuestsAsync(int userId)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == userId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            int[] questIds = (await _questToUserRepository.GetAsync(qu => qu.UserID == userId)).Select(qu => qu.QuestID).ToArray();

            Quest[] quests = (await _questRepository.GetAsync(q => questIds.Contains(q.ID))).ToArray();

            return quests;
        }

        /// <summary>
        /// Increases the user quests task asynchronous.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>The method is void.</returns>
        /// <exception cref="UserException">Invalid userId.</exception>
        /// <exception cref="QuestToUserException">Invalid questId or userId.</exception>
        /// <exception cref="MissionToQuestException">Invalid missionId or questId.</exception>
        public async Task IncreaseUserQuestsTaskAsync(QuestToUserDto questToUser)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            QuestToUser existedQuestToUser = (await _questToUserRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId && qu.UserID == questToUser.UserId)).FirstOrDefault();

            if (existedQuestToUser == null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.NotExist);
            }

            MissionToQuest missionToQuest = (await _missionToQuestRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId)).OrderByDescending(qu => qu.TaskNumber).FirstOrDefault();

            if (missionToQuest == null || missionToQuest.TaskNumber <= existedQuestToUser.FinishedTask)
            {
                throw new MissionToQuestException(MissionToQuestErrorCode.LastMission);
            }

            existedQuestToUser.FinishedTask++;

            await _questToUserRepository.UpdateAsync(existedQuestToUser);
        }

        /// <summary>
        /// Quests the task is last.
        /// </summary>
        /// <param name="questToUser">The quest to user.</param>
        /// <returns>
        /// The indicator if the quest is last.
        /// </returns>
        /// <exception cref="UserException">Invalid userId.</exception>
        /// <exception cref="QuestToUserException">Invalid questId or userId.</exception>
        /// <exception cref="MissionToQuestException">Invalid missionId or questId.</exception>
        public async Task<bool> QuestTaskIsLast(QuestToUserDto questToUser)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            QuestToUser existedQuestToUser = (await _questToUserRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId && qu.UserID == questToUser.UserId)).FirstOrDefault();

            if (existedQuestToUser == null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.NotExist);
            }

            MissionToQuest missionToQuest = (await _missionToQuestRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId)).OrderByDescending(qu => qu.TaskNumber).FirstOrDefault();

            if (missionToQuest == null)
            {
                throw new MissionToQuestException(MissionToQuestErrorCode.LastMission);
            }

            return missionToQuest.TaskNumber == existedQuestToUser.FinishedTask;
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
        public async Task<TaskToUserDto> GetQuestTasksDone(QuestToUserDto questToUser)
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
                throw new QuestToUserException(QuestToUserErrorCode.NotExist);
            }

            int[] taskIds = (await _missionToQuestRepository.GetAsync(mq => mq.QuestID == questToUser.QuestId && mq.TaskNumber <= existingQuestToUser.FinishedTask)).Select(mq => mq.TaskID).ToArray();

            TaskToUserDto.Task[] tasks = (await _missionRepository.GetAsync(m => taskIds.Contains(m.ID))).Select(m => new TaskToUserDto.Task
            {
                Id = m.ID,
                Points = m.Points,
                Text = m.Text,
                Answer = m.Answer
            }).ToArray();

            TaskToUserDto userTasks = new TaskToUserDto
            {
                Count = questToUser.FinishedTasks,
                Tasks = tasks
            };

            return userTasks;
        }

        /// <summary>
        /// Deletes the quest asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="QuestException">Invalid questId.</exception>
        public async Task DeleteQuestAsync(int id)
        {
            var d = (await _questRepository.ListAllAsync()).ToArray();

            Quest quest = await _questRepository.GetByIdAsync(id);

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            QuestToUser[] questsToUsers = (await _questToUserRepository.GetAsync(q => q.QuestID == id)).ToArray();

            if (questsToUsers != null && questsToUsers.Length > 0)
            {
                await _questToUserRepository.DeleteAsync(questsToUsers);
            }

            MissionToQuest[] missionsToQuests = (await _missionToQuestRepository.GetAsync(m => m.QuestID == id)).ToArray();

            if (missionsToQuests != null && missionsToQuests.Length > 0)
            {
                await _missionToQuestRepository.DeleteAsync(missionsToQuests);
            }

            await _questRepository.DeleteAsync(quest);
        }
    }
}
