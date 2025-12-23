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
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteDTO> Cadastrar(ClienteDTO clienteDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);

                await _clienteRepository.CadastrarAsync(cliente);

                await _unitOfWork.CommitAsync();

                return clienteDTO;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }


        public Task<bool> Excluir(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }
    }
}
