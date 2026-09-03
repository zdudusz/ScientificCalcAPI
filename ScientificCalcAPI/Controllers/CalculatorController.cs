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
            var result = 0.0;
            var operation = request.Operation.ToLower();
            switch(operation)
            {
                case "add":
                     result = request.Operands.Sum();break;
                case "subtract":
                     result = request.Operands[0] - request.Operands.Skip(1).Sum();break;
                case "multiply":
                     result = request.Operands.Aggregate(1.0, (acc, x) => acc * x);break;
                case "divide":
                     result = request.Operands[0] / request.Operands.Skip(1).Aggregate(1.0, (acc, x) => acc * x); break;
                case "power":
                    result = Math.Pow(request.Operands[0], request.Operands[1]); break;
                case "sqrt":
                    result = Math.Sqrt(request.Operands[0]); break;
                case "log":
                    result = Math.Log(request.Operands[0], request.Operands[1]); break;
                case "sin":
                    result = Math.Sin(request.Operands[0]); break;
                case "cos":
                    result = Math.Cos(request.Operands[0]); break;
                case "tan":
                    result = Math.Tan(request.Operands[0]); break;
            }
            return Ok(result);
        }
    }
}
