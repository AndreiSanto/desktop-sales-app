using SistemaVendas.Application.DTOs;
using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service.Interface
{
    public interface IClienteAppService
    {
        public Task<ClienteDTO> Cadastrar(ClienteDTO clienteDTO);
        public Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
        public Task<bool> Excluir(int Id);
        public Task<List<Cliente>> ListarClientesAsync();


    }
}
