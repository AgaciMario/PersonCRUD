using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Exceptions;

namespace PersonCRUD.Application.Querys.GetPersonByIdQuery
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {
		private readonly IPersonRepository PersonRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                Person person = await PersonRepository.GetPersonById(request.Id, cancellationToken)
                    ?? throw new NotFoundException("A person with the given id was not found.");

                return new PersonDTO
                {
                    Id = person.Id.Value,
                    Name = person.Name,
                    Sex = person.Sex,
                    Email = person.Email,
                    BirthDate = person.BirthDate,
                    PlaceOfBirth = person.PlaceOfBirth,
                    Nationality = person.Nationality,
                    CPF = person.CPF,
                    CreatedAt = person.CreatedAt,
                    UpdatedAt = person.UpdatedAt
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
