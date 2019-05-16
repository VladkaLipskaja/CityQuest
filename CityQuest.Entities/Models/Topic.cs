//-----------------------------------------------------------------------
// <copyright file="Topic.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Topic entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.TopicBase" />
    public class Topic : TopicBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Topic"/> class.
        /// </summary>
        public Topic()
        {
            TaskToTopics = new HashSet<MissionToTopic>();
        }

        /// <summary>
        /// Gets or sets the task to topics.
        /// </summary>
        /// <value>
        /// The task to topics.
        /// </value>
        public virtual ICollection<MissionToTopic> TaskToTopics { get; set; }
    }

    /// <summary>
    /// Topic base entity class.
    /// </summary>
    public class TopicBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
