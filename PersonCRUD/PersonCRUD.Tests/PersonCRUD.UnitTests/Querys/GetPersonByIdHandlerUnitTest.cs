using Microsoft.EntityFrameworkCore;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonByIdQuery;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Exceptions;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Infra.Seed;

namespace PersonCRUD.UnitTests.Querys
{
    public class GetPersonByIdHandlerUnitTest
    {
        // TODO: realizar teste unitários utilizando o banco de dados inmemory não é recomendado pela documentação do EF
        // uma alternativa um pouco melhor é utilizar o sqlLite inmemory mode, que ainda sim não é ideal mais e melhor que
        // usar o in memory do EF puro, sem o provider. O recomendado e usar o respository pattern e fazer as consultas sobre o IEnumerable.
        private static DbContextOptions<PersonDbContext> dbOptions =
            new DbContextOptionsBuilder<PersonDbContext>()
            .UseInMemoryDatabase(databaseName: "testeDatabase").Options;

        PersonDbContext context;
        IPersonRepository personRepository;

        public GetPersonByIdHandlerUnitTest()
        {
            // TODO: buscar uma forma de adicionar isso com injeção de dependência.
            context = new PersonDbContext(dbOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            DbSeed.Initialize(context);
            personRepository = new PersonRepository(context);
        }

        [Fact]
        public async Task IdNonExistingInDatabaseThrowNotFoundException()
        {
            long id = long.MaxValue;
            GetPersonByIdQuery query = new GetPersonByIdQuery(id);
            GetPersonByIdHandler handler = new GetPersonByIdHandler(personRepository);

            await Assert.ThrowsAsync<NotFoundException>(async () => { await handler.Handle(query, TestContext.Current.CancellationToken); });
        }

        [Fact]
        public async Task IdExistingInDatabaseReturnPersonWithTheId()
        {
            long id = 1;
            GetPersonByIdQuery query = new GetPersonByIdQuery(id);
            GetPersonByIdHandler handler = new GetPersonByIdHandler(personRepository);

            PersonDTO person = await handler.Handle(query, TestContext.Current.CancellationToken);

            Assert.Equal(id, person.Id);
        }
    }
}