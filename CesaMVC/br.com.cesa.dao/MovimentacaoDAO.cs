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
    public class MovimentacaoDAO
    {
        private readonly MySqlConnection vcon;

        public MovimentacaoDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddMovimentacao(Movimentacao obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_movimentacao(tipo, movimento, valor, funcionario, data, id_movimento) VALUES(@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("@movimento", obj.Movimento);
                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                cmd.Parameters.AddWithValue("@id_movimento", obj.IdMovimento);
                vcon.Open();
                cmd.ExecuteNonQuery();
                
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex);
            }
        }

        public void UpdateMovimentacao(Movimentacao obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_movimentacao SET valor=@valor, funcionario=@funcionario, data=curDate() WHERE id_movimento=@id AND movimento=@movimento";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);                
                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                cmd.Parameters.AddWithValue("@movimento", obj.Movimento);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();

                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
            }
        }

        public void DeleteMovimentacao(string id, string movimento)
        {
            try
            {
                string sql = @"DELETE FROM tb_movimentacao WHERE id_movimento=@id AND movimento=@movimento";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);                
                cmd.Parameters.AddWithValue("@movimento", movimento);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();

                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        public DataTable BuscarData(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_movimentacao WHERE data >= @dataInicial AND data <= @dataFinal ORDER BY data desc";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@dataInicial", dataInicial);
                cmd.Parameters.AddWithValue("@dataFinal", dataFinal);
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
                MessageBox.Show("Erro ao buscar data: " + ex);
                return null;
            }
        }

        public DataTable BuscarDataTipo(DateTime dataInicial, DateTime dataFinal, string tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_movimentacao where data >= @dataInicial and data <= @dataFinal and tipo = @tipo order by data desc";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@dataInicial", dataInicial);
                cmd.Parameters.AddWithValue("@dataFinal", dataFinal);
                cmd.Parameters.AddWithValue("@tipo", tipo);
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
                MessageBox.Show("Erro ao buscar data por tipo: " + ex);
                return null;
            }
        }
    }
}
