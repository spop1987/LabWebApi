using System.ComponentModel.DataAnnotations;
using LabDotNet.Models.Constants;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using LabDotNet.Models.Responses;
using LabDotNet.Services.Interfaces;

namespace LabDotNet.Services.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResponse Register(Register register)
        {
            ValidateRegister(register);
        }

        private void ValidateRegister(Register register)
        {
            if(string.IsNullOrEmpty(register.Email) || string.IsNullOrEmpty(register.Password) || string.IsNullOrEmpty(register.FirstName) || string.IsNullOrEmpty(register.LastName))
                throw new ValidationException("Should fill all the fields");
            
            if(register.UserType != UserTypes.ADMIN && register.UserType != UserTypes.CUSTOMER)
                throw new ValidationException("Invalid User Type");
            
        }
    }
}