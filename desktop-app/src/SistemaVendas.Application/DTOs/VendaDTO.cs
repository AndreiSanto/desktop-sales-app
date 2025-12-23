using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.DTOs
{
    public class VendaDTO
    {
        public int ClientId { get; set; }


        public IList<VendaItemDTO> VendaItensDTOs {  get; set; }

        public VendaDTO() {

            this.VendaItensDTOs = new List<VendaItemDTO>();
        }
    }
}
