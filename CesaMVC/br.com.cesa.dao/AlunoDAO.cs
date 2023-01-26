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
    public class AlunoDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public AlunoDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddAluno(Aluno obj, byte[] foto)
        {
            try
            {
                string sql = @"INSERT INTO tb_aluno(nome, rg, cpf, email, nascimento, telefone, celular, sangue, endereco, cep, bairro, cidade, estado, imagem) 
                                VALUES(@nome, @rg, @cpf, @email, @nascimento, @telefone, @celular, @sangue, @endereco, @cep, @bairro, @cidade, @estado, @imagem)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@rg", obj.Rg);
                cmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@nascimento", obj.Nascimento);
                cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                cmd.Parameters.AddWithValue("@celular", obj.Celular);
                cmd.Parameters.AddWithValue("@sangue", obj.Sangue);
                cmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                cmd.Parameters.AddWithValue("@cep", obj.Cep);
                cmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@estado", obj.Estado);
                cmd.Parameters.AddWithValue("@imagem", foto);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aluno adicionado com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar aluno: " + ex);
            }
        }

        public void UpdateAluno(Aluno obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_aluno SET nome=@nome, rg=@rg, cpf=@cpf, email=@email, nascimento=@nascimento, telefone=@telefone, celular=@celular, sangue=@sangue, 
                                endereco=@endereco, cep=@cep, bairro=@bairro, cidade=@cidade, estado=@estado WHERE id_aluno=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@rg", obj.Rg);
                cmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@nascimento", obj.Nascimento);
                cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                cmd.Parameters.AddWithValue("@celular", obj.Celular);
                cmd.Parameters.AddWithValue("@sangue", obj.Sangue);
                cmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                cmd.Parameters.AddWithValue("@cep", obj.Cep);
                cmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@estado", obj.Estado);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aluno atualizado com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar aluno: " + ex);
            }
        }

        public void UpdateAlunoComImagem(Aluno obj, string id, byte[] foto)
        {
            try
            {
                string sql = @"UPDATE tb_aluno SET nome=@nome, rg=@rg, cpf=@cpf, email=@email, nascimento=@nascimento, telefone=@telefone, celular=@celular, sangue=@sangue, 
                                endereco=@endereco, cep=@cep, bairro=@bairro, cidade=@cidade, estado=@estado, imagem=@imagem WHERE id_aluno=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@rg", obj.Rg);
                cmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@nascimento", obj.Nascimento);
                cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                cmd.Parameters.AddWithValue("@celular", obj.Celular);
                cmd.Parameters.AddWithValue("@sangue", obj.Sangue);
                cmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                cmd.Parameters.AddWithValue("@cep", obj.Cep);
                cmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@estado", obj.Estado);
                cmd.Parameters.AddWithValue("@imagem", foto);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aluno atualizado com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar aluno: " + ex);
            }
        }

        public void DeleteAluno(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_aluno WHERE id_aluno=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aluno excluido com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir aluno: " + ex);
            }
        }

        public DataTable ListarAluno()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_aluno";
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

        public DataTable ListarAlunoPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_aluno WHERE nome like @nome";
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
                MessageBox.Show("Erro ao listar aluno: " + ex);
                return null;
            }
        }

        public DataTable VerficarAluno(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nome FROM tb_aluno WHERE nome=@nome";
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
                MessageBox.Show("Erro ao verificar Aluno: " + ex);
                return null;
            }
        }

        public DataTable ListarAlunoPorTurma(string turma)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT id_aluno, a.nome, id_turma FROM tb_aluno_turma tba
                                INNER JOIN tb_aluno a ON a.id_aluno=tba.aluno_id
                                INNER JOIN tb_turma t ON t.id_turma=tba.turma_id
                                WHERE id_turma=@turma
                                ORDER BY a.nome";
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
