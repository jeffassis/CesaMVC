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
    public class TurmaDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public TurmaDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddTurma(Turma obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_turma(nome, serie, turno, ano_id) 
                                VALUES(@nome, @serie, @turno, @ano_id)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@serie", obj.Serie);
                cmd.Parameters.AddWithValue("@turno", obj.Turno);
                cmd.Parameters.AddWithValue("@ano_id", obj.AnoId);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Turma adicionado com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar turma: " + ex);
            }
        }

        public void UpdateTurma(Turma obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_turma SET nome=@nome, serie=@serie, turno=@turno, ano_id=@ano_id WHERE id_turma=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@serie", obj.Serie);
                cmd.Parameters.AddWithValue("@turno", obj.Turno);
                cmd.Parameters.AddWithValue("@ano_id", obj.AnoId);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Turma atualizada com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar turma: " + ex);
            }
        }

        public void DeleteTurma(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_turma WHERE id_turma=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Turma excluida com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir turma: " + ex);
            }
        }

        public DataTable ListarTurma()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT id_turma, nome, serie, turno, tba.ano 
                               FROM tb_turma 
                               INNER JOIN tb_ano AS tba ON tba.id_ano=ano_id";
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

        public DataTable VerficarTurma(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nome FROM tb_turma WHERE nome=@nome";
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
                MessageBox.Show("Erro ao verificar Turma: " + ex);
                return null;
            }
        }

        public DataTable ListarAno()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_ano";
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

        public DataTable ListarTurmaPorAno(int ano)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT id_turma, nome, serie, turno, tba.ano, ano_id
                               FROM tb_turma 
                               INNER JOIN tb_ano AS tba ON tba.id_ano=ano_id
                               WHERE ano_id=@ano_id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@ano_id", ano);
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
    }
}
