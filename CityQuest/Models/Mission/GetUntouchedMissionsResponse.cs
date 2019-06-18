namespace CityQuest.Models.Mission
{
    public class GetUntouchedMissionsResponse
    {
        public Mission[] Missions { get; set; }

        public class Mission
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
}
