using AutoMapper;
using MediatR;
using Marvel.Application.ViewModels;
using Marvel.Domain.Battle;
using Marvel.Domain.Repositories;
using Marvel.Domain.Result;

namespace Marvel.Application.Commands.Battle
{
    public class BattleCommandHandler : IRequestHandler<BattleCommand, ResponseResult<List<Turn>>>
    {    
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;

        private readonly List<Turn> log = new();
        private readonly ResponseResult<List<Turn>> response = new();
        public BattleCommandHandler(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }
        public async Task<ResponseResult<List<Turn>>> Handle(BattleCommand request, CancellationToken cancellationToken)
        {
           
            var hero1 = _mapper.Map<HeroViewModel>(await _heroRepository.GetHeroByIdAsync(request.HeroInFavorId));
            var hero2 = _mapper.Map<HeroViewModel>(await _heroRepository.GetHeroByIdAsync(request.HeroAgainstId));

            if (CheckIfHeroesIsOnSameSide(hero1, hero2))
            {
                return response;
            }           

            while (hero1.HP > 0 && hero2.HP > 0)
            {
                Battle(hero1, hero2);
                Battle(hero2, hero1);
            }
            response.Data = log;

            return response;
        }

        private bool CheckIfHeroesIsOnSameSide(HeroViewModel attacker, HeroViewModel Deffender)
        {
            if (attacker.Affiliation == Deffender.Affiliation)
            {
                response.InternalCode = Domain.Enums.InternalCode.HeroSameSide;
                return true;
            }
            return false;
        }

        private int RollDice(int power)
        {
            Random rnd = new();
            return rnd.Next(0, power);
        }

        private void Battle(HeroViewModel attacker, HeroViewModel Deffender) 
        {            
            var diceAttacker = RollDice(attacker.AttackPower);
            var diceDeffender = RollDice(Deffender.DefensePower);
            var damageDealt = diceAttacker - diceDeffender;

            if (damageDealt >= 0)
            {
                Deffender.HP -= damageDealt;
            }
            
            LogTurn(attacker, Deffender, diceAttacker, diceDeffender, damageDealt);
        }

        private void LogTurn(HeroViewModel attacker, HeroViewModel deffender, int diceAttacker, int diceDeffender, int damageDealt)
        { 
            var turn = new Turn()
            {
                Attacker = _mapper.Map<Attacker>(attacker),
                Defender = _mapper.Map<Defender>(deffender),
                DiceAttackPower = diceAttacker,
                DiceDefensePower = diceDeffender,
                DamageDealed = damageDealt <= 0 ? 0 : damageDealt
            };

            log.Add(turn);
        }
    }
}
