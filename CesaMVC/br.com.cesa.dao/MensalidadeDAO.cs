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
                cmd.Parameters.AddWithValue("@situacao", obj.Situacao);
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

        public DataTable ListarMensalidade()
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
                                ORDER BY tbm.mes desc";
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
    }
}
