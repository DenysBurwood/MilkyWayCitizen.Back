using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.API.Mappers;
using MilkyWayCitizen.Back.API.Services;
using MilkyWayCitizen.Back.API.Tools;
using MilkyWayCitizen.Back.BLL.Services;
using MilkyWayCitizen.Back.DL.Entities;
using System.Security.Claims;

namespace MilkyWayCitizen.Back.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        public UserController(UserService userService, AuthService authService) 
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginFormDTO form) 
        {
            if(form is null)
            {
                throw new Exception("Null form...");
            }
            User user = _userService.Login(form.UserName, form.Password);
            string token = _authService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserRegisterFormDTO form)
        {
            if(form is null)
            {
                throw new Exception("Null form...");
            }
            _userService.Register(form.ToUserFromUserFormDTO());
            return Ok();
        }

        [Authorize]
        [HttpGet("my_account")]
        public ActionResult GetMyAccount() 
        {
            int id = User.GetUserID();
            User? user = _userService.GetUserById(id);
            if(user==null) 
            {
                throw new Exception();
            }
            UserDetailsDTO userDetails = user.ToUserDetailsDTOFromUser();
            return Ok(userDetails);
        }
    }
}
