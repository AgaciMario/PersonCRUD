using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.GenerateAccessTokenCommand
{
    public class GenerateAccessTokenCommand : IRequest<TokenDTO>
    {
        public GenerateAccessTokenCommand(string email, string password, JwtInfo jwtInfo)
        {
            if(string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Email is required.", nameof(Email));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Password is required.", nameof(Password));

            if (jwtInfo == null)
                throw new ArgumentNullException("jwtInfo is required.", nameof(jwtInfo));

            Email = email;
            Password = password;
            JwtInfo = jwtInfo;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public JwtInfo JwtInfo { get; private set; }
    }

    public record JwtInfo(string JwtIssuer, string JwtAudience, byte[] JwtKey);
}
