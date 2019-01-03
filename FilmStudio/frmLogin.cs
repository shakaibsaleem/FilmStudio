using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilmStudio
{
    public partial class frmLogin : Form
    {
        mySQLcon myCon;
        SqlConnection con;
        public bool success { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
            success = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where Username='"+txtUsername.Text+"' and Passkey='"+txtPasskey.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (0==i)
            {
                MessageBox.Show("Incorrect Username or Passkey!");
                txtUsername.Select();
            }
            else
            {
                MessageBox.Show("Welcome, " + txtUsername.Text + "!", "Login Successful");
                success = true;
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pressing RETURN will perform Login
            if (e.KeyChar == (char)Keys.Return)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
