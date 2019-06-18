//-----------------------------------------------------------------------
// <copyright file="MissionService.cs" company="Dream Team">
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
    /// Mission Service
    /// </summary>
    /// <seealso cref="CityQuest.Services.IMissionService" />
    public class MissionService : IMissionService
    {
        /// <summary>
        /// The mission to quest repository
        /// </summary>
        private readonly IRepository<MissionToQuest> _missionToQuestRepository;

        /// <summary>
        /// The quest repository
        /// </summary>
        private readonly IRepository<Quest> _questRepository;

        private readonly IRepository<QuestToUser> _questToUserRepository;

        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// The mission repository
        /// </summary>
        private readonly IRepository<Mission> _missionRepository;

        // private readonly IAppLogger<BasketService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MissionService"/> class.
        /// </summary>
        /// <param name="missionToQuestRepository">The mission to quest repository.</param>
        /// <param name="missionRepository">The mission repository.</param>
        /// <param name="questRepository">The quest repository.</param>
        public MissionService(IRepository<MissionToQuest> missionToQuestRepository, IRepository<Mission> missionRepository, IRepository<Quest> questRepository, IRepository<User> userRepository, IRepository<QuestToUser> questToUserRepository)
        {
            _questRepository = questRepository;
            _missionToQuestRepository = missionToQuestRepository;
            _missionRepository = missionRepository;
            _userRepository = userRepository;
            _questToUserRepository = questToUserRepository;
        }

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
        public async Task<MissionToQuest[]> GetQuestMissionsAsync(int questId)
        {
            Quest quest = (await _questRepository.GetAsync(q => q.ID == questId)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            MissionToQuest[] missions = (await _missionToQuestRepository.GetAsync(q => q.QuestID == questId, q => q.Task)).ToArray();

            return missions;
        }

        public async Task<Mission[]> GetLastDoneMissions(QuestToUserDto questToUser)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == questToUser.UserId)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            Quest quest = (await _questRepository.GetAsync(u => u.ID == questToUser.QuestId)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            QuestToUser existedQuestToUser = (await _questToUserRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId && qu.UserID == questToUser.UserId)).FirstOrDefault();

            if (existedQuestToUser == null)
            {
                throw new QuestToUserException(QuestToUserErrorCode.NotExist);
            }

            int[] missionIds = (await _missionToQuestRepository.GetAsync(qu => qu.QuestID == questToUser.QuestId && qu.TaskNumber <= questToUser.FinishedTasks + 1)).Select(m => m.TaskID).ToArray();

            Mission[] missions = (await _missionRepository.GetAsync(m => missionIds.Contains(m.ID))).ToArray();

            return missions;
        }

        public async Task<Mission[]> GetMissions()
        {
            Mission[] missions = (await _missionRepository.ListAllAsync()).ToArray();

            return missions;
        }

        public async Task<Mission[]> GetUntouchedMissions()
        {
            int[] touchedMissionIds = (await _missionToQuestRepository.ListAllAsync()).Select(m => m.TaskID).ToArray();

            Mission[] missions = (await _missionRepository.GetAsync(m => !touchedMissionIds.Contains(m.ID))).ToArray();

            return missions;
        }

        public async Task AddMissionToQuestAsync(MissionToQuestDto mission)
        {
            Mission existingMission = (await _missionRepository.GetAsync(m => m.ID == mission.TaskID)).FirstOrDefault();

            if (existingMission == null)
            {
                throw new MissionException(MissionErrorCode.NoSuchMission);
            }

            Quest quest = (await _questRepository.GetAsync(u => u.ID == mission.QuestID)).FirstOrDefault();

            if (quest == null)
            {
                throw new QuestException(QuestErrorCode.NoSuchQuest);
            }

            MissionToQuest missionToQuest = new MissionToQuest
            {
                TaskNumber = mission.TaskNumber,
                QuestID = mission.QuestID,
                TaskID = mission.TaskID
            };

            await _missionToQuestRepository.AddAsync(missionToQuest);
        }

        /// <summary>
        /// Adds the mission asynchronous.
        /// </summary>
        /// <param name="mission">The mission.</param>
        /// <returns>
        /// The identifier of the new mission.
        /// </returns>
        public async Task<int> AddMissionAsync(MissionDto mission)
        {
            Mission newMission = new Mission
            {
                Answer = mission.Answer,
                Coordinate1 = mission.Coordinate1,
                Coordinate2 = mission.Coordinate2,
                Coordinate3 = mission.Coordinate3,
                Coordinate4 = mission.Coordinate4,
                Points = mission.Points,
                Text = mission.Text
            };

            await _missionRepository.AddAsync(newMission);

            if (mission.QuestId.HasValue)
            {
                Quest quest = (await _questRepository.GetAsync(u => u.ID == mission.QuestId)).FirstOrDefault();

                if (quest == null)
                {
                    throw new QuestException(QuestErrorCode.NoSuchQuest);
                }

                MissionToQuest missionToQuest = new MissionToQuest
                {
                    TaskNumber = mission.TaskNumber,
                    QuestID = mission.QuestId.Value,
                    TaskID = newMission.ID
                };

                await _missionToQuestRepository.AddAsync(missionToQuest);
            }

            return newMission.ID;
        }
    }
}
