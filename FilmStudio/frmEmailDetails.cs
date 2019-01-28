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
    public partial class frmEmailDetails : Form
    {
        User CurrentUser;
        mySQLcon myCon;
        SqlConnection con;


        public frmEmailDetails(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            CurrentUser = currentUser;
        }

        private void EmailDetails_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Username,Passkey from EmailAccount";

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtAddress.Text = rd[0].ToString();
                    txtPasskey.Text = rd[1].ToString();
                }
                else
                {
                    MessageBox.Show("No email account found", "Error loading details");
                }
                rd.Close();
                txtAddress.ReadOnly = true;
                txtPasskey.ReadOnly = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading email details");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CurrentUser.IsAdmin)
            {
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                txtAddress.ReadOnly = false;
                txtPasskey.ReadOnly = false;
                txtPasskey.PasswordChar = '\0';
            }
            else
            {
                MessageBox.Show("Your account does not have admin privileges.\n" +
                    "An admin account is required.", "Need permission");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update EmailAccount set Username = '" +
                    txtAddress.Text + "', Passkey = '" + txtPasskey.Text + "'";
                cmd.ExecuteNonQuery();

                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                txtAddress.ReadOnly = true;
                txtPasskey.ReadOnly = true;
                txtPasskey.PasswordChar = '*';
                MessageBox.Show("The email account has been updated successfully", "Changes saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving updates");
            }
        }
    }
}
