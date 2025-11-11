using Microsoft.EntityFrameworkCore;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Infra.Seed;

namespace PersonCRUD.UnitTests.ServiceLocator
{
    public class ServiceLocator
    {
        private readonly DbContextOptions<PersonDbContext> dbOptions;
        private readonly PersonDbContext Context;
        private readonly IPersonRepository PersonRepository;

        private static ServiceLocator? instance;

        private ServiceLocator()
        {
            try
            {
                // TODO: realizar teste unitários utilizando o banco de dados inmemory não é recomendado pela documentação do EF
                // uma alternativa um pouco melhor é utilizar o sqlLite inmemory mode, que ainda sim não é ideal mais e melhor que
                // usar o in memory do EF puro sem o provider. O recomendado e usar o respository pattern e fazer as consultas sobre o IEnumerable.
                dbOptions = new DbContextOptionsBuilder<PersonDbContext>()
                    .UseInMemoryDatabase(databaseName: "testeDatabase").Options;

                Context = new PersonDbContext(dbOptions);

                // Garantindo que tenhamos sempre um banco de dados limpos para realização do testes:
                Context.Database.EnsureDeleted();
                Context.Database.EnsureCreated();
                DbSeed.Initialize(Context);

                PersonRepository = new PersonRepository(Context);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ServiceLocator GetInstance() =>
            instance ??= new ServiceLocator();

        public IPersonRepository GetPersonRepository() =>
            PersonRepository;
    }
}
