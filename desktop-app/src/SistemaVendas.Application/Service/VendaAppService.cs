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
    public class VendaAppService : IVendaAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaAppService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository,
            IProdutoRepository produtoRepository)
        {
            _unitOfWork = unitOfWork;
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task RealizarVenda(VendaDTO vendaDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                foreach (var item in vendaDTO.Itens)
                {
                    var produto = await _produtoRepository.ObterProdutoAsync(item.ProdutoId);

                    if (produto.QtdEstoque < item.Quantidade)
                        throw new Exception($"Estoque insuficiente para o produto {produto.Nome}");
                }

                var venda = _mapper.Map<Venda>(vendaDTO);

                var vendaId = await _vendaRepository.CriarVendaAsync(venda);

                foreach (var item in vendaDTO.Itens)
                {
                    var vendaItem = _mapper.Map<VendaItem>(item); 

                    vendaItem.VendaId = vendaId;

                    await _vendaRepository.CriarItemVendaAsync(vendaItem);
                    await _produtoRepository.BaixarEstoqueAsync(item.ProdutoId, item.Quantidade);
                }

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

    }

}
