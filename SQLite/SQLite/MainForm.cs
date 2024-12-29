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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EfCoreButton_Click(object sender, EventArgs e)
        {
            EfCoreForm efCoreForm = new EfCoreForm();
            efCoreForm.ShowDialog(this);
        }

        private void SqlButton_Click(object sender, EventArgs e)
        {
            SqlQueryForm SqlQueryForm = new SqlQueryForm();
            SqlQueryForm.ShowDialog(this);
        }
    }
}
