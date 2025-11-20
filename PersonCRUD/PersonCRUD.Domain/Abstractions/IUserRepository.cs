using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string userEmail, CancellationToken ct);
    }
}
