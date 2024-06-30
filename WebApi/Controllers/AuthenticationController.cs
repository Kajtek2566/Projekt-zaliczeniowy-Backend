using Application.Services;
using Domain.DTO;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IZooUserService _zooUserService;

        public AuthenticationController(IConfiguration configuration, IZooUserService zooUserService)
        {
            _configuration = configuration;
            _zooUserService = zooUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (string.IsNullOrWhiteSpace(registerDTO.Login) || string.IsNullOrWhiteSpace(registerDTO.Password))
            {
                return BadRequest(new { Message = "Username and password are required." });
            }

            var existingUser = await _zooUserService.GetUserByLoginAsync(registerDTO.Login);
            if (existingUser != null)
            {
                return Conflict(new { Message = "Username already exists." });
            }

            await _zooUserService.RegisterUserAsync(registerDTO);
            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.UserName) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { Message = "Username and password are required." });
            }

            var user = await _zooUserService.GetUserByLoginAsync(login.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            var tokenString = GenerateJWTToken(user);
            return Ok(new { Token = tokenString });
        }

        private string GenerateJWTToken(ZooUser zooUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, zooUser.Id.ToString()),
                new Claim(ClaimTypes.Role, zooUser.Role)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

