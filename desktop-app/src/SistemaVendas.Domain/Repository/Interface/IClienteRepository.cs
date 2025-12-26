using SistemaVendas.Communication.Response;
using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Repository.Interface
{
    public interface IClienteRepository
    {
        public Task<Cliente> AtualizarAsync(Cliente cliente);
        public Task<Cliente> ObterClienteAsync(int Id);
        public Task<Cliente> CadastrarAsync(Cliente cliente);
       public Task<List<Cliente>> ListarClientesAsync();
        public Task<bool> ExcluirAsync(int id);
        public Task<bool> EmailJaExisteAsync(string email);


    }
}
