using CesaMVC.br.com.cesa.dao;
using CesaMVC.br.com.cesa.model;
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
    public partial class FrmMensalidade : Form
    {
        string idSelecionado;
        int ultimoIdMensalidade;
        public FrmMensalidade()
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
            Grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Colocar valores centralizados na celula
            Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
            Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           

            // Define tamanho da Coluna
            Grid.Columns[1].Width = 70;
            Grid.Columns[2].Width = 160;
            Grid.Columns[3].Width = 140;
            Grid.Columns[4].Width = 70;
            Grid.Columns[5].Width = 80;
            Grid.Columns[6].Width = 150;
            Grid.Columns[8].Width = 85;
        }

        private void Listar()
        {
            // Preenchendo o DataGridView
            MensalidadeDAO dao = new MensalidadeDAO();
            Grid.DataSource = dao.ListarMensalidade(CbAluno.SelectedValue.ToString(),
                                                    CbTurma.SelectedValue.ToString());
            FormatarDG();
        }

        private void Habilitar()
        {            
            cbMes.Enabled = true;
            txtObs.Enabled = true;
            lblServico.Enabled = true;
            lblValor.Enabled = true;
        }

        private void Desabilitar()
        {
            BtnSalvar.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;            
            cbMes.Enabled = false;
            txtObs.Enabled = false;
            lblServico.Enabled = false;
            lblValor.Enabled = false;
        }

        private void Limpar()
        {            
            cbMes.SelectedIndex = -1;     
            txtObs.Text = "";
            lblServico.Text = "";
            lblValor.Text = "";
        }

        private void ComboTurma()
        {
            TurmaDAO dao = new TurmaDAO();
            CbTurma.DataSource = dao.ListarTurma();
            CbTurma.DisplayMember = "nome";
            CbTurma.ValueMember = "id_turma";
        }         

        private void FrmMensalidade_Load(object sender, EventArgs e)
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

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Habilitar();
            Limpar();
            BtnSalvar.Enabled = true;
            BtnServico.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Desabilitar();
            Limpar();
            CbAluno.SelectedIndex = -1;

            // Codigo para limpar o DataGridView quando o aluno estiver vazio
            if (Grid.DataSource is DataTable dt)
            {
                dt.Rows.Clear();
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se ALUNO está vazio
            if (CbAluno.Text == "")
            {
                MessageBox.Show("O campo aluno não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            // Verifica se SERVICO está vazio
            if (lblServico.Text == "")
            {
                MessageBox.Show("O campo serviço não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
            // Verifica se MES está vazio
            if (cbMes.Text == "")
            {
                MessageBox.Show("O campo mês não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
            Mensalidade obj = new Mensalidade
            {
                TurmaId = int.Parse(CbTurma.SelectedValue.ToString()),
                AlunoId = int.Parse(CbAluno.SelectedValue.ToString()),
                ServicoId = int.Parse(Program.idServico.ToString()),
                Funcionario = Program.nomeUsuario,
                Mes = cbMes.Text,
                Observacao = txtObs.Text                
            };
            MensalidadeDAO dao = new MensalidadeDAO();
            // Verificar se ja foi pago
            DataTable dt = dao.VerficarMensalidade(CbAluno.SelectedValue.ToString(),                                                   
                                                    cbMes.Text,
                                                    CbTurma.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Mensalidade já lançada!!", "Erro lançamento de notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dao.AddMensalidade(obj);

            // ----------------------------------------------------------------------------------------------------------------
            // RECUPERAR O ULTIMO ID DA MENSALIDADE
            ultimoIdMensalidade = dao.UltimoIdMensalidade();

            // LANÇAR A MENSALIDADE NAS MOVIMENTAÇÕES
            Movimentacao mov = new Movimentacao
            {
                Tipo = "Entrada",
                Movimento = "Mensalidade",
                Valor = decimal.Parse(lblValor.Text),
                Funcionario = Program.nomeUsuario,
                IdMovimento = ultimoIdMensalidade
            };
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            movDao.AddMovimentacao(mov);

            // FINALIZA A FUNCAO
            Desabilitar();
            Limpar();
            Listar();
        }

        private void BtnServico_Click(object sender, EventArgs e)
        {
            Program.chamadaServico = "servico";
            FrmServico form = new FrmServico();            
            form.Show();
        }

        private void FrmMensalidade_Activated(object sender, EventArgs e)
        {
            lblServico.Text = Program.nomeServico;          
            lblValor.Text = Program.valorServico;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSelecionado = Grid.CurrentRow.Cells[0].Value.ToString();
            CbTurma.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            CbAluno.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            lblServico.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            lblValor.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            cbMes.Text = Grid.CurrentRow.Cells[8].Value.ToString();
            txtObs.Text = Grid.CurrentRow.Cells[9].Value.ToString();

            Habilitar();
            BtnServico.Enabled = true;
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verifica se ALUNO está vazio
            if (CbAluno.Text == "")
            {
                MessageBox.Show("O campo aluno não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbAluno.Focus();
                return;
            }
            // Verifica se SERVICO está vazio
            if (lblServico.Text == "")
            {
                MessageBox.Show("O campo serviço não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verifica se MES está vazio
            if (cbMes.Text == "")
            {
                MessageBox.Show("O campo mês não pode ser vazio!", "ERROR campo vazio!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mensalidade obj = new Mensalidade
            {
                TurmaId = int.Parse(CbTurma.SelectedValue.ToString()),
                AlunoId = int.Parse(CbAluno.SelectedValue.ToString()),
                ServicoId = int.Parse(Program.idServico.ToString()),
                Funcionario = Program.nomeUsuario,
                Mes = cbMes.Text,
                Observacao = txtObs.Text
            };
            MensalidadeDAO dao = new MensalidadeDAO();
            // Verificar se ja foi pago
            dao.UpdateMensalidade(obj, idSelecionado);            

            // ----------------------------------------------------------------------------------------------------------------
            // ATUALIZAR O VALOR NA MOVIMENTAÇÃO
            Movimentacao mov = new Movimentacao
            {
                Valor = decimal.Parse(lblValor.Text),
                Funcionario = Program.nomeUsuario,
                Movimento = "Mensalidade"
            };
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            movDao.UpdateMovimentacao(mov, idSelecionado);

            // FINALIZA A FUNCAO
            Desabilitar();
            Limpar();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Excluir mensalidade?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MensalidadeDAO dao = new MensalidadeDAO();
                dao.DeleteMensalidade(idSelecionado);
                Grid.Rows.Remove(Grid.CurrentRow);

                // ----------------------------------------------------------------------------------------------------------------
                // EXCLUSAO DO MOVIMENTO DO GASTO
                string movimento = "Mensalidade";
                MovimentacaoDAO movDao = new MovimentacaoDAO();
                movDao.DeleteMovimentacao(idSelecionado, movimento);
            }
            Desabilitar();
            Limpar();
        }
    }
}
