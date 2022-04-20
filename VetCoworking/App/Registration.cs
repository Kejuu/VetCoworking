using AQ.Core.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetCoworking.Persistence;

namespace VetCoworking.App
{
    public static class Registration
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseEntity<VetCoworkingContext>(configuration["ConnectionStrings:Booking"]);

            services.AddRepositories();
            return services;
        }

    }
}
