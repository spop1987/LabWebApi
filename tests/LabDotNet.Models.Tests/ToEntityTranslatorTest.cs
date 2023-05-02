using LabDotNet.Common.Tests;
using LabDotNet.Models.Constants;
using LabDotNet.Models.Request;
using LabDotNet.Models.Translators;
using Xunit;

namespace LabDotNet.Models.Tests
{
    public class ToEntityTranslatorTest
    {
        private readonly ToEntityTranslator _toEntityTranslator;
        private readonly ToDtoTranslator _toDtoTranslator;

        public ToEntityTranslatorTest()
        {
            _toEntityTranslator = new ToEntityTranslator();
            _toDtoTranslator = new ToDtoTranslator();
        }

        [Fact(DisplayName = "ToUser [Success]")]
        public async Task ToUser_Success()
        {
            // Arrange

            var register = CommonTestFactory.CreateRegister("sergio@levio.com", "sergio1234", UserTypes.ADMIN, "sergio", "perez");

            // Act
            var user = _toEntityTranslator.ToUser(register, "string");

            // Assert
            await EntityAsserts.AssertUserAsync(user, register);
        }

        [Fact(DisplayName = "ToUserDto [Success]")]
        public void ToUserDto_Success()
        {
            // Arrange
            var hashPassword = CommonTestFactory.CreateHash(10);
            var user = CommonTestFactory.CreateUser(10, hashPassword);
            
            // Act
            var userDto = _toDtoTranslator.ToUserDto(user);

            // Assert
            Assert.Equal(user.FirstName, userDto.FirstName);
            Assert.Equal(user.LastName, userDto.LastName);
            Assert.Equal(user.UserType, userDto.UserType);
            Assert.Equal(user.CreateDate, userDto.CreateDate);
            Assert.Equal(user.UpdateDate, userDto.UpdateDate);
        }
    }
}