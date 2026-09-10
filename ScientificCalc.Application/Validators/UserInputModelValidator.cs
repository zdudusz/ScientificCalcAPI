using ScientificCalcAPI.Core.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ScientificCalcApi.Application.Validators
{
    public class UserInputModelValidator : AbstractValidator<UserInputModel>
    {
        public UserInputModelValidator() 
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("O campo nome não pode ser vazio")
                .MinimumLength(3).WithMessage("O nome deve ter no minimo 3 caracteres");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("O campo senha não pode ser vazio")
                .MinimumLength(5).WithMessage("A senha deve ter no minimo 5 caracteres");
        }
    }
}
