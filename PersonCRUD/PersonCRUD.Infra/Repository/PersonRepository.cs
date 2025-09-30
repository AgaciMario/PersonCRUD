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

        public Task<Person> DeletePerson(long personId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> GetPersonByCPF(string cpf, CancellationToken ct) => await PersonDbContext.Person
            .Where(person => person.CPF == cpf)
            .AsNoTracking()
            .SingleOrDefaultAsync(ct);

        public async Task<Person?> GetPersonById(long personId, CancellationToken ct) => await PersonDbContext.Person
            .Where(person => person.Id == personId)
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
    }
}
