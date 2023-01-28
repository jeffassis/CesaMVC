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
    public partial class FrmGasto : Form
    {
        string idSelecionado;
        int ultimoIdGasto;        
        public FrmGasto()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID_GASTO";
            Grid.Columns[1].HeaderText = "DESCRICAO";
            Grid.Columns[2].HeaderText = "VALOR";
            Grid.Columns[3].HeaderText = "FUNCIONARIO";
            Grid.Columns[4].HeaderText = "DATA";

            // Visibilidade das colunas no Grid
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

            // Valores numericos com duas casas decimais
            Grid.Columns[2].DefaultCellStyle.Format = "C2";

            // Colocar valores centralizados na celula
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define o tamanho das celulas
            Grid.Columns[2].Width = 90;
            Grid.Columns[3].Width = 120;
            Grid.Columns[4].Width = 100;

            // Função para atualizar o total
            Totalizar();
        }

        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                total += Convert.ToDouble(linha.Cells["valor"].Value);
            }
            lblTotal.Text = Convert.ToDouble(total).ToString("C2");
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            GastoDAO dao = new GastoDAO();
            Grid.DataSource = dao.BuscarGastoPorData(Convert.ToDateTime(txtData.Text));

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtDescricao.Text = txtValor.Text = string.Empty;
            txtData.Value = DateTime.Today;
        }

        private void Habilitar()
        {
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
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
            txtValor.Enabled = false;
        }

        private void FrmGasto_Load(object sender, EventArgs e)
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
            // VERIFICA SE O NOME ESTA VAZIO
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }
            // VERIFICA SE O VALOR ESTA VAZIO
            if (txtValor.Text.ToString().Trim() == "")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }
            // Adiciona o Gasto
            Gasto obj = new Gasto
            {
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text),
                Funcionario = Program.nomeUsuario
            };
            GastoDAO dao = new GastoDAO();
            // Verifica se a Gasto ja existe
            DataTable dt = dao.VerificarGastoPorData(txtDescricao.Text, txtValor.Text, Convert.ToDateTime(txtData.Text));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Gasto já cadastrado!", "Erro ao adicionar gasto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = "";
                txtDescricao.Focus();
                return;
            }
            // Adiciona Gasto
            dao.AddGasto(obj);
            

            // ----------------------------------------------------------------------------------------------------------------

            // RECUPERAR O ULTIMO ID DO GASTO
            ultimoIdGasto = dao.UltimoIdGasto();

            // LANÇAR O GASTO NAS MOVIMENTAÇÕES
            Movimentacao mov = new Movimentacao 
            {
                Tipo = "Saida",
                Movimento = "Gasto",
                Valor = decimal.Parse(txtValor.Text),
                Funcionario = Program.nomeUsuario,
                IdMovimento = ultimoIdGasto
            };
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            movDao.AddMovimentacao(mov);

            // FINALIZA A FUNCAO
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O NOME ESTA VAZIO
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }
            // VERIFICA SE O VALOR ESTA VAZIO
            if (txtValor.Text.ToString().Trim() == "")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }
            // Atualiza o Gasto
            Gasto obj = new Gasto
            {
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text),
                Funcionario = Program.nomeUsuario
            };
            GastoDAO dao = new GastoDAO();
            // Atualiza Gasto
            dao.UpdateGasto(obj, idSelecionado);

            // ----------------------------------------------------------------------------------------------------------------

            // ATUALIZAR O VALOR NA MOVIMENTAÇÃO
            Movimentacao mov = new Movimentacao
            {
                Valor = decimal.Parse(txtValor.Text),
                Funcionario = Program.nomeUsuario,                
                Movimento = "Gasto"
            };
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            movDao.UpdateMovimentacao(mov, idSelecionado);

            // FINALIZA A FUNCAO
            Desabilitar();
            LimparCampos();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                GastoDAO dao = new GastoDAO();
                dao.DeleteGasto(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);

                // ----------------------------------------------------------------------------------------------------------------
                // EXCLUSAO DO MOVIMENTO DO GASTO
                string movimento = "Gasto";
                MovimentacaoDAO movDao = new MovimentacaoDAO();
                movDao.DeleteMovimentacao(idSelecionado, movimento);
            }
            Desabilitar();
            LimparCampos();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();

            Habilitar();
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
