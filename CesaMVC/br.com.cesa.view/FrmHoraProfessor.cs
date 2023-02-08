using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.model;
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
    public partial class FrmHoraProfessor : Form
    {
        string idSelecionado;
        public FrmHoraProfessor()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID_HORA";
            Grid.Columns[1].HeaderText = "HORA";
            Grid.Columns[2].HeaderText = "DIA SEMANA";
            Grid.Columns[3].HeaderText = "DISCIPLINA";
            Grid.Columns[4].HeaderText = "SERIE";
            Grid.Columns[5].HeaderText = "ID TURMA";

            // Visibilidade das Colunas
            Grid.Columns[0].Visible = false;
            Grid.Columns[5].Visible = false;

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

            // Colocar valores centralizados na celula
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 90;
            Grid.Columns[3].Width = 95;
            Grid.Columns[4].Width = 65;
        }

        private void Listar()
        {
            HoraProfessorDAO dao = new HoraProfessorDAO();
            Grid.DataSource = dao.ListarHoraProfessor(CbSerie.SelectedValue.ToString());

            FormatarDG();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbSerie.DataSource = dao.ListarTurma();
            CbSerie.DisplayMember = "serie";
            CbSerie.ValueMember = "id_turma";
        }

        private void ComboDisiciplina()
        {
            DisciplinaDAO dao = new DisciplinaDAO();
            CbDisciplina.DataSource = dao.ListarDisciplina();
            CbDisciplina.DisplayMember = "nome";
            CbDisciplina.ValueMember = "id_disciplina";
        }

        private void Habilitar()
        {            
            BtnHora.Enabled = true;
            CbDisciplina.Enabled = true;            
        }

        private void Desabilitar()
        {
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            BtnHora.Enabled = false;
            CbDisciplina.Enabled = false;
        }

        private void Limpar()
        {
            lblHora.Text = "";
            lblDiaSemana.Text = "";
            CbDisciplina.SelectedIndex = 0;
        }

        private void FrmHoraProfessor_Load(object sender, EventArgs e)
        {
            ComboTurma();
            ComboDisiciplina();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            Limpar();
            Habilitar();
            tabProfessor.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            Desabilitar();
            
            // Codigo para limpar o DataGridView quando o aluno estiver vazio
            var dt = Grid.DataSource as DataTable;
            if (dt != null)
            {
                dt.Rows.Clear();
            }
            tabProfessor.SelectedTab = tabPage1;
        }

        private void CbSerie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbSerie.SelectedValue != null)
            {
                Listar();                
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE HORA ESTA VAZIO
            if (lblHora.Text.ToString().Trim() == "")
            {                
                MessageBox.Show("Selecione a Hora", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            HoraProfessor obj = new HoraProfessor 
            {
                HorarioId = int.Parse(Program.idHorario.ToString()),
                DisciplinaId = int.Parse(CbDisciplina.SelectedValue.ToString()),
                TurmaId = int.Parse(CbSerie.SelectedValue.ToString())
            };
            HoraProfessorDAO dao = new HoraProfessorDAO();
            dao.AddHoraProfessor(obj);
            Desabilitar();
            Limpar();
            Listar();
            tabProfessor.SelectedTab = tabPage1;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE HORA ESTA VAZIO
            if (lblHora.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Selecione a Hora", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            HoraProfessor obj = new HoraProfessor
            {
                HorarioId = int.Parse(Program.idHorario.ToString()),
                DisciplinaId = int.Parse(CbDisciplina.SelectedValue.ToString()),
                TurmaId = int.Parse(CbSerie.SelectedValue.ToString())
            };
            HoraProfessorDAO dao = new HoraProfessorDAO();
            dao.UpdateHoraProfessor(obj, idSelecionado);
            Desabilitar();
            Limpar();
            Listar();
            tabProfessor.SelectedTab = tabPage1;
        }

        private void BtnHora_Click(object sender, EventArgs e)
        {
            Program.chamadaHorario = "hora";
            FrmHorario form = new FrmHorario();
            form.BtnNovo.Visible = false;
            form.BtnExcluir.Visible = false;
            form.Show();
        }

        private void FrmHoraProfessor_Activated(object sender, EventArgs e)
        {
            lblHora.Text = Program.nomeHorario;
            lblDiaSemana.Text = Program.diaHorario;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            lblHora.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            lblDiaSemana.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            CbDisciplina.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            CbSerie.Text = Grid.CurrentRow.Cells[4].Value.ToString();

            BtnExcluir.Enabled = true;
            BtnEditar.Enabled = true;
            BtnSalvar.Enabled = false;
            Habilitar();
            tabProfessor.SelectedTab = tabPage2;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                HoraProfessorDAO dao = new HoraProfessorDAO();
                dao.DeleteHoraProfessor(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            Limpar();
            tabProfessor.SelectedTab = tabPage1;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Report_HoraProfessor form = new Report_HoraProfessor();
            form.ShowDialog();
        }
    }
}
