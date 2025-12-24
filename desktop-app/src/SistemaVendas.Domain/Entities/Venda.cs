using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime DataVenda { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public List<VendaItem> Itens { get; set; } = new();

        public decimal ValorTotal =>
            Itens.Sum(i => i.PrecoVenda * i.Quantidade);
    }

}
