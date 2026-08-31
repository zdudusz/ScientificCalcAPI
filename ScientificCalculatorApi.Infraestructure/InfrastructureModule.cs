using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScientificCalcAPI.Core.Interface.Repositories;
using ScientificCalculatorApi.Infrastructure.Repositories;

namespace ScientificCalculatorApi.Infraestructure
{
    public static class InfrastructureModule
    {
        // Configura o contexto do banco de dados e adiciona os serviços necessários para a infraestrutura
        public static IServiceCollection AddInfraestructure(this IServiceCollection services) { 
        services.AddDbContext<ScientificCalculatorContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5490;Database=CALCDB;Username=calculator;Password=admin"));
            services.AddScoped<IUserRepository, UserRepository>(); // Adiciona a implementação da interface IUserRepository ao container de injeção de dependência
            return services;
        }
    }
}
