

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Target.Exceptions;

namespace Target.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string? Login(string? username, string? password)
        {
            var adminUser = Environment.GetEnvironmentVariable("AUTH_USERNAME");
            var adminPassword = Environment.GetEnvironmentVariable("AUTH_PASSWORD");
            var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new BusinessException("JWT_SECRET não encontrado");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            
            if(username == null || password == null) return null;
            if (username != adminUser || password != adminPassword) return null;


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, username)
                ]),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = jwtIssuer,
                Audience = jwtAudience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}