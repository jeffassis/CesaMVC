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
    public class VendaDAO
    {
        private readonly MySqlConnection vcon;

        public VendaDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void CadastrarVenda(Venda obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_venda(funcionario, data_venda, total_venda, obs) VALUES (@funcionario, @data_venda, @total_venda, @obs)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                cmd.Parameters.AddWithValue("@data_venda", obj.Data_venda);
                cmd.Parameters.AddWithValue("@total_venda", obj.Total_venda);
                cmd.Parameters.AddWithValue("@obs", obj.Obs);
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

        public int RetornaIdUltimaVenda()
        {
            try
            {
                int idVenda = 0;
                string sql = @"SELECT MAX(id_venda) id_venda from tb_venda";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                vcon.Open();

                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    idVenda = read.GetInt32("id_venda");
                }
                vcon.Close();
                return idVenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                return 0;
            }
        }

        public DataTable ListarVendasPorPeriodo(DateTime DtInicial, DateTime DtFinal)
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = @"SELECT id_venda, funcionario, data_venda, total_venda, obs
                               FROM tb_venda
                               WHERE data_venda
                               BETWEEN @data_inicial AND @data_final";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@data_inicial", DtInicial);
                cmd.Parameters.AddWithValue("@data_final", DtFinal);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar o comando: " + ex);
                return null;
            }
        }
    }
}
