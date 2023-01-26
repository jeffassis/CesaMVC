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
    public class BimestreDAO
    {
        // Variavel de conexao
        private readonly MySqlConnection vcon;

        // Construtor
        public BimestreDAO()
        {
            this.vcon = new ConnectionFactory().GetConnection();
        }

        public DataTable ListarBimestre()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_bimestre";
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
