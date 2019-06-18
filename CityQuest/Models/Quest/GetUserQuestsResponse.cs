//-----------------------------------------------------------------------
// <copyright file="GetUserQuestsResponse.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Quest
{
    /// <summary>
    /// The response model for GetUserQuests method.
    /// </summary>
    public class GetUserQuestsResponse
    {
        /// <summary>
        /// Gets or sets the quests.
        /// </summary>
        /// <value>
        /// The quests.
        /// </value>
        public Quest[] Quests { get; set; }

        /// <summary>
        /// Quest class.
        /// </summary>
        public class Quest
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
}
