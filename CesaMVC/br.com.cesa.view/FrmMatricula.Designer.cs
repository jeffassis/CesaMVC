
namespace CesaMVC.br.com.cesa.view
{
    partial class FrmMatricula
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatricula));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CbAnoLetivo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbTurma = new System.Windows.Forms.ComboBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnAluno = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrículas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 100);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.CbAnoLetivo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnNovo);
            this.panel2.Controls.Add(this.BtnAluno);
            this.panel2.Controls.Add(this.CbTurma);
            this.panel2.Controls.Add(this.Grid);
            this.panel2.Controls.Add(this.BtnImprimir);
            this.panel2.Controls.Add(this.BtnExcluir);
            this.panel2.Controls.Add(this.BtnSalvar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAluno);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 512);
            this.panel2.TabIndex = 3;
            // 
            // CbAnoLetivo
            // 
            this.CbAnoLetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAnoLetivo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CbAnoLetivo.FormattingEnabled = true;
            this.CbAnoLetivo.Items.AddRange(new object[] {
            "Tipo A+",
            "Tipo A-",
            "Tipo B+",
            "Tipo B-",
            "Tipo AB+",
            "Tipo AB-",
            "Tipo O+",
            "Tipo O-"});
            this.CbAnoLetivo.Location = new System.Drawing.Point(23, 37);
            this.CbAnoLetivo.Name = "CbAnoLetivo";
            this.CbAnoLetivo.Size = new System.Drawing.Size(166, 29);
            this.CbAnoLetivo.TabIndex = 29;
            this.CbAnoLetivo.SelectionChangeCommitted += new System.EventHandler(this.CbAnoLetivo_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(19, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ano Letivo.:";
            // 
            // CbTurma
            // 
            this.CbTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTurma.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CbTurma.FormattingEnabled = true;
            this.CbTurma.Location = new System.Drawing.Point(23, 109);
            this.CbTurma.Name = "CbTurma";
            this.CbTurma.Size = new System.Drawing.Size(166, 29);
            this.CbTurma.TabIndex = 25;
            this.CbTurma.SelectionChangeCommitted += new System.EventHandler(this.CbTurma_SelectionChangeCommitted);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.Location = new System.Drawing.Point(23, 163);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(597, 263);
            this.Grid.TabIndex = 24;
            this.Grid.TabStop = false;
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Turma.:";
            // 
            // txtAluno
            // 
            this.txtAluno.Enabled = false;
            this.txtAluno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAluno.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtAluno.Location = new System.Drawing.Point(279, 109);
            this.txtAluno.Margin = new System.Windows.Forms.Padding(5);
            this.txtAluno.Name = "txtAluno";
            this.txtAluno.Size = new System.Drawing.Size(253, 27);
            this.txtAluno.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(275, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Aluno.:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CesaMVC.Properties.Resources.calendar_24;
            this.pictureBox3.Location = new System.Drawing.Point(195, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 33);
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CesaMVC.Properties.Resources.livros_48;
            this.pictureBox2.Location = new System.Drawing.Point(195, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 77;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CesaMVC.Properties.Resources.cesa;
            this.pictureBox1.Location = new System.Drawing.Point(540, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNovo.ForeColor = System.Drawing.Color.White;
            this.BtnNovo.Image = global::CesaMVC.Properties.Resources.btn_novo_24;
            this.BtnNovo.Location = new System.Drawing.Point(116, 443);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(120, 50);
            this.BtnNovo.TabIndex = 27;
            this.BtnNovo.Text = "  Novo";
            this.BtnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnNovo, "Novo registro");
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnAluno
            // 
            this.BtnAluno.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAluno.Enabled = false;
            this.BtnAluno.ForeColor = System.Drawing.Color.White;
            this.BtnAluno.Image = global::CesaMVC.Properties.Resources.btn_pesquisar_24;
            this.BtnAluno.Location = new System.Drawing.Point(540, 102);
            this.BtnAluno.Name = "BtnAluno";
            this.BtnAluno.Size = new System.Drawing.Size(40, 40);
            this.BtnAluno.TabIndex = 26;
            this.BtnAluno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnAluno, "Adicionar aluno");
            this.BtnAluno.UseVisualStyleBackColor = false;
            this.BtnAluno.Click += new System.EventHandler(this.BtnAluno_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnImprimir.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.Image = global::CesaMVC.Properties.Resources.btn_imprimir_24;
            this.BtnImprimir.Location = new System.Drawing.Point(586, 102);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(40, 40);
            this.BtnImprimir.TabIndex = 21;
            this.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnImprimir, "Imprimir turma");
            this.BtnImprimir.UseVisualStyleBackColor = false;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.ForeColor = System.Drawing.Color.White;
            this.BtnExcluir.Image = global::CesaMVC.Properties.Resources.btn_excluir_24;
            this.BtnExcluir.Location = new System.Drawing.Point(368, 443);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(120, 50);
            this.BtnExcluir.TabIndex = 20;
            this.BtnExcluir.Text = "  Excluir";
            this.BtnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnExcluir, "Remover dados");
            this.BtnExcluir.UseVisualStyleBackColor = false;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.ForeColor = System.Drawing.Color.White;
            this.BtnSalvar.Image = global::CesaMVC.Properties.Resources.btn_salvar_24;
            this.BtnSalvar.Location = new System.Drawing.Point(242, 443);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(120, 50);
            this.BtnSalvar.TabIndex = 18;
            this.BtnSalvar.Text = "  Salvar";
            this.BtnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.BtnSalvar, "Salvar dados");
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // FrmMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 637);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrículas";
            this.Activated += new System.EventHandler(this.FrmMontTurma_Activated);
            this.Load += new System.EventHandler(this.FrmMontTurma_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.ComboBox CbTurma;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnAluno;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbAnoLetivo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}