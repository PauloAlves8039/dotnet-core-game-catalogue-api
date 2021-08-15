using GameCatalogue.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GameCatalogue.Domain.Interfaces;
using GameCatalogue.Infra.Data.Repositories;

namespace GameCatalogue.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options => 
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            return services;
        }
    }
}
