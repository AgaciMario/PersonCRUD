using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Infra.Context
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
