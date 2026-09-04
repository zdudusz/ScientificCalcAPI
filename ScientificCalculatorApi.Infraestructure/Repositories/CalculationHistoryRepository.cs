using Microsoft.EntityFrameworkCore;
using ScientificCalcAPI.Core.Entities;
using ScientificCalcAPI.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalculatorApi.Infraestructure.Repositories
{
    public class CalculationHistoryRepository : ICalculationHistoryRepository
    {
        private readonly ScientificCalculatorContext _dbContext;

        public CalculationHistoryRepository(ScientificCalculatorContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task DeletarAsync(int id)
        {
           var user = await _dbContext.CalculationHistories.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _dbContext.CalculationHistories.Remove(user); //remove o registro de histórico de cálculo encontrado
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletarTodosAsync(int userId)
        {
            var user = await _dbContext.CalculationHistories.Where(x => x.UserId == userId).ToListAsync();
            _dbContext.CalculationHistories.RemoveRange(user); //remove todos os registros de histórico de cálculo associados ao usuário especificado
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CalculationHistory>> ListarPorUsuarioAsync(int userId)
        {
            return await _dbContext.CalculationHistories.Where(x => x.UserId == userId).ToListAsync(); //retorna todos os registros de histórico de cálculo associados ao usuário especificado
        }

        public Task SalvarAsync(CalculationHistory calculationHistory)
        {
            _dbContext.CalculationHistories.Add(calculationHistory); //adiciona um novo registro de histórico de cálculo ao contexto do banco de dados
            return _dbContext.SaveChangesAsync();
        }
    }
}
