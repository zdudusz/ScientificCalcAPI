using Microsoft.AspNetCore.Mvc;
using ScientificCalcAPI.Core.Interface.Applications;
using ScientificCalcAPI.Core.Models.InputModels;

namespace ScientificCalcAPI.Controllers
{
    public class UserController(ICadastrarUserApplication cadastrarUserApplication) : MainController
    {
        private readonly ICadastrarUserApplication _cadastrarUserApplication = cadastrarUserApplication;
        // Endpoint para cadastrar um usuário
        [HttpPost] 
        public async Task<IActionResult> CadastrarAsync([FromBody] UserInputModel inputModel)
        {
            // Implementação do método CadastrarAsync
            var id = await _cadastrarUserApplication.CadastrarAsync(inputModel);
            return Ok(id);
        }
    }
}
