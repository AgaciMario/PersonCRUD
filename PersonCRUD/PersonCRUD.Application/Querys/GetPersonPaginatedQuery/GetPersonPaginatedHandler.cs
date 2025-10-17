using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Application.Querys.GetPersonPaginatedQuery
{
    public class GetPersonPaginatedHandler : IRequestHandler<GetPersonPaginatedQuery, GetPersonPaginatedDTO>
    {
		readonly IPersonRepository PersonRepository;

        public GetPersonPaginatedHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task<GetPersonPaginatedDTO> Handle(GetPersonPaginatedQuery request, CancellationToken ct)
        {
            try
            {
                (List<Person> rawData, int totalCount) = await PersonRepository.GetPersonPaginated(request.CurrentPage, request.PageSize, request.NameFilter, ct);

                List<PersonDTO> finalData = new List<PersonDTO>();
                foreach (Person person in rawData)
                {
                    finalData.Add(new PersonDTO()
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

                GetPersonPaginatedDTO response = new GetPersonPaginatedDTO(totalCount, request.PageSize, request.CurrentPage, finalData);

                return response;
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
