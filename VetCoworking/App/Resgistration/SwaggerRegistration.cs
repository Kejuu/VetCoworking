using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace VetCoworking.App.Resgistration
{
    public static class SwaggerRegistration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "v2";
                config.Title = "VetCoworking";
            });
        }
    }
}
