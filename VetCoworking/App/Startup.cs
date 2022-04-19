using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Definition;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VetCoworking.App;
using VetCoworking.App.Resgistration;

namespace AQ.Projects.App
{
    [PrimaryConstructor]
    public partial class Startup
    {
        private readonly IConfiguration Configuration;
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGenericRequestClient();

            services.AddSingleton<IEndpointNameFormatter>(provider => new KebabCaseEndpointNameFormatter(true));


            services.AddControllers();

            services.AddOpenApiDocument();

            if (Convert.ToBoolean(Configuration["EnableSwagger"]))
            {
                services.AddSwaggerConfig();
            }

            services.Register(Configuration);

           
        }

        public void Configure(IApplicationBuilder builder)
        {
            if (Environment.IsDevelopment())
            {
                builder
                .UseDeveloperExceptionPage();
            }
            if (Convert.ToBoolean(Configuration["EnableSwagger"]))
            {
                builder
                    .UseOpenApi()
                    .UseSwaggerUi3(options =>
                    {
                        options.DocumentPath = "/swagger/v2/swagger.json";
                    });
            }

            builder
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("VetCoworking");
                    });

                    endpoints.MapControllers();
                });


        }
    }
}
