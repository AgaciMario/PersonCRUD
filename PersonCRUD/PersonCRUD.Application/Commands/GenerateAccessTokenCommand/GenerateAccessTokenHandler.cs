using MediatR;
using Microsoft.IdentityModel.Tokens;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PersonCRUD.Application.Commands.GenerateAccessTokenCommand
{
    public class GenerateAccessTokenHandler(IUserRepository userRepository) : IRequestHandler<GenerateAccessTokenCommand, TokenDTO>
    {
        public async Task<TokenDTO> Handle(GenerateAccessTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                //TODO: Criar um service para lidar com este caso, pois a geração do token e validação de usuário
                // devem ser separados.
                User? user = await userRepository.GetUserByEmail(command.Email, cancellationToken);
                if (user == null)
                    return new TokenDTO(false, string.Empty, "A user with the given email was not found!");

                if (command.Password != user.Password)
                    return new TokenDTO(false, string.Empty, "Incorrect password!");

                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("role", user.Role),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    Issuer = command.JwtInfo.JwtIssuer,
                    Audience = command.JwtInfo.JwtAudience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(command.JwtInfo.JwtKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken jwtToken = tokenHandler.CreateToken(securityTokenDescriptor);
                string stringToken = tokenHandler.WriteToken(jwtToken);

                return new TokenDTO(true, stringToken, null);
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
