using LabDotNet.Models.Request;
using LabDotNet.Models.Responses;
using LabDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabDotNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponse> Login(Login login)
        {
            return _userService.Login(login);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult<AuthenticationResponse> Register(Register register)
        {
            return _userService.Register(register);
        }   
    }
}