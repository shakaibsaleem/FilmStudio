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
    public partial class frmEnrolment : Form
    {
        public User CurrentUser;
        Enrolment myEnrolment;

        mySQLcon myCon;
        SqlConnection con;
        string state;

        public frmEnrolment(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myEnrolment = new Enrolment();
            CurrentUser = currentUser;
            state = "Empty";
        }

        public frmEnrolment(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myEnrolment = new Enrolment();
            CurrentUser = currentUser;
            //LoadRecord(id);
            state = "View";
        }

        private void frmEnrolment_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedItem != null)
            {
                myEnrolment.Student = (Student)comboBoxStudent.SelectedItem;
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourse.SelectedItem != null)
            {
                myEnrolment.Course = (Course)comboBoxCourse.SelectedItem;
            }
        }

        private void comboBoxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstructor.SelectedItem != null)
            {
                myEnrolment.Instructor = (Instructor)comboBoxInstructor.SelectedItem;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            myEnrolment.Term = txtName.Text;
        }
    }
}
