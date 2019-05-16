//-----------------------------------------------------------------------
// <copyright file="QuestException.cs" company="Dream Team">
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
    public class QuestException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<QuestErrorCode, string> errorCodeToMessage = new Dictionary<QuestErrorCode, string>
        {
            { QuestErrorCode.NoSuchQuest, "Are you sure? I can't find such quest:(" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public QuestException(QuestErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public QuestErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(QuestErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
