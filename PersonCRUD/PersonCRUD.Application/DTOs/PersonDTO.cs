namespace PersonCRUD.Application.DTOs
{
    // TODO: Explorar a ideia de tornar este DTO não modificavel, assim protegendo os dados internos de uma possível alteração.
    public class PersonDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
