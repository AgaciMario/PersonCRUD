namespace PersonCRUD.Domain.Records
{
    public record CreatePersonRecord(string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf);
    public record UpdatePersonRecord(long id, string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf);
}
