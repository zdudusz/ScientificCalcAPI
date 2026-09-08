using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using ScientificCalcAPI.Core.Interface.Applications;
using ScientificCalcAPI.Core.Models.InputModels;

namespace ScientificCalcAPI.Controllers
{
    public class UserController(ICadastrarUserApplication cadastrarUserApplication, UserApplication userApplication) : MainController
    {
        private readonly ICadastrarUserApplication _cadastrarUserApplication = cadastrarUserApplication;
        private readonly UserApplication _userApplication = userApplication;
        // Endpoint para cadastrar um usuário
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] UserInputModel inputModel)
        {
            // Implementação do método CadastrarAsync
            var id = await _cadastrarUserApplication.CadastrarAsync(inputModel);
            return Ok(id);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterDadosAsync()
        {// Endpoint para obter os dados do usuário logado
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var user = await _userApplication.ListarDados(int.Parse(userIdClaim.Value));
            return Ok(user);
        }
        [HttpPut("email")]
        [Authorize]
        public async Task<IActionResult> AtualizarEmailAsync([FromBody] string newEmail)
        {// Endpoint para atualizar o email do usuário logado
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            await _userApplication.AlterarEmail(int.Parse(userIdClaim.Value), newEmail);
            return Ok();
        }
        [HttpPut("password")]
        [Authorize]
        public async Task<IActionResult> AtualizarPasswordAsync([FromBody] string newPassword)
        {// Endpoint para atualizar a senha do usuário logado
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            await _userApplication.AlterarPassword(int.Parse(userIdClaim.Value), newPassword);
            return Ok();
        }
        [HttpPut("name")]
        [Authorize]
        public async Task<IActionResult> AtualizarNameAsync([FromBody] string newName)
        {// Endpoint para atualizar o nome do usuário logado
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            await _userApplication.AlterarNome(int.Parse(userIdClaim.Value), newName);
            return Ok();
        }
    }
}
