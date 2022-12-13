using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel.Application.Commands.Create;
using Marvel.Application.Mapper;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.UnitTests.Application.Commands
{
    public class CreateHeroCommandHandlerTests
    {
        readonly IMapper mapper;
        public CreateHeroCommandHandlerTests()
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
        public async Task CreateHero_WithValidInput_ShouldReturnCreated()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();

            var heroCommand = new CreateHeroCommand
            {                
                Name = "Super Choque",
                HP = 500,
                AttackPower = 100,
                DefensePower = 100,
                Affiliation = true
            };

            var handler = new CreateHeroCommandHandler(heroRepository.Object, mapper);

            //Act
            await handler.Handle(heroCommand, new CancellationToken());

            //Assert
            heroRepository.Verify(ar => ar.CreateHero(It.IsAny<Hero>()), Times.Once());
          

        }

        [Fact]
        public async Task CreateHero_WithInvalidInput_ShouldReturnIdZero()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();
            var heroCommand = new CreateHeroCommand
            {
                Name = "",
                HP = 501,
                AttackPower = 250,
                DefensePower = 100,
                Affiliation = false
            };

            var handler = new CreateHeroCommandHandler(heroRepository.Object, mapper);

            //Act
            var id = await handler.Handle(heroCommand, new CancellationToken());

            //Assert
            heroRepository.Verify(ar => ar.CreateHero(It.IsAny<Hero>()), Times.Once());
            Assert.Equal(0, id);

        }
    }
}
