using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service.Interface
{
    public interface IProdutoAppService
    {
        public Task<ProdutoDTO> Cadastrar(ProdutoDTO produtoDTO);
        public Task<ProdutoDTO> Alterar(ProdutoDTO produtoDTO);
        public Task<bool> Excluir(ProdutoDTO produtoDTO);
    }
}
