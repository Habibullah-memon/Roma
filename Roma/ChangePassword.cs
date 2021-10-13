using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Roma
{
    public partial class ChangePassword : Form
    {

        public ChangePassword()
        {
            InitializeComponent();
            labelWelcomeUserf.Text = ForgetPassword.u_name;
            textBoxNewPassword.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text == textBoxConfirmPassword.Text)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Users set Password = '" + textBoxConfirmPassword.Text + "' where Username = '" + labelWelcomeUserf.Text + "' ", Classes.DB.sql_con);
                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show("Password Changed Successfully");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Password Does not Match");
                textBoxNewPassword.Text = "";
                textBoxConfirmPassword.Text = "";
                textBoxNewPassword.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
