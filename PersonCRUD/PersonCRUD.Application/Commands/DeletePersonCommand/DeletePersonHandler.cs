using MediatR;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Entities;
using PersonCRUD.Domain.Exceptions;

namespace PersonCRUD.Application.Commands.DeletePersonCommand
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository PersonRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Person person = await PersonRepository.GetPersonById(request.Id, cancellationToken)
                    ?? throw new NotFoundException("A person with the given id was not found.");

                person.SetAsDeleted();
                await PersonRepository.DeletePerson(person, cancellationToken);
            }
            catch (Exception)
			{
				throw;
			}
        }
    }
}
