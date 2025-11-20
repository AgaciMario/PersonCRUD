using PersonCRUD.Domain.Entities;
using PersonCRUD.Infra.Context;

namespace PersonCRUD.Infra.Seed;

public static class DbSeed
{
    public static void Initialize(PersonDbContext db)
    {
        if (db.Person.Any()) return;

        db.Person.AddRange(new List<Person>
        {
            new Person("João Alberto", "Male", "joao_alberto@gmail.com", new DateTime(2000, 3, 6), "Sobral-CE", "Brasileiro", "12312311234"),
            new Person("Maria Fernanda", "Female", "maria.fernanda@example.com", new DateTime(1998, 7, 22), "Fortaleza-CE", "Brasileira", "32165498700"),
            new Person("Carlos Henrique", "Male", "carlos.henrique@example.com", new DateTime(1995, 11, 15), "São Paulo-SP", "Brasileiro", "11122233344"),
            new Person("Ana Beatriz", "Female", "ana.beatriz@example.com", new DateTime(2001, 2, 5), "Rio de Janeiro-RJ", "Brasileira", "55566677788"),
            new Person("Lucas Silva", "Male", "lucas.silva@example.com", new DateTime(1992, 9, 12), "Belo Horizonte-MG", "Brasileiro", "98765432100"),
            new Person("Juliana Costa", "Female", "juliana.costa@example.com", new DateTime(1997, 6, 18), "Recife-PE", "Brasileira", "65498732111"),
            new Person("Felipe Andrade", "Male", "felipe.andrade@example.com", new DateTime(1989, 4, 3), "Curitiba-PR", "Brasileiro", "11223344556"),
            new Person("Camila Rocha", "Female", "camila.rocha@example.com", new DateTime(1994, 1, 9), "Salvador-BA", "Brasileira", "22334455667"),
            new Person("Rafael Martins", "Male", "rafael.martins@example.com", new DateTime(1990, 8, 21), "Porto Alegre-RS", "Brasileiro", "33445566778"),
            new Person("Beatriz Almeida", "Female", "beatriz.almeida@example.com", new DateTime(2002, 12, 11), "Natal-RN", "Brasileira", "44556677889"),
            new Person("Rodrigo Pires", "Male", "rodrigo.pires@example.com", new DateTime(1985, 10, 25), "Campinas-SP", "Brasileiro", "55667788990"),
            new Person("Larissa Mendes", "Female", "larissa.mendes@example.com", new DateTime(1999, 5, 30), "João Pessoa-PB", "Brasileira", "66778899001"),
            new Person("Thiago Barbosa", "Male", "thiago.barbosa@example.com", new DateTime(1993, 7, 14), "Florianópolis-SC", "Brasileiro", "77889900112"),
            new Person("Patrícia Oliveira", "Female", "patricia.oliveira@example.com", new DateTime(1996, 11, 7), "Goiânia-GO", "Brasileira", "88990011223"),
            new Person("Eduardo Lima", "Male", "eduardo.lima@example.com", new DateTime(1991, 3, 19), "Manaus-AM", "Brasileiro", "99001122334"),
            new Person("Sofia Duarte", "Female", "sofia.duarte@example.com", new DateTime(2000, 9, 27), "Belém-PA", "Brasileira", "10111213141"),
            new Person("Gustavo Nunes", "Male", "gustavo.nunes@example.com", new DateTime(1998, 2, 16), "Vitória-ES", "Brasileiro", "12131415161"),
            new Person("Isabela Freitas", "Female", "isabela.freitas@example.com", new DateTime(1995, 6, 6), "Maceió-AL", "Brasileira", "14151617181"),
            new Person("Marcelo Torres", "Male", "marcelo.torres@example.com", new DateTime(1988, 1, 28), "Aracaju-SE", "Brasileiro", "16171819201"),
            new Person("Carolina Pinto", "Female", "carolina.pinto@example.com", new DateTime(1997, 8, 8), "Campo Grande-MS", "Brasileira", "18192021212"),
            new Person("André Gomes", "Male", "andre.gomes@example.com", new DateTime(1994, 4, 12), "São Luís-MA", "Brasileiro", "20212223232"),
            new Person("Fernanda Souza", "Female", "fernanda.souza@example.com", new DateTime(2001, 11, 2), "Teresina-PI", "Brasileira", "21222324242")
        });

        db.User.AddRange(new List<User>
        {
            new User(1, "admin", "admin@email.com", "admin", "admin"),
            new User(2, "default", "default@email.com", "default")
        });

        db.SaveChanges();
    }
}
