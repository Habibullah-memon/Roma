using System;
using System.Windows.Forms;

namespace Roma
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }


        private void MDIParent_Load(object sender, EventArgs e)
        {

            //Login1 childForm = new Login1();
            //childForm.MdiParent = this;
            //childForm.Text = "LoginMDI " /*+ childFormNumber++*/;
            //childForm.WindowState = FormWindowState.Maximized;
            //childForm.Show();
            // PROGRAM.CS IS OPENING LOGIN FINE NOW....
        }

        Listing.Lists _Lists;

        private void ListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Lists == null)
            {
                _Lists = new Listing.Lists();
                _Lists.MdiParent = this;
                _Lists.Text = "All Types Lists";
                _Lists.WindowState = FormWindowState.Maximized;
                _Lists.FormClosed += new FormClosedEventHandler(_Lists_FormClosed);
                this.tableLayoutPanelMain.Visible = false;
                _Lists.Show();
            }
            else
            {
                this.tableLayoutPanelMain.Visible = false;
                _Lists.Activate();
            }
        }

        void _Lists_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Lists = null;
            this.tableLayoutPanelMain.Visible = true;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }





        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }



        Peoples _People;
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_People == null)
            {
                _People = new Peoples();
                _People.MdiParent = this;
                _People.Text = "People";
                _People.WindowState = FormWindowState.Maximized;
                _People.FormClosed += new FormClosedEventHandler(_People_FormClosed);
                this.tableLayoutPanelMain.Visible = false;
                _People.Show();
            }
            else
            {
                this.tableLayoutPanelMain.Visible = false;
                _People.Activate();
            }
        }

        private void _People_FormClosed(object sender, FormClosedEventArgs e)
        {
            _People = null;
            this.tableLayoutPanelMain.Visible = true;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login1 _login = new Login1();
            _login.Show();
        }

        Products _products;

        private void buttonProductsWIN_Click(object sender, EventArgs e)
        {
            if (_products == null)
            {
                _products = new Products();
                _products.MdiParent = this;
                _products.Text = "Define A Product";
                _products.WindowState = FormWindowState.Maximized;
                _products.FormClosed += new FormClosedEventHandler(_Products_FormClosed);
                this.tableLayoutPanelMain.Visible = false;
                _products.Show();
            }
            else
            {
                this.tableLayoutPanelMain.Visible = false;
                _products.Activate();
            }
        }

        private void _Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            _products = null;
            this.tableLayoutPanelMain.Visible = true;

        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            Customers _cust = new Customers();
            _cust.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login1 _log = new Login1();
            _log.Show();
        }
        Sale__Invoice _invoice;
        private void buttonInvoiceWIN_Click(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                _invoice = new Sale__Invoice();
                _invoice.MdiParent = this;
                _invoice.Text = "Add Sale Invoice";
                _invoice.WindowState = FormWindowState.Maximized;
                _invoice.FormClosed += new FormClosedEventHandler(_invoice_FormClosed);
                this.tableLayoutPanelMain.Visible = false;
                _invoice.Show();
            }
            else
            {
                this.tableLayoutPanelMain.Visible = false;
                _invoice.Activate();
            }
        }

        private void _invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            _invoice = null;
            this.tableLayoutPanelMain.Visible = true;
        }

        private void priceListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PriceLists _Pricelist = new PriceLists();
            _Pricelist.ShowDialog();
        }
        Purchase_Invoice _purchaseInvoice;
        private void buttonPurInvoice_Click(object sender, EventArgs e)
        {
            if (_purchaseInvoice == null)
            { 
                _purchaseInvoice = new Purchase_Invoice();
                _purchaseInvoice.MdiParent = this;
                _purchaseInvoice.Text = "Add Purchase | Supplier Invoice";
                _purchaseInvoice.WindowState = FormWindowState.Maximized;
                _purchaseInvoice.FormClosed += new FormClosedEventHandler(_purinvoice_FormClosed);
                this.tableLayoutPanelMain.Visible = false;
                _purchaseInvoice.Show();
            }
            else
            {
                this.tableLayoutPanelMain.Visible = false;
                _purchaseInvoice.Activate();
            }
        }
        private void _purinvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            _purchaseInvoice = null;
            this.tableLayoutPanelMain.Visible = true;
        }
    }
}
