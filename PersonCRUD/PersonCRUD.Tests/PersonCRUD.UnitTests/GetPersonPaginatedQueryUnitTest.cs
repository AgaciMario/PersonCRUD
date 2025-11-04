using PersonCRUD.Application.Querys.GetPersonPaginatedQuery;

namespace PersonCRUD.UnitTests
{
    public class GetPersonPaginatedQueryUnitTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CurrentPageLessThenOneShouldThrowException(int currentPage)
        {
            var exception = Assert.Throws<ArgumentException>(() => { GetPersonPaginatedQuery query = new(currentPage, 10, null); });
            Assert.Equal("CurrentPage must be greater than zero. (Parameter 'CurrentPage')", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void PageSizeLessThenOneShouldThrowException(int pageSize)
        {
            var exception = Assert.Throws<ArgumentException>(() => { GetPersonPaginatedQuery query = new(1, pageSize, null); });
            Assert.Equal("PageSize must be greater than zero. (Parameter 'PageSize')", exception.Message);
        }

        [Fact]
        public void NameFilterShouldByOptional()
        {
            string personName = "José Alberto";
            GetPersonPaginatedQuery queryWithoutNameFilter = new GetPersonPaginatedQuery(1, 10);
            GetPersonPaginatedQuery queryWithNameFilter = new GetPersonPaginatedQuery(1, 10, personName);

            Assert.Null(queryWithoutNameFilter.NameFilter);
            Assert.True(queryWithNameFilter.NameFilter == personName);
        }
    }
}
