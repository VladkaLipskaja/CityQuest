//-----------------------------------------------------------------------
// <copyright file="MissionDto.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Dtos
{
    /// <summary>
    /// Mission data transfer object.
    /// </summary>
    public class MissionDto
    {
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
        /// Gets or sets the coordinate1.
        /// </summary>
        /// <value>
        /// The coordinate1.
        /// </value>
        public string Coordinate1 { get; set; }

        /// <summary>
        /// Gets or sets the coordinate2.
        /// </summary>
        /// <value>
        /// The coordinate2.
        /// </value>
        public string Coordinate2 { get; set; }

        /// <summary>
        /// Gets or sets the coordinate3.
        /// </summary>
        /// <value>
        /// The coordinate3.
        /// </value>
        public string Coordinate3 { get; set; }

        /// <summary>
        /// Gets or sets the coordinate4.
        /// </summary>
        /// <value>
        /// The coordinate4.
        /// </value>
        public string Coordinate4 { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets the task number.
        /// </summary>
        /// <value>
        /// The task number.
        /// </value>
        public int TaskNumber { get; set; }

        /// <summary>
        /// Gets or sets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestId { get; set; }
    }
}
