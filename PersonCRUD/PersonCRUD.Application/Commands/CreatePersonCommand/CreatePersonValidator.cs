using System.Text.RegularExpressions;

namespace PersonCRUD.Application.Commands.CreatePersonCommand
{
    public class CreatePersonValidator
    {
        public static void Validate(CreatePersonCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (!string.IsNullOrWhiteSpace(command.Email))
            {
                // TODO: Implementar uma validação de email mais robusta pois atualmente o email: .@..com é considerado válido
                string mailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(command.Email, mailRegex))
                {
                    throw new ArgumentException("Email format is invalid.");
                }
            }

            if (command.BirthDate == default)
            {
                throw new ArgumentException("BirthDate is required and must be a valid date.");
            }
            else
            {
                DateTime upperLimit = DateTime.Now.AddYears(120);
                DateTime lowerLimit = DateTime.Now.AddYears(-120);

                if(command.BirthDate < lowerLimit || command.BirthDate > upperLimit)
                {
                   throw new ArgumentException("BirthDate is a invalid date.");
                }
            }

            if (string.IsNullOrWhiteSpace(command.CPF))
            {
                throw new ArgumentException("CPF is required.");
            }
            else
            {
                // TODO: Realizar limpeza do CPF removendo caracteres não numéricos
                // TODO: Implementar uma validação de CPF mais robusta calcular os digitos verificadores
                string cpfRegex = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$|^\d{11}$";

                if (!Regex.IsMatch(command.CPF, cpfRegex))
                {
                    throw new ArgumentException("CPF format is invalid.");
                }
            }
        }
    }
}
