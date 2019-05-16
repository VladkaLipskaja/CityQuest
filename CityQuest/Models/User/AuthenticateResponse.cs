//-----------------------------------------------------------------------
// <copyright file="AuthenticateResponse.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CityQuest.Models.User
{
    /// <summary>
    /// The response model for Authenticate method.
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
