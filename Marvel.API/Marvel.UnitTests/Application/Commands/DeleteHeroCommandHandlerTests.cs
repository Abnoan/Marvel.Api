using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel.Application.Commands.Create;
using Marvel.Application.Commands.Delete;
using Marvel.Application.Mapper;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.UnitTests.Application.Commands
{
    public class DeleteHeroCommandHandlerTests
    {
        readonly IMapper mapper;
        public DeleteHeroCommandHandlerTests()
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
        public async Task DeleteHero_WithValidInput_ShouldReturnTrue()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();

            var createHeroCommand = new CreateHeroCommand
            {
                Name = "Super Choque",
                HP = 500,
                AttackPower = 100,
                DefensePower = 100,
                Affiliation = true
            };

            var heroFake = new Hero
            {
                Name = "Super Choque",
                HP = 500,
                AttackPower = 100,
                DefensePower = 100,
                Affiliation = true,
                Id = 1
            };


            heroRepository.Setup(ar => ar.GetHeroByIdAsync(It.IsAny<int>()).Result).Returns(heroFake);
            var deleteAppointmentCommand = new DeleteHeroCommand(1);

            var createHandler = new CreateHeroCommandHandler(heroRepository.Object, mapper);
            var deleteHandler = new DeleteHeroCommandHandler(heroRepository.Object);

            //Act
            await createHandler.Handle(createHeroCommand, new CancellationToken());
            await deleteHandler.Handle(deleteAppointmentCommand, new CancellationToken());
            var hero = await heroRepository.Object.GetHeroByIdAsync(1);

            //Assert
            heroRepository.Verify(hr => hr.CreateHero(It.IsAny<Hero>()), Times.Once());
            heroRepository.Verify(hr => hr.GetHeroByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            heroRepository.Verify(hr => hr.DeleteHeroByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            
        }
    }
}
