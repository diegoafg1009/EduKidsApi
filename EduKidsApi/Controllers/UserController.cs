using EduKidsApi.Dtos;
using EduKidsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduKidsApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // POST: api/Users/Register

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.Email,
                Email = userDto.Email
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return Ok(await BuildToken(userDto));
            }

            return BadRequest(result.Errors);
        }

        // POST: api/Users/Login

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto model)
        {

            var login = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (login.Succeeded)
            {
                return await BuildToken(model);
            }
            else
            {
                return BadRequest("Usuario y/o contraseña incorrecto");
            }
        }

        private async Task<string> BuildToken(UserDto userDto)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userDto.Email),
            };

            var user = await _userManager.FindByEmailAsync(userDto.Email);

            claims.Add(new Claim("Id", user.Id.ToString()));
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtkey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
