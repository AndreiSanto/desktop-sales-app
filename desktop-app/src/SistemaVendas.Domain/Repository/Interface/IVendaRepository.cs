using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Repository.Interface
{
    public  interface IVendaRepository
    {
       public  Task<int> CriarVendaAsync(Venda venda);
        public Task CriarItemVendaAsync(VendaItem item);
    }
}
