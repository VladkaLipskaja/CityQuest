//-----------------------------------------------------------------------
// <copyright file="MissionToQuestException.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CityQuest.Models.Enums;

namespace CityQuest.Models.Exceptions
{
    /// <summary>
    /// User exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class MissionToQuestException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<MissionToQuestErrorCode, string> errorCodeToMessage = new Dictionary<MissionToQuestErrorCode, string>
        {
            { MissionToQuestErrorCode.LastMission, "You are my hero! You already have passed all missions in this quest:)" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="MissionToQuestException" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public MissionToQuestException(MissionToQuestErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public MissionToQuestErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(MissionToQuestErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
