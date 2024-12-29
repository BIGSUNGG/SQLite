namespace Sqlite
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
            ddToolStripMenuItem = new ToolStripMenuItem();
            AccountComboBox = new ComboBox();
            AccountNameTextBox = new TextBox();
            CreateAccountButton = new Button();
            ChatMessageEditBox = new TextBox();
            SendButton = new Button();
            SendMessageEditBox = new TextBox();
            SuspendLayout();
            // 
            // ddToolStripMenuItem
            // 
            ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            ddToolStripMenuItem.Size = new Size(32, 19);
            // 
            // AccountComboBox
            // 
            AccountComboBox.FormattingEnabled = true;
            AccountComboBox.Location = new Point(12, 25);
            AccountComboBox.Name = "AccountComboBox";
            AccountComboBox.Size = new Size(121, 23);
            AccountComboBox.TabIndex = 0;
            AccountComboBox.SelectedIndexChanged += AccountComboBox_SelectedIndexChanged;
            // 
            // AccountNameTextBox
            // 
            AccountNameTextBox.Location = new Point(607, 25);
            AccountNameTextBox.Name = "AccountNameTextBox";
            AccountNameTextBox.Size = new Size(100, 23);
            AccountNameTextBox.TabIndex = 1;
            AccountNameTextBox.TextChanged += AccountNameTextBox_TextChanged;
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Location = new Point(713, 12);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.Size = new Size(75, 51);
            CreateAccountButton.TabIndex = 2;
            CreateAccountButton.Text = "Create\r\nAccount";
            CreateAccountButton.UseVisualStyleBackColor = true;
            CreateAccountButton.Click += CreateAccountButton_Click;
            // 
            // ChatMessageEditBox
            // 
            ChatMessageEditBox.Location = new Point(12, 67);
            ChatMessageEditBox.Multiline = true;
            ChatMessageEditBox.Name = "ChatMessageEditBox";
            ChatMessageEditBox.Size = new Size(776, 371);
            ChatMessageEditBox.TabIndex = 3;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(526, 25);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // SendMessageEditBox
            // 
            SendMessageEditBox.Location = new Point(139, 25);
            SendMessageEditBox.Name = "SendMessageEditBox";
            SendMessageEditBox.Size = new Size(381, 23);
            SendMessageEditBox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SendMessageEditBox);
            Controls.Add(SendButton);
            Controls.Add(ChatMessageEditBox);
            Controls.Add(CreateAccountButton);
            Controls.Add(AccountNameTextBox);
            Controls.Add(AccountComboBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem ddToolStripMenuItem;
        private ComboBox AccountComboBox;
        private TextBox AccountNameTextBox;
        private Button CreateAccountButton;
        private TextBox ChatMessageEditBox;
        private Button SendButton;
        private TextBox SendMessageEditBox;
    }
}