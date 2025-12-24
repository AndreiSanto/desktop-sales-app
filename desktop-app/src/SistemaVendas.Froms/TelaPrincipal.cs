using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.Froms
{
    public partial class TelaPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form frmAtivo;

        public TelaPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void AbrirForm<T>() where T : Form
        {
            if (frmAtivo != null)
            {
                frmAtivo.Hide();
                frmAtivo.Dispose();
            }

            frmAtivo = _serviceProvider.GetRequiredService<T>();

            frmAtivo.TopLevel = false;
            frmAtivo.FormBorderStyle = FormBorderStyle.None;
            frmAtivo.Dock = DockStyle.Fill;

            panelForm.Controls.Clear();
            panelForm.Controls.Add(frmAtivo);

            frmAtivo.Show();
        }



        private void bntCliente_Click(object sender, EventArgs e)
        {
            AbrirForm<frmClientes>();
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bntProduto_Click(object sender, EventArgs e)
        {
            AbrirForm<frmProdutos>();
        }
    }
}
