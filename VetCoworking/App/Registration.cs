using System;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VetCoworking.App
{
    public static class Registration
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }

    }
}
