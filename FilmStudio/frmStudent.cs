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
    public partial class frmStudent : Form
    {
        public User CurrentUser;
        Student myStudent;

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmStudent(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myStudent = new Student();
            CurrentUser = currentUser;
            state = "Empty";
        }

        public frmStudent(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myStudent = new Student();
            CurrentUser = currentUser;
            //LoadRecord(id);
            state = "View";
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please enter Student's Name, then Add", "Name Field is blank");
            }
            else if (txtContact.Text.Length == 0)
            {
                MessageBox.Show("Please enter Student's Contact number, then Add", "Contact Field is blank");
            }
            else if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Please enter Student's Email address, then Add", "Email Field is blank");
            }
            else if (txtHabibID.Text.Length == 0)
            {
                MessageBox.Show("Please enter Student's Habib ID, then Add.", "Habib ID Field is blank");
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

                    cmd.CommandText = "insert into Students (Name,Contact," +
                        "Email,HabibID) values ('" + myStudent.Name + "','" +
                        myStudent.Contact + "','" +
                        myStudent.Email + "','" +
                        myStudent.HabibID + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 StudentID from Students" +
                        " order by StudentID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myStudent.ID = rd[0].ToString();
                    }
                    rd.Close();
                    tran.Commit();
                    state = "Incomplete";
                    //UpdateFields(state);

                    //temp scene
                    MessageBox.Show(myStudent.Name +
                        " has been added", "Student added");
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
            myStudent.Name = txtName.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            myStudent.Contact = txtContact.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            myStudent.Email = txtEmail.Text;
        }

        private void txtHabibID_TextChanged(object sender, EventArgs e)
        {
            myStudent.HabibID = txtHabibID.Text;
        }
    }
}
