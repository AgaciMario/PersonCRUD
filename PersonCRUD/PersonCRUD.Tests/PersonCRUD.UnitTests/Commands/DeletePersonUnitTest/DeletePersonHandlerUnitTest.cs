using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Application.Commands.DeletePersonCommand;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Exceptions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Commands.DeletePersonUnitTest
{
    public sealed class DeletePersonHandlerUnitTest : IDisposable
    {
        private readonly IPersonRepository personRepository;
        private readonly IServiceScope scope;

        public DeletePersonHandlerUnitTest()
        {
            scope = ServiceLocator.Instance.CreateScope();
            personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();
        }

        [Fact]
        public async Task IdRegisteredDeletePerson()
        {
            long id = 2; // TODO: realizar a criação da pessoa, ao invés de confiar numa seed de banco de dados.
            DeletePersonCommand command = new(id);
            DeletePersonHandler handler = new(personRepository);

            var ex = await Record.ExceptionAsync(async () => await handler.Handle(command, TestContext.Current.CancellationToken));

            Assert.Null(ex);
        }

        [Fact]
        public async Task IdNotRegisteredThrowException()
        {
            long id = long.MaxValue;
            DeletePersonCommand command = new(id);
            DeletePersonHandler handler = new(personRepository);

            var ex = await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, TestContext.Current.CancellationToken));

            Assert.Equal("A person with the given id was not found.", ex.Message);
        }

        public void Dispose() => scope.Dispose();
    }
}
