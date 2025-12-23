using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.DTOs
{
    public class VendaItemDTO
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; } = 0;

        public decimal PrecoVenda { get; set; }
    }
}
