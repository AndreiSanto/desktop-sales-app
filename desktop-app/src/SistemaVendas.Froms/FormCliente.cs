using SistemaVendas.Application.DTOs;
using SistemaVendas.Application.Service.Interface;
using System.Threading.Tasks;

namespace SistemaVendas.Froms
{
    public partial class frmClientes : Form
    {
        private readonly IClienteAppService _clienteAppService;
        private int? clienteIdSelecionado = null;




        public frmClientes(IClienteAppService clienteAppService)
        {
            InitializeComponent();
            _clienteAppService = clienteAppService;
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var clienteDto = new ClienteDTO()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text

            };
            await _clienteAppService.Cadastrar(clienteDto);

        }

        private async void frmClientes_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
            EstadoNovo();
            ConfigurarGrid();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridViewClientes.Rows[e.RowIndex];

            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtTelefone.Text = row.Cells["Telefone"].Value.ToString();

            clienteIdSelecionado = (int)row.Cells["Id"].Value;

            EstadoEdicao();

        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridViewClientes.Rows[e.RowIndex];

            clienteIdSelecionado = (int)row.Cells["Id"].Value;
            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtTelefone.Text = row.Cells["Telefone"].Value.ToString();

            EstadoEdicao();
        }


        private void EstadoNovo()
        {
            clienteIdSelecionado = null;

            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();

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
            var clienteDto = new ClienteDTO
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text
            };

            try
            {
                if (clienteIdSelecionado == null)
                {
                    await _clienteAppService.Cadastrar(clienteDto);
                    MessageBox.Show(
                        "Cliente cadastrado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    var confirmar = MessageBox.Show(
                        "Deseja realmente alterar este cliente?",
                        "Confirmação",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmar == DialogResult.Yes)
                    {
                        await _clienteAppService.Alterar(clienteDto);
                        MessageBox.Show(
                            "Cliente alterado com sucesso!",
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
                    "Ocorreu um erro inesperado ao salvar o cliente.\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (clienteIdSelecionado == null)
                return;

            var confirmar = MessageBox.Show(
                "Deseja realmente excluir este cliente?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                await _clienteAppService.Excluir(clienteIdSelecionado.Value);

                MessageBox.Show(
                    "Cliente excluído com sucesso!",
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
                    "Erro ao excluir",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ConfigurarGrid()
        {
            dataGridViewClientes.AutoGenerateColumns = false;
            dataGridViewClientes.Columns.Clear();

           
            dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Código",
                DataPropertyName = "Id",
                FillWeight = 10 
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                FillWeight = 30
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                FillWeight = 35
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                FillWeight = 25
            });

            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersVisible = false;

            dataGridViewClientes.EnableHeadersVisualStyles = false;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewClientes.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private async Task CarregarGrid()
        {
            var clientes = await _clienteAppService.ListarClientesAsync();
            dataGridViewClientes.DataSource = clientes;
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            EstadoNovo();
        }
    }
}
