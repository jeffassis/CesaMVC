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
    public class HorarioDAO
    {
        private readonly MySqlConnection vcon;

        public HorarioDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddHorario(Horario obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_horario(descricao, dia_id) VALUES(@descricao, @dia_id)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@dia_id", obj.DiaId);
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

        public void UpdateHorario(Horario obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_horario SET descricao=@descricao, dia_id=@dia_id WHERE id_horario=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@dia_id", obj.DiaId);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizada com sucesso!", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex);
            }
        }

        public void DeleteHorario(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_horario WHERE id_horario=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluida com sucesso!", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        public DataTable ListarDiaSemana()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_dia_semana";
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

        public DataTable ListarHorario()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT id_horario, descricao, tbd.dia FROM tb_horario INNER JOIN tb_dia_semana as tbd ON tbd.id_dia=dia_id";
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

        public DataTable VerficarHorario(string descricao, string dia)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT descricao FROM tb_horario WHERE descricao=@descricao and dia_id=@dia_id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@dia_id", dia);
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
    }
}
