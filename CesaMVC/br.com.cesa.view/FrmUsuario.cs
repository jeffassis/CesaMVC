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

namespace CesaMVC
{
    public partial class FrmUsuario : Form
    {
        string idSelecionado;
        string UsuarioAntigo;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "USERNAME";
            Grid.Columns[3].HeaderText = "SENHA";
            Grid.Columns[4].HeaderText = "STATUS";
            Grid.Columns[5].HeaderText = "NIVEL";

            // Visibilidade das Colunas
            Grid.Columns[3].Visible = false;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 45;
            Grid.Columns[2].Width = 100;
            Grid.Columns[4].Width = 100;
            Grid.Columns[5].Width = 140;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            UsuarioDAO dao = new UsuarioDAO();
            Grid.DataSource = dao.ListarUser();

            FormatarDG();
        }


        private void LimparCampos()
        {
            txtNome.Text = txtSenha.Text = txtUsername.Text = string.Empty;
            cbStatus.SelectedIndex = 0;
            txtNivel.Value = 0;
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtUsername.Enabled = true;
            txtSenha.Enabled = true;
            cbStatus.Enabled = true;
            txtNivel.Enabled = true;
        }

        private void Desabilitar()
        {
            // Botoes
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            // Campos
            txtNome.Enabled = false;
            txtUsername.Enabled = false;
            txtSenha.Enabled = false;
            cbStatus.Enabled = false;
            txtNivel.Enabled = false;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
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
            tabUsuario.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            LimparCampos();
            Desabilitar();
            tabUsuario.SelectedTab = tabPage1;
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
            // VERIFICA SE O CAMPO USERNAME VAZIO
            if (txtUsername.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo USERNAME!", "Campo username está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            // VERIFICA SE O CAMPO SENHA VAZIO
            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo SENHA!", "Campo senha está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return;
            }
            // Adiciona o Usuário
            Usuario obj = new Usuario
            {
                Nome = txtNome.Text,
                Username = txtUsername.Text,
                Senha = txtSenha.Text,
                Status = cbStatus.Text,
                Nivel = int.Parse(txtNivel.Value.ToString())
            };            
            UsuarioDAO dao = new UsuarioDAO();

            // Verifica se o username ja existe
            DataTable dt = dao.VerficaUsername(txtUsername.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Username já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtUsername.Focus();
                return;
            }
            // Adiciona usuario
            dao.AddUser(obj);
            Desabilitar();
            LimparCampos();
            Listar();
            tabUsuario.SelectedTab = tabPage1;
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
            // VERIFICA SE O CAMPO USERNAME VAZIO
            if (txtUsername.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo USERNAME!", "Campo username está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            // VERIFICA SE O CAMPO SENHA VAZIO
            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo SENHA!", "Campo senha está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return;
            }
            // Atualiza o Usuário
            Usuario obj = new Usuario
            {
                Nome = txtNome.Text,
                Username = txtUsername.Text,
                Senha = txtSenha.Text,
                Status = cbStatus.Text,
                Nivel = int.Parse(txtNivel.Value.ToString())
            };
            UsuarioDAO dao = new UsuarioDAO();

            // Verifica se o username ja existe
            if (txtUsername.Text != UsuarioAntigo)
            {
                DataTable dt = dao.VerficaUsername(txtUsername.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Username já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    return;
                }
            }            
            // Atualiza usuario
            dao.UpdateUser(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
            tabUsuario.SelectedTab = tabPage1;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.DeleteUser(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
            tabUsuario.SelectedTab = tabPage1;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtUsername.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            cbStatus.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtNivel.Text = Grid.CurrentRow.Cells[5].Value.ToString();

            tabUsuario.SelectedTab = tabPage2;
            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;

            // Pega o nome de usuario para atualizar
            UsuarioAntigo = Grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + TxtPesquisar.Text + "%";

            UsuarioDAO dao = new UsuarioDAO();
            Grid.DataSource = dao.ListarUserPorNome(nome);
        }
    }
}
