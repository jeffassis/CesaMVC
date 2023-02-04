using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmProduto : Form
    {
        string foto;
        string alterou;
        string idSelecionado;
        string ProdutoAntigo;
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "DESCRICAO";
            Grid.Columns[3].HeaderText = "FORNECEDOR";
            Grid.Columns[4].HeaderText = "ESTOQUE";
            Grid.Columns[5].HeaderText = "ID_FORNECEDOR";
            Grid.Columns[6].HeaderText = "VENDA";
            Grid.Columns[7].HeaderText = "COMPRA";
            Grid.Columns[8].HeaderText = "DATA";
            Grid.Columns[9].HeaderText = "IMAGEM";

            // Visibilidade das colunas no Grid
            Grid.Columns[0].Visible = false;
            Grid.Columns[5].Visible = false;
            Grid.Columns[9].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            //FORMATAR COLUNA PARA MOEDA
            Grid.Columns[6].DefaultCellStyle.Format = "C2";
            Grid.Columns[7].DefaultCellStyle.Format = "C2";

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define o tamanho das celulas
            Grid.Columns[1].Width = 160;
            Grid.Columns[2].Width = 120;
            Grid.Columns[3].Width = 150;
            Grid.Columns[4].Width = 75;
            Grid.Columns[6].Width = 85;
            Grid.Columns[7].Width = 80;
            Grid.Columns[8].Width = 100;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            ProdutoDAO dao = new ProdutoDAO();
            Grid.DataSource = dao.ListarProduto();

            FormatarDG();
        }

        private void ComboFornecedor()
        {
            FornecedorDAO dao = new FornecedorDAO();
            CbFornecedor.DataSource = dao.ListarFornecedor();
            CbFornecedor.DisplayMember = "nome";
            CbFornecedor.ValueMember = "id_fornecedor";
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEstoque.Text = "";
            txtDescricao.Text = "";
            txtVenda.Text = "";
            CbFornecedor.SelectedIndex = 0;
            LimparFoto();
        }

        private void Habilitar()
        {
            txtNome.Enabled = true;
            //txtEstoque.Enabled = true;
            txtDescricao.Enabled = true;
            txtVenda.Enabled = true;
            CbFornecedor.Enabled = true;
            txtNome.Focus();
        }

        private void Desabilitar()
        {
            // Botoes            
            BtnFoto.Enabled = false;
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            // Campos
            txtNome.Enabled = false;
            //txtEstoque.Enabled = false;
            txtDescricao.Enabled = false;
            txtVenda.Enabled = false;
            CbFornecedor.Enabled = false;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            TxtPesquisar.Focus();
            ComboFornecedor();
            Listar();
            LimparFoto();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            BtnFoto.Enabled = true;
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            LimparCampos();
            Habilitar();
            tabProduto.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Desabilitar();
            tabProduto.SelectedTab = tabPage1;
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
            // VERIFICA SE O VALOR ESTA VAZIO
            if (txtVenda.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVenda.Focus();
                return;
            }
            // Adiciona o produto
            Produto obj = new Produto 
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                FornecedorId = int.Parse(CbFornecedor.SelectedValue.ToString()),
                ValorVenda = decimal.Parse(txtVenda.Text),
            };
            ProdutoDAO dao = new ProdutoDAO();

            DataTable dt = dao.VerficarProduto(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Produto já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            dao.AddProduto(obj, Img());
            Desabilitar();
            LimparCampos();
            Listar();
            tabProduto.SelectedTab = tabPage1;
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
            // VERIFICA SE O VALOR ESTA VAZIO
            if (txtVenda.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVenda.Focus();
                return;
            }
            // Atualiza o produto
            Produto obj = new Produto
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                FornecedorId = int.Parse(CbFornecedor.SelectedValue.ToString()),
                ValorVenda = decimal.Parse(txtVenda.Text),
            };
            ProdutoDAO dao = new ProdutoDAO();

            if (txtNome.Text != ProdutoAntigo)
            {
                DataTable dt = dao.VerficarProduto(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Produto já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }
            // Atualizacao com foto ou sem foto
            if (alterou == "1")
            {
                dao.UpdateProdutoComImagem(obj, idSelecionado, Img());
            }
            else
            {
                dao.UpdateProduto(obj, idSelecionado);
            }
            Desabilitar();
            LimparCampos();
            Listar();
            alterou = "";
            tabProduto.SelectedTab = tabPage1;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.DeleteProduto(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
            tabProduto.SelectedTab = tabPage1;
        }

        private byte[] Img()
        {
            byte[] imagem_byte = null;
            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }

        private void LimparFoto()
        {
            Foto_produto.Image = Properties.Resources.sem_foto;
            foto_produto2.Image = Properties.Resources.sem_foto;
            foto = "img/sem-foto.jpg";
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Imagens(*.jpg;*.png)|*.jpg;*.png|Todos os Arquivos(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                Foto_produto.ImageLocation = foto;
                alterou = "1";
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            CbFornecedor.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            txtEstoque.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtVenda.Text = Grid.CurrentRow.Cells[6].Value.ToString();

            if (Grid.CurrentRow.Cells[9].Value != DBNull.Value)
            {
                byte[] imagem = (byte[])Grid.CurrentRow.Cells[9].Value;
                MemoryStream ms = new MemoryStream(imagem);
                Foto_produto.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                Foto_produto.Image = Properties.Resources.sem_foto;
            }           

            tabProduto.SelectedTab = tabPage2;
            Habilitar();            
            BtnFoto.Enabled = true;
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;

            // Pega o nome do produto para atualizar
            ProdutoAntigo = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Foto do tab1
            if (Grid.CurrentRow.Cells[9].Value != DBNull.Value)
            {
                byte[] imagem = (byte[])Grid.CurrentRow.Cells[9].Value;
                MemoryStream ms = new MemoryStream(imagem);
                foto_produto2.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                foto_produto2.Image = Properties.Resources.sem_foto;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + TxtPesquisar.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();
            Grid.DataSource = dao.ListarProdutoPorNome(nome);
        }        
    }
}
