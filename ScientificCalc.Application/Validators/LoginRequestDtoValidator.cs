using FluentValidation;
using ScientificCalcApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.Validators
{
    public class LoginRequestDtoValidator :AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("O campo senha não pode ser vazio")
                .MinimumLength(5).WithMessage("A senha deve ter no minimo 5 caracteres");

            RuleFor(login => login.Email)
                .NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("Email invalido");
        }
    }
}
