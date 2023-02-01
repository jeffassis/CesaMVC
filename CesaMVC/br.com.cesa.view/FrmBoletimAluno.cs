using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.report;
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
    public partial class FrmBoletimAluno : Form
    {
        public FrmBoletimAluno()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {            
            Grid.Columns[0].HeaderText = "DISCIPLINA";
            Grid.Columns[1].HeaderText = "BIMESTRE";
            Grid.Columns[2].HeaderText = "NOTA";

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //FORMATAR COLUNA PARA DECIMAL
            Grid.Columns[2].DefaultCellStyle.Format = "N2";

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 160;
            Grid.Columns[1].Width = 110;
            Grid.Columns[2].Width = 90;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            NotasDAO dao = new NotasDAO();
            Grid.DataSource = dao.ListarBoletimAluno(int.Parse(CbAluno.SelectedValue.ToString()), 
                                                    int.Parse(cbBimestre.SelectedValue.ToString()),
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

        private void FrmBoletimAluno_Load(object sender, EventArgs e)
        {
            ComboTurma();
            ComboBimestre();
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                CbAluno.SelectedIndex = -1;
                ComboAluno();
                CbAluno.Enabled = true;
                cbBimestre.Enabled = true;
            }
        }

        private void ComboBimestre()
        {
            BimestreDAO dao = new BimestreDAO();
            cbBimestre.DataSource = dao.ListarBimestre();
            cbBimestre.DisplayMember = "bimestre";
            cbBimestre.ValueMember = "id_bimestre";
        }

        private void ComboAluno()
        {
            AlunoDAO dao = new AlunoDAO();
            CbAluno.DataSource = dao.ListarAlunoPorTurma(CbTurma.SelectedValue.ToString());
            CbAluno.DisplayMember = "nome";
            CbAluno.ValueMember = "id_aluno";
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (CbAluno.Text == "" || cbBimestre.Text == "")
            {
                MessageBox.Show("Selecione aluno e bimestre!", "Erro de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();

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
                CbAluno.Enabled = false;
                cbBimestre.Enabled = false;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Report_BoletimAluno form = new Report_BoletimAluno();
            form.ShowDialog();
        }
    }
}
