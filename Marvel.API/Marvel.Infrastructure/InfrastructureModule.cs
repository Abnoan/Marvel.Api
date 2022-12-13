using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Marvel.Domain.Repositories;
using Marvel.Infrastructure.Persistence;
using Marvel.Infrastructure.Persistence.Repositories;

namespace Marvel.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddRepositories()
                .InjectAutoMapper();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VixtraDBContext>(options => options.UseInMemoryDatabase("Vixtra"));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHeroRepository, HeroRepository>();

            return services;
        }

        private static IServiceCollection InjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
