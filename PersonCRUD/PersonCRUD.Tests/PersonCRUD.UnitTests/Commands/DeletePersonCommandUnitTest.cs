using PersonCRUD.Application.Commands.DeletePersonCommand;

namespace PersonCRUD.UnitTests.Commands
{
    public class DeletePersonCommandUnitTest
    {
        [Theory]
        [InlineData(-3)]
        [InlineData(-2)]
        [InlineData(-1.0)]
        [InlineData(default(long))]
        public void IdLessThenOneShouldThrowException(long id)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                DeletePersonCommand command = new(id);
            });

            Assert.Equal("Id must be greater than zero. (Parameter 'Id')", ex.Message);
        }
    }
}
