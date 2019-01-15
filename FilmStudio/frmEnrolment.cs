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
            UpdateStudents();
            UpdateCourses();
            UpdateInstructors();
        }

        private void UpdateCourses()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select CourseID, CourseName, CourseCode " +
                    "from Courses order by CourseName";

                comboBoxCourse.Items.Clear();
                Course course = new Course();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    course.ID = rd[0].ToString();
                    course.CourseName = rd[1].ToString();
                    course.CourseCode = rd[2].ToString();
                    comboBoxCourse.Items.Add(course);
                }
                rd.Close();

                int width = comboBoxCourse.DropDownWidth;
                int maxWidth = frmBooking.DropDownWidth(comboBoxCourse);
                if (maxWidth > width)
                {
                    comboBoxCourse.DropDownWidth = maxWidth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating Courses");
            }
        }

        private void UpdateInstructors()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select InstructorID, HabibID, Name, Email, " +
                    "Contact from Instructors order by Name";

                comboBoxInstructor.Items.Clear();
                Instructor instructor = new Instructor();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    instructor.ID = rd[0].ToString();
                    instructor.HabibID = rd[1].ToString();
                    instructor.Name = rd[2].ToString();
                    instructor.Email = rd[3].ToString();
                    instructor.Contact = rd[4].ToString();
                    comboBoxInstructor.Items.Add(instructor);
                }
                rd.Close();

                int width = comboBoxInstructor.DropDownWidth;
                int maxWidth = frmBooking.DropDownWidth(comboBoxInstructor);
                if (maxWidth > width)
                {
                    comboBoxInstructor.DropDownWidth = maxWidth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating Instructors");
            }
        }

        private void UpdateStudents()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StudentID, HabibID, Name, Email, " +
                    "Contact from Students order by HabibID";

                comboBoxStudent.Items.Clear();
                Student student = new Student();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    student.ID = rd[0].ToString();
                    student.HabibID = rd[1].ToString();
                    student.Name = rd[2].ToString();
                    student.Email = rd[3].ToString();
                    student.Contact = rd[4].ToString();
                    comboBoxStudent.Items.Add(student);
                }
                rd.Close();

                int width = comboBoxStudent.DropDownWidth;
                int maxWidth = frmBooking.DropDownWidth(comboBoxStudent);
                if (maxWidth > width)
                {
                    comboBoxStudent.DropDownWidth = maxWidth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating student IDs");
            }
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
        
        private void txtTerm_TextChanged(object sender, EventArgs e)
        {
            myEnrolment.Term = txtTerm.Text;
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            frmStudent frm = new frmStudent(CurrentUser);
            frm.Show();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            frmCourse frm = new frmCourse(CurrentUser);
            frm.Show();
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {
            frmInstructor frm = new frmInstructor(CurrentUser);
            frm.Show();
        }

        private void btnEnrolment_Click(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select a Student, then Add", "Student field is blank");
            }
            else if (comboBoxCourse.SelectedItem == null)
            {
                MessageBox.Show("Please select a Course, then Add", "Course Field is blank");
            }
            else if (comboBoxInstructor.SelectedItem == null)
            {
                MessageBox.Show("Please select an Instructor, then Add", "Instructor Field is blank");
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

                    cmd.CommandText = "insert into Enrolments (CourseID,StudentID" +
                        ",InstructorID,Term) values (" + myEnrolment.Course.ID + "," +
                        myEnrolment.Student.ID + "," + myEnrolment.Instructor.ID + ",'" +
                        myEnrolment.Term + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 EnrolmentID from Enrolments" +
                        " order by EnrolmentID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myEnrolment.ID = rd[0].ToString();
                    }
                    rd.Close();
                    tran.Commit();
                    state = "Incomplete";
                    //UpdateFields(state);

                    //temp scene
                    MessageBox.Show(myEnrolment.Student.Name + " has been added" +
                        " to " + myEnrolment.Course.CourseName + " with " +
                        myEnrolment.Instructor.Name + " in " + myEnrolment.Term,
                        "Enrolment information added");
                    Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message, "Error in adding enrolment");
                }
            }
        }
    }
}
