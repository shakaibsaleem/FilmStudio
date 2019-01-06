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
        public User CurrentUser;
        public bool success { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
            CurrentUser = new User();
            success = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select UserID,Name,Username,Passkey,isAdmin " +
                "from Users where Username='" + txtUsername.Text + "'";
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                CurrentUser.ID = rd[0].ToString();
                CurrentUser.Name = rd[1].ToString();
                CurrentUser.Username = rd[2].ToString();
                CurrentUser.Passkey = rd[3].ToString();
                CurrentUser.IsAdmin = rd[4].ToString() == "1";
            }
            else
            {
                MessageBox.Show("The username you have provided does not exist", "User not found");
                rd.Close();
                txtUsername.Select();
                return;
            }
            rd.Close();

            if (CurrentUser.Passkey == txtPasskey.Text)
            {
                MessageBox.Show("Welcome, " + CurrentUser.Name + "!", "Login Successful");
                success = true;
                Close();
            }
            else
            {
                MessageBox.Show("If you are " + CurrentUser.Name + ", enter the " +
                    "correct Password or contact an admin to reset your password",
                    "Incorrect Password");
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
