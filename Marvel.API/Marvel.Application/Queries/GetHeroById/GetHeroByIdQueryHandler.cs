using AutoMapper;
using MediatR;
using Marvel.Application.ViewModels;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Queries.GetHeroById
{
    public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, HeroViewModel>
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;

        public GetHeroByIdQueryHandler(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }
        public async Task<HeroViewModel> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _heroRepository.GetHeroByIdAsync(request.Id);
            if (entity is null) return null;

            var viewModel = _mapper.Map<HeroViewModel>(entity);
            return viewModel;
        }
    }
}
