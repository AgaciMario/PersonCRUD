using MediatR;
using PersonCRUD.Application.DTOs;

// TODO: explorar a ideia de colocar as validações de campos obrigatórios e com formatação especifica dentro do command 
namespace PersonCRUD.Application.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommand : IRequest<PersonDTO>
    {
        public UpdatePersonCommand(long id, string name, string? sex, string? email, DateTime birthDate, string? placeOfBirth, string? nationality, string cpf)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Email = email;
            BirthDate = birthDate;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            CPF = cpf;
        }

        public /*required*/ long Id { get; }   
        public /*required*/ string Name { get; }
        public string? Sex { get; }
        public string? Email { get; }
        public /*required*/ DateTime BirthDate { get; }
        public string? PlaceOfBirth { get; }
        public string? Nationality { get; }
        public /*required*/ string CPF { get; }
    }
}
