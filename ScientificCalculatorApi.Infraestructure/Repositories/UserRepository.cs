using ScientificCalcAPI.Core.Interface.Repositories;
using ScientificCalcAPI.Core.Entities;


namespace ScientificCalculatorApi.Infrastructure.Repositories
{
    public class UserRepository(ScientificCalculatorContext dbContext) : IUserRepository
    {
        private readonly ScientificCalculatorContext _dbContext = dbContext;

        // Metodo para cadastrar um novo usuário no banco de dados
        public async Task<int> CadastrarAsync(User user) {
           var entidade = await _dbContext.Users.AddAsync(user);
            
            await _dbContext.SaveChangesAsync();

            return entidade.Entity.Id;
        }
    }
}
