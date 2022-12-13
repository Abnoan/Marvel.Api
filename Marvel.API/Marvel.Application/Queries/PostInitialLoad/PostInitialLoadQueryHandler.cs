using MediatR;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Queries.PostInitialLoad
{
    public class PostInitialLoadQueryHandler : IRequestHandler<PostInitialLoadQuery, Unit>
    {
        private readonly IHeroRepository _heroRepository;
        public PostInitialLoadQueryHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        public async Task<Unit> Handle(PostInitialLoadQuery request, CancellationToken cancellationToken)
        {
            var heroes = GetListHeroes();
            await _heroRepository.InsertBulk(heroes);

            return Unit.Value;
           
        }
        #region GetListHeroes       
        private List<Hero> GetListHeroes()
        {
            var Heroes = new List<Hero>()
            {
                //Against the Registry
                new Hero()
                {
                    Name = "Capitão América",
                    AttackPower = 83,
                    DefensePower = 88,
                    HP = 500,
                    Affiliation = false
                },
                 new Hero()
                {
                    Name = "Soldado Invernal",
                    AttackPower = 75,
                    DefensePower = 100,
                    HP = 500,
                    Affiliation = false
                },
                  new Hero()
                {
                    Name = "Gavião Arqueiro",
                    AttackPower = 88,
                    DefensePower = 77,
                    HP = 500,
                    Affiliation = false
                },
                   new Hero()
                {
                    Name = "Feiticeira Escarlate",
                    AttackPower = 93,
                    DefensePower = 77,
                    HP = 500,
                    Affiliation = false
                },
                    new Hero()
                {
                    Name = "Falcão",
                    AttackPower = 80,
                    DefensePower = 82,
                    HP = 500,
                    Affiliation = false
                },
                     new Hero()
                {
                    Name = "Hulk",
                    AttackPower = 100,
                    DefensePower = 70,
                    HP = 500,
                    Affiliation = false
                },

                //In Favor of the Registry

               new Hero()
                {
                    Name = "Homem de Ferro",
                    AttackPower = 75,
                    DefensePower = 100,
                    HP = 500,
                    Affiliation = true
                },
                 new Hero()
                {
                    Name = "Pantera Negra",
                    AttackPower = 86,
                    DefensePower = 93,
                    HP = 500,
                    Affiliation = true
                },
                   new Hero()
                {
                    Name = "Viúva Negra",
                    AttackPower = 88,
                    DefensePower = 77,
                    HP = 500,
                    Affiliation = true
                },
                   new Hero()
                {
                    Name = "Visão",
                    AttackPower = 100,
                    DefensePower = 70,
                    HP = 500,
                    Affiliation = true
                },
                     new Hero()
                {
                    Name = "Máquina de Combate",
                    AttackPower = 75,
                    DefensePower = 100,
                    HP = 500,
                    Affiliation = true
                },
                       new Hero()
                {
                    Name = "Homem-Aranha",
                    AttackPower = 80,
                    DefensePower = 82,
                    HP = 500,
                    Affiliation = true
                }
            };

         return Heroes;
        }

        #endregion
    }
}
