//-----------------------------------------------------------------------
// <copyright file="MissionToQuest.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Mission to quest entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.MissionToQuestBase" />
    public class MissionToQuest : MissionToQuestBase
    {
        /// <summary>
        /// Gets or sets the quest.
        /// </summary>
        /// <value>
        /// The quest.
        /// </value>
        public virtual Quest Quest { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual Mission Task { get; set; }
    }

    /// <summary>
    /// Mission to quest base entity class.
    /// </summary>
    public class MissionToQuestBase
    {
        /// <summary>
        /// Gets or sets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestID { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public int TaskID { get; set; }

        /// <summary>
        /// Gets or sets the task number.
        /// </summary>
        /// <value>
        /// The task number.
        /// </value>
        public int? TaskNumber { get; set; }
    }
}
