using GameCatalogue.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GameCatalogue.Domain.Interfaces;
using GameCatalogue.Infra.Data.Repositories;
using GameCatalogue.Application.Interfaces;
using GameCatalogue.Application.Services;
using GameCatalogue.Application.Mappings;
using System;
using MediatR;

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
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlatformService, PlatformService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("GameCatalogue.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
