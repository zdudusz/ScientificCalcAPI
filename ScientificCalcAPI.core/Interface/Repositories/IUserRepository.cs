using ScientificCalcAPI.Core.Entities;

namespace ScientificCalcAPI.Core.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<int> CadastrarAsync(User user); // Cria um novo usuário e retorna o ID do usuário criado
    }
}
