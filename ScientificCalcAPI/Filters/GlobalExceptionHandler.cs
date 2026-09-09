using ScientificCalcAPI.Core;
using System.Net;

namespace ScientificCalcAPI.Filters
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private const string ERROR_MESSAGE = "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.";
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {// O middleware de tratamento global de exceções
            try
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {// Configura a resposta HTTP para indicar um erro interno do servidor sem expor detalhes sensíveis
            context.Response.ContentType = "application/json";
            var MensagemErro = Variaveis.Geral.ENV == "Development" ? ex.InnerException?.Message ?? ex.Message : ERROR_MESSAGE; // Mensagem de erro detalhada apenas em ambiente de desenvolvimento
            if (context != null)
            {// Define o código de status HTTP com base no tipo de exceção
                context.Response.StatusCode = ex switch 
                 { 
                    ArgumentException => 400,
                     UnauthorizedAccessException => 401,
                     KeyNotFoundException => 404,
                     _ => 500
                 };
                await context.Response.WriteAsJsonAsync(new
                {// Retorna um objeto JSON com o código de status e a mensagem de erro
                    statusCode = context.Response.StatusCode,
                    message = MensagemErro
                });
            }
        }

    }
}
