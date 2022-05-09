namespace servidor
{
    partial class FServidor
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServidor));
            this.btInicia = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.memoLog = new System.Windows.Forms.TextBox();
            this.txtUsersConnect = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtIpServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btInicia
            // 
            this.btInicia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(95)))), ((int)(((byte)(61)))));
            this.btInicia.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicia.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btInicia.Location = new System.Drawing.Point(15, 89);
            this.btInicia.Name = "btInicia";
            this.btInicia.Size = new System.Drawing.Size(182, 47);
            this.btInicia.TabIndex = 0;
            this.btInicia.Text = "Iniciar Servidor";
            this.btInicia.UseVisualStyleBackColor = false;
            this.btInicia.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 63);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(182, 20);
            this.txtPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Porta";
            // 
            // memoLog
            // 
            this.memoLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.memoLog.CausesValidation = false;
            this.memoLog.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoLog.Location = new System.Drawing.Point(389, 12);
            this.memoLog.Multiline = true;
            this.memoLog.Name = "memoLog";
            this.memoLog.ReadOnly = true;
            this.memoLog.Size = new System.Drawing.Size(386, 418);
            this.memoLog.TabIndex = 3;
            // 
            // txtUsersConnect
            // 
            this.txtUsersConnect.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsersConnect.Location = new System.Drawing.Point(15, 181);
            this.txtUsersConnect.Multiline = true;
            this.txtUsersConnect.Name = "txtUsersConnect";
            this.txtUsersConnect.Size = new System.Drawing.Size(340, 249);
            this.txtUsersConnect.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(217, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtIpServidor
            // 
            this.txtIpServidor.Location = new System.Drawing.Point(12, 24);
            this.txtIpServidor.Name = "txtIpServidor";
            this.txtIpServidor.Size = new System.Drawing.Size(182, 20);
            this.txtIpServidor.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP";
            // 
            // FServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(184)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIpServidor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtUsersConnect);
            this.Controls.Add(this.memoLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btInicia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidor Chat";
            this.Load += new System.EventHandler(this.FServidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInicia;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox memoLog;
        private System.Windows.Forms.TextBox txtUsersConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtIpServidor;
        private System.Windows.Forms.Label label2;
    }
}

