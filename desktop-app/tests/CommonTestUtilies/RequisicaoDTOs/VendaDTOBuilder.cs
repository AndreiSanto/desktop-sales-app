using Bogus;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.RequisicaoDTOs
{
    public class VendaDTOBuilder
    {
        public static VendaDTO Build()
        {
            var itens = new Faker<VendaItemDTO>("pt_BR")
                .CustomInstantiator(f => VendaItemDTOBuilder.Build())
                .GenerateBetween(1, 5);

            return new Faker<VendaDTO>("pt_BR")
                .RuleFor(v => v.ClienteId, f => f.Random.Int(1, 1000))
                .RuleFor(v => v.DataVenda, f => f.Date.Recent())
                .RuleFor(v => v.Itens, itens)
                .RuleFor(v => v.ValorTotal,
                    f => itens.Sum(i => i.Quantidade * i.PrecoVenda));
        }
    }
}
