using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Infra.Context;

namespace PersonCRUD.Infra.Repository
{
    public class UserRepository(PersonDbContext personDbContext) : IUserRepository
    {
        public async Task<User?> GetUserByEmail(string userEmail, CancellationToken ct) => await personDbContext.User
            .Where(user => user.Email == userEmail && user.DeletedAt == null)
            .AsNoTracking()
            .SingleOrDefaultAsync(ct);
    }
}
