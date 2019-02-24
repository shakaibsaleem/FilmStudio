using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudio
{
    public partial class EmailManual : Form
    {
        public string to, subject, body;

        private void EmailManual_Load(object sender, EventArgs e)
        {
            txtTo.Text = to;
            txtSubject.Text = subject;
            txtBody.Text = body;
        }

        public EmailManual()
        {
            InitializeComponent();
        }

    }
}
