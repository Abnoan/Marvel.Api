using MediatR;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Commands.Delete
{
    public class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand, Unit>
    {
        private readonly IHeroRepository _heroRepository;
        public DeleteHeroCommandHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        public async Task<Unit> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            await _heroRepository.DeleteHeroByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}
