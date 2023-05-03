using LabDotNet.Common.Tests;
using LabDotNet.DataBase.DataAccess;
using LabDotNet.DataBase.DataAccess.Interfaces;
using Xunit;

namespace LabDotNet.DataBase.Tests
{
    public class QueriesTest : IClassFixture<LabDbContextFixture>
    {
        private readonly LabDbContextFixture _fixture;
        private readonly IQueries _queries;

        public QueriesTest()
        {
            _fixture = new LabDbContextFixture();
            _queries = new Queries(_fixture.Context);
        }

        [Fact(DisplayName = "GetUser [Success]")]
        public void GetUser_Success()
        {
            // Arrange
            var user = CommonTestFactory.CreateUser(10, "fdbjkfdsjkfbdsjkgb");
            _fixture.Context.Users.Add(user);
            _fixture.Context.SaveChanges();

            var userId = user.UserId;

            // Act
            var currentUser = _queries.FindUserByEmail(user.Email);

            // Assert
            Assert.NotNull(currentUser);
            Assert.Equal(user.FirstName, currentUser.FirstName);
            Assert.Equal(user.LastName, currentUser.LastName);
            Assert.Equal(user.Email, currentUser.Email);
        }
    }
}