using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using ScientificCalcApi.Application.Applications;
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

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}