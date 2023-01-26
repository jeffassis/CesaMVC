
namespace CesaMVC.br.com.cesa.view
{
    partial class FrmNotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotas));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBimestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbTurma = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CbAluno = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lançamento de Notas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 100);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnPesquisar);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnExcluir);
            this.panel1.Controls.Add(this.BtnEditar);
            this.panel1.Controls.Add(this.BtnSalvar);
            this.panel1.Controls.Add(this.BtnNovo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Grid);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNota);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbBimestre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CbDisciplina);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbTipo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CbTurma);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CbAluno);
            this.panel1.Location = new System.Drawing.Point(12, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 460);
            this.panel1.TabIndex = 3;
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPesquisar.ForeColor = System.Drawing.Color.White;
            this.BtnPesquisar.Image = global::CesaMVC.Properties.Resources.btn_pesquisar_24;
            this.BtnPesquisar.Location = new System.Drawing.Point(246, 87);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(40, 40);
            this.BtnPesquisar.TabIndex = 61;
            this.BtnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnPesquisar, "Consultar notas");
            this.BtnPesquisar.UseVisualStyleBackColor = false;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Image = global::CesaMVC.Properties.Resources.btn_cancelar_24;
            this.BtnCancelar.Location = new System.Drawing.Point(532, 402);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BtnCancelar.Size = new System.Drawing.Size(110, 40);
            this.BtnCancelar.TabIndex = 60;
            this.BtnCancelar.Text = " Cancelar";
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnCancelar, "Cancelar ação");
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcluir.ForeColor = System.Drawing.Color.White;
            this.BtnExcluir.Image = global::CesaMVC.Properties.Resources.btn_excluir_24;
            this.BtnExcluir.Location = new System.Drawing.Point(416, 402);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(110, 40);
            this.BtnExcluir.TabIndex = 59;
            this.BtnExcluir.Text = "  Excluir";
            this.BtnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnExcluir, "Remover nota");
            this.BtnExcluir.UseVisualStyleBackColor = false;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditar.Enabled = false;
            this.BtnEditar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.ForeColor = System.Drawing.Color.White;
            this.BtnEditar.Image = global::CesaMVC.Properties.Resources.btn_editar_24;
            this.BtnEditar.Location = new System.Drawing.Point(300, 402);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(110, 40);
            this.BtnEditar.TabIndex = 58;
            this.BtnEditar.Text = "  Editar";
            this.BtnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnEditar, "Editar nota");
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.Color.White;
            this.BtnSalvar.Image = global::CesaMVC.Properties.Resources.btn_salvar_24;
            this.BtnSalvar.Location = new System.Drawing.Point(184, 402);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(110, 40);
            this.BtnSalvar.TabIndex = 57;
            this.BtnSalvar.Text = "  Salvar";
            this.BtnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnSalvar, "Lançar nota");
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNovo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.ForeColor = System.Drawing.Color.White;
            this.BtnNovo.Image = global::CesaMVC.Properties.Resources.btn_novo_24;
            this.BtnNovo.Location = new System.Drawing.Point(68, 402);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(110, 40);
            this.BtnNovo.TabIndex = 56;
            this.BtnNovo.Text = "  Novo";
            this.BtnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnNovo, "Novo registro");
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CesaMVC.Properties.Resources.cesa;
            this.pictureBox1.Location = new System.Drawing.Point(590, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(16, 141);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(709, 241);
            this.Grid.TabIndex = 54;
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(494, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "Nota.:";
            // 
            // txtNota
            // 
            this.txtNota.Enabled = false;
            this.txtNota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(489, 92);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(65, 26);
            this.txtNota.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "Bimestre.:";
            // 
            // cbBimestre
            // 
            this.cbBimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBimestre.Enabled = false;
            this.cbBimestre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBimestre.FormattingEnabled = true;
            this.cbBimestre.Location = new System.Drawing.Point(300, 31);
            this.cbBimestre.Name = "cbBimestre";
            this.cbBimestre.Size = new System.Drawing.Size(157, 28);
            this.cbBimestre.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(301, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 49;
            this.label7.Text = "Disciplina.:";
            // 
            // CbDisciplina
            // 
            this.CbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDisciplina.Enabled = false;
            this.CbDisciplina.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDisciplina.FormattingEnabled = true;
            this.CbDisciplina.Location = new System.Drawing.Point(302, 92);
            this.CbDisciplina.Name = "CbDisciplina";
            this.CbDisciplina.Size = new System.Drawing.Size(159, 28);
            this.CbDisciplina.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(159, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "Tipo.:";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Enabled = false;
            this.cbTipo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Prova",
            "Recuperação"});
            this.cbTipo.Location = new System.Drawing.Point(160, 31);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(120, 28);
            this.cbTipo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Turma.:";
            // 
            // CbTurma
            // 
            this.CbTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTurma.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbTurma.FormattingEnabled = true;
            this.CbTurma.Location = new System.Drawing.Point(18, 31);
            this.CbTurma.Name = "CbTurma";
            this.CbTurma.Size = new System.Drawing.Size(122, 28);
            this.CbTurma.TabIndex = 1;
            this.CbTurma.SelectionChangeCommitted += new System.EventHandler(this.CbTurma_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Aluno.:";
            // 
            // CbAluno
            // 
            this.CbAluno.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAluno.FormattingEnabled = true;
            this.CbAluno.Location = new System.Drawing.Point(16, 93);
            this.CbAluno.Name = "CbAluno";
            this.CbAluno.Size = new System.Drawing.Size(224, 28);
            this.CbAluno.TabIndex = 2;
            // 
            // FrmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 578);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento de Notas";
            this.Load += new System.EventHandler(this.FrmNotas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbTurma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbAluno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBimestre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbDisciplina;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}