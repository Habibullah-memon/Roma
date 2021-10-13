using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Roma
{
    public partial class Products : Form
    {
        public static bool gRefresh; public static bool cRefresh; public static bool pRefresh;
        public Products()
        {
            InitializeComponent();
        }
        string _idString;
        int _idInt;

        private void Products_Load(object sender, EventArgs e)
        {
            generateID();
            RetriveComboBoxData("Company", comboBoxCompany);
            RetriveComboBoxData("Groups", comboBoxGroup);
            RetriveComboBoxData("Packing", comboBoxPacking);

            //RetriveCheckedListData("Packing", checkedListBox1);
            RetriveDatainGridView(""); _Clear();
            buttonDelete.Enabled = false;
            btnUpdate.Enabled = false;
            comboBoxActiveState.SelectedIndex = 0;

        }
        
        public void RetriveDatainGridViewPacking()
        {
            string Querry;
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }

            Querry = "SELECT Name_of_Field FROM Lists where Name_of_List = 'Packing' ";

            SqlCommand cmd1 = new SqlCommand(Querry, Classes.DB.sql_con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                //dataGridView2.Columns.Add(dt.Rows[0][0], typeof(bool));
                //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // dataGridView2.Columns.Add(dt.Rows[0][0]);
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "habib";/*dt.Rows[i][0].ToString();*/
                checkColumn.HeaderText = dt.Rows[i][0].ToString();
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                                             // dataGridView2.Columns.Add(checkColumn);
                i++;
            }
        }


        //TO LOAD DATA IN COMPANY | GROUP COMBOBOX
        private void RetriveComboBoxData(string _idstartportion, ComboBox _comboBoxName)
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd2 = new SqlCommand("select * from  Lists where ID like '%" + _idstartportion + "%'   ", Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda2.Fill(dt);

            Classes.DB.sql_con.Open();
            cmd2.ExecuteNonQuery();
            Classes.DB.sql_con.Close();

            _comboBoxName.DataSource = dt;
            _comboBoxName.DisplayMember = "Name_of_Field";
            _comboBoxName.ValueMember = "ID";

        }
        
         public class _Pack
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public string QtyOfDescription { get; set; }
            public _Pack()
            {
                //Default Constructor
            }
            
            public void add(string id, string des, string qtydes)
            {
                this.Id = id;
                Description = des;
                QtyOfDescription = qtydes;
            }
        }
        List<_Pack> AllPackColl = new List<_Pack>();
        List<_Pack> SelectedPackColl = new List<_Pack>();

        //TO LOAD DATA IN PACKING CHECKBOX
        private void RetrivePackingListData(string _idstartportion, CheckedListBox _CheckedListBox)
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd2 = new SqlCommand("select * from  Lists where ID like '%" + _idstartportion + "%'   ", Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda2.Fill(dt);

            Classes.DB.sql_con.Open();
            cmd2.ExecuteNonQuery();
            Classes.DB.sql_con.Close();
            // _CheckedListBox.DataSource = dt;
            _CheckedListBox.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string a, b, c; 
                a = row["ID"].ToString();
                b = row["Name_of_List"].ToString();
                c = row["Name_of_Field"].ToString();

                comboBoxPacking.Items.Add(b + "[ " + c+" ]");
                _CheckedListBox.ValueMember = a;
                //MessageBox.Show(_CheckedListBox.SelectedValue.ToString());

                _Pack pc = new _Pack();
                pc.add(a, b, c);
                AllPackColl.Add(pc);
            }
        }

        //char[] mychar = { '[' };
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int i = 0;
        //    SelectedPackColl.Clear();
        //    foreach (var item in checkedListBox1.Items)
        //    {
        //        if (checkedListBox1.GetItemChecked(i)) // GO INSIDE IF THE FIRST ITEM IS CHECKED
        //        {
        //            string[] _checkedPacking = checkedListBox1.Items[i].ToString().Split(mychar);
        //            string a = "0"; string b = _checkedPacking[0];  string c = _checkedPacking[0];

        //            _Pack pack_item = new _Pack();
        //            pack_item.add(a, b, c);
        //            SelectedPackColl.Add(pack_item);
        //        }
        //        i++;
        //    }

        //    for (int k = 0; k < SelectedPackColl.Count; k++)
        //    {
        //        MessageBox.Show(SelectedPackColl[k].Description);
        //    }
        //}

        private void comboBoxCompany_Click(object sender, EventArgs e)
        {
            if (cRefresh == true)
            {
                RetriveComboBoxData("Company", comboBoxCompany);
                cRefresh = false;
            }
        }

        private void comboBoxGroup_Click(object sender, EventArgs e)
        {
            if (gRefresh == true)
            {
                RetriveComboBoxData("Groups", comboBoxGroup);
                gRefresh = false;
            }
        }
        private void comboBoxPacking_Click(object sender, EventArgs e)
        {
            if (pRefresh == true)
            {
                RetriveComboBoxData("Packing", comboBoxPacking);
                pRefresh = false;
            }
        }
        //private void checkedListBox1_Enter(object sender, EventArgs e)
        //{
        //    if (pRefresh == true)
        //    {
        //        RetriveCheckedListData("Packing", checkedListBox1);
        //        pRefresh = false;
        //    }
        //}


        private void generateID()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Classes.DB.sql_con;
                cmd.CommandText = "select max(Id) from Products";
                //Classes.DB.sql_con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);

                SDA.Fill(dt);
                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();

                _idString = Convert.ToString(dt.Rows[0][0]);

                if (Convert.ToString(dt.Rows[0][0]) == "")
                {
                    _idString = "Product-0000";
                }
                _idInt = Convert.ToInt32(_idString.TrimStart('P', 'r', 'o', 'd', 'u', 'c', 't', '-'));
                _idString = "Product-" + (_idInt + 0001).ToString("######0000");
                textBoxID.Text = _idString;
                Classes.DB.sql_con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text == "")
            {
                MessageBox.Show("Please Fill the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (_Pack item in SelectedPackColl)
            {
            try
             {
            SqlCommand cmd = new SqlCommand("insert into Products values (@Id,@Product_Name,@C_Id,@G_Id,@P_Id,@Pur_Price,@Sale_Price,@Discount,@Re_Order_Qty,@Expiry_Date,@Active)" ,Classes.DB.sql_con);

            cmd.Parameters.AddWithValue("@Id",textBoxID.Text);
            cmd.Parameters.AddWithValue("@Product_Name",textBoxProductName.Text);
            cmd.Parameters.AddWithValue("@C_Id",comboBoxCompany.SelectedValue);
            cmd.Parameters.AddWithValue("@G_Id", comboBoxGroup.SelectedValue);
            //cmd.Parameters.AddWithValue("@P_Id", comboBoxPacking.SelectedValue);
            cmd.Parameters.AddWithValue("@Pur_Price", textBoxPurPrice.Text);
            cmd.Parameters.AddWithValue("@Sale_Price", textBoxSalePrice.Text);
            cmd.Parameters.AddWithValue("@Discount", textBoxDiscount.Text);
            cmd.Parameters.AddWithValue("@Re_Order_Qty",textBoxReOrderQty.Text);
            cmd.Parameters.AddWithValue("@Expiry_Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@Active", comboBoxActiveState.Text);

            Classes.DB.sql_con.Open();
            cmd.ExecuteNonQuery();
            Classes.DB.sql_con.Close();

            generateID();
            comboBoxActiveState.SelectedIndex = 0;
                MessageBox.Show("Record successfully saved!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh(); textBoxProductName.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
                comboBoxActiveState.SelectedIndex = 0;

            }

            }
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            _Refresh();
            buttonAdd.Enabled = true; buttonAdd.BackColor = Color.LimeGreen;
            buttonDelete.Enabled = false; buttonDelete.BackColor = Color.Gray;
            btnUpdate.Enabled = false; btnUpdate.BackColor = Color.Gray;
        }

        private void _Refresh()
        {
            RetriveDatainGridView(""); 
            generateID();
            _Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text == "")
            {
                MessageBox.Show("Please Fill Name of Item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                try
                {
                    string querry = @"update Products set Product_Name = @Product_Name, C_Id= @C_Id , G_Id = @G_Id , P_Id = @P_Id , Pur_Price = @Pur_Price, Sale_Price = @Sale_Price, Discount = @Discount, Re_Order_Qty = @Re_Order_Qty, Expiry_Date = @Expiry_Date, Active = @Active where ID = @Id";
                    SqlCommand cmd = new SqlCommand(querry, Classes.DB.sql_con);

                    cmd.Parameters.AddWithValue("@Product_Name", textBoxProductName.Text);
                    cmd.Parameters.AddWithValue("@C_Id", comboBoxCompany.SelectedValue);
                    cmd.Parameters.AddWithValue("@G_Id", comboBoxGroup.SelectedValue);
                    //cmd.Parameters.AddWithValue("@P_Id", comboBoxPacking.SelectedValue);
                    cmd.Parameters.AddWithValue("@Pur_Price", textBoxPurPrice.Text);
                    cmd.Parameters.AddWithValue("@Sale_Price", textBoxSalePrice.Text);
                    cmd.Parameters.AddWithValue("@Discount", textBoxDiscount.Text);
                    cmd.Parameters.AddWithValue("@Re_Order_Qty", textBoxReOrderQty.Text);
                    cmd.Parameters.AddWithValue("@Expiry_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Active", comboBoxActiveState.Text);
                    cmd.Parameters.AddWithValue("@Id", textBoxID.Text);


                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    MessageBox.Show("Updated Sucessfully!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh(); textBoxProductName.Focus();
                    buttonAdd.Enabled = true; buttonAdd.BackColor = Color.LimeGreen;
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you wnat to delete " + textBoxProductName.Text + " Record ", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int a;
                    SqlCommand cmddel = new SqlCommand("Delete from [dbo].[Products] where [ID] = '" + textBoxID.Text + "' ", Classes.DB.sql_con);
                    Classes.DB.sql_con.Open();
                    a= cmddel.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    if (a>0)
                    {
                    MessageBox.Show(textBoxProductName.Text + " Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show( "No Row Effected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _Refresh();
                    buttonAdd.Enabled = true; buttonAdd.BackColor = Color.LimeGreen;
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
            textBoxProductName.Focus();
        }
        public void RetriveDatainGridView(string _search)
        {
            string additionalquerry;
            if (Classes.DB.sql_con.State == ConnectionState.Open)
            { Classes.DB.sql_con.Close(); }
            if (_search == "")
            {
                // additionalquerry = "SELECT * FROM Products";
                additionalquerry = "SELECT P.[Id], P.[Product_Name], L.Name_of_Field AS Company, L1.Name_of_Field AS Groups, L2.Name_of_Field AS Packing ,P.[Pur_Price] ,P.[Sale_Price],P.[Discount],P.[Re_Order_Qty],P.[Expiry_Date],P.[Active] FROM Products as P inner join Lists as L ON P.[C_Id] = L.[ID] inner join Lists as L1 ON P.[G_Id] = L1.[ID] inner join Lists as L2 ON P.[P_Id] = L2.[ID]";
            }
            else
            {               
                additionalquerry = " SELECT P.[Id], P.[Product_Name], L.Name_of_Field AS Company, L1.Name_of_Field AS Groups, L2.Name_of_Field AS Packing ,P.[Pur_Price] ,P.[Sale_Price],P.[Discount],P.[Re_Order_Qty],P.[Expiry_Date],P.[Active] FROM Products as P inner join Lists as L ON P.[C_Id] = L.[ID] inner join Lists as L1 ON P.[G_Id] = L1.[ID] inner join Lists as L2 ON P.[P_Id] = L2.[ID]                            WHERE P.[Id] like '%" + _search + "%' OR P.Product_Name like '%" + _search + "%' OR L.Name_of_Field like '%" + _search + "%' OR L1.Name_of_Field like '%" + _search + "%' OR L2.Name_of_Field like '%" + _search + "%' OR P.Expiry_Date like '%" + _search + "%' OR P.Active like '%" + _search + "%'";

            }

            SqlCommand cmd1 = new SqlCommand(additionalquerry, Classes.DB.sql_con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                _Clear();
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxProductName.Text = row.Cells[1].Value.ToString();
                comboBoxCompany.Text = row.Cells[2].Value.ToString();
                comboBoxGroup.Text = row.Cells[3].Value.ToString();
                //comboBoxPacking.Text = row.Cells[4].Value.ToString();
                textBoxPurPrice.Text = row.Cells[5].Value.ToString();
                textBoxSalePrice.Text = row.Cells[6].Value.ToString();
                textBoxDiscount.Text = row.Cells[7].Value.ToString();
                textBoxReOrderQty.Text = row.Cells[8].Value.ToString();
                //dateTimePickerExpiry.Value = Convert.ToDateTime( row.Cells[9].Value);
                comboBoxActiveState.Text = row.Cells[10].Value.ToString();

                buttonAdd.Enabled = false; buttonAdd.BackColor = Color.Gray;
                buttonDelete.Enabled = true; buttonDelete.BackColor = Color.Red;
                btnUpdate.Enabled = true; btnUpdate.BackColor = Color.DeepSkyBlue;
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddCompny_Click(object sender, EventArgs e)
        {
            Listing.AddList _List = new Listing.AddList("Company", "Description");
            _List.ShowDialog();
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            Listing.AddList _List = new Listing.AddList("Groups", "Description");
            _List.ShowDialog();
        }

        private void buttonAddPacking_Click(object sender, EventArgs e)
        {
            Listing.AddPackingIntoList _List = new Listing.AddPackingIntoList();
            _List.ShowDialog();
        }
        private void _Clear()
        {
            textBoxProductName.Text = "";
            comboBoxCompany.SelectedIndex = -1;
            comboBoxGroup.SelectedIndex = -1;
            //comboBoxPacking.SelectedIndex = -1;
            textBoxPurPrice.Text = "";
            textBoxSalePrice.Text = "";
            textBoxDiscount.Text = "";
            textBoxReOrderQty.Text = "";
            //dateTimePickerExpiry.Value = DateTime.Now;
            comboBoxActiveState.SelectedIndex = 0;

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveDatainGridView(textBoxSearch.Text);
        }

        
       
    }
}
