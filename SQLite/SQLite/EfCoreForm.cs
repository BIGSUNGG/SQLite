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
    /// .NET EF Core Sqlite를 사용하기 위한 Winform
    /// </summary>
    public partial class EfCoreForm : Form
    {
        public EfCoreForm()
        {
            InitializeComponent();

            using (SQLiteDbContext context = new SQLiteDbContext())
            {
                // 계정 불러오기
                var accounts = context.Accounts.AsNoTracking();
                foreach (var account in accounts)
                {
                    AddAccountComboBox(account);
                }

                // 채팅 내역 불러오기
                var chats = context.Chats.AsNoTracking().Include(c => c.Sender).OrderBy(c => c.DateTime);
                foreach(var chat in chats)
                {
                    AddMessage(chat);
                }
            }
        }

        void AddAccountComboBox(AccountDb account)
        {
            AccountComboBox.Items.Add(account);
        }

        void SendMessage(AccountDb sender)
        {
            using (SQLiteDbContext context = new SQLiteDbContext())
            {
                context.Attach(sender);

                ChatDb chat = new ChatDb();
                chat.Sender = sender;
                chat.DateTime = DateTime.Now;
                chat.Text = SendMessageEditBox.Text;
                context.Chats.Add(chat);
                context.SaveChanges();

                SendMessageEditBox.Text = "";
                AddMessage(chat);
            }
        }

        void AddMessage(ChatDb chat)
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

            using (SQLiteDbContext context = new SQLiteDbContext())
            {
                AccountDb account = new AccountDb();
                account.Name = AccountNameTextBox.Text;
                context.Accounts.Add(account);
                context.SaveChanges();

                AccountNameTextBox.Text = "";
                AddAccountComboBox(account);
            }
        }

        private void AccountNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            AccountDb senderAccount = AccountComboBox.SelectedItem as AccountDb;
            if (senderAccount == null)
                return;

            SendMessage(senderAccount);
        }
    }
}
