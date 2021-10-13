using System;
using System.Windows.Forms;

namespace Roma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void peoplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Peoples pop = new Peoples();
            pop.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cpass = new ChangePassword();
            cpass.Show();
        }

        private void listsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listing.Lists _list = new Listing.Lists();

            _list.MdiParent = this;
            _list.WindowState = FormWindowState.Maximized;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
