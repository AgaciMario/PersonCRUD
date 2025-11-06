using MediatR;

namespace PersonCRUD.Application.Commands.DeletePersonCommand
{
    public class DeletePersonCommand : IRequest
    {
        public DeletePersonCommand(long id)
        {
            if (id <= 0) throw new ArgumentException("Id must be greater than zero.", nameof(Id));
            Id = id;
        }

        public long Id { get; }
    }
}
