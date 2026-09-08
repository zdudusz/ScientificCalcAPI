using ScientificCalcAPI.Core.Entities;
using ScientificCalcAPI.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Applications
{
    public class CalculationHistoryApplication
    {
        private readonly ICalculationHistoryRepository _repository;

        public CalculationHistoryApplication(ICalculationHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CalculationHistory>> ListarPorUsuarioAsync(int userId) 
        { 
            return await _repository.ListarPorUsuarioAsync(userId);
        }

        public async Task DeletarAsync(int id, int userId)
        {
            await _repository.DeletarAsync(id, userId);
        }
        public async Task DeletarTodosAsync(int userId)
        {
            await _repository.DeletarTodosAsync(userId);
        }

    }
}
