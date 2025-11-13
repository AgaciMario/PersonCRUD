using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonPaginatedQuery;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Querys.GetPersonPaginatedUnitTests
{
    public sealed class GetPersonPaginatedHandlerUnitTest : IDisposable
    {
        private readonly IPersonRepository personRepository;
        private readonly IServiceScope scope;

        public GetPersonPaginatedHandlerUnitTest()
        {
            scope = ServiceLocator.Instance.CreateScope();
            personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();
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

        public void Dispose() => scope.Dispose();
    }
}