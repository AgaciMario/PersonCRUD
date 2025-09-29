using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Records;

namespace PersonCRUD.Domain.Abstractions
{
    public interface IPersonService
    {
        Task<Person> CreatePerson(CreatePersonRecord personRecord, CancellationToken ct);
        Task<Person> UpdatePerson(UpdatePersonRecord personRecord, CancellationToken ct);
    }
}
