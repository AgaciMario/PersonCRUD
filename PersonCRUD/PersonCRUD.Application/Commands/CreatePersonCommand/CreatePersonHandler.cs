using MediatR;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
    {
        private readonly IPersonService personService;
        private readonly IPersonRepository personRepository;

        // TODO: Adicionar contrutor primario e remover as propriedades
        public CreatePersonHandler(IPersonService personService, IPersonRepository personRepository)
        {
            this.personService = personService;
            this.personRepository = personRepository;
        }

        public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken ct = default)
        {
            // TODO: mudar mapping para usar AutoMapper ou isolar o mapeamento em uma classe propria;
            try
            {
                Person newPerson = await personService.CreatePerson(new( 
                    name: request.Name,
                    sex: request.Sex,
                    email: request.Email,
                    birthDate: request.BirthDate,
                    placeOfBirth: request.PlaceOfBirth,
                    nationality: request.Nationality,
                    cpf: request.CPF
                ), ct);

                newPerson = await personRepository.RegisterPerson(newPerson, ct);

                var personDTO = new PersonDTO
                {
                    Id = newPerson.Id.Value,
                    Name = newPerson.Name,
                    Sex = newPerson.Sex,
                    Email = newPerson.Email,
                    BirthDate = newPerson.BirthDate,
                    PlaceOfBirth = newPerson.PlaceOfBirth,
                    Nationality = newPerson.Nationality,
                    CPF = newPerson.CPF,
                    CreatedAt = newPerson.CreatedAt,
                    UpdatedAt = newPerson.UpdatedAt,
                };

                return personDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
