using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Application.Commands.LoginCommand
{
    public class LoginHandler(IUserRepository userRepository, IAuthService authService) : IRequestHandler<LoginCommand, TokenDTO>
    {
        public async Task<TokenDTO> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await userRepository.GetUserByEmail(command.Email, cancellationToken);
                if (user == null)
                    return new TokenDTO(false, string.Empty, "A user with the given email was not found!");

                string commandPassword = authService.ComputeHash(command.Password, user.Salt);

                if (!user.Password.Equals(commandPassword))
                    return new TokenDTO(false, string.Empty, "Incorrect password! hash: ");
                
                string token = authService.GenerateToken(user.Email, user.Role);

                return new TokenDTO(true, token, null);
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
