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

            FilterAccountComboBox.Items.Add("None");

            LoadAllAccount();
            LoadAllChat();
        }

        /// <summary>
        /// 모든 계정 불러오기
        /// </summary>
        void LoadAllAccount()
        {
            List<AccountGateWay> accountGateWy = AccountGateWay.SelectAll();
            foreach (var account in accountGateWy)
            {
                AddAccountComboBox(account);
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

            AccountGateWay filterAccount = FilterAccountComboBox.SelectedItem as AccountGateWay;
            int filterCount = (int)FilterNum.Value;

            List<ChatGateWay> chatGateWays = ChatGateWay.SelectAll(filterAccount, filterCount);
            foreach (var chat in chatGateWays)
            {
                AddMessage(chat);
            }
        }

        /// <summary>
        /// 계정을 콤보 박스 리스트에 추가
        /// </summary>
        /// <param name="account"></param>
        void AddAccountComboBox(AccountGateWay account)
        {
            AccountComboBox.Items.Add(account);
            FilterAccountComboBox.Items.Add(account);
        }

        /// <summary>
        /// DB에 메시지 추가
        /// </summary>
        /// <param name="sender"></param>
        void SendMessage(AccountGateWay sender)
        {
            ChatGateWay chat = new ChatGateWay();
            chat.Sender = sender;
            chat.DateTime = DateTime.Now;
            chat.Text = SendMessageEditBox.Text;
            chat.Insert();

            SendMessageEditBox.Text = "";
            LoadAllChat();
        }

        /// <summary>
        /// 채팅창에 메시지 추가
        /// </summary>
        /// <param name="chat"></param>
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
