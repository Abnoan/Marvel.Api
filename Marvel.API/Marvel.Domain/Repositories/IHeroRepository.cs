using Marvel.Domain.Entities;
using Marvel.Domain.Result;

namespace Marvel.Domain.Repositories
{
    public interface IHeroRepository
    {
        Task CreateHero(Hero hero);
        Task<Hero?> GetHeroByIdAsync(int id);
        Task DeleteHeroByIdAsync(int id);
        Task SaveChangesAsync();
        Task<PaginationResult<Hero>> GetAllAsync(string query, int page);
        Task InsertBulk(List<Hero> heroes);
    }
}
