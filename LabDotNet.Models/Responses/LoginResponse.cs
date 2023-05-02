using LabDotNet.Models.Dtos;

namespace LabDotNet.Models.Responses
{
    public class LoginResponse
    {
        public UserDto User { get; set; }
        public string AccessToken { get; set; }
    }
}