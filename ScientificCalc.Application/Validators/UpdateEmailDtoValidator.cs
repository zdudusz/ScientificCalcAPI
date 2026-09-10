using FluentValidation;
using ScientificCalcApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Validators
{
    public class UpdateEmailDtoValidator :AbstractValidator<UpdateEmailDto>
    {
        public UpdateEmailDtoValidator() 
        {
            RuleFor(updateEmail => updateEmail.NewEmail)
                .NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("Email invalido");
        }
    }
}
