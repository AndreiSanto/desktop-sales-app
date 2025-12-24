using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Repository.Interface
{
    public interface IProdutoRepository
    {

        public Task<Produto> AtualizarAsync(Produto produto);
        public Task<Produto> ObterProdutoAsync(int Id);
        public Task<Produto> CadastrarAsync(Produto produto);
        public Task<List<Produto>> ListarProdutoAsync();
        public Task<bool> ExcluirAsync(int id);
    }
}
