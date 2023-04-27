using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;

namespace LabDotNet.Models.Translators.Interfaces
{
    public interface IToEntityTranslator
    {
        User ToUser(Register register, string hashedPassword);
    }
}