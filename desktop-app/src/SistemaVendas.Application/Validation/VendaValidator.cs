using FluentValidation;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Validation
{
    public class VendaValidator : AbstractValidator<VendaDTO>
    {

        public VendaValidator()
        {
            RuleFor(v => v.ClienteId)
                .GreaterThan(0)
                .WithMessage("O cliente é obrigatório.");

            RuleFor(v => v.DataVenda)
                .NotEmpty()
                .WithMessage("A data da venda é obrigatória.");

            RuleFor(v => v.Itens)
                .NotEmpty()
                .WithMessage("A venda deve possuir ao menos um item.");

            RuleForEach(v => v.Itens)
                .SetValidator(new VendaItemValidator());

           
        }
    }
}
