using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Entities
{
    public class VendaItens
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; } = 0;

        public decimal PrecoVenda { get; set; }
    }
}
