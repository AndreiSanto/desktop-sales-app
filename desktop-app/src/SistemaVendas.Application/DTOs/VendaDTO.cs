using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.DTOs
{

    public class VendaDTO
    {
        public int ClienteId { get; set; }

        public DateTime DataVenda { get; set; } = DateTime.Now;

        public List<VendaItemDTO> Itens { get; set; } = new();

        public decimal ValorTotal { get; set; }
    }


}

