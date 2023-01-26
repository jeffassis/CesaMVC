
namespace CesaMVC.br.com.cesa.report
{
    partial class Report_HoraProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_HoraProfessor));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CbCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.cesadbDataSet = new CesaMVC.cesadbDataSet();
            this.horaProfessorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.horaProfessorTableAdapter = new CesaMVC.cesadbDataSetTableAdapters.HoraProfessorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horaProfessorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DS_horaProfessor";
            reportDataSource1.Value = this.horaProfessorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CesaMVC.br.com.cesa.report.RelHoraProfessor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(777, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // CbCombo
            // 
            this.CbCombo.FormattingEnabled = true;
            this.CbCombo.Location = new System.Drawing.Point(94, 18);
            this.CbCombo.Name = "CbCombo";
            this.CbCombo.Size = new System.Drawing.Size(121, 28);
            this.CbCombo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Turma.:";
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPesquisar.ForeColor = System.Drawing.Color.White;
            this.BtnPesquisar.Image = global::CesaMVC.Properties.Resources.btn_pesquisar_24;
            this.BtnPesquisar.Location = new System.Drawing.Point(221, 11);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(40, 40);
            this.BtnPesquisar.TabIndex = 61;
            this.BtnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPesquisar.UseVisualStyleBackColor = false;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // cesadbDataSet
            // 
            this.cesadbDataSet.DataSetName = "cesadbDataSet";
            this.cesadbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // horaProfessorBindingSource
            // 
            this.horaProfessorBindingSource.DataMember = "HoraProfessor";
            this.horaProfessorBindingSource.DataSource = this.cesadbDataSet;
            // 
            // horaProfessorTableAdapter
            // 
            this.horaProfessorTableAdapter.ClearBeforeFill = true;
            // 
            // Report_HoraProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbCombo);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Report_HoraProfessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report_HoraProfessor";
            this.Load += new System.EventHandler(this.Report_HoraProfessor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horaProfessorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox CbCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.BindingSource horaProfessorBindingSource;
        private cesadbDataSet cesadbDataSet;
        private cesadbDataSetTableAdapters.HoraProfessorTableAdapter horaProfessorTableAdapter;
    }
}