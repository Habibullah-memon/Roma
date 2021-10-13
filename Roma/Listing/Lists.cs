using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Roma.Listing
{
    public partial class Lists : Form
    {
        public Lists()
        {
            InitializeComponent();
        }

        string _idString;
        int _idInt;

        private void _Clear()
        {
            comboBoxType.SelectedIndex = -1; textboxId.Text = ""; textBoxNameofItem.Text = ""; 
        }

        private void Lists_Load(object sender, EventArgs e)
        {
            RetriveComboBoxData();
            RetriveDatainGridView(""); _Clear();
            btnAdd.Enabled = true; btnAdd.BackColor = Color.LimeGreen;
            buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
            btnUpdate.Enabled = false; btnUpdate.BackColor = Color.Gray;
            comboBoxType.Focus();
        }
        public void generateID(string idname)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "select max(Id) from Lists where ID like '%" + idname + "%'";
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
                _idInt = Convert.ToInt32(string.Join("", from ch in _idString where char.IsDigit(ch) select ch));

                _idString = idname + "-" + (_idInt + 0001).ToString("######0000");
                //MessageBox.Show(_idString);
                textboxId.Text = _idString;
                Classes.DB.sql_con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }

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


        public void RetriveDatainGridView(string _search)
        {
            string additionalquerry;
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            if (_search == "")
            {
                additionalquerry = "SELECT * FROM Lists";
            }
            else
            {
                additionalquerry = "SELECT * FROM Lists WHERE ID like '%"+_search+"%' OR Name_of_Field like '%"+_search+"%' ";
            }

            SqlCommand cmd1 = new SqlCommand(additionalquerry, Classes.DB.sql_con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            _Refresh();
            btnAdd.Enabled = true; btnAdd.BackColor = Color.LimeGreen;
            buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
            btnUpdate.Enabled = false; btnUpdate.BackColor = Color.Gray;
        }

        public void _Refresh()
        {
            RetriveDatainGridView(""); RetriveComboBoxData();
            _Clear();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you wnat to delete " + textBoxNameofItem.Text + " Record ", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmddel = new SqlCommand("Delete from [dbo].[Lists] where [ID] = '" + textboxId.Text + "' ", Classes.DB.sql_con);
                    Classes.DB.sql_con.Open();
                    cmddel.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show(textBoxNameofItem.Text + " Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                    btnAdd.Enabled = true; btnAdd.BackColor = Color.LimeGreen;
                    buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
                    btnUpdate.Enabled = false; btnUpdate.BackColor = Color.Gray;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
            }
            else
            {
                _Clear();
            }
            buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
            textboxId.Focus();
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameofItem.Text == "")
            {
                MessageBox.Show("Please Fill Name of Item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            else
            {
                try
                {
                    string querry = @"INSERT INTO Lists VALUES(@ID, @Name_of_List,@Name_of_Field)";
                    SqlCommand cmd = new SqlCommand(querry, Classes.DB.sql_con);
                    cmd.Parameters.AddWithValue("@ID", textboxId.Text);
                    cmd.Parameters.AddWithValue("@Name_of_List", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("@Name_of_Field", textBoxNameofItem.Text);
                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show("Record successfully saved!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh(); comboBoxType.Focus();
                }
                catch (SqlException l)
                {
                    MessageBox.Show(l.Message, "May be Record Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                _Clear();
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textboxId.Text = row.Cells[0].Value.ToString();
                textBoxNameofItem.Text = row.Cells[2].Value.ToString();
                comboBoxType.Text = row.Cells[1].Value.ToString();
                btnAdd.Enabled = false; btnAdd.BackColor = Color.Gray;
                buttonDelete.Enabled = true; buttonDelete.BackColor = Color.Red;
                btnUpdate.Enabled = true; btnUpdate.BackColor = Color.DeepSkyBlue;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxNameofItem.Text == "")
            {
                MessageBox.Show("Please Fill Name of Item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                try
                {
                    string querry = @"update Lists set Name_of_List = @Name_of_List, Name_of_Field= @Name_of_Field where ID = @ID";
                    SqlCommand cmd = new SqlCommand(querry, Classes.DB.sql_con);
                    cmd.Parameters.AddWithValue("@Name_of_List", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("@Name_of_Field", textBoxNameofItem.Text);
                    cmd.Parameters.AddWithValue("@ID", textboxId.Text);
                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show("Updated Sucessfully!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh(); comboBoxType.Focus();
                    btnAdd.Enabled = true; btnAdd.BackColor = Color.LimeGreen;
                    btnUpdate.Enabled = false; btnUpdate.BackColor = Color.Gray;
                    buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
                }
                catch (SqlException l)
                {
                    MessageBox.Show(l.Message, "May be Record Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveDatainGridView(textBoxSearch.Text);
        }

        private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddListFromListing addlistFL = new AddListFromListing();
            addlistFL.ShowDialog();
        }

        private void comboBoxType_Leave(object sender, EventArgs e)
        {
            generateID(comboBoxType.Text);
        }
    }
}
