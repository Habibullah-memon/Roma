using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Roma
{
    public partial class PriceLists : Form
    {
        public PriceLists()
        {
            InitializeComponent();
        }
        string _idString;
        int _idInt;

        private void PriceLists_Load(object sender, EventArgs e)
        {
            generateID();
            fetchComboBoxDescription();
        }

        private void fetchComboBoxDescription()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "SELECT [Description] FROM [dbo].[PriceList]";
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);

                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();
                comboBoxDescription.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    comboBoxDescription.Items.Add (row["Description"].ToString());
                }
                Classes.DB.sql_con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }
        }

        private void fetchComboBoxPercentage()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "SELECT [Percentage] FROM [dbo].[PriceList] where Description like '"+comboBoxDescription.SelectedItem+"' ";
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);

                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();
                textBoxPercentage.Clear();
                if (dt.Rows.Count != 0)
                {
                textBoxPercentage.Text = dt.Rows[0][0].ToString();
                }
                Classes.DB.sql_con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }
        }
        private  void generateID()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "select max(Id) from PriceList";
                //Classes.DB.sql_con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);

                SDA.Fill(dt);
                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();

                _idString = Convert.ToString(dt.Rows[0][0]);

                if (Convert.ToString(dt.Rows[0][0]) == "")
                {
                    _idString = "PriceList-0000";
                }
                _idInt = Convert.ToInt32(_idString.TrimStart('P', 'r', 'i', 'c', 'e', 'L', 'i', 's', 't', '-'));
                _idString = "PriceList-" + (_idInt + 0001).ToString("######0000");
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
            if (comboBoxDescription.Text == "")
            {
                MessageBox.Show("Please Fill Description", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                string _querrycmd = "insert into PriceList values (@id,@dec,@per)";

                Classes.DB.sql_con.Open();
                SqlCommand cmd = new SqlCommand(_querrycmd, Classes.DB.sql_con);

                cmd.Parameters.AddWithValue("@id", _idString);
                cmd.Parameters.AddWithValue("@dec", comboBoxDescription.Text);
                cmd.Parameters.AddWithValue("@per", textBoxPercentage.Text);
                // cmd.CommandType = CommandType.Text ;
                cmd.ExecuteNonQuery();
                Classes.DB.sql_con.Close();
                MessageBox.Show("Saved Sucessfully","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }
            generateID();
            fetchComboBoxDescription();
        }

        private void comboBoxDescription_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBoxDescription_TextChanged(object sender, EventArgs e)
        {
            fetchComboBoxPercentage();
        }
    }
}
