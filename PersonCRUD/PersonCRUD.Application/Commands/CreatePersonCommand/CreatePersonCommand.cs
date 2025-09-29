using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : IRequest<PersonDTO>
    {
        public required string Name { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public required DateTime BirthDate { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Nationality { get; set; }
        public required string CPF { get; set; }
    }
}
