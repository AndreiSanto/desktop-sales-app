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
    

    public class VendaValidatorTest
    {
        [Fact(DisplayName = "Validar Campos de Venda")]
        public void Sucesso_Cadastro()
        {
            var validador = new VendaValidator();
            var vendaDto = VendaDTOBuilder.Build();

            var resultado = validador.Validate(vendaDto);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Erro_Quando_ClienteId_For_Invalido()
        {
            var validador = new VendaValidator();
            var venda = VendaDTOBuilder.Build();
            venda.ClienteId = 0;

            var resultado = validador.Validate(venda);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaDTO.ClienteId)
                           && e.ErrorMessage == "O cliente é obrigatório.");
        }

        [Fact]
        public void Erro_Quando_DataVenda_For_Vazia()
        {
            var validador = new VendaValidator();
            var venda = VendaDTOBuilder.Build();
            venda.DataVenda = default;

            var resultado = validador.Validate(venda);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaDTO.DataVenda)
                           && e.ErrorMessage == "A data da venda é obrigatória.");
        }

        [Fact]
        public void Erro_Quando_Nao_Possuir_Itens()
        {
            var validador = new VendaValidator();
            var venda = VendaDTOBuilder.Build();
            venda.Itens.Clear();

            var resultado = validador.Validate(venda);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName == nameof(VendaDTO.Itens)
                           && e.ErrorMessage == "A venda deve possuir ao menos um item.");
        }

        
        

        [Fact]
        public void Erro_Quando_Item_For_Invalido()
        {
            var validador = new VendaValidator();
            var venda = VendaDTOBuilder.Build();

           
            venda.Itens[0].Quantidade = 0;

            var resultado = validador.Validate(venda);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should()
                .Contain(e => e.PropertyName.Contains(nameof(VendaItemDTO.Quantidade))
                           && e.ErrorMessage == "A quantidade deve ser maior que zero.");
        }
    }

}
