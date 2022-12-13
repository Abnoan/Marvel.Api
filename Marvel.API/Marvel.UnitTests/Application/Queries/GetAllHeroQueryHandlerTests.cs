using Moq;
using Marvel.Application.Queries.GetAllHeroes;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;
using Marvel.Domain.Result;

namespace Marvel.UnitTests.Application.Queries
{
    public class GetAllHeroQueryHandlerTests
    {
        [Fact]
        public async Task GetListHeros_WithValidInput_ShouldReturnAListHeros()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();
            var heros = new PaginationResult<Hero>
            {
                Data = new List<Hero>
                {
                    new Hero
                    {
                        Name = "Super Choque",
                        HP = 500,
                        AttackPower = 100,
                        DefensePower = 100,
                        Affiliation = true
                    },
                     new Hero
                    {
                        Name = "The Flash",
                        HP = 500,
                        AttackPower = 100,
                        DefensePower = 100,
                        Affiliation = false
                    }
                },
                Page = 1,
                PageSize = 2,
                ItemsCount = 0,
                TotalPages = 0
            };

            heroRepository.Setup(ar => ar.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(heros);
            var query = new GetAllHeroesQuery { Query = "", Page = 1 };
            var handler = new GetAllHeroesQueryHandler(heroRepository.Object);

            //Act
            var paginationResult = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(paginationResult);
            Assert.NotEmpty(paginationResult.Data);
            Assert.Equal(heros.Data.Count, paginationResult.Data.Count);

            heroRepository.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }

        [Fact]
        public async Task GetListHeros_WithEmptyInput_ShouldReturnEmptyList()
        {
            //Arrage
            var heroRepository = new Mock<IHeroRepository>();
            var heros = new PaginationResult<Hero>
            {
                Data = new List<Hero>(),
                Page = 1,
                PageSize = 2,
                ItemsCount = 0,
                TotalPages = 0
            };

            heroRepository.Setup(ar => ar.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(heros);
            var query = new GetAllHeroesQuery { Query = "Tiger", Page = 1 };
            var handler = new GetAllHeroesQueryHandler(heroRepository.Object);

            //Act
            var paginationResult = await handler.Handle(query, new CancellationToken());

            // Assert        
            Assert.NotNull(paginationResult);
            Assert.Equal(0, paginationResult.ItemsCount);

            heroRepository.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
