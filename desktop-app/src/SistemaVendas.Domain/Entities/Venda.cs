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

        public DateTime DataVenda {  get; set; }

        public decimal ValorTotal { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

    }
}
