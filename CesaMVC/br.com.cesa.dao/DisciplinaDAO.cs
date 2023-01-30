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
    public class DisciplinaDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public DisciplinaDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddDisciplina(Disciplina obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_disciplina(nome) VALUES(@nome)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Disciplina adicionada com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar disciplina: " + ex);
            }
        }

        public void UpdateDisciplina(Disciplina obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_disciplina SET nome=@nome WHERE id_disciplina=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Disciplina atualizada com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar disciplina: " + ex);
            }
        }

        public void DeleteDisciplina(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_disciplina WHERE id_disciplina=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Disciplina excluida com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir disciplina: " + ex);
            }
        }

        public DataTable ListarDisciplina()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_disciplina";
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

        public DataTable VerficarDisciplina(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nome FROM tb_disciplina WHERE nome=@nome";
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
                MessageBox.Show("Erro ao verificar Disciplina: " + ex);
                return null;
            }
        }

        public DataTable ListarDisciplinaPorTurma(string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT DISTINCT(tbd.nome), tbd.id_disciplina, tbn.turma_id FROM tb_nota tbn
                                INNER JOIN tb_disciplina tbd ON tbd.id_disciplina=tbn.disciplina_id
                                INNER JOIN tb_turma tbt ON tbt.id_turma=tbn.turma_id
                                WHERE turma_id=@turma
                                ORDER BY tbd.nome";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@turma", turma);
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
