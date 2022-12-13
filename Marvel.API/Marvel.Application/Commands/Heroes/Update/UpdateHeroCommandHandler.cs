using MediatR;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Commands.Update
{
    public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand, Unit>
    {
        private readonly IHeroRepository _heroRepository;
        public UpdateHeroCommandHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<Unit> Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(request.Id);           
            hero.Update(request.Name, request.AttackPower, request.DefensePower, request.HP, request.Affiliation);
            await _heroRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
