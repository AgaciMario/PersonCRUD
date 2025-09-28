using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonHandler
    {
        public static PersonDTO Handle(CreatePersonCommand command)
        {
            // Here you would typically add logic to save the person to a database
            // For this example, we'll just return a new PersonDTO with the provided data
            var newPerson = new PersonDTO
            {
                Id = 1, // Simulate database-generated ID
                Name = command.Name,
                BirthDate = command.BirthDate,
                CPF = command.CPF
            };
            return newPerson;
        }

    }
}
