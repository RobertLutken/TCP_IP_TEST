namespace Server_Connection_Interface
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbIP = new System.Windows.Forms.MaskedTextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.tbPortAddress = new System.Windows.Forms.TextBox();
            this.lbStat = new System.Windows.Forms.Label();
            this.btConnect = new System.Windows.Forms.Button();
            this.lbByte = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbIP);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.lbServer);
            this.groupBox1.Controls.Add(this.tbPortAddress);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 87);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect to a Server";
            // 
            // tbIP
            // 
            this.tbIP.AllowPromptAsInput = false;
            this.tbIP.HidePromptOnLeave = true;
            this.tbIP.HideSelection = false;
            this.tbIP.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tbIP.Location = new System.Drawing.Point(9, 43);
            this.tbIP.Mask = "000.000.0.00";
            this.tbIP.Name = "tbIP";
            this.tbIP.PromptChar = '#';
            this.tbIP.ResetOnPrompt = false;
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 1;
            this.tbIP.UseWaitCursor = true;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(109, 27);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Port";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(6, 27);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(90, 13);
            this.lbServer.TabIndex = 2;
            this.lbServer.Text = "Server IP / Name";
            // 
            // tbPortAddress
            // 
            this.tbPortAddress.Location = new System.Drawing.Point(112, 43);
            this.tbPortAddress.Name = "tbPortAddress";
            this.tbPortAddress.Size = new System.Drawing.Size(33, 20);
            this.tbPortAddress.TabIndex = 2;
            // 
            // lbStat
            // 
            this.lbStat.AutoSize = true;
            this.lbStat.Location = new System.Drawing.Point(9, 195);
            this.lbStat.Name = "lbStat";
            this.lbStat.Size = new System.Drawing.Size(80, 13);
            this.lbStat.TabIndex = 9;
            this.lbStat.Text = "Error Messages";
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(165, 190);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 3;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // lbByte
            // 
            this.lbByte.AutoSize = true;
            this.lbByte.Location = new System.Drawing.Point(17, 172);
            this.lbByte.Name = "lbByte";
            this.lbByte.Size = new System.Drawing.Size(39, 13);
            this.lbByte.TabIndex = 11;
            this.lbByte.Text = "Bytes :";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(252, 222);
            this.Controls.Add(this.lbByte);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.lbStat);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbPort;
        
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox tbPortAddress;
        private System.Windows.Forms.Label lbStat;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.MaskedTextBox tbIP;
        private System.Windows.Forms.Label lbByte;
    }
}

