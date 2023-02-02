
namespace CesaMVC.br.com.cesa.report
{
    partial class Report_EntradaSaida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_EntradaSaida));
            this.CbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.entradaSaidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cesadbDataSet = new CesaMVC.cesadbDataSet();
            this.entradaSaidaTableAdapter = new CesaMVC.cesadbDataSetTableAdapters.EntradaSaidaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.entradaSaidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CbTipo
            // 
            this.CbTipo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbTipo.FormattingEnabled = true;
            this.CbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saida"});
            this.CbTipo.Location = new System.Drawing.Point(15, 30);
            this.CbTipo.Name = "CbTipo";
            this.CbTipo.Size = new System.Drawing.Size(138, 28);
            this.CbTipo.TabIndex = 59;
            this.CbTipo.SelectedIndexChanged += new System.EventHandler(this.CbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 58;
            this.label2.Text = "Entradas / Saídas.:";
            // 
            // DtInicial
            // 
            this.DtInicial.CalendarFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicial.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.DtInicial.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(424, 35);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(162, 23);
            this.DtInicial.TabIndex = 60;
            this.DtInicial.ValueChanged += new System.EventHandler(this.DtInicial_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(420, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Data Inicial.:";
            // 
            // DtFinal
            // 
            this.DtFinal.CalendarFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFinal.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.DtFinal.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(598, 34);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(162, 23);
            this.DtFinal.TabIndex = 62;
            this.DtFinal.ValueChanged += new System.EventHandler(this.DtFinal_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(594, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 63;
            this.label4.Text = "Data Final.:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DSEntradaSaida";
            reportDataSource1.Value = this.entradaSaidaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CesaMVC.br.com.cesa.report.RelMovimentacao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 78);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(781, 480);
            this.reportViewer1.TabIndex = 64;
            // 
            // entradaSaidaBindingSource
            // 
            this.entradaSaidaBindingSource.DataMember = "EntradaSaida";
            this.entradaSaidaBindingSource.DataSource = this.cesadbDataSet;
            // 
            // cesadbDataSet
            // 
            this.cesadbDataSet.DataSetName = "cesadbDataSet";
            this.cesadbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // entradaSaidaTableAdapter
            // 
            this.entradaSaidaTableAdapter.ClearBeforeFill = true;
            // 
            // Report_EntradaSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbTipo);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report_EntradaSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report_EntradaSaida";
            this.Load += new System.EventHandler(this.Report_EntradaSaida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.entradaSaidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cesadbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private cesadbDataSet cesadbDataSet;
        private System.Windows.Forms.BindingSource entradaSaidaBindingSource;
        private cesadbDataSetTableAdapters.EntradaSaidaTableAdapter entradaSaidaTableAdapter;
    }
}