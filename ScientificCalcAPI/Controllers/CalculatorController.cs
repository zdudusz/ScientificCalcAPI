using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using ScientificCalcApi.Application.DTOs;
using ScientificCalcAPI.Core.Interface.Applications;

namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : MainController
    {
        private readonly CalculatorApplication _calculatorApplication;

        public CalculatorController(CalculatorApplication calculatorApplication) //Aplicando injeção de dependência para o serviço CalculatorApplication
        {
            _calculatorApplication = calculatorApplication;
        }
        /// <summary>
        /// Realiza uma operação matemática
        /// </summary>
        /// <remarks>
        /// Operações disponíveis:
        /// - add: soma (ex: [10, 5])
        /// - subtract: subtração (ex: [10, 5])
        /// - multiply: multiplicação (ex: [10, 5])
        /// - divide: divisão (ex: [10, 5])
        /// - power: potência (ex: [2, 8])
        /// - sqrt: raiz quadrada (ex: [16])
        /// - log: logaritmo (ex: [100, 10])
        /// - sin: seno em radianos (ex: [1.5707])
        /// - cos: cosseno em radianos (ex: [0])
        /// - tan: tangente em radianos (ex: [0.7853])
        /// - factorial: fatorial (ex: [5])
        /// - percent: porcentagem (ex: [200, 15])
        /// - abs: valor absoluto (ex: [-10])
        /// - exp: exponencial e^x (ex: [2])
        /// </remarks>
        [HttpPost]
        
        public IActionResult Calculate([FromBody] CalculationRequestDto request)
        {
          var result = _calculatorApplication.Calculate(request.Operation, request.Operands);
            return Ok(result);
        }
    }
}
