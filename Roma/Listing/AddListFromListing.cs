using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roma.Listing
{
    public partial class AddListFromListing : Form
    {
        public AddListFromListing()
        {
            InitializeComponent();
        }

        Lists  _listInstance = new Lists();
        private void AddListFromListing_Load(object sender, EventArgs e)
        {
             RetriveComboBoxData();
        }
        public void RetriveComboBoxData()
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT Name_of_List from  Lists ", Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            sda2.Fill(ds);

            Classes.DB.sql_con.Open();
            cmd2.ExecuteNonQuery();
            Classes.DB.sql_con.Close();
            comboBoxType.DataSource = ds.Tables[0];
            comboBoxType.DisplayMember = "Name_of_List";
            // comboBoxType.ValueMember = "Name_of_List";

        }
        private void comboBoxType_SelectionChangeCommitted(object sender, EventArgs e)
        {
           //Lists.ActiveForm.comboBoxType.BindingContext =  comboBoxType.BindingContext;
            //.generateID(comboBoxType.Text);


            this.Dispose();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
