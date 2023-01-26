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

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmBoletimAluno : Form
    {
        public FrmBoletimAluno()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {            
            Grid.Columns[0].HeaderText = "DISCIPLINA";
            Grid.Columns[1].HeaderText = "BIMESTRE";
            Grid.Columns[2].HeaderText = "NOTA";

            Grid.Columns[0].Width = 160;
            Grid.Columns[1].Width = 110;
            Grid.Columns[2].Width = 90;

        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            NotasDAO dao = new NotasDAO();
            Grid.DataSource = dao.ListarBoletimAluno(int.Parse(CbAluno.SelectedValue.ToString()), 
                                                    int.Parse(cbBimestre.SelectedValue.ToString()),
                                                    int.Parse(CbTurma.SelectedValue.ToString()));

            FormatarDG();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void FrmBoletimAluno_Load(object sender, EventArgs e)
        {
            ComboTurma();
            ComboBimestre();
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                ComboAluno();
                CbAluno.Enabled = true;
                cbBimestre.Enabled = true;
            }
        }

        private void ComboBimestre()
        {
            BimestreDAO dao = new BimestreDAO();
            cbBimestre.DataSource = dao.ListarBimestre();
            cbBimestre.DisplayMember = "bimestre";
            cbBimestre.ValueMember = "id_bimestre";
        }

        private void ComboAluno()
        {
            AlunoDAO dao = new AlunoDAO();
            CbAluno.DataSource = dao.ListarAlunoPorTurma(CbTurma.SelectedValue.ToString());
            CbAluno.DisplayMember = "nome";
            CbAluno.ValueMember = "id_aluno";
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (CbAluno.Text == "" || cbBimestre.Text == "")
            {
                MessageBox.Show("Selecione aluno e bimestre!", "Erro de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            else
            {
                Listar();
                CbAluno.Enabled = false;
                cbBimestre.Enabled = false;
            }
        }
    }
}
