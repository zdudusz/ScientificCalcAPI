using ScientificCalcAPI.Core.Interface.Repositories;
using ScientificCalcAPI.Core.Entities;
using ScientificCalculatorApi.Infraestructure;


namespace ScientificCalculatorApi.Infrastructure.Repositories
{
    public class UserRepository(ScientificCalculatorContext dbContext) : IUserRepository
    {
        private readonly ScientificCalculatorContext _dbContext = dbContext;

        // Metodo para cadastrar um novo usuário no banco de dados
        public async Task<int> CadastrarAsync(User user) {
           var entidade = await _dbContext.Users.AddAsync(user);
            
            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados e aguarda a conclusão da operação de forma assíncrona

            return entidade.Entity.Id;
        }
    }
}
