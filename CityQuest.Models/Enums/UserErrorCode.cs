//-----------------------------------------------------------------------
// <copyright file="UserErrorCode.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Enums
{
    /// <summary>
    /// User errors enum.
    /// </summary>
    public enum UserErrorCode
    {
        /// <summary>
        /// The login is invalid 
        /// </summary>
        InvalidLogin = 1,

        /// <summary>
        /// The password is invalid
        /// </summary>
        InvalidPassword = 2,

        /// <summary>
        /// Such login already exists
        /// </summary>
        ExistingLogin = 3,

        /// <summary>
        /// Such topic wasn't found.
        /// </summary>
        NoSuchUser = 4
    }
}
