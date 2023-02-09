using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesaMVC.br.com.cesa.view
{
    public partial class FrmProfessor : Form
    {
        string foto;
        string alterou;
        string idSelecionado;
        string ProfessorAntigo;
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "#";
            Grid.Columns[1].HeaderText = "NOME";
            Grid.Columns[2].HeaderText = "RG";
            Grid.Columns[3].HeaderText = "CPF";
            Grid.Columns[4].HeaderText = "EMAIL";
            Grid.Columns[5].HeaderText = "NASCIMENTO";
            Grid.Columns[6].HeaderText = "TELEFONE";
            Grid.Columns[7].HeaderText = "CELULAR";
            Grid.Columns[8].HeaderText = "SANGUE";
            Grid.Columns[9].HeaderText = "ENDEREÇO";
            Grid.Columns[10].HeaderText = "CEP";
            Grid.Columns[11].HeaderText = "BAIRRO";
            Grid.Columns[12].HeaderText = "CIDADE";
            Grid.Columns[13].HeaderText = "ESTADO";
            Grid.Columns[14].HeaderText = "IMAGEM";

            // Visibilidade das Colunas
            Grid.Columns[2].Visible = false;
            Grid.Columns[4].Visible = false;
            Grid.Columns[6].Visible = false;
            Grid.Columns[8].Visible = false;
            Grid.Columns[9].Visible = false;
            Grid.Columns[10].Visible = false;
            Grid.Columns[11].Visible = false;
            Grid.Columns[12].Visible = false;
            Grid.Columns[13].Visible = false;
            Grid.Columns[14].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[0].Width = 35;
            Grid.Columns[1].Width = 210;
            Grid.Columns[3].Width = 90;
            Grid.Columns[5].Width = 80;
            Grid.Columns[7].Width = 150;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            ProfessorDAO dao = new ProfessorDAO();
            Grid.DataSource = dao.ListarProfessor();

            FormatarDG();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtRg.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtNascimento.Value = DateTime.Today;
            cbSangue.SelectedIndex = 0;
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            cb_estado.SelectedIndex = 0;
            LimparFoto();
        }


        private void Habilitar()
        {
            txtNome.Enabled = true;
            txtRg.Enabled = true;
            txtCpf.Enabled = true;
            txtEmail.Enabled = true;
            txtNascimento.Enabled = true;
            cbSangue.Enabled = true;
            txtTelefone.Enabled = true;
            txtCelular.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCep.Enabled = true;
            txtCidade.Enabled = true;
            cb_estado.Enabled = true;
            txtNome.Focus();
        }

        private void Desabilitar()
        {
            // Botoes
            BtnCep.Enabled = false;
            BtnFoto.Enabled = false;
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            // Campos
            txtNome.Enabled = false;
            txtRg.Enabled = false;
            txtCpf.Enabled = false;
            txtEmail.Enabled = false;
            txtNascimento.Enabled = false;
            cbSangue.Enabled = false;
            txtTelefone.Enabled = false;
            txtCelular.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            cb_estado.Enabled = false;
        }


        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            TxtPesquisar.Focus();
            LimparFoto();            
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            BtnCep.Enabled = true;
            BtnFoto.Enabled = true;
            BtnSalvar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            LimparCampos();
            Habilitar();
            tabProfessor.SelectedTab = tabPage2;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Desabilitar();
            tabProfessor.SelectedTab = tabPage1;
            TxtPesquisar.Focus();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O CAMPO NOME VAZIO
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            // Adiciona o Aluno
            Professor obj = new Professor
            {
                Nome = txtNome.Text,
                Rg = txtRg.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Nascimento = DateTime.Parse(txtNascimento.Value.ToString()),
                Telefone = txtTelefone.Text,
                Celular = txtCelular.Text,
                Sangue = cbSangue.Text,
                Endereco = txtEndereco.Text,
                Cep = txtCep.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = cb_estado.Text
            };
            ProfessorDAO dao = new ProfessorDAO();

            // Verifica se o username ja existe
            DataTable dt = dao.VerficarProfessor(txtNome.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Professor já cadastrado!!", "Erro ao adicionar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            // Adiciona
            dao.AddProfessor(obj, Img());
            Desabilitar();
            LimparCampos();            
            tabProfessor.SelectedTab = tabPage1;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O CAMPO NOME VAZIO
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME!", "Campo nome está vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            Professor obj = new Professor
            {
                Nome = txtNome.Text,
                Rg = txtRg.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Nascimento = DateTime.Parse(txtNascimento.Value.ToString()),
                Telefone = txtTelefone.Text,
                Celular = txtCelular.Text,
                Sangue = cbSangue.Text,
                Endereco = txtEndereco.Text,
                Cep = txtCep.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = cb_estado.Text
            };
            ProfessorDAO dao = new ProfessorDAO();

            // Verifica se o nome ja existe
            if (txtNome.Text != ProfessorAntigo)
            {
                DataTable dt = dao.VerficarProfessor(txtNome.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Professor já cadastrado!!", "Erro ao atualizar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
            }
            // Atualizacao com foto ou sem foto
            if (alterou == "1")
            {
                dao.UpdateProfessorComImagem(obj, idSelecionado, Img());
            }
            else
            {
                dao.UpdateProfessor(obj, idSelecionado);
            }
            Desabilitar();
            LimparCampos();            
            alterou = "";
            tabProfessor.SelectedTab = tabPage1;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ProfessorDAO dao = new ProfessorDAO();
                dao.DeleteProfessor(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            Desabilitar();
            LimparCampos();
            tabProfessor.SelectedTab = tabPage1;
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + TxtPesquisar.Text + "%";

            ProfessorDAO dao = new ProfessorDAO();
            Grid.DataSource = dao.ListarProfessorPorNome(nome);

            FormatarDG();
        }

        private byte[] Img()
        {
            byte[] imagem_byte = null;
            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }

        private void LimparFoto()
        {
            Foto_Professor.Image = Properties.Resources.sem_foto;
            foto = "img/sem-foto.jpg";
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Imagens(*.jpg;*.png)|*.jpg;*.png|Todos os Arquivos(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                Foto_Professor.ImageLocation = foto;
                alterou = "1";
            }
        }

        private void BtnCep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cb_estado.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("CEP não encontrado, por favor digite manualmente.", "Erro ao pesquisar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtNascimento.Text = Grid.CurrentRow.Cells[5].Value.ToString();
            txtTelefone.Text = Grid.CurrentRow.Cells[6].Value.ToString();
            txtCelular.Text = Grid.CurrentRow.Cells[7].Value.ToString();
            cbSangue.Text = Grid.CurrentRow.Cells[8].Value.ToString();
            txtEndereco.Text = Grid.CurrentRow.Cells[9].Value.ToString();
            txtCep.Text = Grid.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = Grid.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = Grid.CurrentRow.Cells[12].Value.ToString();
            cb_estado.Text = Grid.CurrentRow.Cells[13].Value.ToString();

            if (Grid.CurrentRow.Cells[14].Value != DBNull.Value)
            {
                byte[] imagem = (byte[])Grid.CurrentRow.Cells[14].Value;
                MemoryStream ms = new MemoryStream(imagem);
                Foto_Professor.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                Foto_Professor.Image = Properties.Resources.sem_foto;
            }

            tabProfessor.SelectedTab = tabPage2;
            Habilitar();
            BtnCep.Enabled = true;
            BtnFoto.Enabled = true;
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;

            // Pega o nome para atualizar
            ProfessorAntigo = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnAtualizarGrid_Click(object sender, EventArgs e)
        {
            // Codigo para limpar o DataGridView quando o aluno estiver vazio
            if (Grid.DataSource is DataTable dt)
            {
                dt.Rows.Clear();
            }

            Listar();
        }
    }
}
