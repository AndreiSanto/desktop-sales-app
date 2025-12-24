using AutoMapper;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<VendaDTO, Venda>().ForMember(a => a.ValorTotal, b => b.Ignore());
            CreateMap<VendaItemDTO, VendaItem>();

        }
    }
}
