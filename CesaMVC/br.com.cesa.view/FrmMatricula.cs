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
    public partial class FrmMatricula : Form
    {
        string idSelecionado;
        public FrmMatricula()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "ALUNO";
            Grid.Columns[2].HeaderText = "SERIE";
            Grid.Columns[3].HeaderText = "TURMA";
            Grid.Columns[4].HeaderText = "ID_TURMA";

            // Visibilidade das Colunas
            Grid.Columns[4].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 40;
            Grid.Columns[2].Width = 100;
            Grid.Columns[3].Width = 120;
        }

        private void Listar()
        {
            AlunoTurmaDAO dao = new AlunoTurmaDAO();
            Grid.DataSource = dao.ListarAlunoTurma(CbTurma.SelectedValue.ToString());

            FormatarDG();
        }

        private void ComboAno()
        {
            TurmaDAO dao = new TurmaDAO();
            CbAnoLetivo.DataSource = dao.ListarAno();
            CbAnoLetivo.DisplayMember = "ano";
            CbAnoLetivo.ValueMember = "id_ano";
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurmaPorAno(int.Parse(CbAnoLetivo.SelectedValue.ToString()));
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void CbAnoLetivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbAnoLetivo.SelectedValue != null)
            {
                ComboTurma();
            }
        }

        private void Habilitar()
        {
            BtnSalvar.Enabled = true;
            CbTurma.Enabled = true;
            BtnAluno.Enabled = true;
            txtAluno.Focus();
        }

        private void Desabilitar()
        {
            BtnSalvar.Enabled = false;
            BtnExcluir.Enabled = false;
            txtAluno.Enabled = false;            
            BtnAluno.Enabled = false;
        }

        private void Limpar()
        {
            txtAluno.Text = "";                     
        }

        private void FrmMontTurma_Load(object sender, EventArgs e)
        {
            ComboAno();            
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Habilitar();
            Limpar();
            BtnSalvar.Enabled = true;
            BtnExcluir.Enabled = false;
        }

        private void BtnAluno_Click(object sender, EventArgs e)
        {
            Program.chamadaAlunos = "aluno";
            FrmAluno form = new FrmAluno();
            form.BtnNovo.Visible = false;
            form.Show();
        }

        private void FrmMontTurma_Activated(object sender, EventArgs e)
        {
            txtAluno.Text = Program.nomeAluno;            
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                Listar();
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O NOME ESTA VAZIO
            if (txtAluno.Text.ToString().Trim() == "")
            {
                txtAluno.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAluno.Focus();
                return;
            }                       
            AlunoTurmaDAO dao = new AlunoTurmaDAO();
            dao.AddAlunoTurma(Program.idAluno, CbTurma.SelectedValue.ToString());           
            BtnSalvar.Enabled = false;
            BtnExcluir.Enabled = false;
            Desabilitar();
            Limpar();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AlunoTurmaDAO dao = new AlunoTurmaDAO();
                dao.DeleteAlunoTurma(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            Limpar();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();

            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            Habilitar();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Report_AlunoTurma form = new Report_AlunoTurma();
            form.ShowDialog();
        }       
    }
}
