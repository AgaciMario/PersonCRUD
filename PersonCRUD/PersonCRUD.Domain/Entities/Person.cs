namespace PersonCRUD.Domain.Entities
{
    public class Person
    {
        //TODO: Isolar os campos id, updatedate e craetedate em uma classe base
        protected Person() { }

        public Person(string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf)
        {
            Name = name;
            Sex = sex;
            Email = email;
            BirthDate = birthDate;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            CPF = cpf;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public long? Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Sex { get; private set; }
        public string? Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PlaceOfBirth { get; private set; }
        public string? Nationality { get; private set; }
        public string CPF { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public void Update(string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf)
        {
            Name = name;
            Sex = sex;
            Email = email;
            BirthDate = birthDate;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            CPF = cpf;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetAsDeleted()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}