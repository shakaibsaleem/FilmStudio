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

using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace FilmStudio
{
    public partial class frmBooking : Form
    {
        public Booking myBooking;
        public Equipment myEquipment;
        mySQLcon myCon;
        SqlConnection con;
        string state;
        User CurrentUser;
        int indexEquipment;
        List<MyItem> myItems;

        public frmBooking(User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            CurrentUser = currentUser;
            myBooking = new Booking(CurrentUser);
            state = "Empty";
        }

        public frmBooking(string id, User currentUser)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            CurrentUser = currentUser;
            myBooking = new Booking(CurrentUser);
            LoadRecord(id);
            state = "View";
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            myEquipment = new Equipment();
            UpdateFields(state);
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            if (listViewBooking.Items.Count >= 9)
            {
                MessageBox.Show("You cannot add more items to this booking. Consider creating another booking for the remaining items.","Max capacity for items");
                return;
            }
            // check for duplication
            ListViewItem listViewItem = listViewBooking.FindItemWithText(myEquipment.Description);
            if (listViewItem == null)
            {
                // no duplicates
                // Adding values from text boxes to list view
                listViewItem = new ListViewItem(myEquipment.Description);
                listViewItem.SubItems.Add(numQuantity.Value.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            else if (listViewItem.SubItems[0].Text == myEquipment.Description)
            {
                // if item exists, update quantity instead of adding as a duplicate entry
                int i = listViewBooking.Items.IndexOf(listViewItem);
                ListViewItem.ListViewSubItem subItem = listViewBooking.Items[i].SubItems[1];
                int q = Convert.ToInt32(subItem.Text);
                listViewBooking.Items.RemoveAt(i);
                listViewItem = new ListViewItem(myEquipment.Description);
                int qNew = Convert.ToInt32(numQuantity.Value) + q;
                listViewItem.SubItems.Add(qNew.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            else
            {
                // only partial match, so not a duplicate
                // Adding values from text boxes to list view
                listViewItem = new ListViewItem(myEquipment.Description);
                listViewItem.SubItems.Add(numQuantity.Value.ToString());
                listViewBooking.Items.Add(listViewItem);
            }
            myEquipment.Description = "";
            txtAvailable.Text = "0";
            txtTotal.Clear();
            numQuantity.Value = 1;
            comboBoxEquipment.ResetText();
            comboBoxEquipment.Select();
            btnAddEquipment.Enabled = false;
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            btnAddEquipment.Enabled = Convert.ToInt32(numQuantity.Value) > 0 && (comboBoxEquipment.SelectedItem != null);
            if (numQuantity.Value > Convert.ToInt32(txtAvailable.Text))
            {
                btnAddEquipment.Enabled = false;
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
            if (state == "Empty")
            {
                Close();
                //DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                //    " Press Yes to add the record and then close. Press No to close without" +
                //    " adding.","Add record before closing?", MessageBoxButtons.YesNoCancel);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    btnAdd.PerformClick();
                //    Close();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    Close();
                //}
            }
            else if (state == "Add" || state == "Edit")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then close. Press No to close without" +
                    " saving.", "Save record before closing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
            else if (state == "View")
            {
                Close();
            }
            else
            {
                MessageBox.Show("State = " + state, "Unexpected value in btnClose");
            }
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
                    "(UserID,BookedBy,Notes,BookingDate,BookingTime,IssueDate," +
                    "IssueTime,DueDate,DueTime,OffCampus)values(" + myBooking.User.ID + ",'" +
                    myBooking.BookedBy + "','" + myBooking.Notes + "','" +
                    DateOf(myBooking.BookedOn) + "','" + TimeOf(myBooking.BookedOn) + "','" +
                    DateOf(myBooking.IssuedOn) + "','" + TimeOf(myBooking.IssuedOn) + "','" +
                    DateOf(myBooking.DueOn) + "','" + TimeOf(myBooking.DueOn) + "'," +
                    (myBooking.OffCampus ? "1" : "0") + ")";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select top 1 BookingID from Bookings order by BookingID desc";
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    myBooking.ID = rd[0].ToString();
                }
                rd.Close();
                tran.Commit();
                state = "Add";
                UpdateFields(state);
                UpdateComboBoxEquipment();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in btnAdd");
            }
        }

        private void rbtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStudent.Checked)
            {
                myBooking.BookedBy = "Student";
                UpdateFields("Student");
            }
        }

        private void rbtnInstructor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInstructor.Checked)
            {
                myBooking.BookedBy = "Instructor";
                UpdateFields("Instructor");
            }
        }

        private void rbtnStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStaff.Checked)
            {
                myBooking.BookedBy = "Staff";
                UpdateFields("Staff");
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
                            myBooking.Instructor.ID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();
                    }
                    else if (1 == i)
                    {
                        cmd.CommandText = "update BookingsByInstructors set InstructorID = " +
                            myBooking.Instructor.ID +
                            " where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "delete from BookingsByInstructors where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into BookingsByInstructors (InstructorID,BookingID) values (" +
                            myBooking.Instructor.ID + "," + myBooking.ID + ")";
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
                            myBooking.Enrolment.ID + "," + myBooking.ID + ",'" + txtAssignment.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (1 == i)
                    {
                        cmd.CommandText = "update BookingsByStudents set EnrolmentID = " +
                            myBooking.Enrolment.ID + ",Project = '" + txtAssignment.Text +
                            "' where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "delete from BookingsByStudents where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into BookingsByStudents (EnrolmentID,BookingID,Project) values (" +
                            myBooking.Enrolment.ID + "," + myBooking.ID + ",'" + txtAssignment.Text + "')";
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
                            myBooking.Staff.ID + "," + myBooking.ID + ")";
                        cmd.ExecuteNonQuery();
                    }
                    else if (1 == i)
                    {
                        cmd.CommandText = "update BookingsByStaff set StaffID = " +
                            myBooking.Staff.ID +
                            " where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "delete from BookingsByStaff where BookingID = " + myBooking.ID;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into BookingsByStaff (StaffID,BookingID) values (" +
                            myBooking.Staff.ID + "," + myBooking.ID + ")";
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

                cmd.CommandText = "update Bookings set " +
                    "   UserID = " + myBooking.User.ID +
                    " , OffCampus=" + (myBooking.OffCampus ? "1" : "0") +
                    " , Notes = '" + myBooking.Notes +
                    "', BookedBy = '" + myBooking.BookedBy +
                    "', BookingDate = '" + DateOf(myBooking.BookedOn) +
                    "', BookingTime = '" + TimeOf(myBooking.BookedOn) +
                    "', IssueDate = '" + DateOf(myBooking.IssuedOn) +
                    "', IssueTime = '" + TimeOf(myBooking.IssuedOn) +
                    "', DueDate = '" + DateOf(myBooking.DueOn) +
                    "', DueTime = '" + TimeOf(myBooking.DueOn) +
                    "'  where BookingID = " + myBooking.ID;
                cmd.ExecuteNonQuery();
                if (myBooking.Returned)
                {
                    cmd.CommandText = "update Bookings set " +
                        "ReturnDate = '" + DateOf(myBooking.ReturnedOn) +
                        "', ReturnTime = '" + TimeOf(myBooking.ReturnedOn) +
                        "' where BookingID = " + myBooking.ID;
                }
                else
                {
                    cmd.CommandText = "update Bookings set ReturnDate = NULL" +
                        ",ReturnTime = NULL where BookingID = " + myBooking.ID;
                }
                cmd.ExecuteNonQuery();

                string myDescription, myItemID;
                int myQuantity, oldQuantity, qtyTotal;
                SqlDataReader rd;
                List<string> myList = new List<string>();

                foreach (ListViewItem item in listViewBooking.Items)
                {
                    myDescription = item.SubItems[0].Text;
                    myQuantity = Convert.ToInt32(item.SubItems[1].Text);

                    cmd.CommandText = "select EquipmentID,QuantityTotal from " +
                        "Equipments where Description = '" + myDescription + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myItemID = rd[0].ToString();
                        qtyTotal = Convert.ToInt32(rd[1].ToString());
                        myList.Add(myItemID);
                    }
                    else
                    {
                        MessageBox.Show("Invalid value of description: " + myDescription, "Error in fetching equipment details");
                        myItemID = "1";
                        qtyTotal = 0;
                    }
                    rd.Close();

                    cmd.CommandText = "select QuantityBooked from BookedItems where " +
                        "BookingID = " + myBooking.ID + " and EquipmentID = " + myItemID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        oldQuantity = Convert.ToInt32(rd[0].ToString());
                        rd.Close();
                        cmd.CommandText = "update BookedItems set QuantityBooked = " + myQuantity +
                            " where BookingID = " + myBooking.ID + " and EquipmentID = " + myItemID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        oldQuantity = 0;
                        rd.Close();
                        cmd.CommandText = "insert into BookedItems (BookingID,EquipmentID,QuantityBooked) values " +
                            "(" + myBooking.ID + ", " + myItemID + ", " + myQuantity + ")";
                        cmd.ExecuteNonQuery();
                    }

                    //cmd.CommandText = "update Equipments set " +
                    //    "QuantityBooked = " + (qtyBooked + (myQuantity-oldQuantity)) +
                    //    ", QuantityAvailable = " + (qtyAvailable - (myQuantity - oldQuantity)) +
                    //    " where EquipmentID = " + myItemID;
                    //cmd.ExecuteNonQuery();
                }

                List<string> toDelete = new List<string>();
                myItemID = "";

                cmd.CommandText = "select EquipmentID from BookedItems where BookingID = " + myBooking.ID;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    myItemID = rd[0].ToString();
                    if (myList.Contains(myItemID) == false)
                    {
                        toDelete.Add(myItemID);
                    }
                }
                rd.Close();

                foreach (string id in toDelete)
                {
                    //cmd.CommandText = "select Quantity,QuantityAvailable,QuantityBooked " +
                    //    "from BookedItems,Equipments where BookingID = " +
                    //    myBooking.ID + " and BookedItems.EquipmentID = " + id +
                    //    " and BookedItems.EquipmentID = Equipments.EquipmentID";
                    //rd = cmd.ExecuteReader();

                    //if (rd.Read() == true)
                    //{
                    //    oldQuantity = Convert.ToInt32(rd[0].ToString());
                    //    qtyAvailable = Convert.ToInt32(rd[1].ToString());
                    //    qtyBooked = Convert.ToInt32(rd[2].ToString());
                    //    rd.Close();

                    //    cmd.CommandText = "update Equipments set " +
                    //    "QuantityBooked = " + (qtyBooked - oldQuantity) +
                    //    ", QuantityAvailable = " + (qtyAvailable + oldQuantity) +
                    //    " where EquipmentID = " + id;
                    //    cmd.ExecuteNonQuery();
                    //}
                    //rd.Close();
                    cmd.CommandText = "delete from BookedItems where EquipmentID = "
                        + id + " and BookingID = " + myBooking.ID;
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                state = "View";
                UpdateFields(state);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in Save");
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to send email" +
                " confirming the booking?", "Send email?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                /*EmailHandler email = new EmailHandler();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select top 1 Username,Passkey from EmailAccount";
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    email.User = rd[0].ToString();
                    email.Passkey = rd[1].ToString();
                    rd.Close();
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("No valid account found", "Email not sent");
                    return;
                }
                MessageBox.Show("Sending email from: " + email.User + "\nPlease wait a few seconds after closing this message.", "Email sending");
                */
                string subject = "Film Studio Booking Confirmation";
                string body = "Dear " + txtName.Text + ",\n" +
                    "\n" +
                    "This is a confirmation of your booking on the following date/time.\n" +
                    "\n" +
                    "Issue Date: " + myBooking.IssuedOn.ToString("dddd dd-MM-yyyy") + "\n" +
                    "Due On: " + myBooking.DueOn.ToString("hh:mm tt dddd dd-MM-yyyy") + "\n" +
                    "Off Campus: " + (myBooking.OffCampus ? "Yes" : "No") + "\n" +
                    "\n" +
                    "Equipment Details:\n";
                foreach (ListViewItem item in listViewBooking.Items)
                {
                    body = body + item.SubItems[0].Text + ", Quantity = " + item.SubItems[1].Text + "\n";
                }

                body = body + "\n" +
                    "Note:\n" +
                    "\n" +
                    "1. Please check all equipment is functional before checking it out of the Studio.\n" +
                    "\n" +
                    "2. Kindly make sure all batteries are charged and the data from sd cards is copied before the equipment is returned.\n" +
                    "\n" +
                    "3. Kindly ensure timely return of the above mentioned equipment, failure to do so may result in a penalty.\n" +
                    "\n" +
                    "\n" +
                    "Film Studio Management\n" +
                    "\n" +
                    "This is a system generated email. Please do not reply to this email.\n";

                string recipient = "";
                bool isSent = false;

                if (myBooking.BookedBy == "Instructor")
                {
                    recipient = myBooking.Instructor.Email;
                    //isSent = email.Send(recipient: recipient, subject: subject, body: body);
                }
                else if (myBooking.BookedBy == "Student")
                {
                    recipient = myBooking.Student.Email;
                    //isSent = email.Send(recipient: recipient, subject: subject, body: body);
                }
                else if (myBooking.BookedBy == "Staff")
                {
                    recipient = myBooking.Staff.Email;
                    //isSent = email.Send(recipient: recipient, subject: subject, body: body);
                }

                if (isSent)
                {
                    MessageBox.Show("Booking confirmation has been emailed successfully.", "Email sent");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Please send email manually!",
                        "Email could NOT be sent.", MessageBoxButtons.OKCancel);
                    /*\n\nTo: " + recipient +
                        "\nSubject: " + subject + "\n\n" + body,
                        "Error sending email");*/
                    if (dr == DialogResult.OK)
                    {
                        EmailManual frm = new EmailManual();
                        frm.to = recipient;
                        frm.subject = subject;
                        frm.body = body;
                        frm.Show();
                    }
                }
            }
        }

        private void dateTimeIssued_ValueChanged(object sender, EventArgs e)
        {
            myBooking.IssuedOn = dateTimeIssued.Value;
            UpdateComboBoxEquipment();
        }

        private void dateTimeDue_ValueChanged(object sender, EventArgs e)
        {
            myBooking.DueOn = dateTimeDue.Value;
            UpdateComboBoxEquipment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            state = "Edit";
            UpdateFields(state);
            UpdateComboBoxEquipment();
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
            if (state == "Empty")
            {
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then go to next record. Press No to go to next record without" +
                    " adding.", "Add record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    AdvanceTo("NextRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("NextRecord", myBooking.ID);
                }
            }
            else if (state == "Add" || state == "Edit")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then go to next record. Press No to go to next record without" +
                    " saving.", "Save record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    AdvanceTo("NextRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("NextRecord", myBooking.ID);
                }
            }
            else if (state == "View")
            {
                AdvanceTo("NextRecord", myBooking.ID);
            }
            else
            {
                MessageBox.Show("State = " + state, "Unexpected value in btnNext");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (state == "Empty")
            {
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then go to previous record. Press No to go to previous record without" +
                    " adding.", "Add record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    AdvanceTo("PrevRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("PrevRecord", myBooking.ID);
                }
            }
            else if (state == "Add" || state == "Edit")
            {
                DialogResult dialogResult = MessageBox.Show("There may be unsaved changes to the record." +
                    " Press Yes to save the record and then go to previous record. Press No to go to previous record without" +
                    " saving.", "Save record before advancing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    AdvanceTo("PrevRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    AdvanceTo("PrevRecord", myBooking.ID);
                }
            }
            else if (state == "View")
            {
                AdvanceTo("PrevRecord", myBooking.ID);
            }
            else
            {
                MessageBox.Show("State = ", "Unexpected value in btnPrevious");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                //delete from booked items
                cmd.CommandText = "delete from BookedItems where BookingID = " + myBooking.ID;
                cmd.ExecuteNonQuery();

                //delete from booked by
                cmd.CommandText = "";
                if (myBooking.BookedBy == "Student")
                {
                    cmd.CommandText = "delete from BookingsByStudents where BookingID = " + myBooking.ID;
                }
                else if (myBooking.BookedBy == "Instructor")
                {
                    cmd.CommandText = "delete from BookingsByInstructors where BookingID = " + myBooking.ID;
                }
                else if (myBooking.BookedBy == "Staff")
                {
                    cmd.CommandText = "delete from BookingsByStaff where BookingID = " + myBooking.ID;
                }
                else
                {
                    MessageBox.Show("Invalid value: " + myBooking.BookedBy, "Error in UpdateBookingDetails");
                }
                cmd.ExecuteNonQuery();

                //delete from bookings
                cmd.CommandText = "delete from Bookings where BookingID = " + myBooking.ID;
                cmd.ExecuteNonQuery();

                tran.Commit();
                Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myItems = new List<MyItem>();
            string myDesc = "";
            int myQuantity = 0;

            int c = listViewBooking.Items.Count;
            for (int i = 0; i < c; i++)
            {
                ListViewItem item = listViewBooking.Items[i];

                //ListViewItem.ListViewSubItemCollection col = item.SubItems;
                //string d = col[0].Text;
                //string q = col[1].Text;
                //int qty = Convert.ToInt32(q);

                myDesc = item.SubItems[0].Text.ToString();
                myQuantity = Convert.ToInt32(item.SubItems[1].Text.ToString());

                myItems.Add(new MyItem(myDesc, myQuantity));
                //myBooking.Equipments.Add(new Equipment(myQuantity, myDesc));
            }

            frmReportBooking frm = new frmReportBooking(myBooking, myItems);
            frm.ShowDialog();

            //PrintDocument printDocument = new PrintDocument();
            //printDocument.PrintPage += new PrintPageEventHandler(PrintImage);

            //PrintDialog printDialog = new PrintDialog();
            //printDialog.AllowSomePages = true;
            //printDialog.ShowHelp = true;
            //printDialog.Document = printDocument;
            //DialogResult result = printDialog.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    //printDocument.Print();
            //    //MessageBox.Show("Printed");
            //}
        }

        public void PrintImage(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = -1;
            string habibID = "ab12345";
            string iD, name, email, contact;
            try
            {
                i = comboBoxID.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in index selection");
                i = 0;
            }
            habibID = comboBoxID.Items[i].ToString();

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
                        myBooking.Student = new Student(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.Student = new Student();
                    }
                    rd.Close();
                    txtHabibID.Text = myBooking.Student.HabibID;
                    txtName.Text = myBooking.Student.Name;
                    txtContact.Text = myBooking.Student.Contact;

                    btnSave.Enabled = false;

                    comboBoxCourse.Items.Clear();
                    comboBoxCourse.ResetText();
                    comboBoxInstructor.Items.Clear();
                    comboBoxInstructor.ResetText();

                    //fetching and displaying courses of selected student
                    cmd.CommandText = "select distinct CourseName from Courses, Enrolments " +
                        "where Courses.CourseID=Enrolments.CourseID and StudentID = " +
                        myBooking.Student.ID;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBoxCourse.Items.Add(rd["CourseName"]);
                    }
                    rd.Close();
                    int width = comboBoxCourse.DropDownWidth;
                    int maxWidth = DropDownWidth(comboBoxCourse);
                    if (maxWidth > width)
                    {
                        comboBoxCourse.DropDownWidth = maxWidth;
                    }
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
                        myBooking.Instructor = new Instructor(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.Instructor = new Instructor();
                    }
                    rd.Close();
                    txtHabibID.Text = myBooking.Instructor.HabibID;
                    txtName.Text = myBooking.Instructor.Name;
                    txtContact.Text = myBooking.Instructor.Contact;
                    btnSave.Enabled = true;
                    //btnSave.Select();
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
                        myBooking.Staff = new Staff(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.Staff = new Staff();
                    }
                    rd.Close();
                    txtHabibID.Text = myBooking.Staff.HabibID;
                    txtName.Text = myBooking.Staff.Name;
                    txtContact.Text = myBooking.Staff.Contact;
                    btnSave.Enabled = true;
                    //btnSave.Select();
                }
                else
                {
                    MessageBox.Show("myBooking.BookedBy: " + myBooking.BookedBy, "Unexpected value in fetching details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in fetching courses");
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = -1;
            string iD, name, code;
            try
            {
                i = comboBoxCourse.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in index selection");
                i = 0;
            }
            name = comboBoxCourse.Items[i].ToString();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd;

                cmd.CommandText = "select CourseID,CourseName,CourseCode from " +
                    "Courses where CourseName = '" + name + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    iD = rd[0].ToString();
                    name = rd[1].ToString();
                    code = rd[2].ToString();
                    myBooking.Course = new Course(iD, name, code);
                }
                else
                {
                    myBooking.Course = new Course();
                }
                rd.Close();
                txtCourse.Text = myBooking.Course.CourseName;
                btnSave.Enabled = false;
                comboBoxInstructor.Items.Clear();
                comboBoxInstructor.ResetText();

                //fetching and displaying Instructor of student's selected course
                cmd.CommandText = "select distinct Instructors.Name from Courses, Enrolments, Instructors " +
                    "where Courses.CourseID = Enrolments.CourseID and " +
                    "Instructors.InstructorID = Enrolments.InstructorID and " +
                    "StudentID = " + myBooking.Student.ID +
                    " and Enrolments.CourseID = " + myBooking.Course.ID;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBoxInstructor.Items.Add(rd["Name"]);
                }
                rd.Close();
                int width = comboBoxInstructor.DropDownWidth;
                int maxWidth = DropDownWidth(comboBoxInstructor);
                if (maxWidth > width)
                {
                    comboBoxInstructor.DropDownWidth = maxWidth;
                }
                comboBoxInstructor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in fetching Instructors");
            }
        }

        private void comboBoxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = -1;
            string iD,habibID,name,email,contact;
            try
            {
                i = comboBoxInstructor.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in index selection");
                i = 0;
            }
            name = comboBoxInstructor.Items[i].ToString();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd;

                cmd.CommandText = "select InstructorID,HabibID,Name,Email,Contact from " +
                    "Instructors where Name = '" + name + "'";
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    iD = rd[0].ToString();
                    habibID = rd[1].ToString();
                    name =  rd[2].ToString();
                    email = rd[3].ToString();
                    contact = rd[4].ToString();
                    //MessageBox.Show(iD + habibID + name + email + contact, "Instructor Details:");
                    myBooking.Instructor = new Instructor(iD, habibID, name, email,contact);
                }
                else
                {
                    myBooking.Instructor = new Instructor();
                }
                rd.Close();
                txtInstructor.Text = myBooking.Instructor.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in fetching details of Instructor");
            }

            // fetching details of corresponding enrolment
            List<Enrolment> enrolments = new List<Enrolment>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd;

                cmd.CommandText = "select EnrolmentID,Term from Enrolments " +
                    "where CourseID = " + myBooking.Course.ID +
                    " and StudentID = " + myBooking.Student.ID +
                    " and InstructorID = " + myBooking.Instructor.ID;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    enrolments.Add(new Enrolment(
                        rd["EnrolmentID"].ToString(), 
                        myBooking.Student, 
                        myBooking.Course, 
                        myBooking.Instructor, 
                        rd["Term"].ToString()
                        ));
                }
                rd.Close();

                if (enrolments.Count == 1)
                {
                    myBooking.Enrolment = enrolments[0];
                    btnSave.Enabled = true;
                }
                else if (enrolments.Count == 0)
                {
                    MessageBox.Show("No enrolment records found", "Error in fetching enrolments");
                }
                else
                {
                    myBooking.Enrolment = enrolments.Last<Enrolment>();
                    btnSave.Enabled = true;
                    btnSave.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in fetching enrolments");
            }
        }

        private void comboBoxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEquipment.SelectedItem != null)
            {
                indexEquipment = comboBoxEquipment.SelectedIndex;
                Equipment eq = (Equipment)comboBoxEquipment.SelectedItem;
                myEquipment.ID = eq.ID;
                myEquipment.Description = eq.Description;
                myEquipment.QuantityTotal = eq.QuantityTotal;
                myEquipment.QuantityAvailable = eq.QuantityAvailable;
                myEquipment.Remarks = eq.Remarks;

                txtAvailable.Text = eq.QuantityAvailable.ToString();
                txtTotal.Text = eq.QuantityTotal.ToString();

                btnAddEquipment.Enabled = comboBoxEquipment.SelectedIndex >= 0;
                if (numQuantity.Value > Convert.ToInt32(txtAvailable.Text))
                {
                    btnAddEquipment.Enabled = false;
                }
            }
            else
            {
                btnAddEquipment.Enabled = false;
            }
        }

        private void checkBoxReturned_CheckedChanged(object sender, EventArgs e)
        {
            myBooking.Returned = checkBoxReturned.Checked;
            dateTimeReturned.Visible = checkBoxReturned.Checked;

            if (checkBoxReturned.Checked)
            {
                dateTimeReturned.Value = DateTime.Now;
            }
        }

        private void dateTimeReturned_ValueChanged(object sender, EventArgs e)
        {
            myBooking.ReturnedOn = dateTimeReturned.Value;
        }

        private void checkBoxOffCampus_CheckedChanged(object sender, EventArgs e)
        {
            myBooking.OffCampus = checkBoxOffCampus.Checked;
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
                    cmd.CommandText = "select HabibID from " + type + "s order by HabibID";
                }
                else if (type == "Instructor")
                {
                    cmd.CommandText = "select HabibID from " + type + "s order by HabibID";
                }
                else if (type == "Staff")
                {
                    cmd.CommandText = "select HabibID from " + type + " order by HabibID";
                }
                else
                {
                    MessageBox.Show("Invalid argument: " + type, "Error in UpdateBookingDetails");
                }

                comboBoxID.Items.Clear();
                comboBoxID.ResetText();
                txtHabibID.Clear();
                comboBoxCourse.Items.Clear();
                comboBoxCourse.ResetText();
                txtCourse.Clear();
                comboBoxInstructor.Items.Clear();
                comboBoxInstructor.ResetText();
                txtInstructor.Clear();

                txtName.Clear();
                txtContact.Clear();
                txtAssignment.Clear();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBoxID.Items.Add(rd["HabibID"]);
                }
                rd.Close();

                int width = comboBoxID.DropDownWidth;
                int maxWidth = DropDownWidth(comboBoxID);
                if (maxWidth > width)
                {
                    comboBoxID.DropDownWidth = maxWidth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching Habib ID for " + type);
            }
            //MessageBox.Show("Press OK to continue","BookingDetails updated successfully");
        }

        private void UpdateFields(string s)
        {
            if (s == "View")
            {
                btnAddEquipment.Enabled = false;
                btnClose.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;

                btnPrint.Visible = true;
                btnPrint.Enabled = true;
                btnAdd.Visible = false;
                btnAdd.Enabled = false;

                //groupBoxBookedBy.Enabled = false;
                rbtnInstructor.AutoCheck = false;
                rbtnStaff.AutoCheck = false;
                rbtnStudent.AutoCheck = false;

                //groupBoxBooking.Enabled = false;
                txtHabibID.Visible = true;
                comboBoxID.Visible = false;
                txtInstructor.Visible = true;
                comboBoxInstructor.Visible = false;
                txtCourse.Visible = true;
                comboBoxCourse.Visible = false;

                groupBoxEquipment.Enabled = false;

                dateTimeIssued.Enabled = false;
                dateTimeDue.Enabled = false;

                txtNotes.ReadOnly = true;
                txtAssignment.ReadOnly = true;

                listViewBooking.Enabled = false;

                checkBoxOffCampus.AutoCheck = false;
                checkBoxReturned.AutoCheck = false;
                checkBoxReturned.Enabled = true;
                dateTimeReturned.Visible = checkBoxReturned.Checked;
                dateTimeReturned.Enabled = false;
            }
            else if (s == "Empty")
            {
                btnPrint.Visible = false;
                btnPrint.Enabled = false;
                btnAdd.Visible = true;
                btnAdd.Enabled = true;

                btnAddEquipment.Enabled = false;
                btnClose.Enabled = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSave.Enabled = false;
                groupBoxBookedBy.Enabled = true;
                groupBoxBooking.Enabled = false;
                groupBoxEquipment.Enabled = false;
                listViewBooking.Enabled = false;
                txtNotes.Enabled = false;

                dateTimeDue.Value = myBooking.DueOn;
                dateTimeIssued.Value = myBooking.IssuedOn;
                numQuantity.Value = 1;
                rbtnStudent.Checked = true;

                btnAdd.Select();
            }
            else if (s == "Add")
            {
                btnAdd.Visible = false;
                btnAdd.Enabled = false;
                btnPrint.Visible = true;
                btnPrint.Enabled = false;

                btnAddEquipment.Enabled = false;
                btnClose.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSave.Enabled = false;
                groupBoxBookedBy.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;
                listViewBooking.Enabled = true;
                txtNotes.Enabled = true;

                checkBoxReturned.Enabled = true;

                comboBoxID.Focus();
            }
            else if (s == "Edit")
            {
                btnPrint.Visible = true;
                btnPrint.Enabled = false;
                btnAdd.Visible = false;
                btnAdd.Enabled = false;

                btnAddEquipment.Enabled = false;
                btnClose.Enabled = true;
                btnEdit.Enabled = false;
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;

                //groupBoxBookedBy.Enabled = true;
                rbtnInstructor.AutoCheck = true;
                rbtnStaff.AutoCheck = true;
                rbtnStudent.AutoCheck = true;

                //groupBoxBooking.Enabled = true;
                txtHabibID.Visible = false;
                comboBoxID.Visible = true;
                txtInstructor.Visible = false;
                comboBoxInstructor.Visible = true;
                txtCourse.Visible = false;
                comboBoxCourse.Visible = true;

                groupBoxEquipment.Enabled = true;

                dateTimeIssued.Enabled = true;
                dateTimeDue.Enabled = true;

                txtNotes.ReadOnly = false;
                txtAssignment.ReadOnly = false;

                listViewBooking.Enabled = true;

                checkBoxOffCampus.AutoCheck = true;
                checkBoxReturned.AutoCheck = true;
                checkBoxReturned.Enabled = true;
                dateTimeReturned.Visible = checkBoxReturned.Checked;
                dateTimeReturned.Enabled = true;
            }
            else if (s == "Student")
            {
                btnSave.Enabled = false;
                txtAssignment.Enabled = true;
                comboBoxCourse.Enabled = true;
                txtCourse.Enabled = true;
                comboBoxInstructor.Enabled = true;
                txtInstructor.Enabled = true;
                UpdateBookingDetails("Student");
            }
            else if (s == "Instructor")
            {
                btnSave.Enabled = false;
                txtAssignment.Enabled = false;
                comboBoxCourse.Enabled = false;
                txtCourse.Enabled = false;
                comboBoxInstructor.Enabled = false;
                txtInstructor.Enabled = false;
                UpdateBookingDetails("Instructor");
            }
            else if (s == "Staff")
            {
                btnSave.Enabled = false;
                txtAssignment.Enabled = false;
                comboBoxCourse.Enabled = false;
                txtCourse.Enabled = false;
                comboBoxInstructor.Enabled = false;
                txtInstructor.Enabled = false;
                UpdateBookingDetails("Staff");
            }
            else
            {
                MessageBox.Show("Invalid argument: " + s, "Error in UpdateFields()");
            }
        }

        public void AdvanceTo(string record, string id)
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            try
            {
                if (record == "NextRecord")
                {
                    cmd.CommandText = "select * from (select lead(BookingID) over " +
                        "(order by BookingID) NextValue, BookingID from Bookings) as " +
                        "NewTable where NewTable.BookingID = " + id;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        id = rd[0].ToString();
                        if (id == "")
                        {
                            MessageBox.Show("The last available record is currently loaded", "No next record");
                            rd.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Next record not found");
                    }
                    rd.Close();
                }
                else if (record == "PrevRecord")
                {
                    cmd.CommandText = "select * from (select lag(BookingID) over " +
                        "(order by BookingID) PrevValue, BookingID from Bookings) as " +
                        "NewTable where NewTable.BookingID = " + id;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        id = rd[0].ToString();
                        if (id == "")
                        {
                            MessageBox.Show("The first available record is currently loaded", "No previous record");
                            rd.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Previous record not found");
                    }
                    rd.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect value for record: " + record, "Error in AdvanceTo()");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in AdvanceTo()");
            }
            LoadRecord(id: id);
        }

        public void LoadRecord(string id)
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            string str1, str2;
            ListViewItem item;

            try
            {
                cmd.CommandText = "select UserID,Notes,BookedBy,BookingDate,BookingTime," +
                    "IssueDate,IssueTime,DueDate,DueTime,OffCampus,ReturnDate,ReturnTime" +
                    " from Bookings where BookingID = " + id;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    myBooking.ID = id;
                    myBooking.User.ID = rd[0].ToString();
                    myBooking.Notes = rd[1].ToString();
                    myBooking.BookedBy = rd[2].ToString();

                    str1 = rd[3].ToString();
                    str2 = rd[4].ToString();
                    myBooking.BookedOn = DateTimeOf(date: str1, time: str2);

                    if (!rd.IsDBNull(5) && !rd.IsDBNull(6))
                    {
                        str1 = rd[5].ToString();
                        str2 = rd[6].ToString();
                        myBooking.IssuedOn = DateTimeOf(date: str1, time: str2);
                    }
                    else
                    {
                        MessageBox.Show("Please update Issue Date and Time");
                    }

                    str1 = rd[7].ToString();
                    str2 = rd[8].ToString();
                    myBooking.DueOn = DateTimeOf(date: str1, time: str2);
                    myBooking.OffCampus = rd[9].ToString() == "True";

                    str1 = rd[10].ToString();
                    str2 = rd[11].ToString();
                    if (!rd.IsDBNull(10) && !rd.IsDBNull(11))
                    {
                        myBooking.ReturnedOn = DateTimeOf(date: str1, time: str2);
                        myBooking.Returned = true;
                    }
                    else if (rd.IsDBNull(10) && rd.IsDBNull(11))
                    {
                        myBooking.Returned = false;
                    }
                    else
                    {
                        myBooking.Returned = false;
                        MessageBox.Show(
                            "Unexpected value encountered:" + "\n" +
                            "ReturnDate = " + str1 + "\n" +
                            "ReturnTime = " + str2 + "\n" +
                            "where BookingID = " + myBooking.ID, "Error in LoadRecord()");
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in LoadRecord()");
                return;
            }

            dateTimeIssued.Value = myBooking.IssuedOn;
            dateTimeDue.Value = myBooking.DueOn;
            txtNotes.Text = myBooking.Notes;
            checkBoxOffCampus.Checked = myBooking.OffCampus;
            checkBoxReturned.Checked = myBooking.Returned;

            UpdateBookingDetails(myBooking.BookedBy);

            try
            {
                if (myBooking.BookedBy == "Student")
                {
                    rbtnStudent.Checked = true;
                    rbtnInstructor.Checked = false;
                    rbtnStaff.Checked = false;

                    cmd.CommandText = "select Enrolments.EnrolmentID,Project,Term," +
                        "Students.StudentID,Students.HabibID,Students.Name,Students.Email," +
                        "Students.Contact,Courses.CourseID,Courses.CourseName," +
                        "Courses.CourseCode,Instructors.InstructorID,Instructors.HabibID," +
                        "Instructors.Name,Instructors.Email,Instructors.Contact from " +
                        "BookingsByStudents, Enrolments, Students, Courses, Instructors " +
                        "where BookingsByStudents.BookingID = " + myBooking.ID +
                        " and BookingsByStudents.EnrolmentID = Enrolments.EnrolmentID " +
                        "and Enrolments.StudentID = Students.StudentID and Enrolments.CourseID " +
                        "= Courses.CourseID and Enrolments.InstructorID = Instructors.InstructorID";
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        myBooking.Enrolment.ID = rd[0].ToString();
                        myBooking.Project = rd[1].ToString();
                        myBooking.Enrolment.Term = rd[2].ToString();
                        myBooking.Student.ID = rd[3].ToString();
                        myBooking.Student.HabibID = rd[4].ToString();
                        myBooking.Student.Name = rd[5].ToString();
                        myBooking.Student.Email = rd[6].ToString();
                        myBooking.Student.Contact = rd[7].ToString();
                        myBooking.Course.ID = rd[8].ToString();
                        myBooking.Course.CourseName = rd[9].ToString();
                        myBooking.Course.CourseCode = rd[10].ToString();
                        myBooking.Instructor.ID = rd[11].ToString();
                        myBooking.Instructor.HabibID = rd[12].ToString();
                        myBooking.Instructor.Name = rd[13].ToString();
                        myBooking.Instructor.Email = rd[14].ToString();
                        myBooking.Instructor.Contact = rd[15].ToString();
                    }
                    rd.Close();
                    txtAssignment.Text = myBooking.Project;
                    txtContact.Text = myBooking.Student.Contact;
                    txtCourse.Text = myBooking.Course.CourseName;
                    txtHabibID.Text = myBooking.Student.HabibID;
                    txtInstructor.Text = myBooking.Instructor.Name;
                    txtName.Text = myBooking.Student.Name;
                    comboBoxID.SelectedItem = txtHabibID.Text;
                    comboBoxCourse.SelectedItem = txtCourse.Text;
                    comboBoxInstructor.SelectedItem = txtInstructor.Text;
                }
                else if (myBooking.BookedBy == "Instructor")
                {
                    rbtnInstructor.Checked = true;
                    rbtnStaff.Checked = false;
                    rbtnStudent.Checked = false;

                    cmd.CommandText = "select InstructorID from BookingsByInstructors where BookingID = " + myBooking.ID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        myBooking.Instructor.ID = rd[0].ToString();
                    }
                    rd.Close();

                    cmd.CommandText = "select HabibID,Name,Email,Contact from Instructors where InstructorID = " + myBooking.Instructor.ID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        myBooking.Instructor.HabibID = rd[0].ToString();
                        myBooking.Instructor.Name = rd[1].ToString();
                        myBooking.Instructor.Email = rd[2].ToString();
                        myBooking.Instructor.Contact = rd[3].ToString();
                    }
                    rd.Close();
                    txtHabibID.Text = myBooking.Instructor.HabibID;
                    txtName.Text = myBooking.Instructor.Name;
                    txtContact.Text = myBooking.Instructor.Contact;
                    comboBoxID.SelectedItem = txtHabibID.Text;
                }
                else if (myBooking.BookedBy == "Staff")
                {
                    rbtnStaff.Checked = true;
                    rbtnStudent.Checked = false;
                    rbtnInstructor.Checked = false;

                    cmd.CommandText = "select StaffID from BookingsByStaff where BookingID = " + myBooking.ID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        myBooking.Staff.ID = rd[0].ToString();
                    }
                    rd.Close();

                    cmd.CommandText = "select HabibID,Name,Email,Contact from Staff where StaffID = " + myBooking.Staff.ID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        myBooking.Staff.HabibID = rd[0].ToString();
                        myBooking.Staff.Name = rd[1].ToString();
                        myBooking.Staff.Email = rd[2].ToString();
                        myBooking.Staff.Contact = rd[3].ToString();
                    }
                    rd.Close();
                    txtHabibID.Text = myBooking.Staff.HabibID;
                    txtName.Text = myBooking.Staff.Name;
                    txtContact.Text = myBooking.Staff.Contact;
                    comboBoxID.SelectedItem = txtHabibID.Text;
                }
                else
                {
                    MessageBox.Show("Invalid value of myBooking.BookedBy: " + myBooking.BookedBy, "Error in LoadRecord()");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Load Record()");
            }

            try
            {
                listViewBooking.Items.Clear();
                cmd.CommandText = "select Description,QuantityBooked from BookedItems,Equipments" +
                    " where BookedItems.EquipmentID=Equipments.EquipmentID " +
                    "and BookingID = " + myBooking.ID + " order by Description";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    str1 = rd[0].ToString();
                    str2 = rd[1].ToString();
                    item = new ListViewItem(str1);
                    item.SubItems.Add(str2);
                    listViewBooking.Items.Add(item);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Load Record()");
            }
        }

        public void UpdateComboBoxEquipment()
        {
            Equipment eq;
            string desc = "";
            string id = "";
            string remarks = "";
            int qtyTotal,qtyAvail;

            try
            {
                int i;
                try
                {
                    if (comboBoxEquipment.SelectedItem != null)
                    {
                        i = comboBoxEquipment.SelectedIndex;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                catch (Exception)
                {
                    i = 0;
                }
                comboBoxEquipment.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select EquipmentID,Description,QuantityTotal," +
                    "Remarks from Equipments order by Description";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    id = rd[0].ToString();
                    desc = rd[1].ToString();
                    qtyTotal = Convert.ToInt32(rd[2].ToString());
                    remarks = rd[3].ToString();
                    qtyAvail = GetAvailableQty(id, qtyTotal, myBooking.IssuedOn, myBooking.DueOn);
                    //qtyA = Convert.ToInt32(rd[2].ToString());
                    //qtyB = Convert.ToInt32(rd[1].ToString());
                    //d = rd[0].ToString();
                    //if (d == "Nikon D3200")
                    //{
                    //qtyA = GetAvailableQty(id, 4, myBooking.IssuedOn, myBooking.DueOn);
                    //}
                    eq = new Equipment(iD: id, description: desc, quantityTotal: qtyTotal, quantityAvail: qtyAvail, remarks: remarks);
                    comboBoxEquipment.Items.Add(eq);
                }
                rd.Close();

                int width = comboBoxEquipment.DropDownWidth;
                int maxWidth = DropDownWidth(comboBoxEquipment);
                if (maxWidth > width)
                {
                    comboBoxEquipment.DropDownWidth = maxWidth;
                }
                if (i!=0)
                {
                    comboBoxEquipment.SelectedIndex = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in UpdateComboBoxEquipment()");
                return;
            }
        }

        public static int GetAvailableQty(string ItemID, int TotalQty, DateTime myIssue, DateTime myDue)
        {
            //SqlDataReader rd;
            SqlConnection con = new mySQLcon().con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select Bookings.BookingID,EquipmentID,QuantityBooked," +
                "IssueDate,IssueTime,DueDate,Duetime from BookedItems, Bookings " +
                " where Bookings.BookingID = BookedItems.BookingID and IssueDate " +
                "<= '" + DateOf(myDue) + "' and DueDate >= '" + DateOf(myIssue) + "' and " +
                "EquipmentID = " + ItemID + " order by IssueDate,IssueTime,DueDate,DueTime";
            //rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();

            int numBookings = 0;
            DateTime IssuedOn, DueOn;

            foreach(DataRow row in dt.Rows)
            {
                IssuedOn = GetDateTime(row["IssueDate"], row["IssueTime"]);
                DueOn = GetDateTime(row["DueDate"], row["DueTime"]);
                if (IssuedOn < myIssue && DueOn > myIssue)
                {
                    numBookings += 1;
                }
            }

            int maxBookings = numBookings;
            //List<DateTime> todayIssue = new List<DateTime>();
            //List<DateTime> todayDue = new List<DateTime>();

            foreach (DateTime day in EachDay(myIssue, myDue))
            {
                foreach (DataRow row in dt.Rows)
                {
                    DueOn = GetDateTime(row["DueDate"], row["DueTime"]);
                    if (DateOf(DueOn) == DateOf(day))//<<----------masla here onwards----------
                    {
                        //todayDue.Add(DueOn);
                        numBookings -= 1;
                    }
                    IssuedOn = GetDateTime(row["IssueDate"], row["IssueTime"]);
                    if (DateOf(IssuedOn) == DateOf(day))
                    {
                        //todayIssue.Add(IssuedOn);
                        numBookings += 1;
                    }
                }

                ////pair the bookings that are due today to the first possible booking issued today
                //todayIssue.Sort();
                //todayDue.Sort();

                //int i = 0; //index for todayIssue
                //int j = 0; //index for todayDue
                //DateTime currentIssue, currentDue;

                //while (i < todayIssue.Count || j < todayDue.Count)
                //{
                //    currentIssue = todayIssue[i];
                //    currentDue = todayDue[j];

                //    if (currentIssue < currentDue)
                //    {
                //        numBookings += 1;
                //        i += 1;
                //    }
                //    //if

                //}

                if (numBookings > maxBookings)
                {
                    maxBookings = numBookings;
                }
                //MessageBox.Show(day.ToString() + "\n" + numBookings.ToString() + "\n" + maxBookings.ToString());
            }
            int qtyAvail = TotalQty - maxBookings;
            return qtyAvail;
        }

        public static DateTime GetDateTime(object date, object time)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            DateTime myDate = Convert.ToDateTime(date);
            DateTime myTime = DateTime.Parse(time.ToString());
            DateTime myDateTime = new DateTime(myDate.Year,myDate.Month,myDate.Day,myTime.Hour,myTime.Minute,myTime.Second);
            return myDateTime;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public static int DropDownWidth(ComboBox myCombo)
        {
            //Credits: stackoverflow.com/a/16435431
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(myCombo.GetItemText(obj), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth + SystemInformation.VerticalScrollBarWidth;
        }

        public static string DateOf(DateTime dateTime)
        {
            string str = dateTime.ToString("yyyy-MM-dd");
            return str;
        }

        public static DateTime DateTimeOf(string date, string time)
        {
            DateTime dateTime1;
            DateTime dateTime2;
            dateTime1 = Convert.ToDateTime(date);

            //DateTime d = DateTime.TryParseExact(date, "");

            //MessageBox.Show("Date = " + date + "\nTime = " + time + "\ndateTime = " + dateTime1.ToString(), "1");

            try
            {
                date = dateTime1.ToString("M/d/yyyy");
                dateTime2 = Convert.ToDateTime(date + " " + time);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "The system date format should be month/date/year");
                date = dateTime1.ToString("dd/MM/yyyy");
                dateTime2 = Convert.ToDateTime(date + " " + time);
            }
            //MessageBox.Show("Date = " + date + "\nTime = " + time + "\ndateTime = " + dateTime2.ToString(), "3");

            //MessageBox.Show("4");
            //Convert.ToDateTime()
            //MessageBox.Show(dateTime.ToString());
            return dateTime2;
        }

        public static string TimeOf(DateTime dateTime)
        {
            string str = dateTime.ToString("HH:mm:00");
            return str;
        }

        private void txtAssignment_TextChanged(object sender, EventArgs e)
        {
            myBooking.Project = txtAssignment.Text;
        }
    }
}
