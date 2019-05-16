//-----------------------------------------------------------------------
// <copyright file="Quest.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Quest entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.QuestBase" />
    public class Quest : QuestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quest"/> class.
        /// </summary>
        public Quest()
        {
            TaskToQuests = new HashSet<MissionToQuest>();
            TaskToTopics = new HashSet<MissionToTopic>();
            QuestToUsers = new HashSet<QuestToUser>();
        }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public virtual User Author { get; set; }

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

        /// <summary>
        /// Gets or sets the quest to users.
        /// </summary>
        /// <value>
        /// The quest to users.
        /// </value>
        public virtual ICollection<QuestToUser> QuestToUsers { get; set; }
    }

    /// <summary>
    /// Quest base entity class.
    /// </summary>
    public class QuestBase
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

        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        public int AuthorID { get; set; }

        /// <summary>
        /// Gets or sets the topic identifier.
        /// </summary>
        /// <value>
        /// The topic identifier.
        /// </value>
        public int TopicID { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public int? Price { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public int? Points { get; set; }
    }
}
