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
    public partial class FrmHorario : Form
    {
        string idSelecionado;
        string HorarioAntigo;
        public FrmHorario()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "DESCRICAO";
            Grid.Columns[2].HeaderText = "DIA SEMANA";

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 35;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            HorarioDAO dao = new HorarioDAO();
            Grid.DataSource = dao.ListarHorario();

            FormatarDG();
        }

        private void ComboDiaSemana()
        {
            HorarioDAO dao = new HorarioDAO();
            CbDiaSemana.DataSource = dao.ListarDiaSemana();
            CbDiaSemana.DisplayMember = "dia";
            CbDiaSemana.ValueMember = "id_dia";
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            CbDiaSemana.SelectedIndex = 0;
        }

        private void Habilitar()
        {
            txtDescricao.Enabled = true;
            CbDiaSemana.Enabled = true;
            txtDescricao.Focus();
        }

        private void Desabilitar()
        {
            // Botoes
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            // Campos
            txtDescricao.Enabled = false;
            CbDiaSemana.Enabled = false;
        }

        private void FrmHorario_Load(object sender, EventArgs e)
        {
            ComboDiaSemana();
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            LimparCampos();
            Habilitar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Desabilitar();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {                       
            Horario obj = new Horario
            {
                Descricao = txtDescricao.Text,
                DiaId = int.Parse(CbDiaSemana.SelectedValue.ToString())
            };
            HorarioDAO dao = new HorarioDAO();
            // Verifica se horario ja existe
            DataTable dt = dao.VerficarHorario(txtDescricao.Text, CbDiaSemana.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Horario já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = "";
                txtDescricao.Focus();
                return;
            }
            dao.AddHorario(obj);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {                       
            Horario obj = new Horario
            {
                Descricao = txtDescricao.Text,
                DiaId = int.Parse(CbDiaSemana.SelectedValue.ToString())
            };
            HorarioDAO dao = new HorarioDAO();
            // Verifica se Horario ja existe            
            if (txtDescricao.Text != HorarioAntigo)
            {
                DataTable dt = dao.VerficarHorario(txtDescricao.Text, CbDiaSemana.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Horario já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }
            }
            dao.UpdateHorario(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                HorarioDAO dao = new HorarioDAO();
                dao.DeleteHorario(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            CbDiaSemana.Text = Grid.CurrentRow.Cells[2].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;

            HorarioAntigo = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaHorario == "hora")
            {
                Program.idHorario = Grid.CurrentRow.Cells[0].Value.ToString();
                Program.nomeHorario = Grid.CurrentRow.Cells[1].Value.ToString();
                Program.diaHorario = Grid.CurrentRow.Cells[2].Value.ToString();                
                Close();
            }
        }
    }
}
