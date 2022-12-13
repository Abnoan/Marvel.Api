using MediatR;
using Marvel.Domain.Battle;
using Marvel.Domain.Result;

namespace Marvel.Application.Commands.Battle
{
    public class BattleCommand : IRequest<ResponseResult<List<Turn>>>
    {
        public int HeroInFavorId { get; set; }
        public int HeroAgainstId { get; set; }
    }
}
