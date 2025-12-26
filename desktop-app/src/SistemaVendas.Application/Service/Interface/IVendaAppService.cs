using SistemaVendas.Application.DTOs;
using SistemaVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service.Interface
{
    public interface IVendaAppService
    {
        public Task RealizarVenda(VendaDTO vendaDto);

        public Task<List<RelatorioVendaModel>> Gerar(DateTime inicio, DateTime fim);

    }
}
