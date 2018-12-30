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
                bookedBy: "Instructor"
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
            txtQuantity.Text = 12.ToString();
            rbtnInstructor.Select();
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            // check for duplication
            if (listViewBooking.FindItemWithText(txtEquipment.Text) == null)
            {
                // Adding values from text boxes to list view
                ListViewItem listViewItem = new ListViewItem(txtEquipment.Text);
                listViewItem.SubItems.Add(txtQuantity.Text);
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
                int qNew = Convert.ToInt32(txtQuantity.Text) + q;
                listViewItem.SubItems.Add(qNew.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            txtEquipment.Clear();
            txtQuantity.Clear();
            txtEquipment.Select();
        }

        private void txtEquipment_TextChanged(object sender, EventArgs e) => CheckEnableAdd();

        private void txtQuantity_TextChanged(object sender, EventArgs e) => CheckEnableAdd();

        private void CheckEnableAdd()
        {
            if (txtEquipment.TextLength == 0 || txtQuantity.TextLength == 0)
            {
                btnAddEquipment.Enabled = false;
            }
            else
            {
                btnAddEquipment.Enabled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

                MessageBox.Show("Booking ID is: " + myBooking.ID, "Booking Created");
                //btnAdd.Enabled = false;
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

                        MessageBox.Show("Record added succesfully", "Added to database");
                    }
                    else
                    {
                        MessageBox.Show("Record already exists!", "No need to add");
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

                        MessageBox.Show("Record added succesfully", "Added to database");
                    }
                    else
                    {
                        MessageBox.Show("Record already exists!", "No need to add");
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

                        MessageBox.Show("Record added succesfully", "Added to database");
                    }
                    else
                    {
                        MessageBox.Show("Record already exists!", "No need to add");
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
    }
}
