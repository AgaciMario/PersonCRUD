using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IPersonRepository
    {
        Task<Person> RegisterPerson(Person person, CancellationToken ct);
        Task<Person> UpdatePerson(Person person, CancellationToken ct);
        Task<Person> DeletePerson(long personId, CancellationToken ct);
        Task<Person> GetPersonById(long personId, CancellationToken ct);
        Task<Person> GetPersonByCPF(string CPF, CancellationToken ct);
    }
}
