using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Exceptions;
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

        public async Task<Person> CreatePerson(CreatePersonRecord person, CancellationToken ct = default)
        {
            try
            {
                Person? existingPerson = await _personRepository.GetPersonByCPF(person.cpf, ct);

                if (existingPerson != null)
                    throw new ArgumentException("A Person with this CPF is already registered.");

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

        public async Task<Person> UpdatePerson(UpdatePersonRecord person, CancellationToken ct = default)
        {
            try
            {
                // TODO: Adicionar exception propria pois a null ArgumentNullException adiciona conteudo a mensagem de erro.
                Person? existingPerson = await _personRepository.GetPersonById(person.id, ct)
                    ?? throw new NotFoundException("A person with the given id was not found");

                existingPerson.Update(
                    person.name,
                    person.sex,
                    person.email,
                    person.birthDate,
                    person.placeOfBirth,
                    person.nationality,
                    person.cpf
                );

                return existingPerson;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
