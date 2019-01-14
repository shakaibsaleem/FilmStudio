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
    public partial class frmCourse : Form
    {
        public User CurrentUser;
        Course myCourse;

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmCourse(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myCourse = new Course();
            CurrentUser = currentUser;
            state = "Empty";
        }

        public frmCourse(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myCourse = new Course();
            CurrentUser = currentUser;
            LoadRecord(id);
            state = "View";
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            UpdateFields(state);
        }

        private void LoadRecord(string id)
        {

        }

        private void UpdateFields(string state)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please enter Course Name, then Add", "Name Field is blank");
            }
            else if (txtCode.Text.Length == 0)
            {
                MessageBox.Show("Please enter Course Code, then Add", "Code Field is blank");
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

                    cmd.CommandText = "insert into Courses (CourseName,CourseCode) values ('" +
                        myCourse.CourseName + "','" + myCourse.CourseCode + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 CourseID from Courses order by CourseID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myCourse.ID = rd[0].ToString();
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
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            myCourse.CourseName = txtName.Text;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            myCourse.CourseCode = txtCode.Text;
        }
    }
}
