using ScientificCalcAPI.Core.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core.Interface.Applications
{
    public interface ICadastrarUserApplication
    {
        Task<int> CadastrarAsync(UserInputModel inputModel); //Metodo que todos que assinarem a interface devem implementar, para cadastrar um usuário no banco de dados
    }
}
