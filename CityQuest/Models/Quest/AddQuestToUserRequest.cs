//-----------------------------------------------------------------------
// <copyright file="AddQuestToUserRequest.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Quest
{
    /// <summary>
    /// The model for AddQuestToUser method.
    /// </summary>
    public class AddQuestToUserRequest
    {
        /// <summary>
        /// Gets or sets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is finished; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Gets or sets the finished tasks.
        /// </summary>
        /// <value>
        /// The finished tasks.
        /// </value>
        public int FinishedTasks { get; set; }
    }
}
