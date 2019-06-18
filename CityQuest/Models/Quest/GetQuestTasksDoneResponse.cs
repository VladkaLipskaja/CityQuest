//-----------------------------------------------------------------------
// <copyright file="GetQuestTasksDoneResponse.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Quest
{
    /// <summary>
    /// The response model for GetQuestTasksDone method.
    /// </summary>
    public class GetQuestTasksDoneResponse
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        public Task[] Tasks { get; set; }

        public class Task
        {
            public int Id { get; set; }

            public int? Points { get; set; }

            public string Text { get; set; }
        }
    }
}
