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
    public partial class frmInstructor : Form
    {
        public User CurrentUser;
        Instructor myInstructor;

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmInstructor(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myInstructor = new Instructor();
            CurrentUser = currentUser;
            state = "Empty";
        }

        public frmInstructor(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myInstructor = new Instructor();
            CurrentUser = currentUser;
            //LoadRecord(id);
            state = "View";
        }

        private void frmInstructor_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please enter Instructor's Name, then Add", "Name Field is blank");
            }
            else if (txtContact.Text.Length == 0)
            {
                MessageBox.Show("Please enter Instructor's Contact number, then Add", "Contact Field is blank");
            }
            else if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Please enter Instructor's Email address, then Add", "Email Field is blank");
            }
            else if (txtHabibID.Text.Length == 0)
            {
                MessageBox.Show("Please enter Instructor's Habib ID, then Add.", "Habib ID Field is blank");
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

                    cmd.CommandText = "insert into Instructors (Name,Contact," +
                        "Email,HabibID) values ('" + myInstructor.Name + "','" +
                        myInstructor.Contact + "','" +
                        myInstructor.Email + "','" +
                        myInstructor.HabibID + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 InstructorID from Instructors" +
                        " order by InstructorID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myInstructor.ID = rd[0].ToString();
                    }
                    rd.Close();
                    tran.Commit();
                    state = "Incomplete";
                    //UpdateFields(state);

                    //temp scene
                    MessageBox.Show(myInstructor.Name +
                        " has been added", "Instructor added");
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
            myInstructor.Name = txtName.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            myInstructor.Contact = txtContact.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            myInstructor.Email = txtEmail.Text;
        }

        private void txtHabibID_TextChanged(object sender, EventArgs e)
        {
            myInstructor.HabibID = txtHabibID.Text;
        }
    }
}
