using ScientificCalcAPI.Core.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core.Interface.Applications
{
    public interface ICadastratUserApplication
    {
        Task<int> CadastrarAsync(UserInputModel inputModel);
    }
}
