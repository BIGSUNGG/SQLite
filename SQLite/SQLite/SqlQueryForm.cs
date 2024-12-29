using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite
{
    /// <summary>
    /// Sqlite 쿼리를 사용하기 위한 WinForm
    /// </summary>
    public partial class SqlQueryForm : Form
    {
        public SqlQueryForm()
        {
            InitializeComponent();

            List<AccountGateWay> accountGateWy = AccountGateWay.SelectAll();
            foreach (var account in accountGateWy)
            {
                AddAccountComboBox(account);
            }

            List<ChatGateWay> chatGateWays = ChatGateWay.SelectAll();
            foreach (var chat in chatGateWays)
            {
                AddMessage(chat);
            }
        }

        void AddAccountComboBox(AccountGateWay account)
        {
            AccountComboBox.Items.Add(account);
        }

        void SendMessage(AccountGateWay sender)
        {
            ChatGateWay chat = new ChatGateWay();
            chat.Sender = sender;
            chat.DateTime = DateTime.Now;
            chat.Text = SendMessageEditBox.Text;
            chat.Insert();

            SendMessageEditBox.Text = "";
            AddMessage(chat);
        }

        void AddMessage(ChatGateWay chat)
        {
            ChatMessageEditBox.Text += $"[{chat.DateTime}] {chat.Sender.Name} : {chat.Text}{Environment.NewLine}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (AccountNameTextBox.Text == "")
                return;

            AccountGateWay account = new AccountGateWay();
            account.Name = AccountNameTextBox.Text;
            account.Insert();

            AccountNameTextBox.Text = "";
            AddAccountComboBox(account);
        }        

        private void AccountNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            AccountGateWay senderAccount = AccountComboBox.SelectedItem as AccountGateWay;
            if (senderAccount == null)
                return;

            SendMessage(senderAccount);
        }
    }
}
