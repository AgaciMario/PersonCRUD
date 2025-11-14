using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Application.Commands.UpdatePersonCommand;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Exceptions;
using PersonCRUD.UnitTests.Services;

namespace PersonCRUD.UnitTests.Commands.UpdatePersonUnitTest
{
    public class UpdatePersonHandlerUnitTest : IDisposable
    {
        private readonly IServiceScope scope;
        private readonly IPersonService personService;
        private readonly IPersonRepository personRepository;

        public UpdatePersonHandlerUnitTest()
        {
            scope = ServiceLocator.Instance.CreateScope();
            personService = scope.ServiceProvider.GetRequiredService<IPersonService>();
            personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();
        }

        [Fact]
        public async Task IdAndPersonInfoValidUpdateRegister()
        {
            UpdatePersonCommand command = new(
                id: 2,
                name: "João Nobrega",
                sex: "Male",
                email: "joao_n@gmail.com",
                birthDate: new DateTime(2000, 3, 6),
                placeOfBirth: "Campo Grande-RG",
                nationality: "Brasileiro",
                cpf: "12312654321"
            );
            UpdatePersonHandler handler = new(personService, personRepository);

            PersonDTO response = await handler.Handle(command, TestContext.Current.CancellationToken);

            Assert.True(response.Id != default && response.Id != 0);

            Assert.True(command.Id == response.Id);
            Assert.True(command.Name == response.Name);
            Assert.True(command.Sex == response.Sex);
            Assert.True(command.Email == response.Email);
            Assert.True(command.BirthDate == response.BirthDate);
            Assert.True(command.PlaceOfBirth == response.PlaceOfBirth);
            Assert.True(command.Nationality == response.Nationality);
            Assert.True(command.CPF == response.CPF);
        }

        [Fact]
        public async Task IdInvalidThrowException()
        {
            UpdatePersonCommand command = new(
                id: long.MaxValue,
                name: "João Nobrega",
                sex: "Male",
                email: "joao_n@gmail.com",
                birthDate: new DateTime(2000, 3, 6),
                placeOfBirth: "Campo Grande-RG",
                nationality: "Brasileiro",
                cpf: "12312654321"
            );
            UpdatePersonHandler handler = new(personService, personRepository);

            NotFoundException ex = await Assert.ThrowsAsync<NotFoundException>(async () => { 
                await handler.Handle(command, TestContext.Current.CancellationToken); 
            });

            Assert.Equal("A person with the given id was not found", ex.Message);
        }

        public void Dispose() => scope.Dispose();
    }
}
