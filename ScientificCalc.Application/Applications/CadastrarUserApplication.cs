using ScientificCalcAPI.Core.Entities;
using ScientificCalcAPI.Core.Interface.Applications;
using ScientificCalcAPI.Core.Interface.Repositories;
using ScientificCalcAPI.Core.Models.InputModels;
using BCrypt.Net;


namespace ScientificCalcApi.Application.Applications
{
    public class CadastrarUserApplication(IUserRepository userRepository): ICadastrarUserApplication
    {// Implementação da interface ICadastrarUserApplication para cadastrar um usuário no banco de dados
        private readonly IUserRepository _userRepository = userRepository;

        
        public async Task<int> CadastrarAsync(UserInputModel userInputModel) 
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userInputModel.Password); // Hashing da senha do usuário usando BCrypt

            var user = new User(
                userInputModel.Name, 
                userInputModel.Email, 
                passwordHash);
            
            return await _userRepository.CadastrarAsync(user);
        }
     
    }
}
