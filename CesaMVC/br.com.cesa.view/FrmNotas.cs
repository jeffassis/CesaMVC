using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.model;
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
    public partial class FrmNotas : Form
    {
        string idSelecionado;
        public FrmNotas()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "BIMESTRE";
            Grid.Columns[3].HeaderText = "DISCIPLINA";
            Grid.Columns[4].HeaderText = "TIPO";
            Grid.Columns[5].HeaderText = "NOTA";
            Grid.Columns[6].HeaderText = "TURMA";

            // Visibilidade das Colunas
            Grid.Columns[0].Visible = false;           

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //FORMATAR COLUNA PARA DECIMAL
            Grid.Columns[5].DefaultCellStyle.Format = "N2";

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 160;
            Grid.Columns[2].Width = 80;
            Grid.Columns[3].Width = 100;
            Grid.Columns[4].Width = 90;
            Grid.Columns[5].Width = 80;
            Grid.Columns[6].Width = 90;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            NotasDAO dao = new NotasDAO();
            Grid.DataSource = dao.ListarNotas(CbAluno.SelectedValue.ToString(),
                                              CbTurma.SelectedValue.ToString());
            FormatarDG();
        }

        private void Habilitar()
        {            
            CbDisciplina.Enabled = true;
            cbBimestre.Enabled = true;
            cbTipo.Enabled = true;
            txtNota.Enabled = true;
        }

        private void Desabilitar()
        {
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            CbDisciplina.Enabled = false;
            cbBimestre.Enabled = false;
            cbTipo.Enabled = false;
            txtNota.Enabled = false;
        }

        private void Limpar()
        {            
            CbDisciplina.SelectedIndex = -1;
            cbBimestre.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
            txtNota.Text = "";
        }
        private void ComboBimestre()
        {
            BimestreDAO dao = new BimestreDAO();
            cbBimestre.DataSource = dao.ListarBimestre();
            cbBimestre.DisplayMember = "bimestre";
            cbBimestre.ValueMember = "id_bimestre";
        }

        private void ComboDisciplina()
        {
            DisciplinaDAO dao = new DisciplinaDAO();
            CbDisciplina.DataSource = dao.ListarDisciplina();
            CbDisciplina.DisplayMember = "nome";
            CbDisciplina.ValueMember = "id_disciplina";
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void FrmNotas_Load(object sender, EventArgs e)
        {
            ComboBimestre();
            ComboDisciplina();
            ComboTurma();
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                CbAluno.SelectedIndex = -1;
                ComboAluno();
            }
        }

        private void ComboAluno()
        {
            AlunoDAO dao = new AlunoDAO();            
            CbAluno.DataSource = dao.ListarAlunoPorTurma(CbTurma.SelectedValue.ToString());
            CbAluno.DisplayMember = "nome";
            CbAluno.ValueMember = "id_aluno";
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Habilitar();
            Limpar();
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Desabilitar();
            Limpar();
            CbAluno.SelectedIndex = -1;

            // Codigo para limpar o DataGridView quando o aluno estiver vazio
            var dt = Grid.DataSource as DataTable;
            dt.Rows.Clear();            
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se está vazio
            if (CbAluno.Text == "" || txtNota.Text == "" || CbDisciplina.Text == "")
            {
                MessageBox.Show("Os campos não podem ser vazios", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            Notas obj = new Notas 
            {
                AlunoId = int.Parse(CbAluno.SelectedValue.ToString()),
                DisciplinaId = int.Parse(CbDisciplina.SelectedValue.ToString()),
                TurmaId = int.Parse(CbTurma.SelectedValue.ToString()),
                Bimestre = int.Parse(cbBimestre.SelectedValue.ToString()),
                Tipo = cbTipo.Text,
                Nota = decimal.Parse(txtNota.Text)
            };
            NotasDAO dao = new NotasDAO();

            // Verifica se a nota já foi lancada
            DataTable dt = dao.VerficarNotas(CbAluno.SelectedValue.ToString(),
                                             CbDisciplina.SelectedValue.ToString(),
                                             cbBimestre.SelectedValue.ToString(), 
                                             CbTurma.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Nota já lançada!!", "Erro lançamento de notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dao.AddNotas(obj);
            Desabilitar();
            Limpar();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verifica se está vazio
            if (CbAluno.Text == "" || txtNota.Text == "" || CbDisciplina.Text == "")
            {
                MessageBox.Show("Os campos não podem ser vazios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            Notas obj = new Notas
            {
                AlunoId = int.Parse(CbAluno.SelectedValue.ToString()),
                DisciplinaId = int.Parse(CbDisciplina.SelectedValue.ToString()),
                TurmaId = int.Parse(CbTurma.SelectedValue.ToString()),
                Bimestre = int.Parse(cbBimestre.SelectedValue.ToString()),
                Tipo = cbTipo.Text,
                Nota = decimal.Parse(txtNota.Text)
            };
            NotasDAO dao = new NotasDAO();
            dao.UpdateNotas(obj, idSelecionado);
            Desabilitar();
            Limpar();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                NotasDAO dao = new NotasDAO();
                dao.DeleteNotas(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            Limpar();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            CbAluno.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            cbBimestre.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            CbDisciplina.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            cbTipo.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtNota.Text = Grid.CurrentRow.Cells[5].Value.ToString();
            CbTurma.Text = Grid.CurrentRow.Cells[6].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;           
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
