using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : IRequest<PersonDTO>
    {
        public required string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public required string CPF { get; set; } = string.Empty;
    }
}
