//-----------------------------------------------------------------------
// <copyright file="ISecurityService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Claims;

namespace CityQuest.Services
{
    /// <summary>
    /// Security service interface
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The token.
        /// </returns>
        string GetToken(int id);

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The hashed value.
        /// </returns>
        string GetHash(string value);

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The user identifier.
        /// </returns>
        int GetUserId(ClaimsPrincipal user);
    }
}
