using LabDotNet.Models.Entities;

namespace LabDotNet.Models.Responses
{
    public class AuthenticationResponse
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
    }
}