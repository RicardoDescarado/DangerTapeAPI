using DangerTapeAPI.Database.Context;
using DangerTapeAPI.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DangerTapeAPI.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDangerTapeDBContext(this IServiceCollection services, IDangerTapeAPIConfiguration config)
        {
            services.AddScoped<DbContext, DangerTapeDBContext>();

            services.AddDbContext<DangerTapeDBContext>(options =>
                options.UseSqlServer(config.DangerTapeDBConnectionString));

            return services;
        }

        public static IServiceCollection AddEfRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EFRepository<>));
            return services;
        }
    }
}