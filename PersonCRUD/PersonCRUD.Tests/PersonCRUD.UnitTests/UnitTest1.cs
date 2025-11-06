namespace PersonCRUD.UnitTests;

public class UnitTest1
{
    public static int Add(int x, int y) =>
        x + y;

    [Fact]
    public void Good() =>
        Assert.Equal(4, Add(2, 2));

    [Fact] // Testes que sempre são verdadeiros
    public void Bad() =>
        Assert.Equal(4, Add(2, 2));

    [Theory] // Testes que são verdadeiros somente para um grupo especifico de dados.
    [InlineData(3)] // Cada um dos data annotation InlineData será um caso de teste da teoria.
    [InlineData(5)]
    [InlineData(7)]
    public void MyFirstTheory(int x)
    {
        Assert.True(isOdd(x));
    }

    bool isOdd(int x) => x % 2 == 1; 
}
