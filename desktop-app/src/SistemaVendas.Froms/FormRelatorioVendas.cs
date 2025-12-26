using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Froms.Relatorio;
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
    public partial class FormRelatorioVendas : Form
    {
        private readonly IVendaAppService _vendaAppService;

        public FormRelatorioVendas(IVendaAppService vendaAppService)
        {
            InitializeComponent();
            _vendaAppService = vendaAppService;
        }

        private void FormRelatorioVendas_Load(object sender, EventArgs e)
        {

        }

        private void bntGerar_Click(object sender, EventArgs e)
        {
            var dataInicio = dtInicio.Value.Date;
            var dataFim = dtFim.Value.Date;

            var frm = new RelatorioVendas(dataInicio, dataFim, _vendaAppService);
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
