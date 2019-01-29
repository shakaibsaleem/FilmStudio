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
        User myUser; //the one who's info is being displayed in form
        public User CurrentUser; //the one who is currently logged in and viewing the form

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmUser(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            CurrentUser = currentUser;
            myUser = new User();
            state = "Empty";
        }

        public frmUser(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            CurrentUser = currentUser;
            myUser = new User();
            LoadRecord(id);
            state = "View";
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            UpdateFields(state);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlDataReader rd;
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into Users (Name,Username,Passkey,isAdmin)values('" +
                    myUser.Name + "','" + myUser.Username + "','" +
                    myUser.Passkey + "'," + (myUser.IsAdmin ? "1" : "0") + ")";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select top 1 UserID from Users order by UserID desc";
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    myUser.ID = rd[0].ToString();
                }
                rd.Close();
                tran.Commit();
                state = "Incomplete";
                UpdateFields(state);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in btnAdd");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (state == "Empty")
            {
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then close. Press No to close without" +
                    " adding.", "Add record before closing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
            else if (state == "Filled")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then close. Press No to close without" +
                    " saving.", "Save record before closing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
            else if (state == "Incomplete")
            {
                DialogResult dialogResult = MessageBox.Show("There are unsaved " +
                    "changes to the record that will be lost if you close. Press " +
                    "OK to close discarding changes or press cancel to go back and " +
                    "edit the record", "Close without saving?", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
            }
            else if (state == "View")
            {
                Close();
            }
            else
            {
                MessageBox.Show("State = " + state, "Unexpected value in btnClose");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlDataReader rd;
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                List<string> lst = new List<string>();

                //check if any bookings made by this selected user
                cmd.CommandText = "select BookingID from Bookings where UserID=" + myUser.ID;
                rd = cmd.ExecuteReader();
                while(rd.Read() == true)
                {
                    lst.Add(rd[0].ToString());
                }
                rd.Close();

                if (lst.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("The user you are trying to " +
                        "delete (" + myUser.Name + ") has " + lst.Count.ToString() + " bookings " +
                        "associated with their account. If you delete their account, these bookings " +
                        "will be associated with your account instead. Press OK to continue.","Warning");
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    // transfer all bookings of selected user to current user
                    cmd.CommandText = "Update Bookings set UserID=" + 
                        CurrentUser.ID + " where UserID=" + myUser.ID;
                    cmd.ExecuteNonQuery();
                }

                // delete user
                cmd.CommandText = "delete from Users where UserID=" + myUser.ID;
                cmd.ExecuteNonQuery();

                tran.Commit();
                state = "View";
                UpdateFields(state);
                MessageBox.Show(myUser.Name + " has been deleted.");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in btnDelete");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            state = "Incomplete";
            UpdateFields(state);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (state == "Empty")
            {
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then go to next record. Press No to go to next record without" +
                    " adding.", "Add record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    AdvanceTo("NextRecord", myUser.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("NextRecord", myUser.ID);
                }
            }
            else if (state == "Filled")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then go to next record. Press No to go to next record without" +
                    " saving.", "Save record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    AdvanceTo("NextRecord", myUser.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("NextRecord", myUser.ID);
                }
            }
            else if (state == "Incomplete")
            {
                DialogResult dialogResult = MessageBox.Show("There are unsaved " +
                    "changes to the record that will be lost if you go to next " +
                    "record. Press OK to advance discarding changes or press " +
                    "cancel to go back and edit the record",
                    "Save record before advancing?", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    AdvanceTo("NextRecord", myUser.ID);
                }
            }
            else if (state == "View")
            {
                AdvanceTo("NextRecord", myUser.ID);
            }
            else
            {
                MessageBox.Show("State = " + state, "Unexpected value in btnNext");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (state == "Empty")
            {
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then go to previous record. Press No to go to previous record without" +
                    " adding.", "Add record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    AdvanceTo("PrevRecord", myUser.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("PrevRecord", myUser.ID);
                }
            }
            else if (state == "Filled")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then go to previous record. Press No to go to previous record without" +
                    " saving.", "Save record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    AdvanceTo("PrecRecord", myUser.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("PrevRecord", myUser.ID);
                }
            }
            else if (state == "Incomplete")
            {
                DialogResult dialogResult = MessageBox.Show("There are unsaved " +
                    "changes to the record that will be lost if you go to previous " +
                    "record. Press OK to advance discarding changes or press " +
                    "cancel to go back and edit the record",
                    "Save record before advancing?", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    AdvanceTo("PrevRecord", myUser.ID);
                }
            }
            else if (state == "View")
            {
                AdvanceTo("PrevRecord", myUser.ID);
            }
            else
            {
                MessageBox.Show("State = " + state, "Unexpected value in btnPrevious");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (myUser.Username != "")
            {
                string str1 = "";
                cmd.CommandText = "select Name from Users where Username = '" + myUser.Username + "'";
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    str1 = rd[0].ToString();
                    MessageBox.Show("This username is already taken by " + str1
                        + ". Please choose another username.", "Username taken");
                    rd.Close();
                    return;
                }
                rd.Close();
            }

            cmd.CommandText = "update Users set Name = '" + myUser.Name +
                "',Username = '" + myUser.Username +
                "',Passkey = '" + myUser.Passkey +
                "',isAdmin = " + (myUser.IsAdmin ? "1" : "0") +
                " where UserID = " + myUser.ID;
            cmd.ExecuteNonQuery();

            state = "View";
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

        public void AdvanceTo(string record, string id)
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            try
            {
                if (record == "NextRecord")
                {
                    cmd.CommandText = "select * from (select lead(UserID) over " +
                        "(order by UserID) NextValue, UserID from Users) as " +
                        "NewTable where NewTable.UserID = " + id;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        id = rd[0].ToString();
                        if (id == "")
                        {
                            MessageBox.Show("The last available record is currently loaded", "No next record");
                            rd.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Next record not found");
                    }
                    rd.Close();
                }
                else if (record == "PrevRecord")
                {
                    cmd.CommandText = "select * from (select lag(UserID) over " +
                        "(order by UserID) PrevValue, UserID from Users) as " +
                        "NewTable where NewTable.UserID = " + id;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        id = rd[0].ToString();
                        if (id == "")
                        {
                            MessageBox.Show("The first available record is currently loaded", "No previous record");
                            rd.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Previous record not found");
                    }
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect value for record: " + record, "Error in AdvanceTo()");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in AdvanceTo()");
            }
            LoadRecord(id: id);
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
            myUser.IsAdmin = str1 == "True";

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
            else if (state == "Incomplete")
            {
                state = "Filled";
            }
            UpdateFields(state);
        }
    }
}
