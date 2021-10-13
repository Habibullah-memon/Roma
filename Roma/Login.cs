using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Roma
{
    public partial class Login1 : Form




    {
        public static string u_name; public static string UserType; 
        public Login1()
        {InitializeComponent();}
        private void ButtonType_Click(object sender, EventArgs e)
        {
            
        }
        private void LabelForgetpassword_Click(object sender, EventArgs e)
        {   
        }
        private void clearLeftPanel()
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {   
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonExit2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
