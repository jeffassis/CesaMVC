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
    public class HoraProfessorDAO
    {
        private readonly MySqlConnection vcon;

        public HoraProfessorDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection(); 
        }

        public void AddHoraProfessor(HoraProfessor obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_hora_professor(horario_id, disciplina_id, turma_id) VALUES(@horario_id, @disciplina_id, @turma_id)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@horario_id", obj.HorarioId);
                cmd.Parameters.AddWithValue("@disciplina_id", obj.DisciplinaId);
                cmd.Parameters.AddWithValue("@turma_id", obj.TurmaId);
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

        public void UpdateHoraProfessor(HoraProfessor obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_hora_professor SET horario_id=@horario_id, disciplina_id=@disciplina_id, turma_id=@turma_id WHERE id_hora_professor=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@horario_id", obj.HorarioId);
                cmd.Parameters.AddWithValue("@disciplina_id", obj.DisciplinaId);
                cmd.Parameters.AddWithValue("@turma_id", obj.TurmaId);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!", "Aatualizar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
            }
        }

        public void DeleteHoraProfessor(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_hora_professor WHERE id_hora_professor=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso!", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        public DataTable ListarHoraProfessor(string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT th.id_hora_professor, tbh.descricao,
                                (SELECT d.dia from tb_dia_semana d WHERE d.id_dia=tbh.dia_id) as dia,
                                tbd.nome, tbt.serie, tbt.id_turma
                               FROM tb_hora_professor as th
                               INNER JOIN tb_horario as tbh ON tbh.id_horario=th.horario_id
                               INNER JOIN tb_disciplina as tbd ON tbd.id_disciplina=th.disciplina_id
                               INNER JOIN tb_turma as tbt ON tbt.id_turma=th.turma_id
                               WHERE tbt.id_turma=@turma
                               ORDER BY tbh.dia_id, tbh.descricao";
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
