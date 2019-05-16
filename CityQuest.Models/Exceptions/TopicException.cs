//-----------------------------------------------------------------------
// <copyright file="TopicException.cs" company="Dream Team">
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
    public class TopicException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<TopicErrorCode, string> errorCodeToMessage = new Dictionary<TopicErrorCode, string>
        {
            { TopicErrorCode.NoSuchTopic, "Are you sure? I can't find such topic:(" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public TopicException(TopicErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public TopicErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(TopicErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
