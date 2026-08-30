using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ScientificCalculatorApi.Infraestructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services) { 
        services.AddDbContext<ScientificCalculatorContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5490;Database=CALCDB;Username=calculator;Password=admin")));

            return services;
        }
    }
}
