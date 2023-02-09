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
    public class ItemVendaDAO
    {
        private readonly MySqlConnection vcon;

        public ItemVendaDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void CadastrarItem(ItemVenda obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_itemvenda(venda_id, produto_id, quantidade, subtotal) VALUES (@venda_id, @produto_id, @quantidade, @subtotal)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@venda_id", obj.Venda_id);
                cmd.Parameters.AddWithValue("@produto_id", obj.Produto_id);
                cmd.Parameters.AddWithValue("@quantidade", obj.Quantidade);
                cmd.Parameters.AddWithValue("@subtotal", obj.SubTotal);
                vcon.Open();
                cmd.ExecuteNonQuery();
                                
                vcon.Close();
                vcon.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
            }

        }

        public DataTable ListarItensVenda(int venda_id)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT i.id_item, p.nome, i.quantidade, p.valor_venda, i.subtotal
                                FROM tb_itemvenda as i 
                                INNER JOIN tb_produto as p ON p.id_produto=i.produto_id
                                WHERE venda_id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", venda_id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
