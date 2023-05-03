using LabDotNet.Models.Dtos;

namespace LabDotNet.Models.Responses
{
    public class AuthenticationResponse
    {
        public UserDto User { get; set; }
        public string AccessToken { get; set; }
    }
}