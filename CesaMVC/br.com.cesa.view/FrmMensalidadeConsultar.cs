using CesaMVC.br.com.cesa.dao;
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
    public partial class FrmMensalidadeConsultar : Form
    {
        public FrmMensalidadeConsultar()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID MENSALIDADE";
            Grid.Columns[1].HeaderText = "TURMA";
            Grid.Columns[2].HeaderText = "ALUNO";
            Grid.Columns[3].HeaderText = "SERVICO";
            Grid.Columns[4].HeaderText = "VALOR";
            Grid.Columns[5].HeaderText = "DATA";
            Grid.Columns[6].HeaderText = "FUNCIONARIO";
            Grid.Columns[7].HeaderText = "SITUACAO";
            Grid.Columns[8].HeaderText = "MES";
            Grid.Columns[9].HeaderText = "OBSERVACAO";

            // Visibilidade das Colunas
            Grid.Columns[0].Visible = false;
            Grid.Columns[3].Visible = false;
            Grid.Columns[6].Visible = false;
            Grid.Columns[7].Visible = false;
            Grid.Columns[9].Visible = false;

            // Tamanho da Letra do Header antes devemos colocar VisualStyles como "FALSE"
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            // O Header so fica centralizado se desabilitar a propriedade de ordenacao
            Grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;            
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 70;
            Grid.Columns[2].Width = 160;            
            Grid.Columns[4].Width = 70;
            Grid.Columns[5].Width = 80;
            Grid.Columns[8].Width = 85;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            MensalidadeDAO dao = new MensalidadeDAO();
            Grid.DataSource = dao.ConsultarMensalidade(CbAluno.SelectedValue.ToString(),
                                                    CbTurma.SelectedValue.ToString(),
                                                    "Pago");
            FormatarDG();
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }

        private void FrmMensalidadeConsultar_Load(object sender, EventArgs e)
        {
            ComboTurma();
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
            if (CbAluno.Text == "")
            {
                MessageBox.Show("Os campos não podem ser vazios!", "ERROR ao consultar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();

                // Codigo para limpar o DataGridView quando o aluno estiver vazio
                if (Grid.DataSource is DataTable dt)
                {
                    dt.Rows.Clear();
                }
                return;
            }
            else
            {
                Listar();
            }
        }

        private void CbTurma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbTurma.SelectedValue != null)
            {
                CbAluno.SelectedIndex = -1;
                ComboAluno();
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Report_ConsultarMensalidade form = new Report_ConsultarMensalidade();
            form.ShowDialog();
        }
    }
}
