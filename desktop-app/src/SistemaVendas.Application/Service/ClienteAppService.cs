using AutoMapper;
using FluentValidation;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Application.Validation;
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

        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                ValidarDados(clienteDTO);
                var cliente = _mapper.Map<Cliente>(clienteDTO);

                await _clienteRepository.AtualizarAsync(cliente);

                await _unitOfWork.CommitAsync();

                return clienteDTO;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ClienteDTO> Cadastrar(ClienteDTO clienteDTO)
        {
            await _unitOfWork.BeginAsync();

            try
            {
                var emailExiste = await _clienteRepository.EmailJaExisteAsync(clienteDTO.Email);

                if (emailExiste)
                    throw new ValidationException(
                        "O e-mail informado já está cadastrado."
                    );
                ValidarDados(clienteDTO);


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


        public async Task<bool> Excluir(int id)
        {

            await _unitOfWork.BeginAsync();

            try
            {
                var cliente = await _clienteRepository.ObterClienteAsync(id);

                

                await _clienteRepository.ExcluirAsync(cliente.Id);

                await _unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                
                throw;
            }

        }

        public async Task<List<Cliente>> ListarClientesAsync()
        {
            await _unitOfWork.BeginAsync();

            try
            {
                return await _clienteRepository.ListarClientesAsync();

            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                throw;
            }
        }

        private void ValidarDados(ClienteDTO clienteDTO)
        {
            var validator = new ClienteValidator();
            var resultado = validator.Validate(clienteDTO);
            if (resultado.IsValid == false)
            {
                var erroMenssage = resultado.Errors.Select(a => a.ErrorMessage).FirstOrDefault();

                throw new ValidationException(erroMenssage);
            }

        }
    }
}
