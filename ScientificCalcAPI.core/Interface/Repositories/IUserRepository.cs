using ScientificCalcAPI.Core.Entities;

namespace ScientificCalcAPI.Core.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<int> CadastrarAsync(User user); // Cria um novo usuário e retorna o ID do usuário criado

        Task<User?> BuscarPorEmail(string email); // Busca um usuário pelo email e retorna o hash da senha do usuário encontrado
    }
}
