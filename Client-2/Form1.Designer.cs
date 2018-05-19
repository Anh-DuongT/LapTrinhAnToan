namespace Client_2
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
            this.components = new System.ComponentModel.Container();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.txtEncryptText = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnKetnoi = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReSult = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPad = new System.Windows.Forms.TextBox();
            this.txtEncryptedPad = new System.Windows.Forms.TextBox();
            this.btnSendNoise = new System.Windows.Forms.Button();
            this.txtAlicePubKey = new System.Windows.Forms.TextBox();
            this.txtBobPubKey = new System.Windows.Forms.TextBox();
            this.btnGenKey = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Enabled = false;
            this.txtRemotePort.Location = new System.Drawing.Point(800, 14);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(48, 20);
            this.txtRemotePort.TabIndex = 75;
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Enabled = false;
            this.txtLocalPort.Location = new System.Drawing.Point(742, 14);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(53, 20);
            this.txtLocalPort.TabIndex = 74;
            // 
            // txtEncryptText
            // 
            this.txtEncryptText.Enabled = false;
            this.txtEncryptText.Location = new System.Drawing.Point(486, 198);
            this.txtEncryptText.Multiline = true;
            this.txtEncryptText.Name = "txtEncryptText";
            this.txtEncryptText.Size = new System.Drawing.Size(354, 158);
            this.txtEncryptText.TabIndex = 72;
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(622, 14);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(115, 20);
            this.txtIP.TabIndex = 70;
            // 
            // btnKetnoi
            // 
            this.btnKetnoi.Location = new System.Drawing.Point(644, 43);
            this.btnKetnoi.Name = "btnKetnoi";
            this.btnKetnoi.Size = new System.Drawing.Size(75, 23);
            this.btnKetnoi.TabIndex = 69;
            this.btnKetnoi.Text = "Kết nối";
            this.btnKetnoi.UseVisualStyleBackColor = true;
            this.btnKetnoi.Click += new System.EventHandler(this.btnKetnoi_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(21, 198);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(439, 158);
            this.txtMessage.TabIndex = 68;
            this.txtMessage.Text = "";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(471, 128);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 24);
            this.btnSend.TabIndex = 67;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(41, 57);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(0, 13);
            this.labelKey.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Padding";
            // 
            // txtReSult
            // 
            this.txtReSult.Enabled = false;
            this.txtReSult.Location = new System.Drawing.Point(88, 135);
            this.txtReSult.Multiline = true;
            this.txtReSult.Name = "txtReSult";
            this.txtReSult.Size = new System.Drawing.Size(368, 58);
            this.txtReSult.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Result";
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(88, 50);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(368, 20);
            this.txtKey.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Key";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(88, 12);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(368, 20);
            this.txtNhap.TabIndex = 56;
            this.txtNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNhap_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Text";
            // 
            // txtPad
            // 
            this.txtPad.Enabled = false;
            this.txtPad.Location = new System.Drawing.Point(88, 97);
            this.txtPad.Margin = new System.Windows.Forms.Padding(2);
            this.txtPad.Name = "txtPad";
            this.txtPad.Size = new System.Drawing.Size(368, 20);
            this.txtPad.TabIndex = 77;
            // 
            // txtEncryptedPad
            // 
            this.txtEncryptedPad.Location = new System.Drawing.Point(85, 384);
            this.txtEncryptedPad.Margin = new System.Windows.Forms.Padding(2);
            this.txtEncryptedPad.Name = "txtEncryptedPad";
            this.txtEncryptedPad.Size = new System.Drawing.Size(368, 20);
            this.txtEncryptedPad.TabIndex = 76;
            this.txtEncryptedPad.Visible = false;
            // 
            // btnSendNoise
            // 
            this.btnSendNoise.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSendNoise.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNoise.Location = new System.Drawing.Point(471, 163);
            this.btnSendNoise.Name = "btnSendNoise";
            this.btnSendNoise.Size = new System.Drawing.Size(91, 28);
            this.btnSendNoise.TabIndex = 78;
            this.btnSendNoise.Text = "Send + Noise";
            this.btnSendNoise.UseVisualStyleBackColor = false;
            this.btnSendNoise.Click += new System.EventHandler(this.btnSendNoise_Click);
            // 
            // txtAlicePubKey
            // 
            this.txtAlicePubKey.Location = new System.Drawing.Point(85, 409);
            this.txtAlicePubKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlicePubKey.Name = "txtAlicePubKey";
            this.txtAlicePubKey.Size = new System.Drawing.Size(326, 20);
            this.txtAlicePubKey.TabIndex = 80;
            this.txtAlicePubKey.Visible = false;
            // 
            // txtBobPubKey
            // 
            this.txtBobPubKey.Location = new System.Drawing.Point(496, 409);
            this.txtBobPubKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtBobPubKey.Name = "txtBobPubKey";
            this.txtBobPubKey.Size = new System.Drawing.Size(319, 20);
            this.txtBobPubKey.TabIndex = 79;
            this.txtBobPubKey.Visible = false;
            // 
            // btnGenKey
            // 
            this.btnGenKey.Location = new System.Drawing.Point(471, 45);
            this.btnGenKey.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenKey.Name = "btnGenKey";
            this.btnGenKey.Size = new System.Drawing.Size(91, 25);
            this.btnGenKey.TabIndex = 81;
            this.btnGenKey.Text = "GenKey";
            this.btnGenKey.UseVisualStyleBackColor = true;
            this.btnGenKey.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(634, 384);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 82;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 362);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGenKey);
            this.Controls.Add(this.txtAlicePubKey);
            this.Controls.Add(this.txtBobPubKey);
            this.Controls.Add(this.btnSendNoise);
            this.Controls.Add(this.txtPad);
            this.Controls.Add(this.txtEncryptedPad);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtEncryptText);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnKetnoi);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReSult);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Client02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.TextBox txtEncryptText;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnKetnoi;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReSult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPad;
        private System.Windows.Forms.TextBox txtEncryptedPad;
        private System.Windows.Forms.Button btnSendNoise;
        private System.Windows.Forms.TextBox txtAlicePubKey;
        private System.Windows.Forms.TextBox txtBobPubKey;
        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

