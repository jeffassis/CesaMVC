using CesaMVC.br.com.cesa.connect;
using CesaMVC.br.com.cesa.model;
using CesaMVC.br.com.cesa.view;
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
    public class UsuarioDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public UsuarioDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public void AddUser(Usuario obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_user(nome, username, senha, status, nivel) 
                                VALUES(@nome, @username, @senha, @status, @nivel)";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@senha", obj.Senha);
                cmd.Parameters.AddWithValue("@status", obj.Status);
                cmd.Parameters.AddWithValue("@nivel", obj.Nivel);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário adicionado com sucesso", "Adicionar dados!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar usuário: " + ex);
            }
        }

        public void UpdateUser(Usuario obj, string id)
        {
            try
            {
                string sql = @"UPDATE tb_user SET nome=@nome, username=@username, senha=@senha, status=@status, 
                                nivel=@nivel WHERE id_user=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@username", obj.Username);
                cmd.Parameters.AddWithValue("@senha", obj.Senha);
                cmd.Parameters.AddWithValue("@status", obj.Status);
                cmd.Parameters.AddWithValue("@nivel", obj.Nivel);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário atualizado com sucesso", "Sucesso ao atualizar!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar usuário: " + ex);
            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                string sql = "DELETE FROM tb_user WHERE id_user=@id";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@id", id);
                vcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário excluido com sucesso", "Sucesso ao excluir!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vcon.Close();
                vcon.Dispose();
                vcon.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir usuário: " + ex);
            }
        }

        public DataTable ListarUser()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_user";
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


        public DataTable ListarUserPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_user WHERE nome like @nome";
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
                MessageBox.Show("Erro ao listar usuário: " + ex);
                return null;
            }
        }

        public DataTable VerficaUsername(string username)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT username FROM tb_user WHERE username=@username";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@username", username);
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
                MessageBox.Show("Erro ao verificar Username: " + ex);
                return null;
            }
        }

        public DataTable EfetuarLogin(string username, string senha)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_user WHERE username=@user and senha=@senha";
                MySqlCommand cmd = new MySqlCommand(sql, vcon);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@senha", senha);
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
                MessageBox.Show("Erro ao efetuar login: " + ex);
                return null;
            }
        }            
    }
}
