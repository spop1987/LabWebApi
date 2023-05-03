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
        public async Task RegisterUser_Success()
        {
            // Arrange
            var register = CommonTestFactory.CreateRegister("sergio@levio.com", "sergio1234", UserTypes.ADMIN, "sergio", "perez");
            var userDto = CommonTestFactory.CreateUserDto("sergio", "perez", "sergio@levio.com");
            var token = "fdsnfjdsnfldsnflsd";
            var authResponse = CommonTestFactory.CreateAuthenticationResponse(userDto, token);
            _userService.Setup(u => u.Register(register)).Returns(authResponse);

            // Act
            var response = _controller.Register(register);
            var userRegistered = response.Value;

            // Assert
            _userService.Verify(u => u.Register(register), Times.Once, "Register should be called once");
             await EntityAsserts.AssertUserDtoAsync(userDto, userRegistered.User);
            Assert.Equal(token, userRegistered.AccessToken);
        }

        [Fact(DisplayName = "LoginUser [Success]")]
        public async Task LoginUser_Success()
        {
            // Arrange
            var login = CommonTestFactory.CreateLogin("sergio@levio.com", "sergio1234");
            var userDto = CommonTestFactory.CreateUserDto("sergio", "perez", "sergio@levio.com");
            var token = "fdsnfjdsnfldsnflsd";
            var loginResponse = CommonTestFactory.CreateAuthenticationResponse(userDto, token);
            _userService.Setup(u => u.Login(login)).Returns(loginResponse);

            // Act
            var response = _controller.Login(login);
            
            // Assert
            _userService.Verify(u => u.Login(login), Times.Once, "Login should be called once");
            await EntityAsserts.AssertUserDtoAsync(userDto, response.Value.User);
        }

    }
}