using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.LoginCommand
{
    public class LoginCommand : IRequest<TokenDTO>
    {
        public LoginCommand(string email, string password)
        {
            // Use static exception classes to throw exception;
            if(string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Email is required.", nameof(Email));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Password is required.", nameof(Password));

            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
