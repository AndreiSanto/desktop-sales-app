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

        private void frmClientes_Load(object sender, EventArgs e)
        {
            var clientes = new List<ClienteDTO>
    {
        new ClienteDTO { Nome = "João Silva", Email = "joao.silva@email.com", Telefone = "(27) 99911-2233" },
        new ClienteDTO { Nome = "Maria Oliveira", Email = "maria.oliveira@email.com", Telefone = "(27) 98822-3344" },
        new ClienteDTO { Nome = "Carlos Santos", Email = "carlos.santos@email.com", Telefone = "(27) 97733-4455" },
        new ClienteDTO { Nome = "Ana Pereira", Email = "ana.pereira@email.com", Telefone = "(27) 96644-5566" },
        new ClienteDTO { Nome = "Lucas Costa", Email = "lucas.costa@email.com", Telefone = "(27) 95555-6677" }
    };

            dataGridViewClientes.AutoGenerateColumns = false;
            dataGridViewClientes.Columns.Clear();

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
                Width = 400
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                Width = 200
            });

            dataGridViewClientes.DataSource = clientes;

            EstadoNovo();

            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersVisible = false;

            // Ajuste visual do header
            dataGridViewClientes.EnableHeadersVisualStyles = false;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Gainsboro;
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
            //var clienteIdSelecionado = (int)row.Cells["Id"].Value;

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
                btnSalvar.Text = "Alterar";
                var confirmar = MessageBox.Show(
                    "Deseja realmente alterar este cliente?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    //await _clienteAppService.Atualizar(clienteDto);
                    MessageBox.Show("Cliente alterado com sucesso!");
                }
            }

            EstadoNovo();
            // Recarregar grid depois
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
               // await _clienteAppService.Excluir(clienteIdSelecionado.Value);
                MessageBox.Show("Cliente excluído com sucesso!");

                EstadoNovo();
                // Recarregar grid depois
            }
        }

    }
}
