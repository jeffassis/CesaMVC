
namespace CesaMVC.br.com.cesa.report
{
    partial class Report_ConsultarMensalidade
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_ConsultarMensalidade));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CbTurma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.CbAluno = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cesadbDataSet = new CesaMVC.cesadbDataSet();
            this.consultarMensalidadeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consultarMensalidadeTableAdapter = new CesaMVC.cesadbDataSetTableAdapters.ConsultarMensalidadeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultarMensalidadeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DS_ConsultarMensalidade";
            reportDataSource1.Value = this.consultarMensalidadeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CesaMVC.br.com.cesa.report.RelConsultarMensalidade.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(780, 497);
            this.reportViewer1.TabIndex = 0;
            // 
            // CbTurma
            // 
            this.CbTurma.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CbTurma.FormattingEnabled = true;
            this.CbTurma.Location = new System.Drawing.Point(79, 12);
            this.CbTurma.Name = "CbTurma";
            this.CbTurma.Size = new System.Drawing.Size(109, 25);
            this.CbTurma.TabIndex = 4;
            this.CbTurma.SelectionChangeCommitted += new System.EventHandler(this.CbTurma_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Turma.:";
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPesquisar.ForeColor = System.Drawing.Color.White;
            this.BtnPesquisar.Image = global::CesaMVC.Properties.Resources.btn_pesquisar_24;
            this.BtnPesquisar.Location = new System.Drawing.Point(494, 5);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(40, 40);
            this.BtnPesquisar.TabIndex = 63;
            this.BtnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPesquisar.UseVisualStyleBackColor = false;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // CbAluno
            // 
            this.CbAluno.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CbAluno.FormattingEnabled = true;
            this.CbAluno.Location = new System.Drawing.Point(268, 13);
            this.CbAluno.Name = "CbAluno";
            this.CbAluno.Size = new System.Drawing.Size(220, 25);
            this.CbAluno.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(203, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 61;
            this.label3.Text = "Aluno.:";
            // 
            // cesadbDataSet
            // 
            this.cesadbDataSet.DataSetName = "cesadbDataSet";
            this.cesadbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // consultarMensalidadeBindingSource
            // 
            this.consultarMensalidadeBindingSource.DataMember = "ConsultarMensalidade";
            this.consultarMensalidadeBindingSource.DataSource = this.cesadbDataSet;
            // 
            // consultarMensalidadeTableAdapter
            // 
            this.consultarMensalidadeTableAdapter.ClearBeforeFill = true;
            // 
            // Report_ConsultarMensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.CbAluno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbTurma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Report_ConsultarMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report_ConsultarMensalidade";
            this.Load += new System.EventHandler(this.Report_ConsultarMensalidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultarMensalidadeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox CbTurma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.ComboBox CbAluno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource consultarMensalidadeBindingSource;
        private cesadbDataSet cesadbDataSet;
        private cesadbDataSetTableAdapters.ConsultarMensalidadeTableAdapter consultarMensalidadeTableAdapter;
    }
}