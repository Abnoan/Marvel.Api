using AutoMapper;
using MediatR;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Commands.Create
{
    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, int>
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;

        public CreateHeroCommandHandler(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = _mapper.Map<Hero>(request);
            await _heroRepository.CreateHero(hero);
            return hero.Id;
        }
    }
}
