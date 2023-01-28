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
    public partial class FrmMovimentacao : Form
    {
        double totalEntradas, totalSaidas;
        public FrmMovimentacao()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID_MOVIMENTACAO";
            Grid.Columns[1].HeaderText = "TIPO";
            Grid.Columns[2].HeaderText = "MOVIMENTO";
            Grid.Columns[3].HeaderText = "VALOR";
            Grid.Columns[4].HeaderText = "FUNCIONARIO";
            Grid.Columns[5].HeaderText = "DATA";
            Grid.Columns[6].HeaderText = "ID_MOVIMENTO";

            // Visibilidade das colunas no Grid
            Grid.Columns[0].Visible = false;
            Grid.Columns[6].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            //FORMATAR COLUNA PARA MOEDA
            Grid.Columns[3].DefaultCellStyle.Format = "C2";

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Grid.Columns[1].Width = 100;
            Grid.Columns[2].Width = 110;
            Grid.Columns[3].Width = 103;
            Grid.Columns[4].Width = 160;
            Grid.Columns[5].Width = 100;

            // Função para totalizar o  valores do Grid
            TotalizarSaidas();
            TotalizarEntradas();
            Totalizar();
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            CbBuscar.SelectedIndex = 0;
            TxtDataInicial.Value = DateTime.Today;
            TxtDataFinal.Value = DateTime.Today;
            BuscarData();
        }

        private void TotalizarSaidas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells["tipo"].Value.ToString() == "Saida")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
            }
            totalSaidas = total;
            lblSaidas.Text = Convert.ToDouble(total).ToString("C2");
        }

        private void TotalizarEntradas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells["tipo"].Value.ToString() == "Entrada")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
            }
            totalEntradas = total;
            lblEntradas.Text = Convert.ToDouble(total).ToString("C2");
        }

        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                total = totalEntradas - totalSaidas;
            }
            lblTotal.Text = Convert.ToDouble(total).ToString("C2");

            if (total >= 0)
            {
                lblTotal.ForeColor = Color.Green;
            }
            else
            {
                lblTotal.ForeColor = Color.Red;
            }
        }

        private void TxtDataInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void TxtDataFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void BuscarData()
        {
            if (CbBuscar.SelectedIndex == 0)
            {
                MovimentacaoDAO dao = new MovimentacaoDAO();
                Grid.DataSource = dao.BuscarData(Convert.ToDateTime(TxtDataInicial.Text), Convert.ToDateTime(TxtDataFinal.Text));
            }
            else
            {
                MovimentacaoDAO dao = new MovimentacaoDAO();
                Grid.DataSource = dao.BuscarDataTipo(Convert.ToDateTime(TxtDataInicial.Text), Convert.ToDateTime(TxtDataFinal.Text), CbBuscar.Text);
            }
            FormatarDG();
        }

    }
}
