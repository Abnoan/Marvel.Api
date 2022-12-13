using AutoMapper;
using Moq;
using Marvel.Application.Mapper;
using Marvel.Application.Queries.GetHeroById;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.UnitTests.Application.Queries
{
    public class GetHeroByIdQueryHandlerTests
    {
        readonly IMapper mapper;
        public GetHeroByIdQueryHandlerTests()
        {
            mapper = SetupMapper();
        }

        private static IMapper SetupMapper()
        {
            var profile = new HeroMapper();
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(mapConfig);
        }


        [Fact]
        public async Task GetHeroById_WithValidId_ShoudlReturnHero()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();
            var heroFake = new Hero
            {
                Name = "Super Choque",
                HP = 500,
                AttackPower = 100,
                DefensePower = 100,
                Affiliation = true,
                Id = 1
            };

            var query = new GetHeroByIdQuery(1);
            heroRepository.Setup(ar => ar.GetHeroByIdAsync(query.Id)).ReturnsAsync(heroFake);
            var handler = new GetHeroByIdQueryHandler(heroRepository.Object, mapper);

            //Act
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(heroFake.Name, result.Name);

            heroRepository.Verify(ar => ar.GetHeroByIdAsync(query.Id).Result, Times.Once);
        }

        [Fact]
        public async Task GetHeroById_WithInvalidId_ShoudlReturn404()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();
            var heroFake = new Hero
            {
                Name = "Super Choque",
                HP = 500,
                AttackPower = 100,
                DefensePower = 100,
                Affiliation = true,
                Id = 1
            };

            var query = new GetHeroByIdQuery(1);
            heroRepository.Setup(ar => ar.GetHeroByIdAsync(2)).ReturnsAsync(heroFake);
            var handler = new GetHeroByIdQueryHandler(heroRepository.Object, mapper);

            //Act
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.Null(result);
        }
    }
}
