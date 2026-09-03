using ScientificCalcAPI.Core.Entities;
using ScientificCalcAPI.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Applications
{
    public class LoginApplication
    {
        private readonly IUserRepository _userRepository;

        public LoginApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.BuscarPorEmail(email);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) { 
            throw new Exception("Senha incorreta.");
            }
            return user;
        }
    }
}
