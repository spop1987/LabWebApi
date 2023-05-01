using LabDotNet.Common.Tests;
using LabDotNet.Models.Constants;
using LabDotNet.Models.Request;
using LabDotNet.Models.Translators;
using Xunit;

namespace LabDotNet.Models.Tests
{
    public class ToEntityTranslatorTest
    {
        private readonly ToEntityTranslator _translator;

        public ToEntityTranslatorTest()
        {
            _translator = new ToEntityTranslator();
        }

        [Fact(DisplayName = "ToUser [Success]")]
        public async Task ToUser_Success()
        {
            // Arrange

            var register = CommonTestFactory.CreateRegister("sergio@levio.com", "sergio1234", UserTypes.ADMIN, "sergio", "perez");

            // Act
            var user = _translator.ToUser(register, "string");

            // Assert
            await EntityAsserts.AssertUserAsync(user, register);
        }
    }
}