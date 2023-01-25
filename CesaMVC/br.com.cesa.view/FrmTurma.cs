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
    public partial class FrmTurma : Form
    {
        string turmaAntiga;
        string idSelecionado;
        public FrmTurma()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "SERIE";
            Grid.Columns[3].HeaderText = "TURNO";

            // Visibilidade das Colunas
            //Grid.Columns[3].Visible = false;

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
            Grid.Columns[0].Width = 35;
            Grid.Columns[2].Width = 100;
            Grid.Columns[3].Width = 90;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            TurmaDAO dao = new TurmaDAO();
            Grid.DataSource = dao.ListarTurma();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtNome.Text = txtSerie.Text = string.Empty;
            cbTurno.SelectedIndex = 0;
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtSerie.Enabled = true;
            cbTurno.Enabled = true;
            txtNome.Focus();
        }

        private void Desabilitar()
        {
            // Botoes
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            // Campos
            txtNome.Enabled = false;
            txtSerie.Enabled = false;
            cbTurno.Enabled = false;
        }

        private void FrmTurma_Load(object sender, EventArgs e)
        {
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
            // VERIFICA SE O CAMPO NOME VAZIO
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            // Adiciona o Turma
            Turma obj = new Turma
            {
                Nome = txtNome.Text,
                Serie = txtSerie.Text,
                Turno = cbTurno.Text
            };
            TurmaDAO dao = new TurmaDAO();
            // Verifica se a turma ja existe
            DataTable dt = dao.VerficarTurma(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Turma já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            // Adiciona turma
            dao.AddTurma(obj);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O CAMPO NOME VAZIO
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            // Adiciona o Turma
            Turma obj = new Turma
            {
                Nome = txtNome.Text,
                Serie = txtSerie.Text,
                Turno = cbTurno.Text
            };
            TurmaDAO dao = new TurmaDAO();
            // Verifica se a turma ja existe            
            if (txtNome.Text != turmaAntiga)
            {
                DataTable dt = dao.VerficarTurma(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Turma já cadastrada!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }
            // Atualiza turma
            dao.UpdateTurma(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtSerie.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            cbTurno.Text = Grid.CurrentRow.Cells[3].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;

            // Pega o nome de usuario para atualizar
            turmaAntiga = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TurmaDAO dao = new TurmaDAO();
                dao.DeleteTurma(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
        }
    }
}
