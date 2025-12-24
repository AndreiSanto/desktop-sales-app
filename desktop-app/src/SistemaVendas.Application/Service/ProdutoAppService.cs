using AutoMapper;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Service
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoDTO> Alterar(ProdutoDTO produtoDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                var produto = _mapper.Map<Produto>(produtoDTO);

                await _produtoRepository.AtualizarAsync(produto);

                await _unitOfWork.CommitAsync();

                return produtoDTO;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ProdutoDTO> Cadastrar(ProdutoDTO produtoDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                var produto = _mapper.Map<Produto>(produtoDTO);

                await _produtoRepository.CadastrarAsync(produto);

                await _unitOfWork.CommitAsync();

                return produtoDTO;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> Excluir(int id)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                var produto = await _produtoRepository.ObterProdutoAsync(id);



                await _produtoRepository.ExcluirAsync(id);

                await _unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                throw;
            }
        }

        public async Task<List<Produto>> ListarProdutosAsync()
        {
            await _unitOfWork.BeginAsync();

            try
            {
                return await _produtoRepository.ListarProdutoAsync();

            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                throw;
            }
        }
    }
}
