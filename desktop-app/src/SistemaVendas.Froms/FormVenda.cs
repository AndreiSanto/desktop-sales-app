using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.Froms
{
    public partial class frmVendas : Form
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IVendaAppService _vendaAppService;

        public frmVendas(
            IProdutoAppService produtoAppService,
            IClienteAppService clienteAppService,
            IVendaAppService vendaAppService)
        {
            InitializeComponent();
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
            _vendaAppService = vendaAppService;
        }

        // ========================= LOAD =========================
        private async void frmVendas_Load(object sender, EventArgs e)
        {
            await CarregarClientes();
            await CarregarProdutos();

            dataGridViewItensVenda.AutoGenerateColumns = false;
        }

        // ========================= CLIENTES =========================
        private async Task CarregarClientes()
        {
            var clientes = await _clienteAppService.ListarClientesAsync();

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

        private void cbProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProdutos.SelectedItem == null)
                return;

            var produto = (Produto)cbProdutos.SelectedItem;
            nudPreco.Text = produto.Preco.ToString("N2");
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

            dataGridViewItensVenda.Rows.Add(
                produto.Id,          // ProdutoId (oculto)
                produto.Nome,
                quantidade,
                produto.Preco,
                subtotal
            );

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

        private async void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            if (dataGridViewItensVenda.Rows.Count == 0)
            {
                MessageBox.Show("Adicione produtos à venda.");
                return;
            }

            var vendaDTO = new VendaDTO
            {
                ClienteId = (int)cbClientes.SelectedValue,
                DataVenda = DateTime.Now
            };

            foreach (DataGridViewRow row in dataGridViewItensVenda.Rows)
            {
                vendaDTO.Itens.Add(new VendaItemDTO
                {
                    ProdutoId = Convert.ToInt32(row.Cells["ProdutoId"].Value),
                    Quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value),
                    PrecoVenda = Convert.ToDecimal(row.Cells["Preco"].Value)
                });
            }

            vendaDTO.ValorTotal =
                vendaDTO.Itens.Sum(i => i.PrecoVenda * i.Quantidade);

            await _vendaAppService.RealizarVenda(vendaDTO);

            MessageBox.Show("Venda realizada com sucesso!");

            dataGridViewItensVenda.Rows.Clear();
            lblTotal.Text = "Total: R$ 0,00";
            cbClientes.SelectedIndex = -1;
        }

       
    }
}
