using CesaMVC.br.com.cesa.report;
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
        //public static string caminhoBanco = "server=mysql247.umbler.com;user id=jeffassis;database=cesadb; pwd=jean1420; port=41890;";

        // Variaveis globais de controle de usuario
        public static string nomeUsuario;
        public static int nivel;
        public static Boolean logado = false;

        // Variaveis globais cadastro Aluno
        public static string chamadaAlunos;
        public static string nomeAluno;
        public static string idAluno;

        // Variaveis para chamar tela horario
        public static string chamadaServico;
        public static string idServico;
        public static string nomeServico;
        public static string valorServico;

        // Variaveis para chamar tela horario
        public static string chamadaHorario;
        public static string idHorario;
        public static string nomeHorario;
        public static string diaHorario;

        // Variaveis para chamar tela produto
        public static string chamadaProduto;
        public static string idProduto;
        public static string nomeProduto;
        public static string precoProduto;
        public static string estoqueProduto;

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
