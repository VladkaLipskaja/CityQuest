//-----------------------------------------------------------------------
// <copyright file="TaskToUserDto.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Dtos
{
    /// <summary>
    /// TaskToUser data transfer object.
    /// </summary>
    public class TaskToUserDto
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public Task[] Tasks { get; set; }

        /// <summary>
        /// Task class.
        /// </summary>
        public class Task
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value>
            /// The text.
            /// </value>
            public string Text { get; set; }

            /// <summary>
            /// Gets or sets the answer.
            /// </summary>
            /// <value>
            /// The answer.
            /// </value>
            public string Answer { get; set; }

            /// <summary>
            /// Gets or sets the points.
            /// </summary>
            /// <value>
            /// The points.
            /// </value>
            public int? Points { get; set; }
        }
    }
}
