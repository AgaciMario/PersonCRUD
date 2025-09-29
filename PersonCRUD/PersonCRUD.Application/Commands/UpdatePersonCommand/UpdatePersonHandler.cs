using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Application.Commands.UpdatePersonCommand
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonDTO>
    {
		private readonly IPersonService PersonService;
		private readonly IPersonRepository PersonRepository;

        public UpdatePersonHandler(IPersonService personService, IPersonRepository personRepository)
        {
            PersonService = personService;
            PersonRepository = personRepository;
        } 

        public async Task<PersonDTO> Handle(UpdatePersonCommand command, CancellationToken ct = default)
		{
			try
			{
				UpdatePersonValidator.Validate(command);

				Person updatedPerson = await PersonService.UpdatePerson(new(
					id: command.Id,
					name: command.Name,
					sex: command.Sex,
					email: command.Email,
					birthDate: command.BirthDate,
					placeOfBirth: command.PlaceOfBirth,
					nationality: command.Nationality,
					cpf: command.CPF
				), ct);

				updatedPerson = await PersonRepository.UpdatePerson(updatedPerson, ct);

				return new PersonDTO
				{
					Id = updatedPerson.Id.Value,
					Name = updatedPerson.Name,
					Sex = updatedPerson.Sex,
					Email = updatedPerson.Email,
					BirthDate = updatedPerson.BirthDate,
					PlaceOfBirth = updatedPerson.PlaceOfBirth,
					Nationality = updatedPerson.Nationality,
					CPF = updatedPerson.CPF,
					CreatedAt = updatedPerson.CreatedAt,
					UpdatedAt = updatedPerson.UpdatedAt
				};
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
