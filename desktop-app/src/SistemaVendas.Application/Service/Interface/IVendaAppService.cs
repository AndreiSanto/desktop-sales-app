using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service.Interface
{
    public interface IVendaAppService
    {
        Task<int> RealizarVendaAsync(VendaDTO vendaDto);
    }
}
