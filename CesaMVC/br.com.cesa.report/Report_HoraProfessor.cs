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
    public partial class Report_HoraProfessor : Form
    {
        public Report_HoraProfessor()
        {
            InitializeComponent();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbCombo.DataSource = dao.ListarTurma();
            CbCombo.DisplayMember = "nome";
            CbCombo.ValueMember = "id_turma";
        }

        private void Report_HoraProfessor_Load(object sender, EventArgs e)
        {
            ComboTurma();
           
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            this.horaProfessorTableAdapter.Fill(this.cesadbDataSet.HoraProfessor, Convert.ToInt32(CbCombo.SelectedValue));
            //this.montTurmaTableAdapter.Fill(this.cesadbDataSet.MontTurma, Convert.ToInt32(CbTurma.SelectedValue));
            this.reportViewer1.RefreshReport();
        }
    }
}
