using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using LabDotNet.Models.Responses;

namespace LabDotNet.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(long userId);
        List<User> GetAll();
        AuthenticationResponse Register(Register register);
        LoginResponse Login(Login login);
    }
}