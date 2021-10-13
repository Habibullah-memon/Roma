using System;
using System.Windows.Forms;

namespace Roma
{
    public partial class Sale_Invoice : Form
    {
        public Sale_Invoice()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MDIParent _mdiparent;
        Products _products;
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
             if (_products == null)
            {
                _products = new Products();
                _products.MdiParent = _mdiparent ;
                _products.Text = "ADD Product";
                _products.WindowState = FormWindowState.Maximized;
                _products.FormClosed += new FormClosedEventHandler(_Products_FormClosed);
               // this.tableLayoutPanelMain.Visible = false;
                _products.Show();
            }
            else
            {
               // this.tableLayoutPanelMain.Visible = false;
                _products.Activate();
            }
        }

        private void _Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            _products = null;
            //this.tableLayoutPanelMain.Visible = true;

        }
    }
}
