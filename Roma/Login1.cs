using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Roma
{
    public partial class Login1 : Form
    {
        public static string u_name; public static string UserType;
        public Login1()
        {
            InitializeComponent();
        }
        private void Login1_Load(object sender, EventArgs e)
        {
            UserType = "User"; textBoxName.Focus();
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlDataAdapter Adp = new SqlDataAdapter("Select * from Users  where Username = '" + textBoxName.Text + "' and password = '" + textBoxPassword.Text + "' and Type = '" + UserType + "' ", Classes.DB.sql_con);
            DataTable dt = new DataTable(); Adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Login Successful", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MDIParent _home = new MDIParent(); clearLeftPanel();
                _home.menuStrip.Enabled = true; _home.Show();
                this.Hide();


            }
            else { MessageBox.Show("Invalid User Name / Password ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            u_name = textBoxName.Text; textBoxPassword.Text = "";
            ForgetPassword forgpass = new ForgetPassword(); forgpass.Show();
        }


        private void clearLeftPanel()
        {
            textBoxPassword.Text = "";
            textBoxName.Text = "";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Listing.setting _setting = new Listing.setting();
            _setting.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test;
            Listing.setting _sett = new Listing.setting();
            /*test = */
            _sett.Show();
            // MessageBox.Show(test);
        }

        private void buttonUserMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (buttonUserMode.Text == "User Mode") { buttonUserMode.Text = "Admin Mode"; UserType = "Admin"; }
            else if (buttonUserMode.Text == "Admin Mode") { buttonUserMode.Text = "User Mode"; UserType = "User"; }
        }
    }
}
