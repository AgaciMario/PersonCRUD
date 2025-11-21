using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonCRUD.Domain.Enum;
using PersonCRUD.Domain.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonCRUD.Infra.Auth
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        public string ComputeHash(string password, string salt)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(string email, UserRoles role)
        {
            string? issuer = configuration["Jwt:Issuer"];
            string? audience = configuration["Jwt:Audience"];
            string? key = configuration["Jwt:Key"];

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var symmetricSecurityKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimList = new List<Claim>
            {
                new(ClaimTypes.Email, email),
                new(ClaimTypes.Role, role.ToString()),
                new("jti", Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(issuer, audience, claimList, null, DateTime.UtcNow.AddHours(2), signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
