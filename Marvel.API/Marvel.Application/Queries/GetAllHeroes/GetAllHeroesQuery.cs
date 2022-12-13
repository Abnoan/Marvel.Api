using MediatR;
using Marvel.Application.ViewModels;
using Marvel.Domain.Result;

namespace Marvel.Application.Queries.GetAllHeroes
{
    public class GetAllHeroesQuery : IRequest<PaginationResult<HeroViewModel>>
    {
        public string? Query { get; set; }
        public int Page { get; set; } = 1;
    }
}
