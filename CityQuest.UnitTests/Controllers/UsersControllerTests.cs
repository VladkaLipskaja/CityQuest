using CityQuest.Entities.Models;
using CityQuest.Models;
using CityQuest.Models.Dtos;
using CityQuest.Models.Enums;
using CityQuest.Models.Exceptions;
using CityQuest.Models.User;
using CityQuest.Services;
using GreenSens.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace GreenSens.UnitTests.Controllers
{
    public class UsersControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private Mock<ISecurityService> _mockSecurityService;

        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockSecurityService = new Mock<ISecurityService>();
        }

        /// <summary>
        /// Adds the data pass test.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AuthenticatePassTest()
        {
            // Arrange            
            _mockUserService.Setup(service => service.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.Authenticate(new AuthenticateRequest());
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.True(value.Result);
        }

        [Fact]
        public async Task AuthenticateNullFailTest()
        {
            // Arrange
            _mockUserService.Setup(service => service.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            Task testCode() => controller.Authenticate(null);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }

        [Fact]
        public async Task AuthenticateUserFailTest()
        {
            // Arrange
            UserException exception = new UserException(UserErrorCode.ExistingLogin);

            _mockUserService.Setup(service => service.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                                                     .Throws(exception);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.Authenticate(new AuthenticateRequest());
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.False(value.Result);
            Assert.Single(value.Errors);
            Assert.Equal(exception.Message, value.Errors[0]);
        }

        [Fact]
        public async Task RegisterPassTest()
        {
            // Arrange            
            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserDto>()))
                                                     .Returns(Task.CompletedTask);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.Register(new RegisterRequest());
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.True(value.Result);
        }

        [Fact]
        public async Task RegisterNullFailTest()
        {
            // Arrange
            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserDto>()))
                                                     .Returns(Task.CompletedTask);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            Task testCode() => controller.Register(null);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }

        [Fact]
        public async Task RegisterUserFailTest()
        {
            // Arrange
            UserException exception = new UserException(UserErrorCode.ExistingLogin);

            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserDto>()))
                                                     .Throws(exception);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.Register(new RegisterRequest());
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.False(value.Result);
            Assert.Single(value.Errors);
            Assert.Equal(exception.Message, value.Errors[0]);
        }

        [Fact]
        public async Task GetUserDataPassTest()
        {
            // Arrange
            User user = new User
            {
                Login = "test"
            };

            _mockSecurityService.Setup(service => service.GetUserId(It.IsAny<ClaimsPrincipal>()))
                                .Returns(It.IsAny<int>());
            _mockUserService.Setup(service => service.GetUserDataAsync(It.IsAny<int>()))
                           .ReturnsAsync(user);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.GetUserData();
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.True(value.Result);
        }

        [Fact]
        public async Task GetUserDataSecurityFailTest()
        {
            // Arrange
            SecurityException exception = new SecurityException(SecurityErrorCode.UnrecognizedUser);

            _mockSecurityService.Setup(service => service.GetUserId(It.IsAny<ClaimsPrincipal>()))
                                .Returns(It.IsAny<int>());
            _mockUserService.Setup(service => service.GetUserDataAsync(It.IsAny<int>()))
                           .Throws(exception);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.GetUserData();
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.False(value.Result);
            Assert.Single(value.Errors);
            Assert.Equal(exception.Message, value.Errors[0]);
        }

        [Fact]
        public async Task GetUserDataUserFailTest()
        {
            // Arrange
            UserException exception = new UserException(UserErrorCode.NoSuchUser);

            _mockSecurityService.Setup(service => service.GetUserId(It.IsAny<ClaimsPrincipal>()))
                                .Returns(It.IsAny<int>());
            _mockUserService.Setup(service => service.GetUserDataAsync(It.IsAny<int>()))
                           .Throws(exception);

            UsersController controller = new UsersController(_mockUserService.Object, _mockSecurityService.Object);

            // Act
            JsonResult result = await controller.GetUserData();
            ApiResponse value = (ApiResponse)result.Value;

            // Assert
            Assert.False(value.Result);
            Assert.Single(value.Errors);
            Assert.Equal(exception.Message, value.Errors[0]);
        }
    }
}
