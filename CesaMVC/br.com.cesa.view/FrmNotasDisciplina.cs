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
    public partial class FrmNotasDisciplina : Form
    {
        public FrmNotasDisciplina()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ALUNO";
            Grid.Columns[1].HeaderText = "BIMESTRE 1";
            Grid.Columns[2].HeaderText = "BIMESTRE 2";
            Grid.Columns[3].HeaderText = "BIMESTRE 3";
            Grid.Columns[4].HeaderText = "BIMESTRE 4";
            Grid.Columns[5].HeaderText = "MEDIA";
            Grid.Columns[6].HeaderText = "ID_TURMA";

            // Visibilidade das colunas no Grid
            Grid.Columns[6].Visible = false;

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

            // Valores numericos com duas casas decimais
            Grid.Columns[1].DefaultCellStyle.Format = "N2";
            Grid.Columns[2].DefaultCellStyle.Format = "N2";
            Grid.Columns[3].DefaultCellStyle.Format = "N2";
            Grid.Columns[4].DefaultCellStyle.Format = "N2";
            Grid.Columns[5].DefaultCellStyle.Format = "N2";

            // Colocar valores centralizados na celula
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define o tamanho das celulas
            Grid.Columns[0].Width = 150;
            Grid.Columns[1].Width = 85;
            Grid.Columns[2].Width = 85;
            Grid.Columns[3].Width = 85;
            Grid.Columns[4].Width = 85;
            Grid.Columns[5].Width = 85;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            NotasDAO dao = new NotasDAO();
            Grid.DataSource = dao.ListarNotasDisciplina(int.Parse(CbDisciplina.SelectedValue.ToString()),
                                                    int.Parse(CbTurma.SelectedValue.ToString()));
            FormatarDG();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void ComboDisciplina()
        {
            DisciplinaDAO dao = new DisciplinaDAO();
            CbDisciplina.DataSource = dao.ListarDisciplinaPorTurma(CbTurma.SelectedValue.ToString());
            CbDisciplina.DisplayMember = "nome";
            CbDisciplina.ValueMember = "id_disciplina";
        }

        private void FrmNotasDisciplina_Load(object sender, EventArgs e)
        {
            ComboTurma();
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                CbDisciplina.SelectedIndex = -1;
                ComboDisciplina();
                CbDisciplina.Enabled = true;
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (CbDisciplina.Text == "")
            {
                MessageBox.Show("Selecione uma disciplina!", "Erro de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbDisciplina.Focus();

                // Codigo para limpar o DataGridView quando o aluno estiver vazio
                var dt = Grid.DataSource as DataTable;
                if (dt != null)
                {
                    dt.Rows.Clear();
                }
                return;
            }
            else
            {
                Listar();
                CbDisciplina.Enabled = false;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja exportar para Excel?", "Exportar arquivo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SalvarExcel(Grid);
            }
        }

        private void SalvarExcel(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColuna = 0;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                IndiceColuna++;
                excel.Cells[1, IndiceColuna] = col.Name;
            }

            int IndiceLinha = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                IndiceLinha++;

                IndiceColuna = 0;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    IndiceColuna++;

                    excel.Cells[IndiceLinha + 1, IndiceColuna] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;
        }
    }
}
