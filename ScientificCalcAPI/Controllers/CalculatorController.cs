using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using ScientificCalcApi.Application.DTOs;
using ScientificCalcAPI.Core.Interface.Applications;

namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorApplication _calculatorApplication;

        public CalculatorController(CalculatorApplication calculatorApplication) //Aplicando injeção de dependência para o serviço CalculatorApplication
        {
            _calculatorApplication = calculatorApplication;
        }

        [HttpPost]
        
        public IActionResult Calculate([FromBody] CalculationRequestDto request)
        {
          var result = _calculatorApplication.Calculate(request.Operation, request.Operands);
            return Ok(result);
        }
    }
}
