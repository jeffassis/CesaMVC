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
    public class GastoDAO
    {
        private readonly MySqlConnection vcon;


        public GastoDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddGasto(Gasto obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_gasto(descricao, valor, funcionario, data) VALUES(@descricao, @valor, @funcionario, curDate())";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
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

        public void UpdateGasto(Gasto obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_gasto SET descricao=@descricao, valor=@valor, funcionario=@funcionario, data=curDate() WHERE id_gasto=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
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

        public void DeleteGasto(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_gasto WHERE id_gasto=@id";
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

        public DataTable ListarGasto()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_gasto ORDER BY data desc";
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

        public DataTable BuscarGastoPorData(DateTime data)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_gasto where data = @data order by data desc";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@data", data);
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

        public DataTable VerificarGastoPorData(string descricao, string valor, DateTime data)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_gasto WHERE descricao=@descricao and valor=@valor and data=@data";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@data", data);
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

        public int UltimoIdGasto()
        {
            try
            {
                int idGasto = 0;
                string sql = "SELECT MAX(id_gasto) id_gasto FROM tb_gasto";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                vcon.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    idGasto = read.GetInt32("id_gasto");                    
                }
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
                return idGasto;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                return 0;
            }
        }
    }
}
