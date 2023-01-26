using CesaMVC.br.com.cesa.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            FrmLogin login = new FrmLogin(this);
            login.ShowDialog();
        }

        // Funcao para abrir os formularios com parametros de nivel de acesso 
        private void AbreForm(int nivel, Form f)
        {
            if (Program.logado)
            {
                if (Program.nivel >= nivel)
                {
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso nao permitido", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("E necessario ter um usuário logado", "Acesso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lbldata.Text = DateTime.Now.ToShortDateString();
        }       

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void LogOff_Click(object sender, EventArgs e)
        {
            lblNivel.Text = "0";
            lblUsuario.Text = "---";
            pictureBox1.Image = Properties.Resources.led_red_20;

            Program.nivel = 0;
            Program.logado = false;
        }

        private void LoginLogOn_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(this);
            login.ShowDialog();
        }

        private void UsuarioGestaoUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuario form = new FrmUsuario();
            AbreForm(2, form);
        }

        private void FerramentasSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Quality Engineer: Jefferson Assis " + "\n" +
                "Tel:(21) 981792-2516" + "\n" +
                "Email: jeff-assis@hotmail.com" + "\n" +
                "Github: jeffassis", "Sobre Nós", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FerramentasBackup_Click(object sender, EventArgs e)
        {
            FrmBackup form = new FrmBackup();
            AbreForm(3, form);
        }

        private void FerramentasCapturarFoto_Click(object sender, EventArgs e)
        {
            FrmCapturarFoto form = new FrmCapturarFoto();
            AbreForm(0, form);
        }

        private void CadastrosAlunos_Click(object sender, EventArgs e)
        {
            Program.chamadaAlunos = "NovoAluno";
            FrmAluno form = new FrmAluno();
            AbreForm(1, form);
        }

        private void CadastrosTurmas_Click(object sender, EventArgs e)
        {
            FrmTurma form = new FrmTurma();
            AbreForm(2, form);
        }

        private void TurmaMontagemTurma_Click(object sender, EventArgs e)
        {
            FrmMontTurma form = new FrmMontTurma();
            AbreForm(2, form);
        }

        private void RelatoriosTurmas_Click(object sender, EventArgs e)
        {
            Report_AlunoTurma form = new Report_AlunoTurma();
            AbreForm(0, form);
        }

        private void CadastrosDisciplinas_Click(object sender, EventArgs e)
        {
            FrmDisciplina form = new FrmDisciplina();
            AbreForm(2, form);
        }

        private void CadastrosProfessor_Click(object sender, EventArgs e)
        {
            FrmProfessor form = new FrmProfessor();
            AbreForm(1, form);
        }

        private void CadastrosResponsavel_Click(object sender, EventArgs e)
        {
            FrmResponsavel form = new FrmResponsavel();
            AbreForm(1, form);
        }

        private void PedagogicoNotasLancamento_Click(object sender, EventArgs e)
        {
            FrmNotas form = new FrmNotas();
            AbreForm(0, form);
        }

        private void PedagogicoNotasBoletimAluno_Click(object sender, EventArgs e)
        {
            FrmBoletimAluno form = new FrmBoletimAluno();
            AbreForm(0, form);
        }
    }
}
