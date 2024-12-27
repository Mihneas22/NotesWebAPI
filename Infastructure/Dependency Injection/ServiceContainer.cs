using Application.Repository;
using Infastructure.Context;
using Infastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Dependency_Injection
{
    public static class ServiceContainer
    {
        public static IServiceCollection InfastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
                ServiceLifetime.Scoped);

            services.AddScoped<IApiKey,ApiKeyRepository>();
            services.AddScoped<INotes, NotesRepository>();

            return services;
        }
    }
}
