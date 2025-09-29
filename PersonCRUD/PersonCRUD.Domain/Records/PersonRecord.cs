namespace PersonCRUD.Domain.Records
{
    public record PersonRecord(string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf);
}
