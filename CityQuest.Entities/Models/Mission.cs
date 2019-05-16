//-----------------------------------------------------------------------
// <copyright file="Mission.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Mission entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.MissionBase" />
    public class Mission : MissionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mission"/> class.
        /// </summary>
        public Mission()
        {
            TaskToQuests = new HashSet<MissionToQuest>();
            TaskToTopics = new HashSet<MissionToTopic>();
        }

        /// <summary>
        /// Gets or sets the task to quests.
        /// </summary>
        /// <value>
        /// The task to quests.
        /// </value>
        public virtual ICollection<MissionToQuest> TaskToQuests { get; set; }

        /// <summary>
        /// Gets or sets the task to topics.
        /// </summary>
        /// <value>
        /// The task to topics.
        /// </value>
        public virtual ICollection<MissionToTopic> TaskToTopics { get; set; }
    }

    /// <summary>
    /// Mission entity base class.
    /// </summary>
    public class MissionBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

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
        public int? Points { get; set; }
    }
}
