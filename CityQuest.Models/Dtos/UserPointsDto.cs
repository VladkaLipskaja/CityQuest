//-----------------------------------------------------------------------
// <copyright file="UserPointsDto.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Dtos
{
    /// <summary>
    /// User Points data transfer object.
    /// </summary>
    public class UserPointsDto
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public int Points { get; set; }
    }
}
