using FluentValidation;
using ScientificCalcApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Validators
{
    public class UpdatePasswordDtoValidator :AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordDtoValidator() 
        {
            RuleFor(updatePassword => updatePassword.NewPassword)
                .NotEmpty().WithMessage("O campo senha não pode ser vazio")
                .MinimumLength(5).WithMessage("A senha deve ter no minimo 5 caracteres");
        }
    }
}
