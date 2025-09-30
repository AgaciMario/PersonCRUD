using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Application.Querys.GetPersonPaginatedQuery
{
    public class GetPersonPaginatedHandler : IRequestHandler<GetPersonPaginatedQuery, List<PersonDTO>>
    {
		readonly IPersonRepository PersonRepository;

        public GetPersonPaginatedHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task<List<PersonDTO>> Handle(GetPersonPaginatedQuery request, CancellationToken ct)
        {
            try
            {
                List<Person> personList = await PersonRepository.GetPersonPaginated(request.CurrentPage, request.PageSize, ct);

                List<PersonDTO> personDTOList = new List<PersonDTO>();
                foreach (Person person in personList)
                {
                    personDTOList.Add(new PersonDTO()
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
                    });
                }

                return personDTOList;
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
