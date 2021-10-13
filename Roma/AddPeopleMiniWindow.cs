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

namespace Roma
{
    public partial class AddPeopleMiniWindow : Form
    {
        public static string peopleTypeDesc;
        public AddPeopleMiniWindow(string _Parameter_PeopleTypeDescription)
        {
            InitializeComponent();  peopleTypeDesc = _Parameter_PeopleTypeDescription; 
        }
        
        private void AddPeopleMiniWindow_Load(object sender, EventArgs e)
        {
            generateID(); comboBoxType.Text = peopleTypeDesc; //RetriveComboBoxData();
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
        private void buttonAddType_Click(object sender, EventArgs e)
        {
            Listing.AddList UserList = new Listing.AddList("People Type", "Description");
            UserList.ShowDialog();
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
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                { (ctrl as TextBox).Clear(); }
                //else if (ctrl is ComboBox)
                //{ (ctrl as ComboBox).SelectedIndex = -1; }
            }
            comboBoxType.Text = peopleTypeDesc;
            buttonSubmit.Enabled = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxBusiness.Text != "" && comboBoxType.Text == peopleTypeDesc)
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
                    generateID(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
                _Clear();
            }
            else
            {
                if (textBoxName.Text == "") { MessageBox.Show("Enter UserName", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                if (textBoxBusiness.Text == "") { MessageBox.Show("Enter Business Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                if (comboBoxType.Text != peopleTypeDesc) { MessageBox.Show("You can only Enter Supplier Here...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBoxType.Text = peopleTypeDesc; }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.Text == "Supplier")
            {
                Purchase_Invoice.sRefresh = true;
            }
            this.Close();

        }

        private void comboBoxType_TextChanged(object sender, EventArgs e)
        {
            string tmp = comboBoxType.Text;
            MessageBox.Show("You can Only Enter Supplier Here...");
            comboBoxType.Text = tmp;

        }
    }
}
