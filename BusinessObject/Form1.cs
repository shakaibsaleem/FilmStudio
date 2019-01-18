using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessObject
{
    public partial class Form1 : Form
    {
        // Instantiate the Merchant class.
        private Merchant m_merchant = new Merchant();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bind the Product collection to the DataSource.
            //this.ProductBindingSource.DataSource = m_merchant.GetProducts();
        }
    }
}
