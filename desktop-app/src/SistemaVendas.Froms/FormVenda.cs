using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Domain.Entities;
using System.Threading.Tasks;

namespace SistemaVendas.Froms
{
    public partial class frmVendas : Form
    {

        private int? produtoIdSelecionado = null;
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;





        public frmVendas(IProdutoAppService produtoAppService, IClienteAppService clienteAppService)
        {
            InitializeComponent();
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private async void frmVendas_Load(object sender, EventArgs e)
        {

            await CarregarClientes();
            await CarregarProdutos();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void dataGridViewVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


        }







        private async void btnSalvar_Click(object sender, EventArgs e)
        {


            var produtoDto = new ProdutoDTO
            {
                Id = produtoIdSelecionado ?? 0,

            };

            if (produtoIdSelecionado == null)
            {
                await _produtoAppService.Cadastrar(produtoDto);
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            else
            {
                var confirmar = MessageBox.Show(
                    "Deseja realmente alterar este produto?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    await _produtoAppService.Alterar(produtoDto);
                    MessageBox.Show("Produto alterado com sucesso!");
                }
            }

        }


        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (produtoIdSelecionado == null)
                return;

            var confirmar = MessageBox.Show(
                "Deseja realmente excluir este produto?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar == DialogResult.Yes)
            {
                MessageBox.Show("Produto excluído com sucesso!");




            }
        }

        private async Task CarregarClientes()
        {
            var clientes = await _clienteAppService.ListarClientesAsync(); //mudar pra trazer o DTO

            cbClientes.DataSource = clientes;
            cbClientes.DisplayMember = "Nome";
            cbClientes.ValueMember = "Id";
            cbClientes.SelectedIndex = -1;
        }

        private async Task CarregarProdutos()
        {
            var produtos = await _produtoAppService.ListarProdutosAsync();

            cbProdutos.DataSource = produtos;
            cbProdutos.DisplayMember = "Nome";
            cbProdutos.ValueMember = "Id";
            cbProdutos.SelectedIndex = -1;
        }



        private void ConfigurarCampos()
        {

        }







        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nudPreco_ValueChanged(object sender, EventArgs e)
        {

        }





        private void dataGridViewVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBoxProduto_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProdutos.SelectedItem == null)
                return;
            var produto = (Produto)cbProdutos.SelectedItem;
            nudQuantidade.Text = produto.Preco.ToString("N2");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (cbProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            var produto = (Produto)cbProdutos.SelectedItem;
            var quantidade = (int)nudQuantidade.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            if (quantidade > produto.QtdEstoque)
            {
                MessageBox.Show("Estoque insuficiente.");
                return;
            }

            var subtotal = quantidade * produto.Preco;
            dataGridViewItensVenda.AutoGenerateColumns = false;


            dataGridViewItensVenda.Rows.Add(
                produto.Id,          // oculto
                produto.Nome,
                quantidade,
                produto.Preco,
                subtotal
            );

            // Atualiza estoque local (importante!)
            produto.QtdEstoque -= quantidade;

            AtualizarTotal();
        }


        private void AtualizarTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewItensVenda.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            lblTotal.Text = $"Total: R$ {total:N2}";
        }


    }
}
