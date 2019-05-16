//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// User entity class.
    /// </summary>
    /// <seealso cref="CityQuest.Entities.Models.UserBase" />
    public class User : UserBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            QuestToUsers = new HashSet<QuestToUser>();
        }

        /// <summary>
        /// Gets or sets the quest to users.
        /// </summary>
        /// <value>
        /// The quest to users.
        /// </value>
        public ICollection<QuestToUser> QuestToUsers { get; set; }
    }

    /// <summary>
    /// User base entity class.
    /// </summary>
    public class UserBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin; otherwise, <c>false</c>.
        /// </value>
        public bool IsAdmin { get; set; }
    }
}
