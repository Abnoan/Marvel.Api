using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Marvel.Application.Commands.Create;

namespace Marvel.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(CreateHeroCommand));

            return services;
        }
    }
}
