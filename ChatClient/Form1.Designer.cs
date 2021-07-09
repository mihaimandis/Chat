namespace ChatClient
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
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.rTxBox_sendMessage = new System.Windows.Forms.RichTextBox();
            this.rTxBox_allMessages = new System.Windows.Forms.RichTextBox();
            this.txBox_nickName = new System.Windows.Forms.TextBox();
            this.txBox_pwd = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txBox_server_ip = new System.Windows.Forms.TextBox();
            this.txBox_port = new System.Windows.Forms.TextBox();
            this.txBox_toNickName = new System.Windows.Forms.TextBox();
            this.btn_checkUser = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_status_name = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(750, 524);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 52);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // rTxBox_sendMessage
            // 
            this.rTxBox_sendMessage.Location = new System.Drawing.Point(12, 524);
            this.rTxBox_sendMessage.Name = "rTxBox_sendMessage";
            this.rTxBox_sendMessage.Size = new System.Drawing.Size(732, 52);
            this.rTxBox_sendMessage.TabIndex = 1;
            this.rTxBox_sendMessage.Text = "";
            // 
            // rTxBox_allMessages
            // 
            this.rTxBox_allMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxBox_allMessages.Location = new System.Drawing.Point(3, 3);
            this.rTxBox_allMessages.Name = "rTxBox_allMessages";
            this.rTxBox_allMessages.Size = new System.Drawing.Size(799, 369);
            this.rTxBox_allMessages.TabIndex = 2;
            this.rTxBox_allMessages.Text = "";
            // 
            // txBox_nickName
            // 
            this.txBox_nickName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txBox_nickName.Location = new System.Drawing.Point(345, 35);
            this.txBox_nickName.Name = "txBox_nickName";
            this.txBox_nickName.Size = new System.Drawing.Size(148, 22);
            this.txBox_nickName.TabIndex = 4;
            this.txBox_nickName.Tag = "User name";
            this.txBox_nickName.Text = "mihai";
            this.txBox_nickName.Enter += new System.EventHandler(this.TxBox_Enter);
            this.txBox_nickName.Leave += new System.EventHandler(this.TxBox_Leave);
            // 
            // txBox_pwd
            // 
            this.txBox_pwd.ForeColor = System.Drawing.Color.Gray;
            this.txBox_pwd.Location = new System.Drawing.Point(499, 35);
            this.txBox_pwd.Name = "txBox_pwd";
            this.txBox_pwd.Size = new System.Drawing.Size(173, 22);
            this.txBox_pwd.TabIndex = 5;
            this.txBox_pwd.Tag = "Password";
            this.txBox_pwd.Text = "12";
            this.txBox_pwd.Enter += new System.EventHandler(this.TxBox_Enter);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(678, 33);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(147, 26);
            this.btn_connect.TabIndex = 6;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // txBox_server_ip
            // 
            this.txBox_server_ip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txBox_server_ip.Location = new System.Drawing.Point(12, 35);
            this.txBox_server_ip.Name = "txBox_server_ip";
            this.txBox_server_ip.Size = new System.Drawing.Size(100, 22);
            this.txBox_server_ip.TabIndex = 7;
            this.txBox_server_ip.Tag = "Server IP";
            this.txBox_server_ip.Text = "127.0.0.1";
            this.txBox_server_ip.Enter += new System.EventHandler(this.TxBox_Enter);
            this.txBox_server_ip.Leave += new System.EventHandler(this.TxBox_Leave);
            // 
            // txBox_port
            // 
            this.txBox_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txBox_port.Location = new System.Drawing.Point(118, 35);
            this.txBox_port.Name = "txBox_port";
            this.txBox_port.Size = new System.Drawing.Size(100, 22);
            this.txBox_port.TabIndex = 8;
            this.txBox_port.Tag = "Port";
            this.txBox_port.Text = "80";
            this.txBox_port.Enter += new System.EventHandler(this.TxBox_Enter);
            this.txBox_port.Leave += new System.EventHandler(this.TxBox_Leave);
            // 
            // txBox_toNickName
            // 
            this.txBox_toNickName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txBox_toNickName.Location = new System.Drawing.Point(12, 73);
            this.txBox_toNickName.Name = "txBox_toNickName";
            this.txBox_toNickName.Size = new System.Drawing.Size(170, 22);
            this.txBox_toNickName.TabIndex = 9;
            this.txBox_toNickName.Tag = "Send to user name";
            this.txBox_toNickName.Text = "Send to user name";
            this.txBox_toNickName.Enter += new System.EventHandler(this.TxBox_Enter);
            this.txBox_toNickName.Leave += new System.EventHandler(this.TxBox_Leave);
            // 
            // btn_checkUser
            // 
            this.btn_checkUser.Location = new System.Drawing.Point(188, 73);
            this.btn_checkUser.Name = "btn_checkUser";
            this.btn_checkUser.Size = new System.Drawing.Size(184, 26);
            this.btn_checkUser.TabIndex = 10;
            this.btn_checkUser.Text = "Check user name exists";
            this.btn_checkUser.UseVisualStyleBackColor = true;
            this.btn_checkUser.Click += new System.EventHandler(this.Btn_checkUser_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(557, 76);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(100, 17);
            this.lbl_status.TabIndex = 11;
            this.lbl_status.Text = "Not connected";
            // 
            // lbl_status_name
            // 
            this.lbl_status_name.AutoSize = true;
            this.lbl_status_name.Location = new System.Drawing.Point(499, 76);
            this.lbl_status_name.Name = "lbl_status_name";
            this.lbl_status_name.Size = new System.Drawing.Size(52, 17);
            this.lbl_status_name.TabIndex = 12;
            this.lbl_status_name.Text = "Status:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 583);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 404);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rTxBox_allMessages);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 620);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lbl_status_name);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_checkUser);
            this.Controls.Add(this.txBox_toNickName);
            this.Controls.Add(this.txBox_port);
            this.Controls.Add(this.txBox_server_ip);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txBox_pwd);
            this.Controls.Add(this.txBox_nickName);
            this.Controls.Add(this.rTxBox_sendMessage);
            this.Controls.Add(this.btnSendMessage);
            this.Name = "Form1";
            this.Text = "Chat client";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.RichTextBox rTxBox_sendMessage;
        private System.Windows.Forms.RichTextBox rTxBox_allMessages;
        private System.Windows.Forms.TextBox txBox_nickName;
        private System.Windows.Forms.TextBox txBox_pwd;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txBox_server_ip;
        private System.Windows.Forms.TextBox txBox_port;
        private System.Windows.Forms.TextBox txBox_toNickName;
        private System.Windows.Forms.Button btn_checkUser;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_status_name;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

