using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        MessageSender messageSender;

        public Form1()
        {
            InitializeComponent();
        }

        private void TxBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            textBox.ForeColor = Color.Black;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                
                if (textBox.Tag.ToString() == "Password")
                    textBox.PasswordChar = '*';
            }
        }

        private void TxBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            if (textBox.Text == textBox.Tag.ToString() || string.IsNullOrEmpty(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                if (textBox.Tag.ToString() == "Password")
                    textBox.PasswordChar='\0';
            }
            else
            {
                textBox.ForeColor = Color.Black;
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (!IPAddress.TryParse(this.txBox_server_ip.Text, out ipAddress))
            {
                this.lblError.Text = "Error: Server IP is empty or not an IP.";
                return;
            };

            int port;
            if (!int.TryParse(txBox_port.Text, out port)) {
                this.showError("Error: Port must be a number.");
                return;
            }
            if (port<0 || port > 65535)
            {
                this.showError("Error: Port must be a number between 0 and 65,535.");
                return;
            }

            if (string.IsNullOrEmpty(this.txBox_nickName.Text)
                || string.IsNullOrEmpty(this.txBox_pwd.Text)) {
                this.showError("Error: User name or password is not provided.");
                return;
            }

            this.messageSender = new MessageSender(
                ipAddress,
                port,
                this.txBox_nickName.Text,
                this.txBox_pwd.Text);
            messageSender.LogIn();
            isConnected();
            return;
        }

        private void Btn_checkUser_Click(object sender, EventArgs e)
        {
            if (!isConnected() || messageSender == null) return;

            if (!this.messageSender.CheckUserExists(this.txBox_toNickName.Text))
            {
                this.lblError.Text = "User does not exist.";
                    return;
            }

            TabPage tabPage = new TabPage(this.txBox_toNickName.Text);
            this.tabControl1.TabPages.Add(tabPage);
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.ReadOnly = true;
            tabPage.Controls.Add(richTextBox);
            tabPage.Controls[0].Dock = DockStyle.Fill;
            tabPage.Controls[0].Focus();
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            if (!isConnected()) return;
            this.messageSender.sendMessage(this.tabControl1.SelectedTab.Text, this.rTxBox_sendMessage.Text);
            
        }
        private void showError(string errorString) {
            this.lblError.Text = errorString;
            this.lblError.ForeColor = Color.Red;
        }
        private bool isConnected() {
            if (this.messageSender.Connected)
            {
                lbl_status.Text = "Connected";
                lbl_status.ForeColor = Color.Green;
                return true;
            }
            {
                lbl_status.Text = "Not connected";
                lbl_status.ForeColor = Color.Red;
                return false;
            }
        }
    }
}
