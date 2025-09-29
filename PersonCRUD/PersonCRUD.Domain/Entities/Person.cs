namespace PersonCRUD.Domain.Entities
{
    public class Person
    {
        protected Person() { }

        public Person(string name, string sex, string email, DateTime birthDate, string placeOfBirth, string nationality, string cpf)
        {
            Name = name;
            Sex = sex;
            Email = email;
            BirthDate = birthDate;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            SetCPF(cpf);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public long? Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Sex { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public string PlaceOfBirth { get; private set; } = string.Empty;
        public string Nationality { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private void SetCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            CPF = cpf;
        }
    }
}