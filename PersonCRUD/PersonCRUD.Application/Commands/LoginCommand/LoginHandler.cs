using MediatR;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Exceptions;

namespace PersonCRUD.Application.Commands.LoginCommand
{
    public class LoginHandler(IUserRepository userRepository, IAuthService authService) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await userRepository.GetUserByEmail(command.Email, cancellationToken);
                UnauthorizedException.ThrowIfNull(user, erroMsg: "A user with the given email was not found!");

                string commandPassword = authService.ComputeHash(command.Password, user.Salt);
                if (!user.Password.Equals(commandPassword)) throw new UnauthorizedException("Incorrect password!");
                
                string token = authService.GenerateToken(user.Email, user.Role);
                return token;
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
