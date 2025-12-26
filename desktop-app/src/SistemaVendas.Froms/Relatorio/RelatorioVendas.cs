using Microsoft.Reporting.WinForms;
using SistemaVendas.Application.Service;
using SistemaVendas.Application.Service.Interface;
using SistemaVendas.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.Froms.Relatorio
{
    public partial class RelatorioVendas : Form
    {
        private readonly DateTime _dataInicio;
        private readonly DateTime _dataFim;
        private readonly IVendaAppService _vendaAppService;

        public RelatorioVendas(
            DateTime dataInicio,
            DateTime dataFim, IVendaAppService vendaAppService)
        {
            InitializeComponent();

            _dataInicio = dataInicio;
            _dataFim = dataFim;
            _vendaAppService = vendaAppService;

        }


private async Task CarregarRelatorio()
    {
        reportViewerVendas.Reset();

        reportViewerVendas.ProcessingMode = ProcessingMode.Local;

        reportViewerVendas.LocalReport.ReportEmbeddedResource =
            "SistemaVendas.Froms.Relatorio.RelatorioVendas.rdlc";

        var dados = await _vendaAppService
            .Gerar(_dataInicio.Date, _dataFim.Date.AddDays(1));

        if (dados == null || dados.Count == 0)
        {
            MessageBox.Show("Nenhum dado encontrado.");
            return;
        }
            var recursos = GetType().Assembly.GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", recursos));


            reportViewerVendas.LocalReport.DataSources.Clear();

        reportViewerVendas.LocalReport.DataSources.Add(
            new ReportDataSource("dsRelatorioVendas", dados)
        );

        reportViewerVendas.RefreshReport();
    }


    private async void RelatorioVendas_Load(object sender, EventArgs e)
        {
            await CarregarRelatorio();
        }
    }



}

