using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using ScientificCalcApi.Application.DTOs;
using ScientificCalcApi.Application.Services;
using ScientificCalcAPI.Core.Models.InputModels;
namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        public AuthController(LoginApplication loginApplication, TokenService tokenService)
        {
            _loginApplication = loginApplication;
            _tokenService = tokenService;
        }
        private readonly LoginApplication _loginApplication;
        private readonly TokenService _tokenService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto _loginRequestDto)
        {
           var user = await _loginApplication.LoginAsync(_loginRequestDto.Email,_loginRequestDto.Password);
            var token =  _tokenService.GenerateToken(user);
            return Ok(token);
        }
    }
}
