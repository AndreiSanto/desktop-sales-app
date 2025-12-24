using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Entities
{
    public class VendaItem
    {
        public int Id { get; set; }

        public int VendaId { get; set; }
        public Venda Venda { get; set; } = null!;

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        public int Quantidade { get; set; }

        public decimal PrecoVenda { get; set; }
    }

}
