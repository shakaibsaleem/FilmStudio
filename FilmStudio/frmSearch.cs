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
    public partial class frmSearch : Form
    {
        mySQLcon myCon;
        SqlConnection con;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;

            HideFields();
            PopulateCombos();
            rbtnStudent.Select();
        }

        private void rbtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxStudent.Visible = rbtnStudent.Checked;
            dataGridResults.DataSource = null;
            comboBoxStudent.ResetText();
        }

        private void rbtnEquip_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEquip.Visible = rbtnEquip.Checked;
            dataGridResults.DataSource = null;
            comboBoxEquip.ResetText();
        }

        private void rbtnDue_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeDueF.Visible = rbtnDue.Checked;
            dateTimeDueT.Visible = rbtnDue.Checked;
            dataGridResults.DataSource = null;
        }

        private void rbtnIssue_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeIssueF.Visible = rbtnIssue.Checked;
            dateTimeIssueT.Visible = rbtnIssue.Checked;
            dataGridResults.DataSource = null;
        }

        private void rbtnReturn_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeReturnF.Visible = rbtnReturn.Checked;
            dateTimeReturnT.Visible = rbtnReturn.Checked;
            dataGridResults.DataSource = null;
        }

        private void rbtnCourse_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxCourse.Visible = rbtnCourse.Checked;
            dataGridResults.DataSource = null;
            comboBoxCourse.ResetText();
        }

        private void rbtnInst_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxInst.Visible = rbtnInst.Checked;
            dataGridResults.DataSource = null;
            comboBoxInst.ResetText();
        }

        private void rbtnStaff_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxStaff.Visible = rbtnStaff.Checked;
            dataGridResults.DataSource = null;
            comboBoxStaff.ResetText();
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBoxEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBoxInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBoxStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeDueF_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeDueT_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeIssueF_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeIssueT_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeReturnF_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimeReturnT_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void HideFields()
        {
            comboBoxCourse.Visible = false;
            comboBoxEquip.Visible = false;
            comboBoxInst.Visible = false;
            comboBoxStaff.Visible = false;
            comboBoxStudent.Visible = false;

            dateTimeDueF.Visible = false;
            dateTimeDueT.Visible = false;
            dateTimeIssueF.Visible = false;
            dateTimeIssueT.Visible = false;
            dateTimeReturnF.Visible = false;
            dateTimeReturnT.Visible = false;
        }

        private void PopulateCombos()
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            comboBoxStudent.Items.Clear();
            cmd.CommandText = "select HabibID from Students order by HabibID";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxStudent.Items.Add(rd[0]);
            }
            rd.Close();

            int width = comboBoxStudent.DropDownWidth;
            int maxWidth = frmBooking.DropDownWidth(comboBoxStudent);
            if (maxWidth > width)
            {
                comboBoxStudent.DropDownWidth = maxWidth;
            }

            comboBoxEquip.Items.Clear();
            cmd.CommandText = "select Description from Equipments order by Description";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxEquip.Items.Add(rd[0]);
            }
            rd.Close();

            width = comboBoxEquip.DropDownWidth;
            maxWidth = frmBooking.DropDownWidth(comboBoxEquip);
            if (maxWidth > width)
            {
                comboBoxEquip.DropDownWidth = maxWidth;
            }

            comboBoxCourse.Items.Clear();
            cmd.CommandText = "select CourseName from Courses order by CourseName";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxCourse.Items.Add(rd[0]);
            }
            rd.Close();

            width = comboBoxCourse.DropDownWidth;
            maxWidth = frmBooking.DropDownWidth(comboBoxCourse);
            if (maxWidth > width)
            {
                comboBoxCourse.DropDownWidth = maxWidth;
            }

            comboBoxInst.Items.Clear();
            cmd.CommandText = "select Name from Instructors order by Name";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxInst.Items.Add(rd[0]);
            }
            rd.Close();

            width = comboBoxInst.DropDownWidth;
            maxWidth = frmBooking.DropDownWidth(comboBoxInst);
            if (maxWidth > width)
            {
                comboBoxInst.DropDownWidth = maxWidth;
            }

            comboBoxStaff.Items.Clear();
            cmd.CommandText = "select Name from Staff order by Name";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxStaff.Items.Add(rd[0]);
            }
            rd.Close();

            width = comboBoxStaff.DropDownWidth;
            maxWidth = frmBooking.DropDownWidth(comboBoxStaff);
            if (maxWidth > width)
            {
                comboBoxStaff.DropDownWidth = maxWidth;
            }
        }

        private void Search()
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (rbtnStudent.Checked)
            {
                int i = 0;
                try
                {
                    i = comboBoxStudent.SelectedIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Please select an item from the dropdown");
                    return;
                }
                string id = comboBoxStudent.Items[i].ToString();

                cmd.CommandText = "select StudentID from Students where HabibID = '" + id + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = rd[0].ToString();
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("No record found for " + id, "Student not found");
                    rd.Close();
                    return;
                }

                cmd.CommandText = "select Bookings.BookingID,Name,IssueDate,ReturnDate,DueDate,HabibID " +
                    "from Bookings, BookingsByStudents, Enrolments, Students " +
                    "where Bookings.BookingID = BookingsByStudents.BookingID " +
                    "and BookingsByStudents.EnrolmentID = Enrolments.EnrolmentID " +
                    "and Enrolments.StudentID = Students.StudentID " +
                    "and Students.StudentID = " + id;
                cmd.ExecuteNonQuery();
            }
            else if (rbtnEquip.Checked)
            {
                int i = 0;
                try
                {
                    i = comboBoxEquip.SelectedIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Please select an item from the dropdown");
                    return;
                }
                string desc = comboBoxEquip.Items[i].ToString();
                string id;

                cmd.CommandText = "select EquipmentID from Equipments where Description = '" + desc + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = rd[0].ToString();
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("No record found for " + desc, "Equipment not found");
                    rd.Close();
                    return;
                }

                cmd.CommandText = "select Bookings.BookingID,Description,Quantity as " +
                    "QuantityIssued,IssueDate,ReturnDate,DueDate,QuantityAvailable," +
                    "BookedBy,Notes from Equipments, BookedItems, Bookings where " +
                    "Equipments.EquipmentID = BookedItems.EquipmentID and " +
                    "BookedItems.BookingID = Bookings.BookingID and " +
                    "Equipments.EquipmentID = " + id;
                cmd.ExecuteNonQuery();
            }
            else if (rbtnCourse.Checked)
            {
                int i = 0;
                try
                {
                    i = comboBoxCourse.SelectedIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Please select an item from the dropdown");
                    return;
                }
                string name = comboBoxCourse.Items[i].ToString();
                string id;

                cmd.CommandText = "select CourseID from Courses where CourseName = '" + name + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = rd[0].ToString();
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("No record found for " + name, "Course not found");
                    rd.Close();
                    return;
                }

                cmd.CommandText = "select Bookings.BookingID,CourseName,IssueDate," +
                    "ReturnDate,DueDate,Project from Courses, Enrolments, BookingsByStudents, " +
                    "Bookings where Courses.CourseID = Enrolments.CourseID and " +
                    "Enrolments.EnrolmentID = BookingsByStudents.EnrolmentID and " +
                    "BookingsByStudents.BookingID = Bookings.BookingID and Courses.CourseID = " + id;
                cmd.ExecuteNonQuery();
            }
            else if (rbtnInst.Checked)
            {
                int i = 0;
                try
                {
                    i = comboBoxInst.SelectedIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Please select an item from the dropdown");
                    return;
                }
                string name = comboBoxInst.Items[i].ToString();
                string id;

                cmd.CommandText = "select InstructorID from Instructors where Name = '" + name + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = rd[0].ToString();
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("No record found for " + name, "Instructor not found");
                    rd.Close();
                    return;
                }

                cmd.CommandText = "select Bookings.BookingID,Name,IssueDate," +
                    "ReturnDate,DueDate from Instructors,BookingsByInstructors, " +
                    "Bookings where Instructors.InstructorID = BookingsByInstructors.InstructorID and " +
                    "BookingsByInstructors.BookingID = Bookings.BookingID and Instructors.InstructorID = " + id;
                cmd.ExecuteNonQuery();
            }
            else if (rbtnStaff.Checked)
            {
                int i = 0;
                try
                {
                    i = comboBoxStaff.SelectedIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Please select an item from the dropdown");
                    return;
                }
                string name = comboBoxStaff.Items[i].ToString();
                string id;

                cmd.CommandText = "select StaffID from Staff where Name = '" + name + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = rd[0].ToString();
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("No record found for " + name, "Staff not found");
                    rd.Close();
                    return;
                }

                cmd.CommandText = "select Bookings.BookingID,Name,IssueDate," +
                    "ReturnDate,DueDate from Staff,BookingsByStaff, " +
                    "Bookings where Staff.StaffID = BookingsByStaff.StaffID and " +
                    "BookingsByStaff.BookingID = Bookings.BookingID and Staff.StaffID = " + id;
                cmd.ExecuteNonQuery();
            }
            else if (rbtnDue.Checked)
            {
                cmd.CommandText = "select BookingID,IssueDate,ReturnDate,DueDate,BookedBy,Notes " +
                    "from Bookings where DueDate >= '" + frmBooking.DateOf(dateTimeDueF.Value) +
                    "' and DueDate <= '" + frmBooking.DateOf(dateTimeDueT.Value) + "'";
                cmd.ExecuteNonQuery();
            }
            else if (rbtnIssue.Checked)
            {
                cmd.CommandText = "select BookingID,IssueDate,ReturnDate,DueDate,BookedBy,Notes " +
                    "from Bookings where IssueDate >= '" + frmBooking.DateOf(dateTimeIssueF.Value) +
                    "' and IssueDate <= '" + frmBooking.DateOf(dateTimeIssueT.Value) + "'";
                cmd.ExecuteNonQuery();
            }
            else if (rbtnReturn.Checked)
            {
                cmd.CommandText = "select BookingID,IssueDate,ReturnDate,DueDate,BookedBy,Notes " +
                    "from Bookings where ReturnDate >= '" + frmBooking.DateOf(dateTimeReturnF.Value) +
                    "' and ReturnDate <= '" + frmBooking.DateOf(dateTimeReturnT.Value) + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Please select a criteria", "Error in Search()");
                return;
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridResults.DataSource = dt;
        }

        private void dataGridResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridResults.CurrentRow.Cells[0].Value.ToString();
            Booking myBooking = new Booking();

            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            string date, time;
            try
            {

                cmd.CommandText = "select UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate," +
                    "IssueTime,DueDate,DueTime,ReturnDate,ReturnTime from Bookings where BookingID = " + id;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    myBooking.ID = id;
                    myBooking.CurrentUser.UserID = rd[0].ToString();
                    myBooking.Notes = rd[1].ToString();
                    myBooking.BookedBy = rd[2].ToString();
                    date = rd[3].ToString();
                    time = rd[4].ToString();
                    myBooking.BookedOn = frmBooking.DateTimeOf(date: date, time: time);
                    date = rd[5].ToString();
                    time = rd[6].ToString();
                    myBooking.IssuedOn = frmBooking.DateTimeOf(date: date, time: time);
                    date = rd[7].ToString();
                    time = rd[8].ToString();
                    myBooking.DueOn = frmBooking.DateTimeOf(date: date, time: time);
                    date = rd[9].ToString();
                    time = rd[10].ToString();
                    myBooking.ReturnedOn = frmBooking.DateTimeOf(date: date, time: time);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Record not found - id=" + id);
            }
            frmBooking frm = new frmBooking(myBooking, "Load");
            frm.Show();
            MessageBox.Show("Exit?");
            Close();
        }
    }
}
