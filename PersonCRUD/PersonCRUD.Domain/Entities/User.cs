using PersonCRUD.Domain.Enum;

namespace PersonCRUD.Domain.Entities
{
    public class User
    {
        protected User() { }

        public User(long? id, string name, string email, string password, string salt, UserRoles role = UserRoles.Default)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Salt = salt;
        }

        // Inicilizando string como Empty por conta do protected constructor
        public long? Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Salt { get; private set; } = string.Empty;
        public UserRoles Role { get; private set; } = UserRoles.Default;
        public DateTime? DeletedAt { get; private set; }
    }
}
