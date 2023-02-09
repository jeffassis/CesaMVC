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
    public partial class FrmVendaPagamento : Form
    {        
        DataTable carrinho = new DataTable();
        readonly DateTime dataAtual;
        public FrmVendaPagamento(DataTable carrinho, DateTime dataAtual)
        {
            this.carrinho = carrinho;
            this.dataAtual = dataAtual;
            InitializeComponent();
        }       

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal v_dinheiro, v_cartao, troco, totalpago, total;

                // variaveis de baixa estoque
                int qtd_estoque, qtd_comprada, estoque_atualizado;
                ProdutoDAO dao_produto = new ProdutoDAO();

                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                v_cartao = decimal.Parse(txtCartao.Text);
                total = decimal.Parse(txtTotal.Text);

                // Calcular o total pago
                totalpago = v_dinheiro + v_cartao;

                if (totalpago < total)
                {
                    MessageBox.Show("O total pago é menor que o valor Total da Venda!","Saldo insuficiente...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Calcular o troco 
                    troco = totalpago - total;
                    Venda venda = new Venda 
                    {
                        Funcionario = Program.nomeUsuario,
                        Data_venda = dataAtual,
                        Total_venda = total,
                        Obs = txtObs.Text
                    };
                    // Exibir o troco
                    txtTroco.Text = troco.ToString();

                    // Executa a venda
                    VendaDAO vdao = new VendaDAO();
                    vdao.CadastrarVenda(venda);

                    // ----------------------------------------------------------------------------------------------------------------
                    // LANÇAR O GASTO NAS MOVIMENTAÇÕES
                    Movimentacao mov = new Movimentacao
                    {
                        Tipo = "Entrada",
                        Movimento = "Venda",
                        Valor = total,
                        Funcionario = Program.nomeUsuario,
                        IdMovimento = vdao.RetornaIdUltimaVenda()
                    };
                    MovimentacaoDAO movDao = new MovimentacaoDAO();
                    movDao.AddMovimentacao(mov);

                    // ----------------------------------------------------------------------------------------------------------------
                    // Cadastrar os itens da venda
                    // Percorrendo os itens do carrinho
                    foreach (DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda
                        {
                            Venda_id = vdao.RetornaIdUltimaVenda(),
                            Produto_id = int.Parse(linha["Codigo"].ToString()),
                            Quantidade = int.Parse(linha["Qtd"].ToString()),
                            SubTotal = decimal.Parse(linha["SubTotal"].ToString())
                        };
                        // Baixa do estoque
                        qtd_estoque = dao_produto.RetornaEstoqueAtual(item.Produto_id);
                        qtd_comprada = item.Quantidade;
                        estoque_atualizado = qtd_estoque - qtd_comprada;
                        dao_produto.BaixaEstoque(item.Produto_id, estoque_atualizado);

                        ItemVendaDAO itemDAO = new ItemVendaDAO();
                        itemDAO.CadastrarItem(item);
                    }                  
                }
                MessageBox.Show("Venda finalizada com sucesso!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegue finalizar" + ex);
            }
        }

        private void FrmVendaPagamento_Load(object sender, EventArgs e)
        {
            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";
            txtTroco.Text = "0,00";
        }
    }
}
