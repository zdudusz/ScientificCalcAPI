using System;
using System.Collections.Generic;
using System.Text;
using ScientificCalcApi.Application.DTOs;
using ScientificCalcAPI.Core.Entities;
using ScientificCalcAPI.Core.Interface.Repositories;

namespace ScientificCalcApi.Application.Applications
{
    public class CalculatorApplication
    {
        private readonly ICalculationHistoryRepository _calculationHistoryRepository;
        public CalculatorApplication(ICalculationHistoryRepository calculationHistoryRepository)
        {
            _calculationHistoryRepository = calculationHistoryRepository;
        }
        public async Task<double> Calculate(string operation, IEnumerable<double> operands, int userId)
        {
            var result = 0.0;
            switch (operation.ToLower())
            {
                case "add":
                    result = operands.Sum(); break;
                case "subtract":
                    result = operands.ElementAt(0) - operands.Skip(1).Sum(); break;
                case "multiply":
                    result = operands.Aggregate(1.0, (acc, x) => acc * x); break;
                case "divide":
                    result = operands.ElementAt(0) / operands.Skip(1).Aggregate(1.0, (acc, x) => acc * x); break;
                case "power":
                    result = Math.Pow(operands.ElementAt(0), operands.ElementAt(1)); break;
                case "sqrt":
                    result = Math.Sqrt(operands.ElementAt(0)); break;
                case "log":
                    result = Math.Log(operands.ElementAt(0), operands.ElementAt(1)); break;
                case "sin":
                    result = Math.Sin(operands.ElementAt(0)); break;
                case "cos":
                    result = Math.Cos(operands.ElementAt(0)); break;
                case "tan":
                    result = Math.Tan(operands.ElementAt(0)); break;
                case "abs":
                    result = Math.Abs(operands.ElementAt(0)); break;
                case "exp":
                    result = Math.Exp(operands.ElementAt(0)); break;
                case "percent":
                    result = operands.ElementAt(0) * operands.ElementAt(1) / 100; break;
                case "factorial":
                    result = 1;
                    for (int i = 1; i <= operands.ElementAt(0); i++)
                    {
                        result *= i;
                    }
                    break;
                default:
                    throw new ArgumentException($"Operação '{operation}' não reconhecida.");
            }
            var parametersJson = System.Text.Json.JsonSerializer.Serialize(operands); // Serializa os operandos em formato JSON para salvar no banco de dados
            CalculationHistory calculationHistory = new CalculationHistory(userId, operation, parametersJson, (decimal)result);
            await _calculationHistoryRepository.SalvarAsync(calculationHistory);
            return result;
        }
    }
}
