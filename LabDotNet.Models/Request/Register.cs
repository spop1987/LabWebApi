namespace LabDotNet.Models.Request
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}