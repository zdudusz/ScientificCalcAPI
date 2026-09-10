using ScientificCalcApi.Application.DTOs;
using ScientificCalcAPI.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ScientificCalcApi.Application.Applications
{
    public class UserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> ListarDados(int userId)
        {
            var user = await _userRepository.BuscarPorId(userId);
            if (user != null)
            {
                return new UserResponseDto(user.Id, user.Name, user.Email, user.CreatedAt, user.UpdatedAt);
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        public async Task AlterarNome(int userId, string newName)
        {
            await _userRepository.AlterarNome(userId, newName);
        }
        public async Task AlterarEmail(int userId, string newEmail)
        {
            await _userRepository.AlterarEmail(userId, newEmail);
        }
        public async Task AlterarPassword(int userId, string newPassword)
        {
            var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.AlterarPassword(userId, newPasswordHash);
        }
    }
    }