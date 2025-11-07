using Microsoft.EntityFrameworkCore;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonPaginatedQuery;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Infra.Seed;

namespace PersonCRUD.UnitTests.Querys.GetPersonPaginatedUnitTests
{
    public class GetPersonPaginatedHandlerUnitTest
    {
        // TODO: realizar teste unitários utilizando o banco de dados inmemory não é recomendado pela documentação do EF
        // uma alternativa um pouco melhor é utilizar o sqlLite inmemory mode, que ainda sim não é ideal mais e melhor que
        // usar o in memory do EF puro, sem o provider. O recomendado e usar o respository pattern e fazer as consultas sobre o IEnumerable.
        private static DbContextOptions<PersonDbContext> dbOptions =
            new DbContextOptionsBuilder<PersonDbContext>()
            .UseInMemoryDatabase(databaseName: "testeDatabase").Options;

        PersonDbContext context;
        IPersonRepository personRepository;

        public GetPersonPaginatedHandlerUnitTest()
        {
            // TODO: buscar uma forma de adicionar isso com injeção de dependência.
            context = new PersonDbContext(dbOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            DbSeed.Initialize(context);
            personRepository = new PersonRepository(context);
        }

        [Fact]
        public async Task PageSizeItsNeverLessThenDataCount()
        {
            int currentPage = 1, pageSize = 10;
            GetPersonPaginatedQuery query = new GetPersonPaginatedQuery(currentPage, pageSize);
            GetPersonPaginatedHandler handler = new GetPersonPaginatedHandler(personRepository);

            GetPersonPaginatedDTO result = await handler.Handle(query, TestContext.Current.CancellationToken);

            Assert.True(pageSize >= result.Data.Count);
        }

        [Fact]
        public async Task NameFilterUsedThenEachDataResultContainsNameFilter()
        {
            int currentPage = 1, pageSize = 10;
            string nameFilter = "a";
            GetPersonPaginatedQuery query = new GetPersonPaginatedQuery(currentPage, pageSize, nameFilter);
            GetPersonPaginatedHandler handler = new GetPersonPaginatedHandler(personRepository);

            GetPersonPaginatedDTO result = await handler.Handle(query, TestContext.Current.CancellationToken);

            Assert.DoesNotContain(result.Data, (item) => { return !item.Name.Contains(nameFilter); });
        }
    }
}