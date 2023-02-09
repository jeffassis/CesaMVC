using CesaMVC.br.com.cesa.connect;
using CesaMVC.br.com.cesa.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.dao
{
    public class ProdutoDAO
    {
        private readonly MySqlConnection vcon;

        public ProdutoDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddProduto(Produto obj, byte[] foto)
        {
            try
            {
                string sql = @"INSERT INTO tb_produto(nome, descricao, fornecedor_id, valor_venda, data, Imagem) 
                                VALUES(@nome, @descricao, @fornecedor_id, @valor_venda, curDate(), @Imagem)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@fornecedor_id", obj.FornecedorId);
                cmd.Parameters.AddWithValue("@valor_venda", obj.ValorVenda);
                cmd.Parameters.AddWithValue("@imagem", foto);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adicionado com sucesso!", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex);
            }
        }

        public void UpdateProduto(Produto obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_produto SET nome=@nome, descricao=@descricao, fornecedor_id=@fornecedor_id, valor_venda=@valor_venda WHERE id_produto=@id ";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@fornecedor_id", obj.FornecedorId);
                cmd.Parameters.AddWithValue("@valor_venda", obj.ValorVenda);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!", "Atualizar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex);
            }
        }

        public void UpdateProdutoComImagem(Produto obj, string id, byte[] foto)
        {
            try
            {
                string sql = @"UPDATE tb_produto SET nome=@nome, descricao=@descricao, fornecedor_id=@fornecedor_id, valor_venda=@valor_venda, imagem=@imagem WHERE id_produto=@id ";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@fornecedor_id", obj.FornecedorId);
                cmd.Parameters.AddWithValue("@valor_venda", obj.ValorVenda);
                cmd.Parameters.AddWithValue("@imagem", foto);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!", "Atualizar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex);
            }
        }

        public void DeleteProduto(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_produto WHERE id_produto=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        public DataTable ListarProduto()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT  tbp.id_produto, tbp.nome, tbp.descricao, tbf.nome, tbp.estoque, tbp.fornecedor_id,
                                        tbp.valor_venda, tbp.valor_compra, tbp.data, tbp.imagem 
                                FROM tb_produto as tbp
                                INNER JOIN tb_fornecedor as tbf ON tbf.id_fornecedor = tbp.fornecedor_id
                                ORDER BY tbp.nome";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a lista: " + ex);
                return null;
            }
        }

        public DataTable VerficarProduto(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nome FROM tb_produto WHERE nome=@nome";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", nome);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar Aluno: " + ex);
                return null;
            }
        }

        public DataTable ListarProdutoPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbp.id_produto, tbp.nome, tbp.descricao, tbf.nome, tbp.estoque, tbp.fornecedor_id,
                                        tbp.valor_venda, tbp.valor_compra, tbp.data, tbp.imagem
                                FROM tb_produto as tbp
                                INNER JOIN tb_fornecedor as tbf ON tbf.id_fornecedor = tbp.fornecedor_id
                                WHERE tbp.nome like @nome
                                ORDER BY tbp.nome ";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", nome);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar: " + ex);
                return null;
            }
        }

        public int RetornaEstoqueAtual(int idProduto)
        {
            try
            {
                int qtd_estoque = 0;
                string sql = "SELECT estoque FROM tb_produto WHERE id_produto=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", idProduto);
                vcon.Open();

                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    qtd_estoque = read.GetInt32("estoque");
                    vcon.Close();
                }
                return qtd_estoque;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                return 0;
            }
        }

        public void BaixaEstoque(int idProduto, int qtdEstoque)
        {
            try
            {
                string sql = "UPDATE tb_produto SET estoque=@qtd WHERE id_produto=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@qtd", qtdEstoque);
                cmd.Parameters.AddWithValue("@id", idProduto);
                vcon.Open();
                cmd.ExecuteNonQuery();
                vcon.Close();
                vcon.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                vcon.Close();
                vcon.Dispose();
            }
        }
    }
}
