using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalculatorApi.Infraestructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration) { 
        services.AddDbContext<ScientificCalculatorContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Server=localhost;Port=5490;Database=CALCDB;Username=calculator;Password=admin")));

            return services;
        }
    }
}
