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
        public Task<Cliente> CadastrarAsync(Cliente cliente);
      //  public Task<RetornoPaginacao<Cliente>> ListarClientesAsync(int pagina, int totalPatina, FiltroDTO filtroDto);
        public Task<bool> ExcluirAsync(int id);

    }
}
