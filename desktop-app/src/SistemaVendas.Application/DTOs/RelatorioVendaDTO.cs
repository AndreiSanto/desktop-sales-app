using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.DTOs
{
    public class RelatorioVendaDTO
    {

        public string Cliente { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public decimal Subtotal => Quantidade * Preco;
    }
}

