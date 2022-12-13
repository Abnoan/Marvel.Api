using MediatR;
using Marvel.Application.ViewModels;

namespace Marvel.Application.Queries.GetHeroById
{
    public class GetHeroByIdQuery : IRequest<HeroViewModel>
    {
        public GetHeroByIdQuery(int id)
        {
            Id = id;
        }     
        public int Id { get; private set; }
    }
}
