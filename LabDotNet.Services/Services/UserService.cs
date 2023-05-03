using System.ComponentModel.DataAnnotations;
using LabDotNet.DataBase.DataAccess.Interfaces;
using LabDotNet.Models.Constants;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using LabDotNet.Models.Responses;
using LabDotNet.Models.Translators.Interfaces;
using LabDotNet.Services.Interfaces;

namespace LabDotNet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ISecurityService _securityService;
        private readonly IQueries _queries;
        private readonly ICommands _commands;
        private readonly IToEntityTranslator _toEntityTranslator;
        private readonly IToDtoTranslator _toDtoTranslator;

        public UserService(ISecurityService securityService,
                           IQueries queries,
                           ICommands commands,
                           IToEntityTranslator toEntityTranslator,
                           IToDtoTranslator toDtoTranslator)
        {
            _securityService = securityService;
            _queries = queries;
            _commands = commands;
            _toEntityTranslator = toEntityTranslator;
            _toDtoTranslator = toDtoTranslator;
        }
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResponse Login(Login login)
        {
            ValidateLogin(login);

            var user = _queries.FindUserByEmail(login.Email);
            if(user is null)
                throw new ValidationException("User does not exists");
            
            var hashedPassword = _securityService.Hash(login.Password);

            if(hashedPassword != user.Password)
                throw new ValidationException("Password incorrect");
            
            var response = new AuthenticationResponse();
            response.User = _toDtoTranslator.ToUserDto(user);
            response.AccessToken = _securityService.GenerateJwtToken(user.UserId, user.Email);

            return response;
        }

        public AuthenticationResponse Register(Register register)
        {
            ValidateRegister(register);
            
            var user = _queries.FindUserByEmail(register.Email);
            if(user != null)
                throw new ValidationException("There is an user with this email in the platform");
            
            var hashedPassword = _securityService.Hash(register.Password);

            var newUser = _toEntityTranslator.ToUser(register, hashedPassword);
            
            var userId = _commands.AddUser(newUser);
            var userDto = _toDtoTranslator.ToUserDto(newUser);
            var response = new AuthenticationResponse();
            response.User = userDto;
            response.AccessToken = _securityService.GenerateJwtToken(userId, newUser.Email);
            return response;
        }

        private void ValidateLogin(Login login)
        {
            if(string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
                throw new ValidationException("Email and password are mandatory");
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