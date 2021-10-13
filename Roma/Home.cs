using System;
using System.Windows.Forms;

namespace Roma
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void ButtonPeoplesWIN_Click(object sender, EventArgs e)
        {
            Peoples _peoples = new Peoples();
            _peoples.Show();

        }
    }
}
