using System.Data.SqlClient;
using System.Windows.Forms;

namespace Roma.Classes
{
    class DB
    {
        public static SqlConnection sql_con = new SqlConnection("Data Source=ADV-PC;Initial Catalog=mmedical;Integrated Security=True");
        //public static SqlConnection sql_con = new SqlConnection("server=192.168.100.3,2498;Initial Catalog=mmedical;User Id = sa; Password=root");

    }
    class Clear
    {
        public static void ClearFormControls(Form form) // we have to give paratemter as panel || tablepanel
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
        }
        public static void ClearFormControls(GroupBox form) // we have to give paratemter as panel || tablepanel
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
        }

    }
}
