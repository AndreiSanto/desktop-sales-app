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
        private Form frmAtivo;
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void AbrirForm(Form form)
        {
            // Fecha o form ativo, se existir
            if (frmAtivo != null)
                frmAtivo.Close();

            frmAtivo = form;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelForm.Controls.Clear();
            panelForm.Controls.Add(form);
            panelForm.Tag = form;

            form.Show();
        }

        private void bntCliente_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmClientes(null));
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
