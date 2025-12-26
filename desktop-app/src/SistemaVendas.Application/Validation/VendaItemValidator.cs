using FluentValidation;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Validation
{
    public class VendaItemValidator : AbstractValidator<VendaItemDTO>
    {
        public VendaItemValidator()
        {
            

            RuleFor(v => v.ProdutoId)
                .GreaterThan(0)
                .WithMessage("O produto é obrigatório.");

            RuleFor(v => v.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.");

            RuleFor(v => v.PrecoVenda)
                .GreaterThan(0)
                .WithMessage("O preço de venda deve ser maior que zero.");
        }
    }
}
