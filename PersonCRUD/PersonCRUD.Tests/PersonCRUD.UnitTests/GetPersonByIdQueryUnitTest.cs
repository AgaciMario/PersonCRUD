using PersonCRUD.Application.Querys.GetPersonByIdQuery;

namespace PersonCRUD.UnitTests
{
    public class GetPersonByIdQueryUnitTest
    {
        [Theory] // Testes que são verdadeiros somente para um grupo especifico de dados.
        [InlineData(-1)] // Cada um dos data annotation InlineData será um caso de teste da teoria.
        [InlineData(0)]
        public void AceptingOnlyNumberGreaterThanZero(int x)
        {
            // Acting and Asserting - realizando operação sobre os dados inicalizados e validando-os:
            var exception = Assert.Throws<ArgumentException>(() => { GetPersonByIdQuery query = new(x); });
            Assert.Equal("Id must be greater than zero. (Parameter 'Id')", exception.Message);
        }
    }
}
