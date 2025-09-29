using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Infra.Context;
using System.Threading;

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

        public async Task<Person?> GetPersonByCPF(string CPF, CancellationToken ct) => await PersonDbContext.Person
                .Where(person => person.CPF == CPF)
                .AsNoTracking()
                .FirstOrDefaultAsync(ct);

        public Task<Person> GetPersonById(long personId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> RegisterPerson(Person person, CancellationToken ct)
        {
            await PersonDbContext.Person.AddAsync(person, ct);
            return person;
        }

        public Task<Person> UpdatePerson(Person person, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
