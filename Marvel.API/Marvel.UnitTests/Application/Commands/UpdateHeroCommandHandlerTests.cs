using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel.Application.Commands.Update;
using Marvel.Application.Mapper;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.UnitTests.Application.Commands
{
    public class UpdateHeroCommandHandlerTests
    {
        readonly IMapper mapper;
        public UpdateHeroCommandHandlerTests()
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
        public async Task UpdateHero_WithValidInput_ShouldReturnValueUpdated()
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

            var updateHeroCommand = new UpdateHeroCommand()
            {
                Id = 1,
                Name = "Not SpiderMan"
            };

            heroRepository.Setup(ar => ar.GetHeroByIdAsync(It.IsAny<int>()).Result).Returns(heroFake);
            var updateHandler = new UpdateHeroCommandHandler(heroRepository.Object);

            //Act

            await updateHandler.Handle(updateHeroCommand, new CancellationToken());
            var heroUpdated = await heroRepository.Object.GetHeroByIdAsync(updateHeroCommand.Id);

            //Assert
            heroRepository.Verify(ar => ar.GetHeroByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            Assert.Equal(updateHeroCommand.Name, heroUpdated.Name);
        }

        [Fact]
        public async Task UpdateHero_WithInvalidInput_ShouldReturnTrue()
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
                Id = 2
            };

            var updateHeroCommand = new UpdateHeroCommand()
            {
                Id = 1,
                Name = "Not SpiderMan"
            };

            heroRepository.Setup(ar => ar.GetHeroByIdAsync(It.IsAny<int>()).Result).Returns(heroFake);
            var updateHandler = new UpdateHeroCommandHandler(heroRepository.Object);

            //Act

            await updateHandler.Handle(updateHeroCommand, new CancellationToken());
            var heroUpdated = await heroRepository.Object.GetHeroByIdAsync(updateHeroCommand.Id);

            //Assert
            heroRepository.Verify(ar => ar.GetHeroByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            Assert.NotEqual(updateHeroCommand.Id, heroUpdated.Id);

        }
    }
}
