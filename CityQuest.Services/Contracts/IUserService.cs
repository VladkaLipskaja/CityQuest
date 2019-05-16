//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using CityQuest.Models.Dtos;

namespace CityQuest.Services
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates asynchronously.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The token.
        /// </returns>
        Task<string> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Registers asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        Task RegisterAsync(UserDto user);
    }
}
