using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Infra.Context;

namespace PersonCRUD.Infra.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext PersonDbContext;

        public PersonRepository(PersonDbContext personDbContext)
        {
            PersonDbContext = personDbContext;
        }

        public async Task<Person> DeletePerson(Person person, CancellationToken ct)
        {
            PersonDbContext.Person.Update(person);
            await PersonDbContext.SaveChangesAsync(ct);
            return person;
        }

        public async Task<Person?> GetPersonByCPF(string cpf, CancellationToken ct) => await PersonDbContext.Person
            .Where(person => person.CPF == cpf && person.DeletedAt == null)
            .AsNoTracking()
            .SingleOrDefaultAsync(ct);

        public async Task<Person?> GetPersonById(long personId, CancellationToken ct) => await PersonDbContext.Person
            .Where(person => person.Id == personId && person.DeletedAt == null)
            .AsNoTracking()
            .SingleOrDefaultAsync(ct);

        public async Task<Person> RegisterPerson(Person person, CancellationToken ct)
        {
            await PersonDbContext.Person.AddAsync(person, ct);
            await PersonDbContext.SaveChangesAsync(ct);
            return person;
        }

        public async Task<Person> UpdatePerson(Person person, CancellationToken ct)
        {
            PersonDbContext.Person.Update(person);
            await PersonDbContext.SaveChangesAsync(ct);
            return person;
        }

        public async Task<List<Person>> GetPersonPaginated(int currentPage, int pageSize, CancellationToken ct) => await PersonDbContext.Person
            .AsNoTracking()
            .Where(person => person.DeletedAt == null)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }
}
