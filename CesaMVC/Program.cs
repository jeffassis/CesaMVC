using CesaMVC.br.com.cesa.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC
{
    static class Program
    {

        // Variavel global de Conexao de dados
        public static string caminhoBanco = "SERVER=localhost; DATABASE=cesadb; UID=root; PWD=; PORT=;";
        //public static string caminhoBanco = "SERVER=mysql835.umbler.com; DATABASE=project_escola; UID=jeffassis; PWD=jean1420; PORT=41890;";

        // Variaveis globais de controle de usuario
        public static string nomeUsuario;
        public static int nivel;
        public static Boolean logado = false;

        // Variaveis globais cadastro Aluno
        public static string chamadaAlunos;
        public static string nomeAluno;
        public static string idAluno;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMenuPrincipal());
        }
    }
}
