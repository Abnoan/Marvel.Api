using MediatR;

namespace Marvel.Application.Commands.Delete
{
    public class DeleteHeroCommand : IRequest<Unit>
    {
        public DeleteHeroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
