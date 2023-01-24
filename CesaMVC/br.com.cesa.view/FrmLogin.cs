using CesaMVC.br.com.cesa.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmLogin : Form
    {
        readonly FrmMenuPrincipal form1;
        public FrmLogin(FrmMenuPrincipal f)
        {
            InitializeComponent();
            form1 = f;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void Logar()
        {
            string user, senha;
            user = txtUsername.Text;
            senha = txtSenha.Text;

            // Verifica se o Username esta vazio
            if (user == "" )
            {
                MessageBox.Show("Username não podem ser vazio!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            // Verifica se a Senha esta vazio
            if (senha == "")
            {
                MessageBox.Show("Senha não podem ser vazia!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }
            UsuarioDAO dao = new UsuarioDAO();
            DataTable dt = dao.EfetuarLogin(user, senha);
            if (dt.Rows.Count == 1)
            {
                form1.lblNivel.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lblUsuario.Text = dt.Rows[0].Field<string>("nome");
                form1.pictureBox1.Image = Properties.Resources.led_green_20;

                Program.nivel = int.Parse(dt.Rows[0].Field<Int32>("nivel").ToString());
                Program.nomeUsuario = dt.Rows[0].Field<string>("nome");
                Program.logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário não encontrado!", "ERROR ao logar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair do Sistema?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            FrmSplash form = new FrmSplash();
            form.ShowDialog();
        }
    }
}
