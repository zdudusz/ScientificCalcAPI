using ScientificCalcAPI.Core.Entities;

namespace ScientificCalcAPI.Core.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<int> CadastrarAsync(User user);
    }
}
