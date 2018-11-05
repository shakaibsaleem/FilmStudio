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

        public frmLogin()
        {
            InitializeComponent();
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
            }
            else
            {
                string s = "Welcome, "+txtUsername.Text+"!";
                MessageBox.Show(s);
                frmEquipment f = new frmEquipment();
                f.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
