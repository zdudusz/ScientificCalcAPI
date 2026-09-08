using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using System.Security.Claims;

namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HistoryController : MainController
    {
        public HistoryController(CalculationHistoryApplication calculationHistoryApplication)
        {
            _calculationHistoryApplication = calculationHistoryApplication;
        }

        private readonly CalculationHistoryApplication _calculationHistoryApplication;

        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var history = await _calculationHistoryApplication.ListarPorUsuarioAsync(int.Parse(userId.Value)); //Busca o historico pelo id do usuario logado
            return Ok(history);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryItem(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            await _calculationHistoryApplication.DeletarAsync(id, int.Parse(userId.Value)); //Deleta o item do historico pelo id do usuario logado e pelo id do item
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllHistory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            await _calculationHistoryApplication.DeletarTodosAsync(int.Parse(userId.Value)); //Deleta todo o historico do usuario logado
            return Ok();
        }
    }
}
