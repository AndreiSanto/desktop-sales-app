using Bogus;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.RequisicaoDTOs
{
    public class ProdutoDTOBuilder
    {
        public static ProdutoDTO Build()
        {
            return new Faker<ProdutoDTO>("pt_BR")
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Descricao, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 1000))
                .RuleFor(p => p.QtdEstoque, f => f.Random.Int(1, 100));
        }
    }
}
