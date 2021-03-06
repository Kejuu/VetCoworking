using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VetCoworking.Domain.Abstractions;
using VetCoworking.Repositories;

namespace VetCoworking.Persistence
{
    public static class Registration
    {
        public static IServiceCollection UseEntity<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
               options.UseNpgsql(connectionString,
               b => b.MigrationsAssembly(typeof(T).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IBookingsRepository, BookingsRepository>();
        }
    }
}