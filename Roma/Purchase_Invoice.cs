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
    public partial class Purchase_Invoice : Form
    {
        string _idString; int _idInt; public static bool sRefresh; bool ProductFoundbyName;
        public Purchase_Invoice()
        {
            InitializeComponent();
        }
        private void Purchase_Invoice_Load(object sender, EventArgs e)
        {
            generateID(); RetriveComboBoxDataSupplierName();
            RetriveComboBoxData(comboBoxProductName, "Products", "Product_Name", "Id");
            //RetriveComboBoxData(comboBoxBarCode, "Products", "BarCode", "Product_Name");
        }

        public void RetriveComboBoxDataSupplierName()
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open)            { Classes.DB.sql_con.Close(); }
            SqlCommand cmd2 = new SqlCommand("select * from  Peoples where Type = 'Supplier' ", Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);            DataTable dt = new DataTable();            sda2.Fill(dt);
            Classes.DB.sql_con.Open();cmd2.ExecuteNonQuery();Classes.DB.sql_con.Close();
                  
            comboBoxSupplierName.DataSource = dt;            comboBoxSupplierName.DisplayMember = "Business_Name";
            comboBoxSupplierName.ValueMember = "ID";
            comboBoxSupplierName.SelectedIndex = -1;
        }
       // To fill Product ComboBox | BarCode Combobox
        public void RetriveComboBoxData(ComboBox comboBox, string DBTable, string displayMemberColumn, string ValueMemberColumn)
        {
            if (Classes.DB.sql_con.State == ConnectionState.Open) { Classes.DB.sql_con.Close(); }
            string querry = "select * from  " + DBTable + "  ";
            SqlCommand cmd2 = new SqlCommand(querry, Classes.DB.sql_con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2); DataTable dt = new DataTable(); sda2.Fill(dt);
            Classes.DB.sql_con.Open(); cmd2.ExecuteNonQuery(); Classes.DB.sql_con.Close();

            comboBox.DataSource = dt; comboBox.DisplayMember = displayMemberColumn;
            comboBox.ValueMember = ValueMemberColumn;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            AddPeopleMiniWindow _miniPeopleWindow = new AddPeopleMiniWindow("Supplier");
            _miniPeopleWindow.ShowDialog();
        }
        private void generateID()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select max(Invoice_ID) from Purchase_Invoice",Classes.DB.sql_con);
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();SDA.Fill(dt);
                Classes.DB.sql_con.Open();cmd.ExecuteNonQuery(); Classes.DB.sql_con.Close();

                _idString = Convert.ToString(dt.Rows[0][0]);
                if (Convert.ToString(dt.Rows[0][0]) == "")
                {
                    _idString = "Invoice-0000";
                }
                _idInt = Convert.ToInt32(_idString.TrimStart('I', 'n', 'v', 'o', 'i', 'c', 'e', '-'));
                _idString = "Invoice-" + (_idInt + 0001).ToString("######0000");
                labelInvoiceID.Text = _idString;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }

        }

        private void comboBoxSupplierName_Enter(object sender, EventArgs e)
        {
            if (sRefresh) // if true re-load new entered supplier
            {
                RetriveComboBoxDataSupplierName();
                sRefresh = false;
            }
        }

        private void comboBoxProductName_Enter(object sender, EventArgs e)
        {
            // refresh combobox when newly added 1 product
        }
        public void _clearProInfo()
        {
            labelBarcode.Text = "";
            textBoxPurPrice.Text = "";
            textBoxSalePrice.Text = "";
            textBoxDiscount.Text = "";
        }
         public void _clearInvoiceDetails()
        {
            comboBoxSupplierName.SelectedIndex = -1;
            labelPreviousDues.Text = "000.00";
            comboBoxPaymentType.SelectedIndex = -1;
            textBoxInvoiceDiscount.Text = "0";
            textBoxMiscService.Text = "0";
            textBoxCash.Text = "0";
            labelReturn.Text = "0";
            textBoxInvoiceNote.Text = "";
            comboBoxSearch.Text = "";
            comboBoxSupplierName.Focus();
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (textBoxTotalAmt.Text == "")
            {
                MessageBox.Show("Input Data is not in a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Product_Detail values (@ProDetail_ID,@Product_ID,@Qty,@Qty_Bonus,@Pur_Price,@Sale_Price,@Discount,@Tax,@Expiry_Date,@Total_Amt)", Classes.DB.sql_con);

                cmd.Parameters.AddWithValue("@ProDetail_ID", labelInvoiceID.Text);
                cmd.Parameters.AddWithValue("@Product_ID", comboBoxProductName.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Qty", textBoxQty.Text);
                cmd.Parameters.AddWithValue("@Qty_Bonus", textBoxQtyBonus.Text);
                cmd.Parameters.AddWithValue("@Pur_Price", textBoxPurPrice.Text);
                cmd.Parameters.AddWithValue("@Sale_Price", textBoxSalePrice.Text);
                cmd.Parameters.AddWithValue("@Discount", textBoxDiscount.Text);
                cmd.Parameters.AddWithValue("@Tax", textBoxTax.Text);
                cmd.Parameters.AddWithValue("@Expiry_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Total_Amt", textBoxTotalAmt.Text);

                Classes.DB.sql_con.Open();cmd.ExecuteNonQuery();Classes.DB.sql_con.Close();

                //MessageBox.Show("Record successfully saved!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh(); comboBoxProductName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
                
            }
            comboBoxProductName.Focus();
            //issearching = 'y';
        }

        private void _Refresh()
        {
            RetriveDatainGridView("");
        }

        public void RetriveDatainGridView(string _search)
        {
            string _querry;
            if (Classes.DB.sql_con.State == ConnectionState.Open){ Classes.DB.sql_con.Close(); }
            if (_search == "")
            { 
             // _querry = "SELECT * from Product_Detail";
                _querry = "SELECT PD.[Pro_Detail_ID], PD.[Product_ID],P.Product_Name AS PName," +
                    "PD.[Qty] ,PD.[QtyBonus],PD.[PurchasePrice],PD.[SoldPrice],PD.[Disc],PD.[Tax],PD.[ExpiryDate],PD.[Total_Amount]" +
                    " FROM Product_Detail as PD" +
                    " inner join Products as P ON PD.[Product_ID] = P.[Id]";
            }
            else
            {
                _querry = "SELECT * from Product_Detail WHERE Pro_Detail_ID  like '%" + _search + "%' " ;

            }

            SqlCommand cmd1 = new SqlCommand(_querry, Classes.DB.sql_con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {               
                dataGridView1.Rows.Add(row[0],row[1],row[2],row[3],row[4],row[5],row[6],row[7], row[8],row[9], row[10]);
                
            }//

        }
        private void comboBoxProductName_Validated(object sender, EventArgs e)
        {// Load Other Fields (Qty,Price,etc) with respect to BARCOde | Product Name
            ProductFoundbyName = false;

            if (comboBoxProductName.Text != "")
            {
                try
                {
                    if (Classes.DB.sql_con.State == ConnectionState.Open) { Classes.DB.sql_con.Close(); }
                    string sqlquerry = "select * from  Products where Product_Name = '" + comboBoxProductName.Text + "' ";
                    SqlCommand cmd = new SqlCommand(sqlquerry, Classes.DB.sql_con);
                    SqlDataReader sqlDataReader;
                    Classes.DB.sql_con.Open(); sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            labelBarcode.Text = sqlDataReader.GetString(1);
                            textBoxPurPrice.Text = sqlDataReader.GetInt32(8).ToString();
                            textBoxSalePrice.Text = sqlDataReader.GetInt32(9).ToString();
                            textBoxDiscount.Text = sqlDataReader.GetInt32(10).ToString();
                            textBoxTax.Text = sqlDataReader.GetInt32(11).ToString();
                        }
                        ProductFoundbyName = true;
                    }
                    else
                    {
                        _clearProInfo();
                    }
                    Classes.DB.sql_con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Classes.DB.sql_con.Close();
                }
            }

            if (ProductFoundbyName != true && comboBoxProductName.Text != "")
            {
                try
                {
                    if (Classes.DB.sql_con.State == ConnectionState.Open) { Classes.DB.sql_con.Close(); }
                    string sqlquerry = "select * from  Products where BarCode = '" + comboBoxProductName.Text + "' ";
                    SqlCommand cmd = new SqlCommand(sqlquerry, Classes.DB.sql_con);
                    SqlDataReader sqlDataReader;
                    Classes.DB.sql_con.Open(); sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            labelBarcode.Text = sqlDataReader.GetString(1);
                            textBoxPurPrice.Text = sqlDataReader.GetInt32(8).ToString();
                            textBoxSalePrice.Text = sqlDataReader.GetInt32(9).ToString();
                            textBoxDiscount.Text = sqlDataReader.GetInt32(10).ToString();
                        }
                    }
                    else
                    {
                        _clearProInfo();
                    }

                    Classes.DB.sql_con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Classes.DB.sql_con.Close();
                }
            }
            textBoxQty.Text = "1";
            textBoxQtyBonus.Text = "0";
            textBoxTax.Text = "0";

            //MessageBox.Show("COMBOBOX VALIDATED");
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxQty.Text == "" || textBoxPurPrice.Text == "" || textBoxDiscount.Text == "" || textBoxTax.Text != "")
                {
                    textBoxTotalAmt.Text = "";
                }
                if (textBoxQty.Text != "" && textBoxPurPrice.Text != "" && textBoxDiscount.Text != "" && textBoxTax.Text != "")
                {
                    textBoxTotalAmt.Text = Convert.ToString((Convert.ToInt32(textBoxQty.Text) * Convert.ToInt32(textBoxPurPrice.Text)) - Convert.ToInt32(textBoxDiscount.Text) - Convert.ToInt32(textBoxTax.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSupplierName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (comboBoxPaymentType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Payment Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Purchase_Invoice values (@Id,@Col_1,@Col_2,@Col_3,@Col_4,@Col_5,@Col_6,@Col_7,@Col_8,@Col_9,@Col_10)", Classes.DB.sql_con);

                cmd.Parameters.AddWithValue("@Id", labelInvoiceID.Text);
                cmd.Parameters.AddWithValue("@Col_1", comboBoxSupplierName.ValueMember.ToString());
                cmd.Parameters.AddWithValue("@Col_2", labelDate.Text);
                cmd.Parameters.AddWithValue("@Col_3", textBoxInvoiceDiscount.Text);
                cmd.Parameters.AddWithValue("@Col_4", textBoxMiscService.Text);
                cmd.Parameters.AddWithValue("@Col_5", labelGrandTotalAmount.Text);
                cmd.Parameters.AddWithValue("@Col_6", comboBoxPaymentType.Text);
                cmd.Parameters.AddWithValue("@Col_7", textBoxCash.Text);
                cmd.Parameters.AddWithValue("@Col_8", labelPreviousDues.Text);
                cmd.Parameters.AddWithValue("@Col_9", textBoxInvoiceNote.Text);
                cmd.Parameters.AddWithValue("@Col_10", labelInvoiceID.Text);
                

                Classes.DB.sql_con.Open();
                cmd.ExecuteNonQuery();
                Classes.DB.sql_con.Close();

                generateID();
                MessageBox.Show("Record successfully saved!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _clearInvoiceDetails();
                _Refresh(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Classes.DB.sql_con.Close();
            }
            //issearching = 'y';
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                if (textBoxCash.Text == "")
                {
                    textBoxCash.Text = "0";
                }
                labelReturn.Text =Convert.ToString( Convert.ToInt32( labelGrandTotalAmount.Text) -Convert.ToInt32( textBoxCash.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxInvoiceDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxInvoiceDiscount.Text == "")
                {
                    textBoxInvoiceDiscount.Text = "0";
                }
                else if (textBoxMiscService.Text == "")
                {
                    textBoxMiscService.Text = "0";
                }
                
                else if (textBoxInvoiceDiscount.Text != "" && textBoxMiscService.Text != "")
                {
                    labelGrandTotalAmount.Text = Convert.ToString( Convert.ToInt32(labelGrandTotalAmount.Text) - Convert.ToInt32(textBoxInvoiceDiscount.Text) - Convert.ToInt32(textBoxMiscService.Text));
                        
                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.ColumnIndex == 11)
            {
                
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string deletingproductid = row.Cells[1].Value.ToString();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete from Product_Detail WHERE Product_ID = '" + deletingproductid + "' ", Classes.DB.sql_con);
                    Classes.DB.sql_con.Open();
                    cmd.ExecuteNonQuery();
                    Classes.DB.sql_con.Close();
                    _Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Classes.DB.sql_con.Close();
                }
                //textBoxID.Text = row.Cells[0].Value.ToString();
                //textBoxBarcode.Text = row.Cells[1].Value.ToString();
                //textBoxProductName.Text = row.Cells[2].Value.ToString();
                //comboBoxCompany.Text = row.Cells[3].Value.ToString();
                //comboBoxGroup.Text = row.Cells[4].Value.ToString();
                //comboBoxPacking.Text = row.Cells[5].Value.ToString();
                //textBoxPurPrice.Text = row.Cells[6].Value.ToString();
                //textBoxSalePrice.Text = row.Cells[7].Value.ToString();
                //textBoxDiscount.Text = row.Cells[8].Value.ToString();
                //textBoxTax.Text = row.Cells[9].Value.ToString();
                //textBoxReOrderQty.Text = row.Cells[10].Value.ToString();
                ////dateTimePickerExpiry.Value = Convert.ToDateTime( row.Cells[9].Value);
                //comboBoxActiveState.Text = row.Cells[12].Value.ToString();

                buttonSave.Enabled = false; buttonSave.BackColor = Color.Gray;
                buttonDelete.Enabled = true; buttonDelete.BackColor = Color.Red;
                buttonUpdate.Enabled = true; buttonUpdate.BackColor = Color.DeepSkyBlue;
            }
        }
    }
}
