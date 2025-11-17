using MediatR;
using PersonCRUD.Application.DTOs;
using System.Text.RegularExpressions;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : IRequest<PersonDTO>
    {
        public CreatePersonCommand(string name, string? sex, string? email, DateTime birthDate, string? placeOfBirth, string? nationality, string cpf)
        {
            SetName(name);
            Sex = sex;
            SetEmail(email);
            SetBirthDate(birthDate);
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            SetCPF(cpf);
        }

        // Nota: Inicializando propriedades como string vazia apenas para remover o warning, o construtor deve garantir que haja um
        // valor valido para as propridades em questão. (TODO: buscar melhor solução)
        public string Name { get; private set; } = string.Empty; 
        public string? Sex { get; private set; }
        public string? Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PlaceOfBirth { get; private set; }
        public string? Nationality { get; private set; }
        public string CPF { get; private set; } = string.Empty;

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(Name));

            Name = name;
        }

        private void SetEmail(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                // TODO: Implementar uma validação de email mais robusta pois atualmente o email: .@..com é considerado válido
                string mailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(email, mailRegex))
                    throw new ArgumentException("Email format is invalid.", nameof(Email));
            }

            Email = email;
        }

        private void SetBirthDate(DateTime birthDate)
        {
            if (birthDate == default)
                throw new ArgumentException("BirthDate is required and must be a valid date.", nameof(BirthDate));
            else
            {
                DateTime upperLimit = DateTime.Now;
                DateTime lowerLimit = DateTime.Now.AddYears(-120);

                if (birthDate < lowerLimit || birthDate > upperLimit)
                    throw new ArgumentException("BirthDate is a invalid date.", nameof(BirthDate));
            }

            BirthDate = birthDate;
        }

        private void SetCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF is required.", nameof(CPF));
            else
            {
                // TODO: Realizar limpeza do CPF removendo caracteres não numéricos
                // TODO: Implementar uma validação de CPF mais robusta calcular os digitos verificadores
                string cpfRegex = @"^\d{11}$";

                if (!Regex.IsMatch(cpf, cpfRegex))
                    throw new ArgumentException("CPF format is invalid.", nameof(CPF));
            }

            CPF = cpf;
        }
    }
}
