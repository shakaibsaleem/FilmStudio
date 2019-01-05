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
    public partial class frmUser : Form
    {
        public User myUser;
        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmUser()
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myUser = new User();
            state = "Empty";
        }

        public frmUser(string id)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myUser = new User();
            LoadRecord(id);
            state = "View";
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            UpdateFields(state);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            state = "Incomplete";
            UpdateFields(state);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            state = "View";
            UpdateFields(state);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            state = "Incomplete";
            UpdateFields(state);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            myUser.Name = txtName.Text;
            CheckFilled();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            myUser.Username = txtUsername.Text;
            CheckFilled();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            myUser.Passkey = txtPass.Text;
            CheckFilled();
        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            myUser.IsAdmin = checkBoxAdmin.Checked;
        }

        public void LoadRecord(string id)
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            string str1 = "";
            try
            {
                cmd.CommandText = "select Name,Username,Passkey,isAdmin from Users where UserID = " + id;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    myUser.ID = id;
                    myUser.Name = rd[0].ToString();
                    myUser.Username = rd[1].ToString();
                    myUser.Passkey = rd[2].ToString();
                    str1 = rd[3].ToString();
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in LoadRecord()");
                return;
            }
            myUser.IsAdmin = str1 == "1";

            txtName.Text = myUser.Name;
            txtPass.Text = myUser.Passkey;
            //txtPass.PasswordChar = '*';
            txtUsername.Text = myUser.Username;
            checkBoxAdmin.Checked = myUser.IsAdmin;
        }

        public void UpdateFields(string s)
        {
            if (s == "View")
            {
                btnAdd.Enabled = false;
                btnClose.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;

                txtName.Enabled = true;
                txtPass.Enabled = true;
                txtUsername.Enabled = true;
                checkBoxAdmin.Enabled = true;

                txtName.ReadOnly = true;
                txtPass.ReadOnly = true;
                txtUsername.ReadOnly = true;
                txtPass.PasswordChar = '*';

                checkBoxAdmin.AutoCheck = false;
            }
            else if (s == "Empty")
            {
                btnAdd.Enabled = true;
                btnClose.Enabled = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSave.Enabled = false;

                txtName.Enabled = false;
                txtPass.Enabled = false;
                txtUsername.Enabled = false;
                checkBoxAdmin.Enabled = false;
            }
            else if (s == "Filled")
            {
                btnSave.Enabled = true;
                checkBoxAdmin.AutoCheck = true;
            }
            else if (s == "Incomplete")
            {
                btnAdd.Enabled = false;
                btnClose.Enabled = true;
                btnEdit.Enabled = false;
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;

                txtName.Enabled = true;
                txtPass.Enabled = true;
                txtUsername.Enabled = true;
                checkBoxAdmin.Enabled = true;

                txtName.ReadOnly = false;
                txtPass.ReadOnly = false;
                txtUsername.ReadOnly = false;
                //txtPass.PasswordChar = '\0';

                checkBoxAdmin.AutoCheck = true;
            }
            else
            {
                MessageBox.Show("Invalid argument: " + s, "Error in UpdateFields()");
            }
        }

        public void CheckFilled()
        {
            if (txtName.Text.Length==0)
            {
                state = "Incomplete";
            }
            else if (txtPass.Text.Length == 0)
            {
                state = "Incomplete";
            }
            else if (txtUsername.Text.Length == 0)
            {
                state = "Incomplete";
            }
            else
            {
                state = "Filled";
            }
            UpdateFields(state);
        }
    }
}
