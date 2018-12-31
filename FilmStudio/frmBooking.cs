﻿using System;
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
    public partial class frmBooking : Form
    {
        public Booking myBooking;
        public Equipment myEquipment;
        mySQLcon myCon;
        SqlConnection con;

        public frmBooking()
        {
            InitializeComponent();
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentUser: new User(),
                currentInstructor: new Instructor(),
                currentStaff: new Staff(),
                currentEnrolment: new Enrolment(),
                currentStudent: new Student(),
                iD: "0",
                issuedOn: DateTime.Now.AddDays(1),
                dueOn: DateTime.Now.AddDays(3),
                returnedOn: DateTime.Now.AddDays(2),
                bookedOn: DateTime.Now,
                notes: "",
                bookedBy: ""
                );
        }
        
        public frmBooking(Booking bk)
        {
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentUser: new User(),
                currentInstructor: new Instructor(),
                currentStaff: new Staff(),
                currentEnrolment: new Enrolment(),
                currentStudent: new Student(),
                iD: bk.ID,
                issuedOn: bk.IssuedOn,
                dueOn: bk.DueOn,
                returnedOn: bk.ReturnedOn,
                bookedOn: bk.BookedOn,
                notes: bk.Notes,
                bookedBy: bk.BookedBy
                );
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;

            dateTimeIssued.Value = myBooking.IssuedOn;
            dateTimeDue.Value = myBooking.DueOn;
            txtAssignment.Text = "";
            txtEquipment.Text = myEquipment.Description;
            numQuantity.Value = 1;
            rbtnStudent.Select();
            //btnAdd.Select();
            UpdateEnabled("Load");
