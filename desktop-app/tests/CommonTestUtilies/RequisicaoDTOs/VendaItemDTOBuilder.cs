using Bogus;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.RequisicaoDTOs
{
    public class VendaItemDTOBuilder
    {
        public static VendaItemDTO Build()
        {
            return new Faker<VendaItemDTO>("pt_BR")
                .RuleFor(v => v.VendaId, f => f.Random.Int(1, 1000))
                .RuleFor(v => v.ProdutoId, f => f.Random.Int(1, 1000))
                .RuleFor(v => v.Quantidade, f => f.Random.Int(1, 10))
                .RuleFor(v => v.PrecoVenda, f => f.Random.Decimal(1, 500));
        }
    }
}
