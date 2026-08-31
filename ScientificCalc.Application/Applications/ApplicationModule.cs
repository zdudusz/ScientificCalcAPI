using Microsoft.Extensions.DependencyInjection;
using ScientificCalcAPI.Core.Interface.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Applications
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Adiciona a implementação da interface ICadastrarUserApplication ao container de injeção de dependência
            services.AddScoped<ICadastrarUserApplication, CadastrarUserApplication>();
            return services;
        }
    }
}
