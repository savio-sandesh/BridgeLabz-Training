// Import configuration, cryptographic security, identity models, and token handling namespaces
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Helpers
{
    // Contract defining JWT generation capabilities
    public interface ITokenService
    {
        string GenerateToken(User user);
    }

    // Concrete utility responsible for signing and issuing JSON Web Tokens based on app settings
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        // Injects IConfiguration to access appsettings.json values
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Creates a signed JWT containing user claims, validity timestamps, and signature
        public string GenerateToken(User user)
        {
            // 1. Read JWT config values from appsettings.json
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings["Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured.");
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryMinutes = int.TryParse(jwtSettings["ExpiryMinutes"], out var m) ? m : 60;

            // 2. Define user identity payload (Claims)
            // Claims store encoded user identity (Id, Email, Full Name) inside the JWT payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                // Assigns a unique identifier (JTI) to this specific token to enable token tracking, revocation/blacklisting, and replay attack prevention
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // 3. Generate symmetric security key and signature credentials using HMAC-SHA256
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 4. Assemble the complete JWT token descriptor
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: credentials
            );

            // 5. Serialize the token into a compact string format (header.payload.signature)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}