using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonByIdQuery;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Exceptions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Querys.GetPersonByIdQueryUnitTests
{
    public class GetPersonByIdHandlerUnitTest
    {
        private readonly IPersonRepository personRepository;

        public GetPersonByIdHandlerUnitTest() =>
            personRepository = ServiceLocator.Instance.GetService<IPersonRepository>();

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