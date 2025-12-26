using CommonTestUtilies.Mapper;
using CommonTestUtilies.Repositories;
using CommonTestUtilies.RequisicaoDTOs;
using FluentAssertions;
using SistemaVendas.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceTest.Cliente
{
    public class ClienteAppServiceTest
    {

        [Fact(DisplayName = "Criação do cliente")]
        public async Task Sucesso()
        {

            var clienteDTO = ClienteDTOBuilder.Build();

            var cliente = this.Create();

            var resultado = await cliente.Cadastrar(clienteDTO);

            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be(clienteDTO.Nome);


        }

        [Fact(DisplayName = "Erro ao cadastrar um cliente com o campo email vazio")]
        public async Task Error_Email_Vazio()
        {

            var clienteDTO = ClienteDTOBuilder.Build();
            var cliente = this.Create();
            clienteDTO.Email = string.Empty;


            Func<Task> act = async () => await cliente.Cadastrar(clienteDTO);


            var exception = (await act.Should()
    .ThrowAsync<FluentValidation.ValidationException>())
    .Which;

            exception.Message.Should().Be("O e-mail é obrigatório.");
        }


        [Fact(DisplayName = "Erro ao cadastrar um cliente com o campo email invalido")]
        public async Task Error_Email_Invalido()
        {

            var clienteDTO = ClienteDTOBuilder.Build();
            var cliente = this.Create();
            clienteDTO.Email = "sadsadsa.com";


            Func<Task> act = async () => await cliente.Cadastrar(clienteDTO);


            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;


            exception.Message.Should().Be("O e-mail informado é inválido.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um cliente com o campo nome vazio")]
        public async Task Error_Nome_Vazio()
        {
            var clienteDTO = ClienteDTOBuilder.Build();
            var cliente = this.Create();
            clienteDTO.Nome = string.Empty;

            Func<Task> act = async () => await cliente.Cadastrar(clienteDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("O nome do cliente é obrigatório.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um cliente com o campo telefone vazio")]
        public async Task Error_Telefone_Vazio()
        {
            var clienteDTO = ClienteDTOBuilder.Build();
            var cliente = this.Create();
            clienteDTO.Telefone = string.Empty;

            Func<Task> act = async () => await cliente.Cadastrar(clienteDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("O telefone é obrigatório.");
        }



        private ClienteAppService Create()
        {
            var mapper = MapperBuilder.Build();

            var clienteRepositoryBuild = ClienteRepositoryBuilder.Build();

            var unitOfWork = UnitOfWorkBuilder.Build();

           

            return new ClienteAppService(clienteRepositoryBuild,mapper,unitOfWork);

        }

    }
}
