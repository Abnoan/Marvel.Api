using Microsoft.EntityFrameworkCore;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;
using Marvel.Domain.Result;

namespace Marvel.Infrastructure.Persistence.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly VixtraDBContext _context;
        private const int PAGE_SIZE = 2;

        public HeroRepository(VixtraDBContext context)
        {
            _context = context;
        }
        public async Task CreateHero(Hero hero)
        {
            await _context.Heroes.AddAsync(hero);
            await SaveChangesAsync();
        }

        public async Task DeleteHeroByIdAsync(int id)
        {
            var hero = await GetHeroByIdAsync(id);
             _context.Remove(hero);
            await SaveChangesAsync();
        }

        public async Task<PaginationResult<Hero>> GetAllAsync(string query, int page)
        {           
            IQueryable<Hero> heroes = _context.Heroes;          

            if (!string.IsNullOrWhiteSpace(query))
            {
                heroes = heroes
                    .Where(p =>
                        p.Name.Contains(query));
            }

            return await heroes.GetPaged<Hero>(page, PAGE_SIZE);
        }

        public async Task<Hero?> GetHeroByIdAsync(int id)
        {
            var hero = await _context.Heroes.SingleOrDefaultAsync(app => app.Id == id);
            return hero;
        }

        public async Task InsertBulk(List<Hero> heroes)
        {
            await _context.AddRangeAsync(heroes);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
