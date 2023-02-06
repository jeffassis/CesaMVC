using CesaMVC.br.com.cesa.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.report
{
    public partial class Report_ConsultarMensalidade : Form
    {
        public Report_ConsultarMensalidade()
        {
            InitializeComponent();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void ComboAluno()
        {
            AlunoDAO dao = new AlunoDAO();
            CbAluno.DataSource = dao.ListarAlunoPorTurma(CbTurma.SelectedValue.ToString());
            CbAluno.DisplayMember = "nome";
            CbAluno.ValueMember = "id_aluno";
        }

        private void Report_ConsultarMensalidade_Load(object sender, EventArgs e)
        {
            ComboTurma();            
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                CbAluno.SelectedIndex = -1;
                ComboAluno();
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (CbAluno.Text == "")
            {
                MessageBox.Show("Selecione um Aluno!", "Erro de consulta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            else
            {
                this.consultarMensalidadeTableAdapter.Fill(this.cesadbDataSet.ConsultarMensalidade,
                                                    int.Parse(CbAluno.SelectedValue.ToString()),                                                    
                                                    int.Parse(CbTurma.SelectedValue.ToString()),
                                                    "Pago");
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
