using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityQuest.Models.Quest
{
    public class GetUserQuestsResponse
    {
        public Quest[] Quests { get; set; }

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
