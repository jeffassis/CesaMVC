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
    public partial class Report_AlunoTurma : Form
    {
        public Report_AlunoTurma()
        {
            InitializeComponent();
        }

        private void CarregarComboBox()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void Report_AlunoTurma_Load(object sender, EventArgs e)
        {
            CarregarComboBox();
            CbTurma.Focus();            
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            this.montTurmaTableAdapter.Fill(this.cesadbDataSet.MontTurma, Convert.ToInt32(CbTurma.SelectedValue));
            this.reportViewer1.RefreshReport();
        }
    }
}
