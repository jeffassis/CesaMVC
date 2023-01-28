using CesaMVC.br.com.cesa.connect;
using CesaMVC.br.com.cesa.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
