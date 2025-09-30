using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Querys.GetPersonByIdQuery
{
    public class GetPersonByIdQuery : IRequest<PersonDTO> 
    {
        public GetPersonByIdQuery(long id)
        {
            if(id <= 0) throw new ArgumentException("Id must be greater than zero.", nameof(Id));
            Id = id;
        }

        public long Id { get; }
    }
}
