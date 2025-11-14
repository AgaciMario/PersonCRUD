using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Commands.CreatePersonUnitTest
{
    public sealed class CreatePersonHandlerUnitTest : IDisposable
    {
        private readonly IServiceScope scope;

        private readonly IPersonService personService;
        private readonly IPersonRepository personRepository;

        public CreatePersonHandlerUnitTest()
        {
            scope = ServiceLocator.Instance.CreateScope();
            personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();
            personService = scope.ServiceProvider.GetRequiredService<IPersonService>();
        }

        [Fact]
        public async Task CreatePersonCommandValidReturnCreatedDBRegister()
        {
            CreatePersonCommand command = new(
                name: "João Nobrega",
                sex: "Male",
                email: "joao_n@gmail.com",
                birthDate: new DateTime(2000, 3, 6),
                placeOfBirth: "Campo Grande-RG",
                nationality: "Brasileiro",
                cpf: "12312654321"
            );

            CreatePersonHandler handler = new(personService, personRepository);

            PersonDTO response = await handler.Handle(command, TestContext.Current.CancellationToken);

            Assert.NotNull(response);
            Assert.True(response.Id != default && response.Id != 0);

            Assert.True(response.Name == command.Name);
            Assert.True(response.Sex == command.Sex);
            Assert.True(response.Email == command.Email);
            Assert.True(response.BirthDate == command.BirthDate);
            Assert.True(response.PlaceOfBirth == command.PlaceOfBirth);
            Assert.True(response.Nationality == command.Nationality);
            Assert.True(response.CPF == command.CPF);
        }

        [Fact]
        public async Task CreatePersonCommandAlreadyRegisteredCPFThrowsException()
        {
            CreatePersonCommand command = new(
                name: "João Nobrega",
                sex: "Male",
                email: "joao_n@gmail.com",
                birthDate: new DateTime(2000, 3, 6),
                placeOfBirth: "Campo Grande-RG",
                nationality: "Brasileiro",
                cpf: "12312654321"
            );
            CreatePersonHandler handler = new(personService, personRepository);
            PersonDTO response = await handler.Handle(command, TestContext.Current.CancellationToken);
            Assert.NotNull(response);   

            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(async () => {
                await handler.Handle(command, TestContext.Current.CancellationToken); 
            });

            Assert.Equal("A Person with this CPF is already registered.", ex.Message);
        } 

        public void Dispose() => scope.Dispose();
    }
}
