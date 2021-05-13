namespace GBTapp_CantareMici.UI
{
    partial class SerialPort
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.cmbbaudrate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbparity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbdatabits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbstopbits = new System.Windows.Forms.ComboBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtDatatoSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(138, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "SerialPort";
            // 
            // txtPort
            // 
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Location = new System.Drawing.Point(21, 173);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(68, 21);
            this.txtPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(95, 157);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(53, 13);
            this.labelBaudrate.TabIndex = 4;
            this.labelBaudrate.Text = "Baudrate:";
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600",
            "4800"});
            this.cmbbaudrate.Location = new System.Drawing.Point(95, 173);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(68, 21);
            this.cmbbaudrate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parity:";
            // 
            // cmbparity
            // 
            this.cmbparity.FormattingEnabled = true;
            this.cmbparity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.cmbparity.Location = new System.Drawing.Point(169, 173);
            this.cmbparity.Name = "cmbparity";
            this.cmbparity.Size = new System.Drawing.Size(68, 21);
            this.cmbparity.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Databits:";
            // 
            // cmbdatabits
            // 
            this.cmbdatabits.FormattingEnabled = true;
            this.cmbdatabits.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbdatabits.Location = new System.Drawing.Point(243, 173);
            this.cmbdatabits.Name = "cmbdatabits";
            this.cmbdatabits.Size = new System.Drawing.Size(68, 21);
            this.cmbdatabits.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "StopBits:";
            // 
            // cmbstopbits
            // 
            this.cmbstopbits.FormattingEnabled = true;
            this.cmbstopbits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Tow"});
            this.cmbstopbits.Location = new System.Drawing.Point(317, 173);
            this.cmbstopbits.Name = "cmbstopbits";
            this.cmbstopbits.Size = new System.Drawing.Size(68, 21);
            this.cmbstopbits.TabIndex = 9;
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(24, 42);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(361, 101);
            this.txtReceive.TabIndex = 12;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(95, 203);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(68, 23);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Visible = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtDatatoSend
            // 
            this.txtDatatoSend.Location = new System.Drawing.Point(169, 202);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(142, 20);
            this.txtDatatoSend.TabIndex = 14;
            this.txtDatatoSend.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(21, 203);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(68, 23);
            this.cmdConnect.TabIndex = 16;
            this.cmdConnect.Text = "Conect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GBTapp_CantareMici.Properties.Resources.icons8_close_window_96;
            this.pictureBox1.Location = new System.Drawing.Point(373, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SerialPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(409, 238);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDatatoSend);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbstopbits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbdatabits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbparity);
            this.Controls.Add(this.labelBaudrate);
            this.Controls.Add(this.cmbbaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerialPort";
            this.Text = "SerialPort";
            this.Load += new System.EventHandler(this.SerialPort_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.ComboBox cmbbaudrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbparity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbdatabits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbstopbits;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtDatatoSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}