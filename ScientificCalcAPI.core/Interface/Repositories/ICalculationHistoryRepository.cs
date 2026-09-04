using ScientificCalcAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core.Interface.Repositories
{
    public interface ICalculationHistoryRepository
    {
        public Task SalvarAsync(CalculationHistory calculationHistory);
        public Task<IEnumerable<CalculationHistory>> ListarPorUsuarioAsync(int userId); //retorma uma lista de histórico de cálculos do usuário
        public Task DeletarAsync(int id);
        public Task DeletarTodosAsync(int userId);

    }
}
