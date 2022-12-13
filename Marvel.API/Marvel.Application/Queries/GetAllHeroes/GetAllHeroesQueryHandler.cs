using MediatR;
using Marvel.Application.ViewModels;
using Marvel.Domain.Repositories;
using Marvel.Domain.Result;

namespace Marvel.Application.Queries.GetAllHeroes
{
    public class GetAllHeroesQueryHandler : IRequestHandler<GetAllHeroesQuery, PaginationResult<HeroViewModel>>
    {
        private readonly IHeroRepository _heroRepository;
        public GetAllHeroesQueryHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        public async Task<PaginationResult<HeroViewModel>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
        {
            var heroPaginationResult = await _heroRepository.GetAllAsync(request.Query, request.Page);

            var heroViewModel = heroPaginationResult
            .Data
            .Select(p => new HeroViewModel(p.Id, p.Name, p.AttackPower, p.DefensePower, p.HP,
                                                  p.Affiliation))
            .ToList();

            var paginationResult = new PaginationResult<HeroViewModel>(
               heroPaginationResult.Page,
               heroPaginationResult.TotalPages,
               heroPaginationResult.PageSize,
               heroPaginationResult.ItemsCount,
               heroViewModel
            );

            return paginationResult;
        }
    }
}
