using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.connect
{
    public class ConnectionFactory
    {
        // Metodo conecta ao DB
        public MySqlConnection GetConnection()
        {
            string vcon = ConfigurationManager.ConnectionStrings["CesaMVC.Properties.Settings.cesadbConnectionString"].ConnectionString;
            return new MySqlConnection(vcon);
        }
    }
}