UpdateEnabled("Add");
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            // check for duplication
            if (listViewBooking.FindItemWithText(txtEquipment.Text) == null)
            {
                // Adding values from text boxes to list view
                ListViewItem listViewItem = new ListViewItem(txtEquipment.Text);
                listViewItem.SubItems.Add(numQuantity.Value.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            else
            {
                // if item exists, update quantity instead of adding as a duplicate entry
                ListViewItem listViewItem = listViewBooking.FindItemWithText(txtEquipment.Text);
                int i = listViewBooking.Items.IndexOf(listViewItem);
                ListViewItem.ListViewSubItem subItem = listViewBooking.Items[i].SubItems[1];
                int q = Convert.ToInt32(subItem.Text);
                listViewBooking.Items.RemoveAt(i);
                listViewItem = new ListViewItem(txtEquipment.Text);
                int qNew = Convert.ToInt32(numQuantity.Value) + q;
                listViewItem.SubItems.Add(qNew.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            txtEquipment.Clear();
            numQuantity.Value = 1;
            txtEquipment.Select();
        }

        private void txtEquipment_TextChanged(object sender, EventArgs e) => CheckEnableAdd();

        private void numQuantity_ValueChanged(object sender, EventArgs e) => CheckEnableAdd();

        private void CheckEnableAdd()
        {
            if (txtEquipment.TextLength == 0 || Convert.ToInt32(numQuantity.Value) == 0)
            {
                btnAddEquipment.Enabled = false;
            }
            else
            {
                btnAddEquipment.Enabled = true;
            }
        }

        private void numQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pressing RETURN after entering quantity to add the item to list
            if (e.KeyChar == (char)Keys.Return)
            {
                btnAddEquipment.PerformClick();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Bookings " +
                    "(UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime) " +
                    "values(" + myBooking.CurrentUser.UserID + ",'" + myBooking.Notes + "','" + myBooking.BookedBy + "','" +
                    DateOf(myBooking.BookedOn) + "','" + TimeOf(myBooking.BookedOn) + "','" +
                    DateOf(myBooking.IssuedOn) + "','" + TimeOf(myBooking.IssuedOn) + "','" +
                    DateOf(myBooking.DueOn) + "','" + TimeOf(myBooking.DueOn) + "','" +
                    DateOf(myBooking.ReturnedOn) + "','" + TimeOf(myBooking.ReturnedOn) + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select top 1 BookingID from Bookings order by BookingID desc";
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    myBooking.ID = rd[0].ToString();
                }
                rd.Close();

                tran.Commit();

                //MessageBox.Show("Booking ID is: " + myBooking.ID, "Booking Created");
                UpdateEnabled("Add");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in btnAdd");
            }
        }

        public string DateOf(DateTime dateTime)
        {
            //string str = dateTime.Year + "-" + dateTime.Month + "-" + dateTime.Day;
            string str = dateTime.ToString("yyyy-MM-dd");
            return str;
        }

        public string TimeOf(DateTime dateTime)
        {
            //string str = dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
            string str = dateTime.ToString("HH:mm:00");
            return str;
        }

        private void rbtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStudent.Checked)
            {
                myBooking.BookedBy = "Student";
                UpdateEnabled("Student");
                UpdateBookingDetails("Student");
            }
        }

        private void rbtnInstructor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInstructor.Checked)
            {
                myBooking.BookedBy = "Instructor";
                UpdateEnabled("Instructor");
                UpdateBookingDetails("Instructor");
            }
        }

        private void rbtnStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStaff.Checked)
            {
                myBooking.BookedBy = "Staff";
                UpdateEnabled("Staff");
                UpdateBookingDetails("Staff");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                if (myBooking.BookedBy == "Instructor")
                {
                    cmd.CommandText = "select * from BookingsByInstructors where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (0 == i)
                    {
                        cmd.CommandText = "insert into BookingsByInstructors (InstructorID,BookingID) values (" + 
                            myBooking.CurrentInstructor.ID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update BookingsByInstructors set InstructorID = " +
                            myBooking.CurrentInstructor.ID + 
                            " where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "delete from BookingsByStudents where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from BookingsByStaff where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                }
                else if (myBooking.BookedBy == "Student")
                {
                    cmd.CommandText = "select * from BookingsByStudents where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (0 == i)
                    {
                        cmd.CommandText = "insert into BookingsByStudents (EnrolmentID,BookingID,Project) values (" + 
                            myBooking.CurrentEnrolment.ID + "," + myBooking.ID + ",'" + txtAssignment.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update BookingsByStudents set EnrolmentID = " +
                            myBooking.CurrentEnrolment.ID +
                            " where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "delete from BookingsByInstructors where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from BookingsByStaff where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                }
                else if (myBooking.BookedBy == "Staff")
                {
                    cmd.CommandText = "select * from BookingsByStaff where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (0 == i)
                    {
                        cmd.CommandText = "insert into BookingsByStaff (StaffID,BookingID) values (" +
                            myBooking.CurrentStaff.ID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update BookingsByStaff set StaffID = " +
                            myBooking.CurrentStaff.ID +
                            " where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "delete from BookingsByStudents where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from BookingsByInstructors where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Unexpected value for BookedBy: " + myBooking.BookedBy, "Error in Save");
                }
                cmd.CommandText = "update Bookings set BookedBy = '" + 
                    myBooking.BookedBy + "' where BookingID = " + myBooking.ID;
                cmd.ExecuteNonQuery();

                tran.Commit();

                //MessageBox.Show("Press OK to continue", "Saved successfully");

                UpdateEnabled("Save");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in Save");
            }
        }

        private void dateTimeIssued_ValueChanged(object sender, EventArgs e)
        {
            myBooking.IssuedOn = dateTimeIssued.Value;
        }

        private void dateTimeDue_ValueChanged(object sender, EventArgs e)
        {
            myBooking.DueOn = dateTimeDue.Value;
        }

        private void UpdateEnabled(string e)
        {
            if (e == "Save")
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;

                groupBoxBookedFor.Enabled = false;
                groupBoxBooking.Enabled = false;
                groupBoxEquipment.Enabled = false;

                dateTimeIssued.Enabled = false;
                dateTimeDue.Enabled = false;

                txtNotes.Enabled = false;
            }
            else if (e == "Add")
            {
                btnAdd.Enabled = false;
                btnSave.Enabled = true;

                groupBoxBookedFor.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;

                txtNotes.Enabled = true;
            }
            else if (e == "Load")
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;

                groupBoxBookedFor.Enabled = false;
                groupBoxBooking.Enabled = false;
                groupBoxEquipment.Enabled = false;

                txtNotes.Enabled = false;
            }
            else if (e == "Edit")
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;

                groupBoxBookedFor.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;

                dateTimeIssued.Enabled = true;
                dateTimeDue.Enabled = true;

                txtNotes.Enabled = true;
            }
            else if (e == "Student")
            {
                //comboBoxID.Enabled = true;
                txtAssignment.Enabled = true;
                txtCourse.Enabled = true;
                txtInstructor.Enabled = true;
            }
            else if (e == "Instructor")
            {
                //comboBoxID.Enabled = false;
                txtAssignment.Enabled = false;
                txtCourse.Enabled = false;
                txtInstructor.Enabled = false;
            }
            else if (e == "Staff")
            {
                //comboBoxID.Enabled = false;
                txtAssignment.Enabled = false;
                txtCourse.Enabled = false;
                txtInstructor.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid argument: " + e, "Error in UpdateEnabled()");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateEnabled("Edit");
        }

        private void listViewBooking_KeyDown(object sender, KeyEventArgs e)
        {
            // pressing DELETE after selecting an item removes it from the list
            if (e.KeyCode == Keys.Delete)
            {
                listViewBooking.SelectedItems[0].Remove();
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            myBooking.Notes = txtNotes.Text;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            myBooking.CurrentEnrolment.ID = "2";
            myBooking.CurrentInstructor.ID = "2";
            myBooking.CurrentStaff.ID = "2";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            myBooking.CurrentEnrolment.ID = "1";
            myBooking.CurrentInstructor.ID = "1";
            myBooking.CurrentStaff.ID = "1";
        }

        private void UpdateBookingDetails(string type)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                if (type == "Student")
                {
                    cmd.CommandText = "select HabibID from " + type + "s";
                }
                else if (type == "Instructor")
                {
                    cmd.CommandText = "select HabibID from " + type + "s";
                }
                else if (type == "Staff")
                {
                    cmd.CommandText = "select HabibID from " + type;
                }
                else
                {
                    MessageBox.Show("Invalid argument: " + type, "Error in UpdateBookingDetails");
                }

                comboBoxID.Items.Clear();
                comboBoxID.ResetText();

                txtName.Clear();
                txtContact.Clear();
                txtAssignment.Clear();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBoxID.Items.Add(rd["HabibID"]);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching Habib ID for " + type);
            }
            //MessageBox.Show("Press OK to continue","BookingDetails updated successfully");
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = -1;
            string habibID = "ab12345";
            string iD, name, email, contact;
            try
            {
                i = comboBoxID.SelectedIndex;
//habibID = comboBoxID.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in index selection");
                i = 0;

            }
            habibID = comboBoxID.Items[i].ToString();
