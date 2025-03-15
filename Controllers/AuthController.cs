using EmployeeManagement.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            if (loginDto.Username == "test" && loginDto.Password == "test1")
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                // Ensure SecretKey is not null
                var secretKey = _configuration["JwtSettings:SecretKey"];
                if (string.IsNullOrEmpty(secretKey))
                {
                    return StatusCode(500, "JWT Secret Key is missing in configuration.");
                }

                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, loginDto.Username),
                        new Claim(ClaimTypes.Role, "Admin") // Example role claim
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _configuration["JwtSettings:Issuer"],
                    Audience = _configuration["JwtSettings:Audience"]
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { token = tokenHandler.WriteToken(token) });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
