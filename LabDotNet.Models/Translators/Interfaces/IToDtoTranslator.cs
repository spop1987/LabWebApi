using LabDotNet.Models.Dtos;
using LabDotNet.Models.Entities;

namespace LabDotNet.Models.Translators.Interfaces
{
    public interface IToDtoTranslator
    {
        UserDto ToUserDto(User user);
    }
}