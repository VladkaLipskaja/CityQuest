//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CityQuest.Entities;
using CityQuest.Entities.Models;
using CityQuest.Models.Dtos;
using CityQuest.Models.Enums;
using CityQuest.Models.Exceptions;

namespace CityQuest.Services
{
    /// <summary>
    /// User service
    /// </summary>
    /// <seealso cref="GreenSens.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// The hashing service
        /// </summary>
        private readonly ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="hashingService">The hashing service.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserService(ISecurityService hashingService, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _securityService = hashingService;
        }

        /// <summary>
        /// Authenticates asynchronously.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The token.
        /// </returns>
        public async Task<string> AuthenticateAsync(string username, string password)
        {
            User user = (await _userRepository.GetAsync(u => u.Login == username)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.InvalidLogin);
            }

            string hashedPassword = _securityService.GetHash(password);

            if (user.Password != hashedPassword)
            {
                throw new UserException(UserErrorCode.InvalidPassword);
            }

            string token = _securityService.GetToken(user.ID);

            return token;
        }

        /// <summary>
        /// Registers asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        public async Task RegisterAsync(UserDto user)
        {
            var existingUser = (await _userRepository.GetAsync(u => u.Login == user.Login)).FirstOrDefault();

            if (existingUser != null)
            {
                throw new UserException(UserErrorCode.ExistingLogin);
            }

            string hashedPassword = _securityService.GetHash(user.Password);

            User newUser = new User
            {
                Login = user.Login,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(newUser);
        }

        /// <summary>
        /// Get users data asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="UserException">
        /// There is no user with such id. 
        /// </exception>
        public async Task<User> GetUserDataAsync(int id)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == id)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            return user;
        }
    }
}
