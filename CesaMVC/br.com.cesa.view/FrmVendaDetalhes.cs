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
    public partial class FrmVendaDetalhes : Form
    {
        readonly int venda_id;
        public FrmVendaDetalhes(int idVenda)
        {
            venda_id = idVenda;
            InitializeComponent();
        }

        private void FrmVendaDetalhes_Load(object sender, EventArgs e)
        {
            ItemVendaDAO dao = new ItemVendaDAO();
            Grid.DataSource = dao.ListarItensVenda(venda_id);
        }
    }
}
