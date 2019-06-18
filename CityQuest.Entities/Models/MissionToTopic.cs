//-----------------------------------------------------------------------
// <copyright file="MissionToTopic.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Mission to topic entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.MissionToTopicBase" />
    public class MissionToTopic : MissionToTopicBase
    {
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual Mission Task { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>
        /// The topic.
        /// </value>
        public virtual Topic Topic { get; set; }
    }

    /// <summary>
    /// Mission to topic base entity class.
    /// </summary>
    public class MissionToTopicBase
    {
        /// <summary>
        /// Gets or sets the topic identifier.
        /// </summary>
        /// <value>
        /// The topic identifier.
        /// </value>
        public int TopicId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public int TaskId { get; set; }
    }
}
