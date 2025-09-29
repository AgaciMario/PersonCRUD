using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Records;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IPersonService
    {
        Person CreatePerson(PersonRecord personRecord, CancellationToken ct);
        void ValidateIfPersonIsRegistered(string cpf, CancellationToken ct);
    }
}
