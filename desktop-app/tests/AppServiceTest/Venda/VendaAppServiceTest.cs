using CommonTestUtilies.Mapper;
using CommonTestUtilies.Repositories;
using CommonTestUtilies.RequisicaoDTOs;
using FluentAssertions;
using FluentValidation;
using SistemaVendas.Application.Service;


namespace AppServiceTest.Venda
{
    public class VendaAppServiceTest
    {
        [Fact(DisplayName = "Cadastrar venda com sucesso")]
        public async Task Sucesso_Cadastro_Venda()
        {
            var vendaDTO = VendaDTOBuilder.Build();

            var produtoDTO = ProdutoDTOBuilder.Build();
            foreach (var item in vendaDTO.Itens)
            {
                item.ProdutoId = produtoDTO.Id;
            }

            var venda = this.Create();

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            await act.Should().NotThrowAsync();
        }

        [Fact(DisplayName = "Erro ao cadastrar venda com ClienteId inválido")]
        public async Task Error_ClienteId_Invalido()
        {
            var vendaDTO = VendaDTOBuilder.Build();
            var venda = this.Create();
            vendaDTO.ClienteId = 0;

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            var exception = (await act.Should()
                .ThrowAsync<ValidationException>())
                .Which;

            exception.Message.Should().Be("O cliente é obrigatório.");
        }

        [Fact(DisplayName = "Erro ao cadastrar venda sem itens")]
        public async Task Error_Sem_Itens()
        {
            var vendaDTO = VendaDTOBuilder.Build();
            var venda = this.Create();
            vendaDTO.Itens.Clear();

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            var exception = (await act.Should()
                .ThrowAsync<ValidationException>())
                .Which;

            exception.Message.Should().Be("A venda deve possuir ao menos um item.");
        }

        [Fact(DisplayName = "Erro ao cadastrar venda com data inválida")]
        public async Task Error_DataVenda_Invalida()
        {
            var vendaDTO = VendaDTOBuilder.Build();
            var venda = this.Create();
            vendaDTO.DataVenda = default;

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            var exception = (await act.Should()
                .ThrowAsync<ValidationException>())
                .Which;

            exception.Message.Should().Be("A data da venda é obrigatória.");
        }

        [Fact(DisplayName = "Erro ao cadastrar venda com valor total inválido")]
        public async Task Error_ValorTotal_Invalido()
        {
            var vendaDTO = VendaDTOBuilder.Build();
            var venda = this.Create();
            vendaDTO.ValorTotal = 0;

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            var exception = (await act.Should()
                .ThrowAsync<ValidationException>())
                .Which;

            exception.Message.Should().Be("O valor total da venda deve ser maior que zero.");
        }

        [Fact(DisplayName = "Erro ao cadastrar venda com item inválido")]
        public async Task Error_Item_Invalido()
        {
            var vendaDTO = VendaDTOBuilder.Build();
            var venda = this.Create();

            // invalida o primeiro item
            vendaDTO.Itens[0].Quantidade = 0;

            Func<Task> act = async () => await venda.RealizarVenda(vendaDTO);

            var exception = (await act.Should()
                .ThrowAsync<ValidationException>())
                .Which;

            exception.Errors.Should()
                .Contain(e => e.ErrorMessage == "A quantidade deve ser maior que zero.");
        }

        private VendaAppService Create()
        {
            var mapper = MapperBuilder.Build();

            var vendaRepositoryBuild = VendaRepositoryBuilder.Build();
            var produtoRepositoryBuild = ProdutoRepositoryBuilder.Build();

            var unitOfWork = UnitOfWorkBuilder.Build();



            return new VendaAppService(unitOfWork,vendaRepositoryBuild, produtoRepositoryBuild, mapper);

        }
    }
}
