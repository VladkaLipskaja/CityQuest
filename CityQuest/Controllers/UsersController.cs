//-----------------------------------------------------------------------
// <copyright file="UsersController.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using CityQuest.Entities.Models;
using CityQuest.Extensions;
using CityQuest.Models.Dtos;
using CityQuest.Models.Exceptions;
using CityQuest.Models.User;
using CityQuest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenSens.Api.Controllers
{
    /// <summary>
    /// The users controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The user service
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// The security service
        /// </summary>
        private ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UsersController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        // POST api/users/authenticate

        /// <summary>
        /// Authenticates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The token.
        /// </returns>
        [HttpPost("authenticate")]
        public async Task<JsonResult> Authenticate([FromBody]AuthenticateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                string token = await _userService.AuthenticateAsync(request.Login, request.Password);

                AuthenticateResponse response = new AuthenticateResponse
                {
                    Token = token
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        // POST api/users/registration

        /// <summary>
        /// Registers the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The success indicator.
        /// </returns>
        [HttpPost("registration")]
        public async Task<JsonResult> Register([FromBody]RegisterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                UserDto user = new UserDto
                {
                    Login = request.Login,
                    Password = request.Password
                };

                await _userService.RegisterAsync(user);

                string token = await _userService.AuthenticateAsync(request.Login, request.Password);

                RegisterResponse response = new RegisterResponse
                {
                    Token = token
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        /// <summary>
        /// Get user data.
        /// </summary>
        /// <returns>
        /// The user data.
        /// </returns>
        [HttpGet]
        public async Task<JsonResult> GetUserData()
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                User user = await _userService.GetUserDataAsync(userId);

                GetUserDataResponse response = new GetUserDataResponse
                {
                    Login = user.Login
                };

                return this.JsonApi(response);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
