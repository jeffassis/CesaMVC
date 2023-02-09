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
    public partial class FrmVenda : Form
    {

        // Variaveis
        int qtd, estoque;
        decimal preco;
        decimal subtotal, total;

        // Carrinho
        DataTable carrinho = new DataTable();
        public FrmVenda()
        {
            InitializeComponent();
            lblData.Visible = false;
            lblTotalVenda.Text = "0,00";

            carrinho.Columns.Add("Codigo", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("SubTotal", typeof(decimal));            

            Grid.DataSource = carrinho;
        }       

        private void Limpar()
        {
            // Limpar os campos
            txtQuantidade.Clear();
            lblProduto.Text = "";
            lblPreco.Text = "";
            lblEstoque.Text = "";                      
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                qtd = int.Parse(txtQuantidade.Text);
                preco = decimal.Parse(lblPreco.Text);

                subtotal = qtd * preco;

                total += subtotal;                

                estoque = int.Parse(lblEstoque.Text);
                if (estoque >= qtd)
                {
                    // Adicionar o produto no carrinho
                    carrinho.Rows.Add(Program.idProduto, lblProduto.Text, qtd, preco, subtotal);

                    // Valor total
                    lblTotalVenda.Text = total.ToString();

                    Limpar();
                }
                else
                {
                    MessageBox.Show("Estoque está menor que a venda", "Erro ao adicionar...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Quantidade vazia ou produto não informado!", "Erro ao adicionar...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAluno_Click(object sender, EventArgs e)
        {
            Program.chamadaProduto = "produto";
            FrmProduto form = new FrmProduto();
            form.Show();
        }

        private void FrmVenda_Activated(object sender, EventArgs e)
        {
            lblProduto.Text = Program.nomeProduto;
            lblEstoque.Text = Program.estoqueProduto;
            lblPreco.Text = Program.precoProduto;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            total = 0.00m;
            lblTotalVenda.Text = total.ToString();

            // Codigo para limpar o DataGridView quando o aluno estiver vazio
            if (Grid.DataSource is DataTable dt)
            {
                dt.Rows.Clear();
            }
            Limpar();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if (Grid.RowCount != 0)
            {
                decimal subproduto = decimal.Parse(Grid.CurrentRow.Cells[4].Value.ToString());

                int indice = Grid.CurrentRow.Index;
                DataRow linha = carrinho.Rows[indice];

                carrinho.Rows.Remove(linha);
                carrinho.AcceptChanges();

                total -= subproduto;

                // Valor total
                lblTotalVenda.Text = total.ToString();

                MessageBox.Show("Item removido com sucesso!", "Produto removido...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            else
            {
                MessageBox.Show("Selecione uma linha!", "Erro ao remover...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpar();
            }            
        }

        private void BtnPagamento_Click(object sender, EventArgs e)
        {
            if (lblTotalVenda.Text != "0,00")
            {
                DateTime dataAtual = DateTime.Parse(lblData.Text);
                FrmVendaPagamento form = new FrmVendaPagamento(carrinho, dataAtual);

                form.txtTotal.Text = total.ToString();
                form.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Não existe itens para venda!", "Tabela vazia...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpar();
            }           
        }       
    }
}
