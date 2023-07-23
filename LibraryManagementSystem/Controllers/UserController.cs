using Library.API.AuthenticationModels;
using Library.API.Services;
using Library.API.Services.UserService;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger, IUserService userService) 
        {
            this.logger = logger    ;
            _userService = userService;
        }


        [HttpPost("signup", Name = "SignUp")]
        public IActionResult SignUp([FromBody] RegisterModel user)
        {
            Task<User?> x = _userService.SignUp(user);

            return Ok(x.Result);

        }



        [HttpPost("login", Name = "Login")]
        public string Post([FromBody] LoginModel user)
        {
            Task<string> x = _userService.Login(user);

            return x.Result;
            

        }






    }
}
