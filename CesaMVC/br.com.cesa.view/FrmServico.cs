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
    public partial class FrmServico : Form
    {
        string idSelecionado;
        public FrmServico()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "VALOR";

            // Se a coluna e visivel
            Grid.Columns[0].Visible = false;

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

            //FORMATAR COLUNA PARA MOEDA
            Grid.Columns[2].DefaultCellStyle.Format = "C2";

            // Define o tamanho das celulas
            Grid.Columns[2].Width = 90;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            ServicosDAO dao = new ServicosDAO();
            Grid.DataSource = dao.ListarServico();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtValor.Text = txtNome.Text = string.Empty;
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtValor.Enabled = true;
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
            txtValor.Enabled = false;
        }

        private void FrmServico_Load(object sender, EventArgs e)
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
            // VERIFICA SE O CAMPO VALOR VAZIO
            if (txtValor.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo VALOR!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }
            // Adiciona o Servico
            Servicos obj = new Servicos
            {
                Nome = txtNome.Text,
                Valor = decimal.Parse(txtValor.Text)
            };
            ServicosDAO dao = new ServicosDAO();
            // Adiciona Servico
            dao.AddServicos(obj);
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
            // VERIFICA SE O CAMPO VALOR VAZIO
            if (txtValor.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo VALOR!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }
            // Atualiza o Servico
            Servicos obj = new Servicos
            {
                Nome = txtNome.Text,
                Valor = decimal.Parse(txtValor.Text)
            };
            ServicosDAO dao = new ServicosDAO();
            // Atualiza Servico
            dao.UpdateServicos(obj, idSelecionado);
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ServicosDAO dao = new ServicosDAO();
                dao.DeleteServicos(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaServico == "servico")
            {
                Program.idServico = Grid.CurrentRow.Cells[0].Value.ToString();
                Program.nomeServico = Grid.CurrentRow.Cells[1].Value.ToString();
                Program.valorServico = Grid.CurrentRow.Cells[2].Value.ToString();
                Close();
            }
        }
    }
}
