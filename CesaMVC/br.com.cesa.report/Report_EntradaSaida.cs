using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.report
{
    public partial class Report_EntradaSaida : Form
    {
        public Report_EntradaSaida()
        {
            InitializeComponent();
        }

        private void Report_EntradaSaida_Load(object sender, EventArgs e)
        {
            DtInicial.Value = DateTime.Today;
            DtFinal.Value = DateTime.Today;
            CbTipo.SelectedIndex = 0;
            BuscarData();
        }

        private void BuscarData()
        {           
            // TODO: esta linha de código carrega dados na tabela 'cesadbDataSet.EntradaSaida'. Você pode movê-la ou removê-la conforme necessário.
            this.entradaSaidaTableAdapter.Fill(this.cesadbDataSet.EntradaSaida, Convert.ToDateTime(DtInicial.Text), Convert.ToDateTime(DtFinal.Text), CbTipo.Text);

            // Buscar o parametro
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", DtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", DtFinal.Text));

            this.reportViewer1.RefreshReport();
        }

        private void CbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
