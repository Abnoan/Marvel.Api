using Microsoft.EntityFrameworkCore;
using Marvel.Domain.Entities;

namespace Marvel.Infrastructure.Persistence
{
    public class VixtraDBContext : DbContext
    {
        public VixtraDBContext(DbContextOptions<VixtraDBContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
