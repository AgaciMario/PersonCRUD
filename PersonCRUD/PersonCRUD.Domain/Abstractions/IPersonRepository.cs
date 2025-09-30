using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IPersonRepository
    {
        Task<Person> RegisterPerson(Person person, CancellationToken ct);
        Task<Person> UpdatePerson(Person person, CancellationToken ct);
        Task<Person> DeletePerson(Person person, CancellationToken ct);
        Task<Person?> GetPersonById(long personId, CancellationToken ct);
        Task<Person?> GetPersonByCPF(string cpf, CancellationToken ct);
    }
}
