namespace SQLite
{
    partial class MainForm
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
            EfCoreButton = new Button();
            SqlQueryButton = new Button();
            SuspendLayout();
            // 
            // EfCoreButton
            // 
            EfCoreButton.Location = new Point(12, 188);
            EfCoreButton.Name = "EfCoreButton";
            EfCoreButton.Size = new Size(335, 75);
            EfCoreButton.TabIndex = 0;
            EfCoreButton.Text = "EF Core";
            EfCoreButton.UseVisualStyleBackColor = true;
            EfCoreButton.Click += EfCoreButton_Click;
            // 
            // SqlQueryButton
            // 
            SqlQueryButton.Location = new Point(453, 188);
            SqlQueryButton.Name = "SqlQueryButton";
            SqlQueryButton.Size = new Size(335, 75);
            SqlQueryButton.TabIndex = 1;
            SqlQueryButton.Text = "SQL Query";
            SqlQueryButton.UseVisualStyleBackColor = true;
            SqlQueryButton.Click += SqlButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SqlQueryButton);
            Controls.Add(EfCoreButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button EfCoreButton;
        private Button SqlQueryButton;
    }
}