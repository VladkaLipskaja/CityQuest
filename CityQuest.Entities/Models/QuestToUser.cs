//-----------------------------------------------------------------------
// <copyright file="QuestToUser.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Quest to user entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.QuestToUserBase" />
    public class QuestToUser : QuestToUserBase
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the quest.
        /// </summary>
        /// <value>
        /// The quest.
        /// </value>
        public virtual Quest Quest { get; set; }
    }

    /// <summary>
    /// Quest to user base entity class.
    /// </summary>
    public class QuestToUserBase
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is finished; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Gets or sets the finished task.
        /// </summary>
        /// <value>
        /// The finished task.
        /// </value>
        public int FinishedTask { get; set; }
    }
}
