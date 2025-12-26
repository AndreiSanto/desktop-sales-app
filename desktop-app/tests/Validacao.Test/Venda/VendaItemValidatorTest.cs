using CommonTestUtilies.RequisicaoDTOs;
using FluentAssertions;
using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao.Test.Venda
{
    

    public class VendaItemValidatorTest
    {
        [Fact(DisplayName = "Validar Campos de Item da Venda")]
        public void Sucesso_Cadastro()
        {
            var validador = new VendaItemValidator();
            var vendaItemDto = VendaItemDTOBuilder.Build();

            var resultado = validador.Validate(vendaItemDto);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Erro_Quando_VendaId_For_Invalido()
        {
            var validador = new VendaItemValidator();
            var item = VendaItemDTOBuilder.Build();
            item.VendaId = 0;

            var resultado = validador.Validate(item);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaItemDTO.VendaId)
                           && e.ErrorMessage == "A venda é obrigatória.");
        }

        [Fact]
        public void Erro_Quando_ProdutoId_For_Invalido()
        {
            var validador = new VendaItemValidator();
            var item = VendaItemDTOBuilder.Build();
            item.ProdutoId = 0;

            var resultado = validador.Validate(item);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaItemDTO.ProdutoId)
                           && e.ErrorMessage == "O produto é obrigatório.");
        }

        [Fact]
        public void Erro_Quando_Quantidade_For_Menor_Ou_Igual_Zero()
        {
            var validador = new VendaItemValidator();
            var item = VendaItemDTOBuilder.Build();
            item.Quantidade = 0;

            var resultado = validador.Validate(item);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaItemDTO.Quantidade)
                           && e.ErrorMessage == "A quantidade deve ser maior que zero.");
        }

        [Fact]
        public void Erro_Quando_PrecoVenda_For_Menor_Ou_Igual_Zero()
        {
            var validador = new VendaItemValidator();
            var item = VendaItemDTOBuilder.Build();
            item.PrecoVenda = 0;

            var resultado = validador.Validate(item);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaItemDTO.PrecoVenda)
                           && e.ErrorMessage == "O preço de venda deve ser maior que zero.");
        }
    }

}
