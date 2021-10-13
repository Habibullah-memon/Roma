using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Roma.Listing
{
    public partial class AddList : Form
    {
        public AddList(string ListName, string FieldName)
        {
            InitializeComponent();
            labelNameofList.Text = ListName;
            labelNameofField.Text = FieldName;
        }
        string _idString;
        int _idInt;
        private void AddList_Load(object sender, EventArgs e)
        {
            generateID(labelNameofList.Text);
        }
        private void generateID(string idname)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "select max(Id) from Lists where ID like '%"+idname+"%'";
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);

                SDA.Fill(dt);
                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();

                _idString = Convert.ToString(dt.Rows[0][0]);

                if (Convert.ToString(dt.Rows[0][0]) == "")
                {
                    _idString = idname + "-0000";
                }
                //_idInt = Convert.ToInt32(_idString.TrimStart('P', 'r', 'o', 'd', 'u', 'c', 't', '-'));
                _idInt =Convert.ToInt32( string.Join("", from ch in _idString where char.IsDigit(ch) select ch));

                _idString = idname +"-" + (_idInt + 0001).ToString("######0000");
                
                Classes.DB.sql_con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textboxField.Text == "")
            {
                MessageBox.Show("Fill textbox to proceed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string querry1 = "Select *  from Lists where Name_of_Field = '" + textboxField.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(querry1, Classes.DB.sql_con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();

            Classes.DB.sql_con.Open();
            sda.Fill(dt);
            Classes.DB.sql_con.Close();

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Record Already Exist", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string querry = @"INSERT INTO Lists VALUES(@ID,@Name_of_List,@Name_of_Field)";
                    SqlCommand cmd = new SqlCommand(querry, Classes.DB.sql_con);
                    cmd.Parameters.AddWithValue("@ID", _idString);
                    cmd.Parameters.AddWithValue("@Name_of_List", labelNameofList.Text);
                    cmd.Parameters.AddWithValue("@Name_of_Field", textboxField.Text);

                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show("Record successfully saved!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Clear();
                    generateID(labelNameofList.Text);
                }
                catch (SqlException l)
                {
                    MessageBox.Show(l.Message, "May be Record Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
            }
        }

        private void Clear()
        {
            textboxField.Text = "";
            textboxField.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (labelNameofList.Text == "Company")
            {
                Products.cRefresh = true;
            }
            else if (labelNameofList.Text == "Groups")
            {
                Products.gRefresh = true;
            }
            else if (labelNameofList.Text == "Packing")
            {
                Products.pRefresh = true;
            }

            else   //if labelNameofList.Text == People;
            {
                Peoples.refresh = true;
            }
            this.Dispose();

        }

    }
}
