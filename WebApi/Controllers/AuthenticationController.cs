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
    public class AuthenticationController : ControllerBase
    {
       
        private readonly IConfiguration _configuration;
        private readonly IZooUserService _zooUserService; 
        private readonly UserManager<ZooUser> _userManager; 

        public AuthenticationController(IConfiguration configuration, IZooUserService zooUserService, UserManager<ZooUser> userManager)
        {
            _configuration = configuration;
            _zooUserService = zooUserService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (string.IsNullOrWhiteSpace(registerDTO.UserName) || string.IsNullOrWhiteSpace(registerDTO.Password))
            {
                return BadRequest(new { Message = "Nazwa i Hasło są wymagane" });
            }

            var existingUser = await _zooUserService.FindByUserName(registerDTO.UserName);
            if (existingUser != null)
            {
                return Conflict(new { Message = "Ta Nazwa już istnieje." });
            }

            await _zooUserService.RegisterUserAsync(registerDTO);
            return Ok(new { Message = "Użytkownik został utworzony" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.UserName) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { Message = "Nazwa i Hasło są wymagane" });
            }
            //await _userManager.CheckPasswordAsync(user, login.Password))  
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return Unauthorized(new { Message = "Nieprawidłowa Nazwa albo Hasło." });
            }

            var tokenString = GenerateJWTToken(user);
            return Ok(new { Token = tokenString });
        }

        private string GenerateJWTToken(ZooUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
               // new Claim(ClaimTypes.Role, user.)
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

