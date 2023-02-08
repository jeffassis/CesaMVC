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
                "Email: jeff-assis@hotmail.com"
               ,"Sobre Nós", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FerramentasBackup_Click(object sender, EventArgs e)
        {
            FrmBackup form = new FrmBackup();
            AbreForm(3, form);
        }

        private void FerramentasCapturarFoto_Click(object sender, EventArgs e)
        {
            FrmCapturarFoto form = new FrmCapturarFoto();
            AbreForm(1, form);
        }

        private void CadastrosAlunos_Click(object sender, EventArgs e)
        {
            Program.chamadaAlunos = "NovoAluno";
            FrmAluno form = new FrmAluno();
            form.BtnNovo.Visible = true;
            AbreForm(1, form);
        }

        private void CadastrosTurmas_Click(object sender, EventArgs e)
        {
            FrmTurma form = new FrmTurma();
            AbreForm(2, form);
        }

        private void TurmaMontagemTurma_Click(object sender, EventArgs e)
        {
            FrmMatricula form = new FrmMatricula();
            AbreForm(2, form);
        }

        private void RelatoriosTurmas_Click(object sender, EventArgs e)
        {
            Report_AlunoTurma form = new Report_AlunoTurma();
            AbreForm(1, form);
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

        private void RelatoriosBoletimBimestral_Click(object sender, EventArgs e)
        {
            Report_BoletimAluno form = new Report_BoletimAluno();
            AbreForm(0, form);
        }

        private void CadastrosHorarios_Click(object sender, EventArgs e)
        {
            FrmHorario form = new FrmHorario();
            AbreForm(3, form);
        }

        private void PedagogicoHorarioProfessor_Click(object sender, EventArgs e)
        {
            Program.chamadaHorario = "NovaHora";
            FrmHoraProfessor form = new FrmHoraProfessor();
            AbreForm(2, form);
        }

        private void RelatoriosHorariosProfessor_Click(object sender, EventArgs e)
        {
            Report_HoraProfessor form = new Report_HoraProfessor();
            AbreForm(0, form);
        }

        private void CadastrosServicos_Click(object sender, EventArgs e)
        {
            Program.chamadaServico = "NovoServico";
            FrmServico form = new FrmServico();
            AbreForm(2, form);
        }

        private void FinanceiroGastos_Click(object sender, EventArgs e)
        {
            FrmGasto form = new FrmGasto();
            AbreForm(2, form);
        }

        private void FinanceiroMovimentacao_Click(object sender, EventArgs e)
        {
            FrmMovimentacao form = new FrmMovimentacao();
            AbreForm(2, form);
        }

        private void EstoqueFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedor form = new FrmFornecedor();
            AbreForm(2, form);
        }

        private void EstoqueProdutos_Click(object sender, EventArgs e)
        {
            FrmProduto form = new FrmProduto();
            AbreForm(2, form);
        }

        private void PedagogicoNotaAnual_Click(object sender, EventArgs e)
        {
            FrmBoletimFinal form = new FrmBoletimFinal();
            AbreForm(0, form);
        }

        private void PedagogicoNotasDisciplina_Click(object sender, EventArgs e)
        {
            FrmNotasDisciplina form = new FrmNotasDisciplina();
            AbreForm(0, form);
        }

        private void FinanceiroEntradaSaida_Click(object sender, EventArgs e)
        {
            Report_EntradaSaida form = new Report_EntradaSaida();
            AbreForm(2, form);
        }

        private void FinanceiroMensalidadeReceber_Click(object sender, EventArgs e)
        {
            FrmMensalidade form = new FrmMensalidade();
            AbreForm(2, form);
        }

        private void PedagogicoTurma_Click(object sender, EventArgs e)
        {
            FrmMatricula form = new FrmMatricula();
            AbreForm(2, form);
        }

        private void FinanceiroMensalidadeConsultar_Click(object sender, EventArgs e)
        {
            FrmMensalidadeConsultar form = new FrmMensalidadeConsultar();
            AbreForm(2, form);
        }

        private void RelatorioFinanceiroMensalidade_Click(object sender, EventArgs e)
        {
            Report_ConsultarMensalidade form = new Report_ConsultarMensalidade();
            AbreForm(2, form);
        }
    }
}
