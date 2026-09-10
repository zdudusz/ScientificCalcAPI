using FluentValidation;
using ScientificCalcApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Validators
{
    public class UpdateNameDtoValidator :AbstractValidator<UpdateNameDto>
    {
        public UpdateNameDtoValidator() 
        {
            RuleFor(updateName => updateName.NewName)
                .NotEmpty().WithMessage("O campo nome não pode ser vazio")
                .MinimumLength(3).WithMessage("O nome deve ter no minimo 3 caracteres");
        }
    }
}
