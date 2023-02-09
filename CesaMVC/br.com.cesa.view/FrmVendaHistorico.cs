using CesaMVC.br.com.cesa.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmVendaHistorico : Form
    {
        public FrmVendaHistorico()
        {
            InitializeComponent();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicial, dataFinal;

            dataInicial = Convert.ToDateTime(DtInicial.Value.ToString("yyyy-MM-dd"));
            dataFinal = Convert.ToDateTime(DtFinal.Value.ToString("yyyy-MM-dd"));

            VendaDAO dao = new VendaDAO();
            Grid.DataSource = dao.ListarVendasPorPeriodo(dataInicial, dataFinal);
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Passando o id da venda
            int venda_id = int.Parse(Grid.CurrentRow.Cells[0].Value.ToString());
            FrmVendaDetalhes form = new FrmVendaDetalhes(venda_id);

            // Formatando a data
            DateTime dataVenda = Convert.ToDateTime(Grid.CurrentRow.Cells[2].Value.ToString());
            form.lblData.Text = dataVenda.ToString("dd-MM-yyyy");

            form.lblFuncionario.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            form.lblTotalVenda.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            form.txtObs.Text = Grid.CurrentRow.Cells[4].Value.ToString();

            form.ShowDialog();
        }
    }
}
