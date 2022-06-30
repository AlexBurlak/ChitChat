using ChitChat.API.Helpers;
using ChitChat.API.Models.Requests;
using ChitChat.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChitChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTHelper _jwtHelper;
        
        public AuthenticationController(UserManager<User> userManager,IJWTHelper jwtHelper)
        {
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
                return BadRequest();

            var user = (await _userManager.FindByNameAsync(request.Login)) ??
                       (await _userManager.FindByEmailAsync(request.Login));
            if (user == null)
                return BadRequest("Bad login");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordCorrect)
                return BadRequest("Bad password");
            return Ok(_jwtHelper.GetToken(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            }

            if (!request.Password.Equals(request.PasswordConfirm))
                return BadRequest("Passwords are not the same");

            var user = await _userManager.FindByNameAsync(request.Login);
            if (user != null)
                return BadRequest("User with such username already exists");

            user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
                return BadRequest("User with such email already exists");

            user = new User() { UserName = request.Login, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return Ok(_jwtHelper.GetToken(user));
            }

            var errors = string.Join(" ", result.Errors.Select(e => e.Description));
            return BadRequest(string.Format($"Some errors occured: {errors}"));
        }
    }
}
