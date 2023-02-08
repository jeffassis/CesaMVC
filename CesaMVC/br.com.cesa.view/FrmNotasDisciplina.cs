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
using Excel = Microsoft.Office.Interop.Excel;

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
            Grid.Columns[7].HeaderText = "DISCIPLINA";

            // Visibilidade das colunas no Grid
            Grid.Columns[6].Visible = false;
            Grid.Columns[7].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

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
                if (Grid.DataSource is DataTable dt)
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
                MessageBox.Show("Exportado com sucesso", "Sucesso ao exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SalvarExcel(DataGridView dgv)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook pasta = app.Workbooks.Add();
            Excel.Worksheet plan;
            plan = pasta.Worksheets.Add();
            // Para salvar arquivo diferente
            string data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

            plan.Range["A1"].Value = "Centro Educacional Soeiro Almeida";
            plan.Range["A3"].Value = "Alunos";
            plan.Range["B3"].Value = "Bimestre1";
            plan.Range["C3"].Value = "Bimestre2";
            plan.Range["D3"].Value = "Bimestre3";
            plan.Range["E3"].Value = "Bimestre4";
            plan.Range["F3"].Value = "Media";

            // Nome da aba na planilha
            plan.Name = "Relatório-PorDisciplina";

            int IndiceLinha = 4;
            foreach(DataGridViewRow r in Grid.Rows)
            {
                plan.Range["A2"].Value = r.Cells["DISCIPLINA"].Value;
                plan.Range["A"+IndiceLinha].Value = r.Cells["aluno"].Value;
                plan.Range["B"+IndiceLinha].Value = r.Cells["BIMESTRE 1"].Value;
                plan.Range["C"+IndiceLinha].Value = r.Cells["BIMESTRE 2"].Value;
                plan.Range["D"+IndiceLinha].Value = r.Cells["BIMESTRE 3"].Value;
                plan.Range["E"+IndiceLinha].Value = r.Cells["BIMESTRE 4"].Value;
                plan.Range["F"+IndiceLinha].Value = r.Cells["MEDIA"].Value;
                IndiceLinha++;
            }            
            pasta.SaveAs(@"C:\cesa\dados\report_disciplina-"+data+".xlsx");
            pasta.Close();
            app.Quit();            
        }
    }
}
