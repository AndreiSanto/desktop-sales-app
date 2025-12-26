using CommonTestUtilies.RequisicaoDTOs;
using FluentAssertions;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao.Test.Cliente
{
    public class ClienteValidatorTest
    {

        [Fact(DisplayName = "Validar Campos de Cliente")]
        public void Sucesso_Cadastro()
        {

            var validador = new ClienteValidator();

            var clienteDto = ClienteDTOBuilder.Build();

            var resultado = validador.Validate(clienteDto);

            resultado.IsValid.Should().BeTrue();

        }

        [Fact]
        public void Erro_Quando_Telefone_For_Invalido()
        {
            var validador = new ClienteValidator();
            var cliente = ClienteDTOBuilder.Build();
            cliente.Telefone = "123";

            var resultado = validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();

            resultado.IsValid.Should().BeFalse("O telefone deve conter 10 ou 11 números.");

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ClienteDTO.Telefone)
                           && e.ErrorMessage == "O telefone deve conter 10 ou 11 números.");
        }

        [Fact]
        public void Erro_Quando_Telefone_For_Vazio()
        {
            var validador = new ClienteValidator();
            var cliente = ClienteDTOBuilder.Build();
            cliente.Telefone = string.Empty;

            var resultado = validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();

            resultado.IsValid.Should().BeFalse("O telefone é obrigatório.");

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ClienteDTO.Telefone)
                           && e.ErrorMessage == "O telefone é obrigatório.");
        }

        [Fact]
        public void Erro_Quando_Email_For_Vazio()
        {
            var validador = new ClienteValidator();
            var cliente = ClienteDTOBuilder.Build();
            cliente.Email =  string.Empty;

            var resultado = validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();

            resultado.IsValid.Should().BeFalse("O e-mail é obrigatório.");

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ClienteDTO.Email)
                           && e.ErrorMessage == "O e-mail é obrigatório.");
        }

        [Fact]
        public void Erro_Quando_Email_For_Invalido()
        {
            var validador = new ClienteValidator();
            var cliente = ClienteDTOBuilder.Build();
            cliente.Email = "1233";

            var resultado = validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();

            resultado.IsValid.Should().BeFalse("O e-mail informado é inválido.");

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ClienteDTO.Email)
                           && e.ErrorMessage == "O e-mail informado é inválido.");
        }

        [Fact]
        public void Erro_Quando_Nome_For_Vazio()
        {
            var validador = new ClienteValidator();
            var cliente = ClienteDTOBuilder.Build();
            cliente.Nome = string.Empty;

            var resultado = validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();

            resultado.IsValid.Should().BeFalse("O nome do cliente é obrigatório.");

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ClienteDTO.Nome)
                           && e.ErrorMessage == "O nome do cliente é obrigatório.");
        }

    }
}
