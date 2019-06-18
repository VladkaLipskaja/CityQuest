//-----------------------------------------------------------------------
// <copyright file="QuestTaskIsLastResponse.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Quest
{
    /// <summary>
    /// The response model for QuestTaskIsLast method.
    /// </summary>
    public class QuestTaskIsLastResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is last.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is last; otherwise, <c>false</c>.
        /// </value>
        public bool IsLast { get; set; }
    }
}
