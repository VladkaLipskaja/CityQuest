//-----------------------------------------------------------------------
// <copyright file="GetTopicsResponse.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Topic
{
    /// <summary>
    /// The response model for GetTopics method.
    /// </summary>
    public class GetTopicsResponse
    {
        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        public Topic[] Topics { get; set; }

        /// <summary>
        /// The model for topics.
        /// </summary>
        public class Topic
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
}
