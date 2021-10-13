using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Roma
{
    public partial class Peoples : Form
    {
        public bool _EnableEditMode; public static bool refresh;

        public Peoples()
        {
            InitializeComponent();
        }

        private void ButtonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxBusiness.Text != "" && comboBoxType.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Peoples] VALUES(@ID,@Name,@Business_Name,@Contact#1,@Contact#2,@Address,@City,@State, @Email, @PriceListID, @Note,@Type)", Classes.DB.sql_con);
                    cmd.Parameters.AddWithValue("@ID", labelID.Text);
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Business_Name", textBoxBusiness.Text);
                    cmd.Parameters.AddWithValue("@Contact#1", textBoxMob1.Text);
                    cmd.Parameters.AddWithValue("@Contact#2", textBoxMob2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@City", textBoxCity.Text);
                    cmd.Parameters.AddWithValue("@State", textBoxState.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@PriceListID", textBoxPriceLevel.Text);
                    cmd.Parameters.AddWithValue("@Note", textBoxNote.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBoxType.Text.ToString());

                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show(textBoxName.Text + " Entered Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generateID(); RetriveDatainGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }

            }
            else
            {
                if (textBoxName.Text == "") { MessageBox.Show("Enter UserName", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                if (comboBoxType.SelectedIndex == -1) { MessageBox.Show("Select Type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }

        }

        public void generateID()
        {

            var chars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            labelID.Text = "PEO-" + result;

        }

        private void Peoples_Load(object sender, EventArgs e)
        {
            generateID(); RetriveComboBoxData(); RetriveDatainGridView(); buttonDelete.Enabled = false; btnUpdate.Enabled = false;
        }
        public void RetriveComboBoxData()
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd2 = new SqlCommand("select * from  Lists where Name_of_List = '" + labelPeopleType.Text + "' ", Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            sda2.Fill(ds);

            Classes.DB.sql_con.Open();
            cmd2.ExecuteNonQuery();
            Classes.DB.sql_con.Close();

            comboBoxType.DataSource = ds.Tables[0];
            comboBoxType.DisplayMember = "Name_of_Field";
            // comboBoxType.ValueMember = "Name_of_List";

        }

        public void RetriveDatainGridView()
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd1 = new SqlCommand("select * from  Peoples ", Classes.DB.sql_con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                _Clear(); _EnableEditMode = true; buttonSubmit.Enabled = false; buttonDelete.Enabled = true; btnUpdate.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                labelID.Text = row.Cells[0].Value.ToString();
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxBusiness.Text = row.Cells[2].Value.ToString();
                textBoxMob1.Text = row.Cells[3].Value.ToString();
                textBoxMob2.Text = row.Cells[4].Value.ToString();
                textBoxAddress.Text = row.Cells[5].Value.ToString();
                textBoxCity.Text = row.Cells[6].Value.ToString();
                textBoxState.Text = row.Cells[7].Value.ToString();
                textBoxEmail.Text = row.Cells[8].Value.ToString();
                textBoxPriceLevel.Text = row.Cells[9].Value.ToString();
                textBoxNote.Text = row.Cells[10].Value.ToString();
                comboBoxType.Text = row.Cells[11].Value.ToString();
            }
        }

        private void _Clear()
        {
            /*labelID.Text = */
            generateID();
            textBoxName.Text = "";
            textBoxBusiness.Text = "";
            textBoxMob1.Text = "";
            textBoxMob2.Text = "";
            textBoxAddress.Text = "";
            textBoxCity.Text = "";
            textBoxState.Text = "";
            textBoxEmail.Text = "";
            textBoxPriceLevel.Text = "";
            textBoxNote.Text = "";
            comboBoxType.SelectedIndex = -1;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you wnat to delete " + textBoxName.Text + " Record ", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete from [dbo].[Peoples] where [ID] = '" + labelID.Text + "' ", Classes.DB.sql_con);
                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show(textBoxName.Text + " Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generateID(); RetriveDatainGridView(); _Clear();
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
            _EnableEditMode = false; buttonSubmit.Enabled = true; buttonDelete.Enabled = false; btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && comboBoxType.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update [dbo].[Peoples]set [Name]=@Name,[Business_Name] = @Business_Name,[Contact#1]=@Contact#1,[Contact#2]=@Contact#2,[Address]=@Address,[City] = @City,[State] = @State,[Email] = @Email, [PriseListID] = @PriceListID,[Note]=@Note,[Type]=@Type where [ID] = @ID ", Classes.DB.sql_con);
                    cmd.Parameters.AddWithValue("@ID", labelID.Text);
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Business_Name", textBoxBusiness.Text);
                    cmd.Parameters.AddWithValue("@Contact#1", textBoxMob1.Text);
                    cmd.Parameters.AddWithValue("@Contact#2", textBoxMob2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@City", textBoxCity.Text);
                    cmd.Parameters.AddWithValue("@State", textBoxState.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@PriceListID", textBoxPriceLevel.Text);
                    cmd.Parameters.AddWithValue("@Note", textBoxNote.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBoxType.Text.ToString());

                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show(labelID.Text + " Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generateID(); _Clear(); RetriveDatainGridView();
                    _EnableEditMode = false; buttonSubmit.Enabled = true; buttonDelete.Enabled = false; btnUpdate.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }

            }
            else
            {
                if (textBoxName.Text == "") { MessageBox.Show("Enter UserName", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                if (comboBoxType.SelectedIndex == -1) { MessageBox.Show("Select Type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }

        }

        private void buttonAddType_Click(object sender, EventArgs e)
        {
            Listing.AddList UserList = new Listing.AddList("People Type", "Description");
            UserList.ShowDialog();
        }




        private void comboBoxType_Click(object sender, EventArgs e)
        {
            if (refresh == true)
            {
                RetriveComboBoxData();
                refresh = false;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                { (ctrl as TextBox).Clear(); }
                else if (ctrl is ComboBox)
                { (ctrl as ComboBox).SelectedIndex = -1; }
            }
            buttonSubmit.Enabled = true;
        }
    }
}
