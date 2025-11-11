using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonPaginatedQuery;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Querys.GetPersonPaginatedUnitTests
{
    public class GetPersonPaginatedHandlerUnitTest
    {
        private readonly IPersonRepository personRepository;

        public GetPersonPaginatedHandlerUnitTest() =>
            personRepository = ServiceLocator.Instance.GetService<IPersonRepository>();

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