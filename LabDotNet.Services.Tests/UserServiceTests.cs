using System.ComponentModel.DataAnnotations;
using LabDotNet.Common.Tests;
using LabDotNet.DataBase.DataAccess.Interfaces;
using LabDotNet.Models.Constants;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Translators.Interfaces;
using LabDotNet.Services.Interfaces;
using LabDotNet.Services.Services;
using Moq;
using Xunit;

namespace LabDotNet.Services.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<ISecurityService> _securityService;
        private readonly Mock<IQueries> _queries;
        private readonly Mock<ICommands> _commands;
        private readonly Mock<IToEntityTranslator> _toEntityTranslator;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _securityService = new Mock<ISecurityService>();
            _queries = new Mock<IQueries>();
            _commands = new Mock<ICommands>();
            _toEntityTranslator = new Mock<IToEntityTranslator>();
            _userService = new UserService(_securityService.Object, _queries.Object, _commands.Object, _toEntityTranslator.Object);
        }

        [Fact(DisplayName="Register new User [Success]")]
        public async Task RegisterNewUser_Success()
        {
            // Arrange
            var register = CommonTestFactory.CreateRegister("sergio@levio.com", "sergio1234", UserTypes.ADMIN, "sergio", "perez");
            var hashPassword = CommonTestFactory.CreateHash(10);
            var user = CommonTestFactory.CreateUser(10, hashPassword);
            user.UserId = 1203L;
            
            _queries.Setup(q => q.FindUserByEmail(register.Email)).Returns(null as User);
            _securityService.Setup(s => s.Hash(register.Password)).Returns(hashPassword);
            _securityService.Setup(s => s.GenerateJwtToken(user.UserId, user.Email)).Returns(It.IsAny<string>());
            _toEntityTranslator.Setup(t => t.ToUser(register, hashPassword)).Returns(user);
            _commands.Setup(c => c.AddUser(user)).Returns(user.UserId);
            // Act
            var authResponse = _userService.Register(register);

            // Assert
            _queries.Verify(q => q.FindUserByEmail(register.Email), Times.Once, "FindUserByEmail should be called once");
            _securityService.Verify(s => s.Hash(register.Password), Times.Once, "Hash should be called once");
            _securityService.Verify(s => s.GenerateJwtToken(user.UserId, user.Email), Times.Once, "GenerateToken should be called onec");
            _toEntityTranslator.Verify(t => t.ToUser(register, hashPassword), Times.Once, "ToUser should be called once");
            _commands.Verify(c => c.AddUser(user), Times.Once, "AddUser should be called once");
            Assert.Equal(user.UserId, authResponse.UserId);
            Assert.IsType<string>(authResponse.AccessToken);
        }

        [Fact(DisplayName = "Trying to register an User without email")]
        public async Task RegisterUserWithoutEmail_Failed()
        {
            // Arrange
            var register = CommonTestFactory.CreateRegister("", "sergio1234", UserTypes.ADMIN, "sergio", "perez");

            // Act
            // Assert
            var exeception = Assert.Throws<ValidationException>(() => _userService.Register(register));
        }
    }
}