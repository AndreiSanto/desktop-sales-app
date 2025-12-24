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

            // Se tiver ID (recomendado)
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

            btnNovo.Enabled = true;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void EstadoEdicao()
        {
            btnNovo.Enabled = false;
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

            if (clienteIdSelecionado == null)
            {
                await _clienteAppService.Cadastrar(clienteDto);
                MessageBox.Show("Cliente cadastrado com sucesso!");
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
                    MessageBox.Show("Cliente alterado com sucesso!");
                }
            }

            EstadoNovo();
            await CarregarGrid();
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

            if (confirmar == DialogResult.Yes)
            {
               await _clienteAppService.Excluir(clienteIdSelecionado.Value);
                MessageBox.Show("Cliente excluído com sucesso!");

                EstadoNovo();
                await CarregarGrid();


            }
        }

        private void ConfigurarGrid()
        {
            dataGridViewClientes.AutoGenerateColumns = false;
            dataGridViewClientes.Columns.Clear();

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Código",
                DataPropertyName = "Id",
                Width = 80
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 300
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                Width = 350
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                Width = 200
            });

            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersVisible = false;

            // Evita header "selecionado"
            dataGridViewClientes.EnableHeadersVisualStyles = false;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dataGridViewClientes.ColumnHeadersDefaultCellStyle.BackColor;
        }
        private async Task CarregarGrid()
        {
            var clientes = await _clienteAppService.ListarClientesAsync();
            dataGridViewClientes.DataSource = clientes;
        }


    }
}
