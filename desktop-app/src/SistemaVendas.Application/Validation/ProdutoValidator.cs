using FluentValidation;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Validation
{
    public class ProdutoValidator : AbstractValidator<ProdutoDTO>
    {
        


        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto é obrigatório.");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do produto é obrigatória.");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero.");

            RuleFor(p => p.QtdEstoque)
                .GreaterThan(0)
                .WithMessage("A quantidade em estoque deve ser maior que zero.");
        }
    }


}
    

