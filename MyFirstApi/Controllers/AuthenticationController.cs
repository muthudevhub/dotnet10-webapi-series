using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // For demonstration purposes, we will just check if the username and password are "admin"
            if (request.Username == "admin" && request.Password == "admin")
            {
                var token = GenerateJwtToken(request.Username);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJwtToken(string username)
        {
            // Create claims
            var claims = new[] { new Claim(ClaimTypes.Name, username) };

            // create secret key
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("your-secret-key-welcome-to-muthudevhub")
            );

            // create signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            // convert the token to a string and return it
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
