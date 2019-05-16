//-----------------------------------------------------------------------
// <copyright file="QuestToUserException.cs" company="Dream Team">
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
    public class QuestToUserException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<QuestToUserErrorCode, string> errorCodeToMessage = new Dictionary<QuestToUserErrorCode, string>
        {
            { QuestToUserErrorCode.AlreadyExists, "You are already in the game!" },
            { QuestToUserErrorCode.NotExist, "Not so fast, first confirm participation:)" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestToUserException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public QuestToUserException(QuestToUserErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public QuestToUserErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(QuestToUserErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