//MessageBox.Show("Item = " + habibID, "Here");            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd;

                if (myBooking.BookedBy == "Student")
                {
                    cmd.CommandText = "select StudentID,HabibID,Name,Email,Contact from " +
                        "Students where HabibID = '" + habibID + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        iD = rd[0].ToString();
                        habibID = rd[1].ToString();
                        name = rd[2].ToString();
                        email = rd[3].ToString();
                        contact = rd[4].ToString();
                        myBooking.CurrentStudent = new Student(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.CurrentStudent = new Student();
                    }
                    txtName.Text = myBooking.CurrentStudent.Name;
                    txtContact.Text = myBooking.CurrentStudent.Contact;
                }
                else if (myBooking.BookedBy == "Instructor")
                {
                    cmd.CommandText = "select InstructorID,HabibID,Name,Email,Contact from " +
                        "Instructors where HabibID = '" + habibID + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        iD = rd[0].ToString();
                        habibID = rd[1].ToString();
                        name = rd[2].ToString();
                        email = rd[3].ToString();
                        contact = rd[4].ToString();
                        myBooking.CurrentInstructor = new Instructor(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.CurrentInstructor = new Instructor();
                    }
                    txtName.Text = myBooking.CurrentInstructor.Name;
                    txtContact.Text = myBooking.CurrentInstructor.Contact;
                }
                else if (myBooking.BookedBy == "Staff")
                {
                    cmd.CommandText = "select StaffID,HabibID,Name,Email,Contact from " +
                        "Staff where HabibID = '" + habibID + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        iD = rd[0].ToString();
                        habibID = rd[1].ToString();
                        name = rd[2].ToString();
                        email = rd[3].ToString();
                        contact = rd[4].ToString();
                        myBooking.CurrentStaff = new Staff(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.CurrentStaff = new Staff();
                    }
                    txtName.Text = myBooking.CurrentStaff.Name;
                    txtContact.Text = myBooking.CurrentStaff.Contact;
                }
                else
                {
                    MessageBox.Show("myBooking.BookedBy: " + myBooking.BookedBy, "Unexpected value in fetching details");
                    cmd.CommandText = "";
                    rd = cmd.ExecuteReader();
                }
                rd.Close();
                //MessageBox.Show(iD+name+email+contact,"Booking Details:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in fetching details");
            }
        }
    }
}
