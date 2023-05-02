using LabDotNet.Models.Dtos;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Translators.Interfaces;

namespace LabDotNet.Models.Translators
{
    public class ToDtoTranslator : IToDtoTranslator
    {
        public UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserType = user.UserType,
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate
            };
        }
    }
}