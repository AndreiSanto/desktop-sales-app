using CommonTestUtilies.RequisicaoDTOs;
using FluentAssertions;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao.Test.Produto
{
    

    public class ProdutoValidatorTest
    {
        [Fact(DisplayName = "Validar Campos de Produto")]
        public void Sucesso_Cadastro()
        {
            var validador = new ProdutoValidator();
            var produtoDto = ProdutoDTOBuilder.Build();

            var resultado = validador.Validate(produtoDto);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Erro_Quando_Nome_For_Vazio()
        {
            var validador = new ProdutoValidator();
            var produto = ProdutoDTOBuilder.Build();
            produto.Nome = string.Empty;

            var resultado = validador.Validate(produto);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ProdutoDTO.Nome)
                           && e.ErrorMessage == "O nome do produto é obrigatório.");
        }

        [Fact]
        public void Erro_Quando_Descricao_For_Vazia()
        {
            var validador = new ProdutoValidator();
            var produto = ProdutoDTOBuilder.Build();
            produto.Descricao = string.Empty;

            var resultado = validador.Validate(produto);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ProdutoDTO.Descricao)
                           && e.ErrorMessage == "A descrição do produto é obrigatória.");
        }

        [Fact]
        public void Erro_Quando_Preco_For_Menor_Ou_Igual_Zero()
        {
            var validador = new ProdutoValidator();
            var produto = ProdutoDTOBuilder.Build();
            produto.Preco = 0;

            var resultado = validador.Validate(produto);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ProdutoDTO.Preco)
                           && e.ErrorMessage == "O preço deve ser maior que zero.");
        }

        [Fact]
        public void Erro_Quando_QtdEstoque_For_Menor_Ou_Igual_Zero()
        {
            var validador = new ProdutoValidator();
            var produto = ProdutoDTOBuilder.Build();
            produto.QtdEstoque = 0;

            var resultado = validador.Validate(produto);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(ProdutoDTO.QtdEstoque)
                           && e.ErrorMessage == "A quantidade em estoque deve ser maior que zero.");
        }
    }

}
