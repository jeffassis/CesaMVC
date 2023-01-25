using CesaMVC.br.com.cesa.connect;
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
    public class AlunoTurmaDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        public AlunoTurmaDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddAlunoTurma(string aluno_id, string turma_id )
        {
            try
            {
                string sql = @"INSERT INTO tb_aluno_turma (aluno_id, turma_id) VALUES (@aluno, @turma)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno_id);
                cmd.Parameters.AddWithValue("@turma", turma_id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adicionado com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados: " + ex);
            }
        }

        public void DeleteAlunoTurma(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_aluno_turma WHERE id_aluno_turma=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados excluido com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir dados: " + ex);
            }
        }

        public DataTable ListarAlunoTurma(string id_turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbd.id_aluno_turma, tba.nome, tbt.serie, tbt.nome, tbt.id_turma
                               FROM tb_aluno_turma as tbd
                               INNER JOIN tb_aluno as tba ON tba.id_aluno = tbd.aluno_id
                               INNER JOIN tb_turma as tbt ON tbt.id_turma = tbd.turma_id
                               WHERE tbt.id_turma=@turma ";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@turma", id_turma);
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
