using LabDotNet.Api.Controllers;
using LabDotNet.Common.Tests;
using LabDotNet.Models.Constants;
using LabDotNet.Services.Interfaces;
using Moq;
using Xunit;

namespace LabDotNet.Controllers.Tests
{
    public class ControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly UserController _controller;

        public ControllerTests()
        {
            _userService = new Mock<IUserService>();
            _controller = new UserController(_userService.Object);
        }

        [Fact(DisplayName="RegisterUser [Success]")]
        public void RegisterUser_Success()
        {
            // Arrange
            var register = CommonTestFactory.CreateRegister("sergio@levio.com", "sergio1234", UserTypes.ADMIN, "sergio", "perez");
            var userId = 123L;
            var token = "fdsnfjdsnfldsnflsd";
            var authResponse = CommonTestFactory.CreateAuthenticationResponse(userId, token);
            _userService.Setup(u => u.Register(register)).Returns(authResponse);

            // Act
            var response = _controller.Register(register);
            var userRegistered = response.Value;
            // Assert
            Assert.Equal(userId, userRegistered.UserId);
            Assert.Equal(token, userRegistered.AccessToken);
        }
    }
}