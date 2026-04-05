using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        // A secure endpoint that validates JWT manually
        [HttpGet("manual")] //GET/manual
        public IActionResult SecureManual([FromHeader(Name = "Authorization")] string authHeader)
        {
            // 1️ Check if Authorization header exists
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized("Missing or invalid Authorization header");

            // 2️ Extract the token string
            var token = authHeader.Substring("Bearer ".Length).Trim();

            // 3️ Create the same secret key used to sign the token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("your-secret-key-welcome-to-muthudevhub")
            );

            // 4️ Set up the token validation parameters (same as AddJwtBearer)
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // don't check issuer
                ValidateAudience = false, // don't check audience
                ValidateLifetime = true, // check expiration
                ValidateIssuerSigningKey = true, // check signature
                IssuerSigningKey = key,
            };

            try
            {
                // 5️ Validate the token
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(
                    token,
                    tokenValidationParameters,
                    out SecurityToken validatedToken
                );

                // 6 Optional: read claims from validated token
                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                // 7 return authorized response
                return Ok($"Welcome {username}, you are authorized!");
            }
            catch (Exception ex)
            {
                // 8 If validation fails, reject the request
                return Unauthorized($"Token validation failed: {ex.Message}");
            }
        }
    }
}
