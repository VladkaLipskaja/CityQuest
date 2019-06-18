//-----------------------------------------------------------------------
// <copyright file="MissionToQuestDto.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Dtos
{
    /// <summary>
    /// MissionToQuest data transfer object.
    /// </summary>
    public class MissionToQuestDto
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
