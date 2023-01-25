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
    public partial class FrmResponsavel : Form
    {
        string idSelecionado;
        string ResponsavelAntigo;
        public FrmResponsavel()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "RG";
            Grid.Columns[3].HeaderText = "CPF";
            Grid.Columns[4].HeaderText = "PARENTESCO";
            Grid.Columns[5].HeaderText = "TELEFONE";

            // Visibilidade das Colunas
            Grid.Columns[0].Visible = false;
            Grid.Columns[2].Visible = false;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula            
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 210;
            Grid.Columns[3].Width = 90;
            Grid.Columns[4].Width = 100;
            Grid.Columns[5].Width = 120;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            ResponsavelDAO dao = new ResponsavelDAO();
            Grid.DataSource = dao.ListarResponsavel();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtRg.Text = "";
            txtCpf.Text = "";
            CbParentesco.SelectedIndex = 0;
            txtTelefone.Text = "";
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtRg.Enabled = true;
            txtCpf.Enabled = true;
            CbParentesco.Enabled = true;
            txtTelefone.Enabled = true;
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
            txtRg.Enabled = false;
            txtCpf.Enabled = false;
            CbParentesco.Enabled = false;
            txtTelefone.Enabled = false;
        }

        private void FrmResponsavel_Load(object sender, EventArgs e)
        {
            TxtPesquisar.Focus();
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {            
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            LimparCampos();
            Habilitar();
            tabAluno.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Desabilitar();
            tabAluno.SelectedTab = tabPage1;
            TxtPesquisar.Focus();
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
            // Adiciona
            Responsavel obj = new Responsavel
            {
                Nome = txtNome.Text,
                Rg = txtRg.Text,
                Cpf = txtCpf.Text,
                Parentesco = CbParentesco.Text,
                Telefone = txtTelefone.Text
            };
            ResponsavelDAO dao = new ResponsavelDAO();

            // Verifica se ja existe
            DataTable dt = dao.VerficarResponsavel(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Responsável já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            // Adiciona aluno
            dao.AddResponsavel(obj);
            Desabilitar();
            LimparCampos();
            Listar();
            tabAluno.SelectedTab = tabPage1;
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
            // Atualiza
            Responsavel obj = new Responsavel
            {
                Nome = txtNome.Text,
                Rg = txtRg.Text,
                Cpf = txtCpf.Text,
                Parentesco = CbParentesco.Text,
                Telefone = txtTelefone.Text
            };
            ResponsavelDAO dao = new ResponsavelDAO();

            // Verifica se o nome ja existe
            if (txtNome.Text != ResponsavelAntigo)
            {
                DataTable dt = dao.VerficarResponsavel(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Responsável já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }           
            dao.UpdateResponsavel(obj, idSelecionado);            
            Desabilitar();
            LimparCampos();
            Listar();
            tabAluno.SelectedTab = tabPage1;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResponsavelDAO dao = new ResponsavelDAO();
                dao.DeleteResponsavel(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
            tabAluno.SelectedTab = tabPage1;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            CbParentesco.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = Grid.CurrentRow.Cells[5].Value.ToString();

            tabAluno.SelectedTab = tabPage2;
            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;

            // Pega o nome verificar na edicao
            ResponsavelAntigo = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + TxtPesquisar.Text + "%";

            ResponsavelDAO dao = new ResponsavelDAO();
            Grid.DataSource = dao.ListarResponsavelPorNome(nome);
        }
    }
}
