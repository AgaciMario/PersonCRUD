using PersonCRUD.Domain.Enum;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IAuthService
    {
        string GenerateToken(string email, UserRoles role);
        string ComputeHash(string password, string salt);
    }
}
