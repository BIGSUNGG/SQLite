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

            FilterAccountComboBox.Items.Add("None");

            LoadAllAccount();
            LoadAllChat();
        }

        /// <summary>
        /// 모든 계정 불러오기
        /// </summary>
        void LoadAllAccount()
        {
            using (SQLiteDbContext context = new SQLiteDbContext())
            {
                // 계정 불러오기
                var accounts = context.Accounts.AsNoTracking();
                foreach (var account in accounts)
                {
                    AddAccountComboBox(account);
                }

            }
        }

        /// <summary>
        /// 모든 채팅 지우기
        /// </summary>
        void ResetAllChat()
        {
            ChatMessageEditBox.Text = "";
        }

        /// <summary>
        /// 모든 채팅 불러오기
        /// </summary>
        void LoadAllChat()
        {
            ResetAllChat();

            AccountDb filterAccount = FilterAccountComboBox.SelectedItem as AccountDb;
            int filterCount = (int)FilterNum.Value;

            using (SQLiteDbContext context = new SQLiteDbContext())
            {
                // 채팅 내역 불러오기
                var chats = context.Chats.AsNoTracking()
                    .Include(c => c.Sender)
                    .Where(c => filterAccount == null ? true : c.SenderId == filterAccount.Id) // filterAccount가 있다면 filterAccount가 전송한 채팅만 불러오도록
                    .OrderByDescending(c => c.DateTime)
                    .Take(filterCount == 0 ? int.MaxValue : filterCount); // filterCount가 0이라면 모든 채팅을 불러오도록

                foreach (var chat in chats)
                {
                    AddMessage(chat);
                }
            }
        }

        /// <summary>
        /// 계정을 콤보 박스 리스트에 추가
        /// </summary>
        /// <param name="account"></param>
        void AddAccountComboBox(AccountDb account)
        {
            AccountComboBox.Items.Add(account);
            FilterAccountComboBox.Items.Add(account);
        }

        /// <summary>
        /// DB에 메시지 추가
        /// </summary>
        /// <param name="sender"></param>
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
                LoadAllChat();
            }
        }

        /// <summary>
        /// 채팅창에 메시지 추가
        /// </summary>
        /// <param name="chat"></param>
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

        private void FilterAccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllChat();
        }

        private void FilterNum_ValueChanged(object sender, EventArgs e)
        {
            LoadAllChat();
        }
    }
}
