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
    public partial class FrmDisciplina : Form
    {
        string idSelecionado;
        string DisciplinaAntiga;
        public FrmDisciplina()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "NOME";

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 35;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            DisciplinaDAO dao = new DisciplinaDAO();
            Grid.DataSource = dao.ListarDisciplina();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtId.Text = txtNome.Text = string.Empty;
        }

        private void Habilitar()
        {            
            txtNome.Enabled = true;
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
        }

        private void FrmDisciplina_Load(object sender, EventArgs e)
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
            // Adiciona o Disciplina
            Disciplina obj = new Disciplina
            {
                Nome = txtNome.Text,
            };
            DisciplinaDAO dao = new DisciplinaDAO();
            // Verifica se a Disciplina ja existe
            DataTable dt = dao.VerficarDisciplina(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Disciplina já cadastrada!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            // Adiciona Disciplina
            dao.AddDisciplina(obj);
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
            // Adiciona o Disciplina
            Disciplina obj = new Disciplina
            {
                Nome = txtNome.Text,
            };
            DisciplinaDAO dao = new DisciplinaDAO();
            // Verifica se a Disciplina ja existe            
            if (txtNome.Text != DisciplinaAntiga)
            {
                DataTable dt = dao.VerficarDisciplina(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Disciplina já cadastrada!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }
            // Atualiza Disciplina
            dao.UpdateDisciplina(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtId.Text = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;

            // Pega o nome de disciplina para atualizar
            DisciplinaAntiga = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DisciplinaDAO dao = new DisciplinaDAO();
                dao.DeleteDisciplina(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
        }
    }
}
