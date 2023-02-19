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
    public partial class Report_BoletimFinal : Form
    {
        public Report_BoletimFinal()
        {
            InitializeComponent();
        }

        private void Report_BoletimFinal_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
