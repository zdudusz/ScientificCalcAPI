using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using ScientificCalcApi.Application.Applications;
using ScientificCalcApi.Application.Services;
using ScientificCalcApi.Application.Validators;
using ScientificCalcAPI.Filters;
using ScientificCalculatorApi.Infraestructure;
using System.Text;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();



        builder.Services.AddControllers();
        builder.Services.AddScoped<CalculatorApplication>();// Adicionando o serviço CalculatorApplication ao contêiner de injeção de dependência
        builder.Services.AddScoped<LoginApplication>();// Adicionando o serviço LoginApplication ao contêiner de injeção de dependência
        builder.Services.AddScoped<TokenService>(); // Adicionando o serviço TokenService ao contêiner de injeção de dependência
        builder.Services.AddScoped<CalculationHistoryApplication>();// Adicionando o serviço CalculationHistoryApplication ao contêiner de injeção de dependência
        builder.Services.AddScoped<CalculationHistoryApplication>(); // Adicionando o serviço CalculationHistoryApplication ao contêiner de injeção de dependência
        builder.Services.AddScoped<UserApplication>();// Adicionando o serviço UserApplication ao contêiner de injeção de dependência
        builder.Services.AddTransient<GlobalExceptionHandler>();// Adicionando o middleware GlobalExceptionHandler ao contêiner de injeção de dependência

        // Adicionando os validadores do FluentValidation ao contêiner de injeção de dependência
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<UserInputModelValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UserInputModelValidator>();


        builder.Services.AddOpenApi(options =>
        { 
        options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
        }
            
            );
        builder.Services
            .AddInfraestructure(builder.Configuration)
            .AddApplication();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options=>{
                options.Title = "Scientific Calculator API";
                options.Theme = ScalarTheme.Purple;
            });
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<GlobalExceptionHandler>();// Adicionando o middleware GlobalExceptionHandler ao pipeline de requisições
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}