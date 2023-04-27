using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using LabDotNet.Models.Translators.Interfaces;

namespace LabDotNet.Models.Translators
{
    public class ToEntityTranslator : IToEntityTranslator
    {
        public User ToUser(Register register, string hashedPassword)
        {
            return new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Password = hashedPassword,
                UserType = register.UserType,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
        }
    }
}