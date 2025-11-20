using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Infra.Context
{
    public class PersonDbContext(DbContextOptions<PersonDbContext> options) : DbContext(options)
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
    }
}
