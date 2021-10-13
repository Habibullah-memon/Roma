using System;
using System.Windows.Forms;

namespace Roma
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.customersDataSet);

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.customersDataSet.Customers);
            long _newid = Convert.ToInt64(customersTableAdapter.ScalarQueryIDMAX());

            iDTextBox.Text = Convert.ToInt64("Customer " + _newid + 1).ToString();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            try
            {
                this.customersTableAdapter.InsertQuery(full_NameTextBox.Text, business_NameTextBox.Text, addressTextBox.Text, cityTextBox.Text, stateTextBox.Text, countryTextBox.Text, contect_1TextBox.Text, contect_2TextBox.Text, emailTextBox.Text, Convert.ToInt32(priseListIDComboBox.Text), notesTextBox.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            this.customersTableAdapter.Fill(this.customersDataSet.Customers);

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.customersDataSet.Customers);
            long _newid = Convert.ToInt64(customersTableAdapter.ScalarQueryIDMAX());

            iDTextBox.Text = Convert.ToInt64("Customer " + _newid + 1).ToString();
            full_NameTextBox.Text = "";
            business_NameTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            countryTextBox.Text = "";
            contect_1TextBox.Text = "";
            contect_2TextBox.Text = "";
            emailTextBox.Text = "";
            notesTextBox.Text = "";
            priseListIDComboBox.Text = "";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.DeleteQuery(Convert.ToInt64(iDTextBox.Text));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            this.customersTableAdapter.Fill(this.customersDataSet.Customers);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.UpdateQuery(full_NameTextBox.Text, business_NameTextBox.Text, addressTextBox.Text, cityTextBox.Text, stateTextBox.Text, countryTextBox.Text, contect_1TextBox.Text, contect_2TextBox.Text, emailTextBox.Text, Convert.ToInt32(priseListIDComboBox.Text), notesTextBox.Text, Convert.ToInt64(iDTextBox.Text));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            this.customersTableAdapter.Fill(this.customersDataSet.Customers);
        }
    }
}
