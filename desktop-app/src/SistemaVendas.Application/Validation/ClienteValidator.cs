using FluentValidation;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Validation
{
    public class ClienteValidator : AbstractValidator<ClienteDTO>
    {

        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente é obrigatório.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty()
                .WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$")
                .WithMessage("O telefone deve conter 10 ou 11 números.");
        }
    }
}
