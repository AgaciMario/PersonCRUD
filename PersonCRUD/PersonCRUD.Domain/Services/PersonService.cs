using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Records;

namespace PersonCRUD.Domain.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> CreatePerson(PersonRecord person, CancellationToken ct = default)
        {
            try
            {
                await ValidateIfPersonIsRegistered(person.cpf, ct);

                return new Person(
                    person.name,
                    person.sex,
                    person.email,
                    person.birthDate,
                    person.placeOfBirth,
                    person.nationality,
                    person.cpf
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ValidateIfPersonIsRegistered(string cpf, CancellationToken ct = default)
        {
            try
            {
                Person? existingPerson = await _personRepository.GetPersonByCPF(cpf, ct);

                if (existingPerson != null)
                    throw new ArgumentException("A Person with this CPF is already registered.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
