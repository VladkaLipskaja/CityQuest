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
        public MissionService(IRepository<MissionToQuest> missionToQuestRepository, IRepository<Mission> missionRepository, IRepository<Quest> questRepository)
        {
            _questRepository = questRepository;
            _missionToQuestRepository = missionToQuestRepository;
            _missionRepository = missionRepository;
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

            MissionToQuest missionToQuest = new MissionToQuest
            {
                TaskNumber = mission.TaskNumber,
                QuestID = mission.QuestId,
                TaskID = newMission.ID
            };

            await _missionToQuestRepository.AddAsync(missionToQuest);

            return newMission.ID;
        }
    }
}
