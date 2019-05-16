//-----------------------------------------------------------------------
// <copyright file="QuestToUserErrorCode.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.Enums
{
    /// <summary>
    /// User errors enum.
    /// </summary>
    public enum QuestToUserErrorCode
    {
        /// <summary>
        /// Such quest to user already exists.
        /// </summary>
        AlreadyExists = 1,

        /// <summary>
        /// Such quest to user wasn't found.
        /// </summary>
        NotExist = 2
    }
}
