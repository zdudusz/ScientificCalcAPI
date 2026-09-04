using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ScientificCalcAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScientificCalcApi.Application.Services
{
    public class TokenService
    {
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration; // Injeção de dependência para acessar as configurações do aplicativo

        public string GenerateToken(User user) 
        {
            // implementação do método para gerar o token JWT usando as informações do usuário
            var secretKey = _configuration["Jwt:SecretKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Criação das claims do token

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
