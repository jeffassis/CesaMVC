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
    public class MensalidadeDAO
    {
        private readonly MySqlConnection vcon;

        public MensalidadeDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddMensalidade(Mensalidade obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_mensalidade (turma_id, aluno_id, servico_id, data, funcionario, situacao, mes, observacao) 
                                                         VALUES (@turma_id, @aluno_id, @servico_id, curDate(), @funcionario, @situacao, @mes, @observacao)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@turma_id", obj.TurmaId);
                cmd.Parameters.AddWithValue("@aluno_id", obj.AlunoId);
                cmd.Parameters.AddWithValue("@servico_id", obj.ServicoId);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                cmd.Parameters.AddWithValue("@situacao", "Pago");
                cmd.Parameters.AddWithValue("@mes", obj.Mes);
                cmd.Parameters.AddWithValue("@observacao", obj.Observacao);
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

        public void UpdateMensalidade(Mensalidade obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_mensalidade SET turma_id=@turma_id, aluno_id=@aluno_id, servico_id=@servico_id, funcionario=@funcionario,
                                        situacao=@situacao, mes=@mes, observacao=@observacao WHERE id_mensalidade=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@turma_id", obj.TurmaId);
                cmd.Parameters.AddWithValue("@aluno_id", obj.AlunoId);
                cmd.Parameters.AddWithValue("@servico_id", obj.ServicoId);
                cmd.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                cmd.Parameters.AddWithValue("@situacao", "Pago");
                cmd.Parameters.AddWithValue("@mes", obj.Mes);
                cmd.Parameters.AddWithValue("@observacao", obj.Observacao);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso", "Atualizar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados: " + ex);
            }
        }

        public void DeleteMensalidade(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_mensalidade WHERE id_mensalidade=@id";
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

        public DataTable ListarMensalidade(string aluno, string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbm.id_mensalidade, tbt.nome, tba.nome, tbs.nome, tbs.valor, tbm.data, tbm.funcionario,
                                            tbm.situacao, tbm.mes, tbm.observacao
                                FROM tb_mensalidade AS tbm
                                INNER JOIN tb_turma as tbt ON id_turma=turma_id
                                INNER JOIN tb_aluno as tba ON id_aluno=aluno_id
                                INNER JOIN tb_servico as tbs ON id_servico=servico_id
                                WHERE tbm.aluno_id=@aluno and tbm.turma_id=@turma
                                ORDER BY tbm.mes desc";
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

        public DataTable VerficarMensalidade(string aluno, string mes, string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT aluno_id FROM tb_mensalidade WHERE aluno_id=@aluno and mes=@mes and turma_id=@turma";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);                
                cmd.Parameters.AddWithValue("@mes", mes);
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

        public int UltimoIdMensalidade()
        {
            try
            {
                int idMensalidade = 0;
                string sql = "SELECT MAX(id_mensalidade) id_mensalidade FROM tb_mensalidade";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                vcon.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    idMensalidade = read.GetInt32("id_mensalidade");
                }
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
                return idMensalidade;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                return 0;
            }
        }

        public DataTable ConsultarMensalidade(string aluno, string turma, string situacao)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT tbm.id_mensalidade, tbt.nome, tba.nome, tbs.nome, tbs.valor, tbm.data, tbm.funcionario,
                                            tbm.situacao, tbm.mes, tbm.observacao
                                FROM tb_mensalidade AS tbm
                                INNER JOIN tb_turma as tbt ON id_turma=turma_id
                                INNER JOIN tb_aluno as tba ON id_aluno=aluno_id
                                INNER JOIN tb_servico as tbs ON id_servico=servico_id
                                WHERE tbm.aluno_id=@aluno and tbm.turma_id=@turma and situacao=@situacao
                                ORDER BY tbm.mes desc";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@aluno", aluno);
                cmd.Parameters.AddWithValue("@turma", turma);
                cmd.Parameters.AddWithValue("@situacao", situacao);
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
