
namespace CesaMVC.br.com.cesa.view
{
    partial class FrmCapturarFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapturarFoto));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cb_combo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCapturar = new System.Windows.Forms.Button();
            this.BtnEncerrar = new System.Windows.Forms.Button();
            this.pictureCaptura = new System.Windows.Forms.PictureBox();
            this.pictureStream = new System.Windows.Forms.PictureBox();
            this.BtnIniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStream)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(558, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Digite o nome do Aluno!!!";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtNome.Location = new System.Drawing.Point(548, 329);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(286, 29);
            this.txtNome.TabIndex = 15;
            // 
            // cb_combo
            // 
            this.cb_combo.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_combo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cb_combo.FormattingEnabled = true;
            this.cb_combo.Location = new System.Drawing.Point(77, 328);
            this.cb_combo.Name = "cb_combo";
            this.cb_combo.Size = new System.Drawing.Size(266, 30);
            this.cb_combo.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CesaMVC.Properties.Resources.cesa;
            this.pictureBox1.Location = new System.Drawing.Point(377, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCapturar
            // 
            this.BtnCapturar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCapturar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCapturar.ForeColor = System.Drawing.Color.White;
            this.BtnCapturar.Image = global::CesaMVC.Properties.Resources.btn_foto_24;
            this.BtnCapturar.Location = new System.Drawing.Point(620, 368);
            this.BtnCapturar.Name = "BtnCapturar";
            this.BtnCapturar.Size = new System.Drawing.Size(140, 55);
            this.BtnCapturar.TabIndex = 14;
            this.BtnCapturar.Text = " Capturar";
            this.BtnCapturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCapturar.UseVisualStyleBackColor = false;
            this.BtnCapturar.Click += new System.EventHandler(this.BtnCapturar_Click);
            // 
            // BtnEncerrar
            // 
            this.BtnEncerrar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEncerrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEncerrar.ForeColor = System.Drawing.Color.White;
            this.BtnEncerrar.Image = global::CesaMVC.Properties.Resources.btn_cancelar_24;
            this.BtnEncerrar.Location = new System.Drawing.Point(213, 377);
            this.BtnEncerrar.Name = "BtnEncerrar";
            this.BtnEncerrar.Size = new System.Drawing.Size(130, 55);
            this.BtnEncerrar.TabIndex = 13;
            this.BtnEncerrar.Text = " Encerrar";
            this.BtnEncerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEncerrar.UseVisualStyleBackColor = false;
            this.BtnEncerrar.Click += new System.EventHandler(this.BtnEncerrar_Click);
            // 
            // pictureCaptura
            // 
            this.pictureCaptura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCaptura.Location = new System.Drawing.Point(478, 13);
            this.pictureCaptura.Name = "pictureCaptura";
            this.pictureCaptura.Size = new System.Drawing.Size(400, 300);
            this.pictureCaptura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCaptura.TabIndex = 12;
            this.pictureCaptura.TabStop = false;
            // 
            // pictureStream
            // 
            this.pictureStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureStream.Location = new System.Drawing.Point(17, 13);
            this.pictureStream.Name = "pictureStream";
            this.pictureStream.Size = new System.Drawing.Size(400, 300);
            this.pictureStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureStream.TabIndex = 11;
            this.pictureStream.TabStop = false;
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniciar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciar.ForeColor = System.Drawing.Color.White;
            this.BtnIniciar.Image = global::CesaMVC.Properties.Resources.btn_play_24;
            this.BtnIniciar.Location = new System.Drawing.Point(77, 377);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(130, 55);
            this.BtnIniciar.TabIndex = 9;
            this.BtnIniciar.Text = "  Iniciar";
            this.BtnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnIniciar.UseVisualStyleBackColor = false;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // FrmCapturarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 472);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.BtnCapturar);
            this.Controls.Add(this.BtnEncerrar);
            this.Controls.Add(this.pictureCaptura);
            this.Controls.Add(this.pictureStream);
            this.Controls.Add(this.cb_combo);
            this.Controls.Add(this.BtnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCapturarFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar Foto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapturarFoto_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button BtnCapturar;
        private System.Windows.Forms.Button BtnEncerrar;
        private System.Windows.Forms.PictureBox pictureCaptura;
        private System.Windows.Forms.PictureBox pictureStream;
        private System.Windows.Forms.ComboBox cb_combo;
        private System.Windows.Forms.Button BtnIniciar;
    }
}