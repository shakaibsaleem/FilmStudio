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
                notes: "No Notes",
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
            txtAssignment.Text = "FYP";
            txtEquipment.Text = myEquipment.Description;
            numQuantity.Value = 1;
            rbtnStudent.Select();
            btnAdd.Select();
            UpdateEnabled("Load");
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
            // pressing RETURN after entering quantity add the item to list
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
            }
        }

        private void rbtnInstructor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInstructor.Checked)
            {
                myBooking.BookedBy = "Instructor";
            }
        }

        private void rbtnStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStaff.Checked)
            {
                myBooking.BookedBy = "Staff";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateBookedBy();
            UpdateEnabled("Save");
        }

        private void UpdateBookedBy()
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
                            myBooking.CurrentInstructor.InstructorID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Record updated succesfully", "Database Updated");
                    }
                    else
                    {
                        //MessageBox.Show("Record already exists!", "No need to update");
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
                            myBooking.CurrentEnrolment.EnrolmentID + "," + myBooking.ID + ",'" + txtAssignment.Text + "')";
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Record updated succesfully", "Database Updated");
                    }
                    else
                    {
                        //MessageBox.Show("Record already exists!", "No need to update");
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
                            myBooking.CurrentStaff.StaffID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Record updated succesfully", "Database Updated");
                    }
                    else
                    {
                        //MessageBox.Show("Record already exists!", "No need to update");
                    }
                    cmd.CommandText = "delete from BookingsByStudents where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from BookingsByInstructors where BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Unexpected value for BookedBy: " + myBooking.BookedBy, "Error in UpdateBookedBy()");
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in UpdateBookedBy()");
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
            }
            else if (e == "Add")
            {
                btnAdd.Enabled = false;
                btnSave.Enabled = true;

                groupBoxBookedFor.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;
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
            }
            else
            {
                MessageBox.Show("Incorrect value of e: " + e, "Error in UpdateEnabled()");
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
    }
}
