using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
    {
        public Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken = default)
        {
            try
            {
                // TODOS: 
                CreatePersonValidator.Validate(request);
                // 2. Map the command to a domain model (if you have one)
                // 3. Save the domain model to the database (you would typically use a repository or a DbContext here)
                // 4. Map the saved domain model to a DTO and return it

                // Here you would typically add logic to save the person to a database
                // For this example, we'll just return a new PersonDTO with the provided data
                var newPerson = new PersonDTO
                {
                    Id = 1, // Simulate database-generated ID
                    Name = request.Name,
                    BirthDate = request.BirthDate,
                    CPF = request.CPF
                };

                return Task.FromResult(newPerson);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
