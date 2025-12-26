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

namespace AppServiceTest.Produto
{
    public class ProdutoAppServiceTest
    {

        [Fact(DisplayName = "Cadastrar produto com sucesso")]
        public async Task Sucesso_Cadastro_Produto()
        {
           
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();

           
            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            
            await act.Should().NotThrowAsync();
        }


        [Fact(DisplayName = "Erro ao cadastrar um produto com o campo nome vazio")]
        public async Task Error_Nome_Vazio()
        {
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();
            produtoDTO.Nome = string.Empty;

            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("O nome do produto é obrigatório.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um produto com o campo descrição vazio")]
        public async Task Error_Descricao_Vazia()
        {
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();
            produtoDTO.Descricao = string.Empty;

            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("A descrição do produto é obrigatória.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um produto com o preço igual a zero")]
        public async Task Error_Preco_Zero()
        {
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();
            produtoDTO.Preco = 0;

            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("O preço deve ser maior que zero.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um produto com o preço negativo")]
        public async Task Error_Preco_Negativo()
        {
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();
            produtoDTO.Preco = -10;

            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("O preço deve ser maior que zero.");
        }

        [Fact(DisplayName = "Erro ao cadastrar um produto com estoque negativo")]
        public async Task Error_QtdEstoque_Negativo()
        {
            var produtoDTO = ProdutoDTOBuilder.Build();
            var produto = this.Create();
            produtoDTO.QtdEstoque = -1;

            Func<Task> act = async () => await produto.Cadastrar(produtoDTO);

            var exception = (await act.Should()
                .ThrowAsync<FluentValidation.ValidationException>())
                .Which;

            exception.Message.Should().Be("A quantidade em estoque deve ser maior que zero.");
        }





        private ProdutoAppService Create()
        {
            var mapper = MapperBuilder.Build();

            var produtoRepositoryBuild = ProdutoRepositoryBuilder.Build();

            var unitOfWork = UnitOfWorkBuilder.Build();



            return new ProdutoAppService(produtoRepositoryBuild, mapper, unitOfWork);

        }

    }
}
