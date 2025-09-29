using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Records;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IPersonService
    {
        Task<Person> CreatePerson(PersonRecord personRecord, CancellationToken ct);
        Task ValidateIfPersonIsRegistered(string cpf, CancellationToken ct);
    }
}
