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
    public partial class frmStaff : Form
    {
        public User CurrentUser;
        Staff myStaff;

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmStaff(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myStaff = new Staff();
            CurrentUser = currentUser;
            state = "Empty";
        }

        public frmStaff(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myStaff = new Staff();
            CurrentUser = currentUser;
            //LoadRecord(id);
            state = "View";
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please enter Staff's Name, then Add", "Name Field is blank");
            }
            else if (txtContact.Text.Length == 0)
            {
                MessageBox.Show("Please enter Staff's Contact number, then Add", "Contact Field is blank");
            }
            else if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Please enter Staff's Email address, then Add", "Email Field is blank");
            }
            else if (txtHabibID.Text.Length == 0)
            {
                MessageBox.Show("Please enter Staff's Habib ID, then Add.", "Habib ID Field is blank");
            }
            else
            {
                SqlDataReader rd;
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "select StaffID,Name,Contact,Email," +
                        "HabibID from Staff where HabibID = '" + myStaff.HabibID +
                        "' or Email = '" + myStaff.Email + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        string tempID = rd[0].ToString();
                        string tempName = rd[1].ToString();
                        string tempContact = rd[2].ToString();
                        string tempEmail = rd[3].ToString();
                        string tempHabibID = rd[4].ToString();
                        MessageBox.Show("The Email or HabibID provided matches an existing record:\n" +
                            tempID + "\n" + tempName + "\n" + tempContact + "\n" + tempEmail + "\n" +
                            tempHabibID, "Duplicate entry");
                        rd.Close();
                        return;
                    }
                    rd.Close();

                    cmd.CommandText = "insert into Staff (Name,Contact," +
                        "Email,HabibID) values ('" + myStaff.Name + "','" +
                        myStaff.Contact + "','" +
                        myStaff.Email + "','" +
                        myStaff.HabibID + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 StaffID from Staff" +
                        " order by StaffID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myStaff.ID = rd[0].ToString();
                    }
                    rd.Close();
                    tran.Commit();
                    state = "Incomplete";
                    //UpdateFields(state);

                    //temp scene
                    MessageBox.Show(myStaff.Name +
                        " has been added", "Staff added");
                    Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message, "Error in btnAdd");
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            myStaff.Name = txtName.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            myStaff.Contact = txtContact.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            myStaff.Email = txtEmail.Text;
        }

        private void txtHabibID_TextChanged(object sender, EventArgs e)
        {
            myStaff.HabibID = txtHabibID.Text;
        }
    }
}
