using PersonCRUD.Application.Querys.GetPersonByIdQuery;

namespace PersonCRUD.UnitTests.Querys
{
    public class GetPersonByIdQueryUnitTest
    {
        [Theory] 
        [InlineData(-1)]
        [InlineData(0)]
        public void IdLessThenOneShouldThrowException(int id)
        {
            var exception = Assert.Throws<ArgumentException>(() => { GetPersonByIdQuery query = new(id); });
            Assert.Equal("Id must be greater than zero. (Parameter 'Id')", exception.Message);
        }
    }
}
