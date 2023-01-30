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
    public class NotasDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public NotasDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddNotas(Notas obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_nota(aluno_id, disciplina_id, turma_id, bimestre_id, tipo, nota) 
                                VALUES(@aluno_id, @disciplina_id, @turma_id, @bimestre, @tipo, @nota)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno_id", obj.AlunoId);
                cmd.Parameters.AddWithValue("@disciplina_id", obj.DisciplinaId);
                cmd.Parameters.AddWithValue("@turma_id", obj.TurmaId);
                cmd.Parameters.AddWithValue("@bimestre", obj.Bimestre);
                cmd.Parameters.AddWithValue("@tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("@nota", obj.Nota);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adicionado com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex);
            }
        }

        public void UpdateNotas(Notas obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_nota SET aluno_id=@aluno, disciplina_id=@disciplina, turma_id=@turma, bimestre_id=@bimestre, tipo=@tipo, nota=@nota WHERE id_nota=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", obj.AlunoId);
                cmd.Parameters.AddWithValue("@disciplina", obj.DisciplinaId);
                cmd.Parameters.AddWithValue("@turma", obj.TurmaId);
                cmd.Parameters.AddWithValue("@bimestre", obj.Bimestre);
                cmd.Parameters.AddWithValue("@tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("@nota", obj.Nota);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizada com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex);
            }
        }

        public void DeleteNotas(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_nota WHERE id_nota=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluida com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        public DataTable ListarNotas(string aluno, string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbn.id_nota, tba.nome, tbb.bimestre, tbd.nome, tbn.tipo, tbn.nota, tbt.nome
                                FROM tb_nota as tbn
                                INNER JOIN tb_aluno as tba ON tba.id_aluno=tbn.aluno_id
                                INNER JOIN tb_disciplina as tbd ON tbd.id_disciplina=tbn.disciplina_id
                                INNER JOIN tb_turma as tbt ON tbt.id_turma=tbn.turma_id
                                INNER JOIN tb_bimestre as tbb ON tbb.id_bimestre=tbn.bimestre_id
                                WHERE tbn.aluno_id=@aluno and tbn.turma_id=@turma
                                ORDER BY tba.nome";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);
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

        public DataTable VerficarNotas(string aluno, string disciplina, string bimestre, string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT aluno_id FROM tb_nota WHERE aluno_id=@aluno and disciplina_id=@disciplina and bimestre_id=@bimestre and turma_id=@turma";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);
                cmd.Parameters.AddWithValue("@disciplina", disciplina);
                cmd.Parameters.AddWithValue("@bimestre", bimestre);
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
                MessageBox.Show("Erro ao verificar: " + ex);
                return null;
            }
        }

        public DataTable ListarBoletimAluno(int aluno, int bimestre, int turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbd.nome, bimestre,
                            (SELECT nota FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND 
                                    n1.bimestre_id=tbb.id_bimestre AND n1.turma_id=tbt.id_turma) AS 'nota'
                            FROM tb_nota as tbn
                            INNER JOIN tb_aluno as tba ON tba.id_aluno=tbn.aluno_id
                            INNER JOIN tb_disciplina as tbd ON tbd.id_disciplina=tbn.disciplina_id
                            INNER JOIN tb_bimestre as tbb ON tbb.id_bimestre=tbn.bimestre_id
                            INNER JOIN tb_turma as tbt ON tbt.id_turma=tbn.turma_id
                            WHERE
                            tbn.aluno_id=@aluno AND tbn.bimestre_id=@bimestre AND tbn.turma_id=@turma
                            GROUP BY tbd.nome, tba.nome, tbd.id_disciplina, tbn.bimestre_id,tbb.bimestre";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);
                cmd.Parameters.AddWithValue("@bimestre", bimestre);
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

        public DataTable ListarBoletimFinal(int aluno, int turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT DISTINCT(tbd.nome) as 'DISCIPLINA',
                (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=1) as 'BIMESTRE 1',
                (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=2) as 'BIMESTRE 2',
                (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=3) as 'BIMESTRE 3',
                (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=4) as 'BIMESTRE 4',
    	            ((SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=1) +
                     (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=2) +
                     (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=3) +
                     (SELECT AVG(nota) FROM tb_nota AS n1 WHERE n1.aluno_id=tba.id_aluno AND n1.disciplina_id=tbd.id_disciplina AND n1.turma_id=tbt.id_turma AND n1.bimestre_id=4))/4 AS 'MEDIA',
                        turma_id
                FROM
                    tb_nota as tbn
                INNER JOIN
                    tb_aluno tba ON tba.id_aluno=tbn.aluno_id 
                INNER JOIN
                    tb_disciplina as tbd ON tbd.id_disciplina=tbn.disciplina_id 
                INNER JOIN
                    tb_bimestre as tbb ON tbb.id_bimestre=tbn.bimestre_id
                INNER JOIN
                    tb_turma as tbt ON tbt.id_turma=tbn.turma_id
                WHERE
                    tbn.aluno_id=@aluno and tbn.turma_id=@turma
                GROUP BY
                    tbd.nome, tba.id_aluno,tbd.id_disciplina,tbn.bimestre_id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);
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
