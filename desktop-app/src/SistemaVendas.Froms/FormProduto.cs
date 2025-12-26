using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Domain.Entities;
using System.Threading.Tasks;

namespace SistemaVendas.Froms
{
    public partial class frmProdutos : Form
    {

        private int? produtoIdSelecionado = null;
        private readonly IProdutoAppService _produtoAppService;




        public frmProdutos(IProdutoAppService produtoAppService)
        {
            InitializeComponent();
            _produtoAppService = produtoAppService;
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private async void frmProdutos_Load(object sender, EventArgs e)
        {
            ConfigurarCampos();
            await CarregarGrid();
            EstadoNovo();
            ConfigurarGrid();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void dataGridViewProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridViewProdutos.Rows[e.RowIndex];

            produtoIdSelecionado = (int)row.Cells["Id"].Value;

            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            nudPreco.Value = Convert.ToDecimal(row.Cells["Preco"].Value);
            nudEstoque.Value = Convert.ToInt32(row.Cells["QtdEstoque"].Value);

            EstadoEdicao();
        }



        private void EstadoNovo()
        {
            produtoIdSelecionado = null;

            txtNome.Clear();
            txtDescricao.Clear();
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void EstadoEdicao()
        {
            btnSalvar.Enabled = true;
            btnSalvar.Text = "Alterar";
            btnExcluir.Enabled = true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            try
            {
                var produtoDto = new ProdutoDTO
                {
                    Id = produtoIdSelecionado ?? 0,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    Preco = nudPreco.Value,
                    QtdEstoque = (int)nudEstoque.Value
                };

                if (produtoIdSelecionado == null)
                {
                    await _produtoAppService.Cadastrar(produtoDto);

                    MessageBox.Show(
                        "Produto cadastrado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
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

                        MessageBox.Show(
                            "Produto alterado com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }

                EstadoNovo();
                await CarregarGrid();
            }
            catch (FluentValidation.ValidationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro de validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocorreu um erro inesperado:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                await _produtoAppService.Excluir(produtoIdSelecionado.Value);

                MessageBox.Show(
                    "Produto excluído com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                EstadoNovo();
                await CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro ao excluir produto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ConfigurarCampos()
        {
            nudPreco.DecimalPlaces = 2;
            nudPreco.Minimum = 0.01M;
            nudPreco.Maximum = 999999;

            nudEstoque.Minimum = 0;
            nudEstoque.Maximum = 100000;
        }


        private void ConfigurarGrid()
        {
            dataGridViewProdutos.AutoGenerateColumns = false;
            dataGridViewProdutos.Columns.Clear();

            dataGridViewProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Código",
                DataPropertyName = "Id",
                FillWeight = 8
            });

            dataGridViewProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                FillWeight = 25
            });

            dataGridViewProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descricao",
                HeaderText = "Descrição",
                DataPropertyName = "Descricao",
                FillWeight = 32
            });

            dataGridViewProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Preco",
                HeaderText = "Preço",
                DataPropertyName = "Preco",
                FillWeight = 15,
                DefaultCellStyle = { Format = "C2" }
            });

            dataGridViewProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QtdEstoque",
                HeaderText = "Estoque",
                DataPropertyName = "QtdEstoque",
                FillWeight = 20
            });

            dataGridViewProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProdutos.MultiSelect = false;
            dataGridViewProdutos.ReadOnly = true;
            dataGridViewProdutos.RowHeadersVisible = false;

            dataGridViewProdutos.EnableHeadersVisualStyles = false;
            dataGridViewProdutos.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewProdutos.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private async Task CarregarGrid()
        {
            var produtos = await _produtoAppService.ListarProdutosAsync();
            dataGridViewProdutos.DataSource = produtos;
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nudPreco_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome");
                return false;
            }

            if (nudPreco.Value <= 0)
            {
                MessageBox.Show("Preço deve ser maior que zero");
                return false;
            }

            if (nudEstoque.Value < 0)
            {
                MessageBox.Show("Estoque não pode ser negativo");
                return false;
            }

            return true;
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            nudPreco.Value = 0.01M;
            nudEstoque.Value = 0;
            produtoIdSelecionado = null;
        }

        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
