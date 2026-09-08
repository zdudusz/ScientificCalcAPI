using ScientificCalcAPI.Core.Interface.Repositories;
using ScientificCalcAPI.Core.Entities;
using ScientificCalculatorApi.Infraestructure;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User?> BuscarPorEmail(string email)
        {
           return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email); // Busca um usuário pelo email
        }

        public async Task AlterarNome(int userId, string newName)
        {
            var user = await _dbContext.Users.FindAsync(userId); // Busca o usuário pelo ID
            if(user!=null)
            {
                user.UpdateName(newName);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AlterarEmail(int userId, string newEmail)
        { 
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null) 
            { 
            user.UpdateEmail(newEmail);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AlterarPassword(int userId,string newPasswordHash) 
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if(user!=null)
            {
                user.UpdatePassword(newPasswordHash);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<User?> BuscarPorId(int userId) 
        { 
            var user = await _dbContext.Users.FindAsync(userId);
            return user;
        } 
    }
}
