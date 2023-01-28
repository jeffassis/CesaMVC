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
    public partial class FrmFornecedor : Form
    {
        string idSelecionado;
        string FornecedorAntiga;
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "ENDERECO";
            Grid.Columns[3].HeaderText = "TELEFONE";

            // Define se a coluna e visivel
            Grid.Columns[0].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 160;
            Grid.Columns[3].Width = 120;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            FornecedorDAO dao = new FornecedorDAO();
            Grid.DataSource = dao.ListarFornecedor();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtTelefone.Text = txtEndereco.Text = txtNome.Text = string.Empty;
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
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
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
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
            tabFornecedor.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Desabilitar();
            tabFornecedor.SelectedTab = tabPage1;
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
            // Adiciona o Fornecedor
            Fornecedor obj = new Fornecedor
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Telefone = txtTelefone.Text
            };
            FornecedorDAO dao = new FornecedorDAO();
            // Verifica se a Fornecedor ja existe
            DataTable dt = dao.VerficarFornecedor(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Fornecedor já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            // Adiciona Fornecedor
            dao.AddFornecedor(obj);
            Desabilitar();
            LimparCampos();
            Listar();
            tabFornecedor.SelectedTab = tabPage1;
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
            // Adiciona o Fornecedor
            Fornecedor obj = new Fornecedor
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Telefone = txtTelefone.Text
            };
            FornecedorDAO dao = new FornecedorDAO();
            // Verifica se a Fornecedor ja existe            
            if (txtNome.Text != FornecedorAntiga)
            {
                DataTable dt = dao.VerficarFornecedor(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Fornecedor já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }
            // Atualiza Fornecedor
            dao.UpdateFornecedor(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
            tabFornecedor.SelectedTab = tabPage1;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FornecedorDAO dao = new FornecedorDAO();
                dao.DeleteHorario(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
            tabFornecedor.SelectedTab = tabPage1;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtEndereco.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtTelefone.Text = Grid.CurrentRow.Cells[3].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            tabFornecedor.SelectedTab = tabPage2;

            // Pega o Fornecedor para atualizar
            FornecedorAntiga = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + TxtPesquisar.Text + "%";

            FornecedorDAO dao = new FornecedorDAO();
            Grid.DataSource = dao.ListarFornecedorPorNome(nome);
        }
    }
}
