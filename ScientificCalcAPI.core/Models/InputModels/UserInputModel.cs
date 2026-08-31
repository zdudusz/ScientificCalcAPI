using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core.Models.InputModels
{// Input model para receber os dados do usuário a ser cadastrado
    public class UserInputModel(string name, string email, string password) 
    {
        
        public string Name { get;} = name;

        public string Email { get;} = email!;

        public string Password { get;} = password!;

    }
}

