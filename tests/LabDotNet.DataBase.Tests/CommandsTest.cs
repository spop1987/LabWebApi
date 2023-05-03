using LabDotNet.Common.Tests;
using LabDotNet.DataBase.DataAccess;
using LabDotNet.DataBase.DataAccess.Interfaces;
using Xunit;

namespace LabDotNet.DataBase.Tests
{
    public class CommandsTest : IClassFixture<LabDbContextFixture>
    {
        private readonly LabDbContextFixture _fixture;
        private readonly ICommands _commands;

        public CommandsTest()
        {
            _fixture = new LabDbContextFixture();
            _commands = new Commands(_fixture.Context);
        }

        [Fact(DisplayName = "AddUser [Success]")]
        public void AddUser_Success()
        {
            // Arranfe
            var user = CommonTestFactory.CreateUser(10, "fdfndsflkdsjfkdsf");
             
            // Act
            var userId = _commands.AddUser(user);

            // Assert
            var currentUser = _fixture.Context.Users.FirstOrDefault(u => u.FirstName == user.FirstName);
            Assert.NotNull(currentUser);
            Assert.Equal(user.Email, currentUser.Email);
            Assert.Equal(user.LastName, currentUser.LastName);
        }
    }
}