using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.DTOs;

namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calculate([FromBody] CalculationRequestDto request)
        {
          //To implement
        }
    }
}
