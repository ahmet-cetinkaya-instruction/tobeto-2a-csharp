using Business.Abstract;
using Business.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public void Register([FromBody] RegisterRequest request)
        {
            _userService.Register(request);
        }
        [HttpPost("Login")]
        public bool Login([FromBody] LoginRequest request)
        {
            return _userService.Login(request);
        }
    }
}
