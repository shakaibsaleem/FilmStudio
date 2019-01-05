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
        string state;

        public frmBooking()
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myBooking = new Booking();
            state = "Empty";
        }

        public frmBooking(string id)
        {
            InitializeComponent();
            myCon = new mySQLcon();
            con = myCon.con;
            myBooking = new Booking();
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
            txtAvailable.Clear();
            txtBooked.Clear();
            numQuantity.Value = 1;
            comboBoxEquipment.ResetText();
            comboBoxEquipment.Select();
            btnAddEquipment.Enabled = false;
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            btnAddEquipment.Enabled = Convert.ToInt32(numQuantity.Value) > 0;
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
                DialogResult dialogResult = MessageBox.Show("You have not added the record." +
                    " Press Yes to add the record and then close. Press No to close without" +
                    " adding.","Add record before closing?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    btnAdd.PerformClick();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
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
                MessageBox.Show("State = ", "Unexpected value in btnClose");
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
                    "IssueTime,DueDate,DueTime)values(" + myBooking.User.ID + ",'" + 
                    myBooking.BookedBy + "','" + myBooking.Notes +"','" +
                    DateOf(myBooking.BookedOn) + "','" + TimeOf(myBooking.BookedOn) + "','" +
                    DateOf(myBooking.IssuedOn) + "','" + TimeOf(myBooking.IssuedOn) + "','" +
                    DateOf(myBooking.DueOn) + "','" + TimeOf(myBooking.DueOn) + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select top 1 BookingID from Bookings order by BookingID desc";
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    myBooking.ID = rd[0].ToString();
                }
                rd.Close();
                tran.Commit();
                state = "Add";
                UpdateFields(state);
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
                    else if (1==i)
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
                    else if (1==i)
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

                string myDescription, myID;
                int myQuantity, oldQuantity, qtyAvailable, qtyBooked;
                SqlDataReader rd;
                List<string> myList = new List<string>();

                foreach (ListViewItem item in listViewBooking.Items)
                {
                    myDescription = item.SubItems[0].Text;
                    myQuantity = Convert.ToInt32(item.SubItems[1].Text);

                    cmd.CommandText = "select EquipmentID,QuantityAvailable,QuantityBooked " +
                        "from Equipments where Description = '" + myDescription + "'";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myID = rd[0].ToString();
                        qtyAvailable = Convert.ToInt32(rd[1].ToString());
                        qtyBooked = Convert.ToInt32(rd[2].ToString());
                        myList.Add(myID);
                    }
                    else
                    {
                        MessageBox.Show("Invalid value of description: " + myDescription,"Error in fetching equipment details");
                        myID = "1";
                        qtyAvailable = 0;
                        qtyBooked = 0;
                    }
                    rd.Close();

                    cmd.CommandText = "select Quantity from BookedItems where " +
                        "BookingID = " + myBooking.ID + " and EquipmentID = " + myID;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        oldQuantity = Convert.ToInt32(rd[0].ToString());
                        rd.Close();
                        cmd.CommandText = "update BookedItems set Quantity = " + myQuantity + 
                            " where BookingID = " + myBooking.ID + " and EquipmentID = " + myID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        oldQuantity = 0;
                        rd.Close();
                        cmd.CommandText = "insert into BookedItems (BookingID,EquipmentID,Quantity) values " +
                            "(" + myBooking.ID + ", " + myID + ", " + myQuantity + ")";
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "update Equipments set " +
                        "QuantityBooked = " + (qtyBooked + (myQuantity-oldQuantity)) +
                        ", QuantityAvailable = " + (qtyAvailable - (myQuantity - oldQuantity)) +
                        " where EquipmentID = " + myID;
                    cmd.ExecuteNonQuery();
                }

                List<string> toDelete = new List<string>();
                myID = "";

                cmd.CommandText = "select EquipmentID from BookedItems where BookingID = " + myBooking.ID;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    myID = rd[0].ToString();
                    if (myList.Contains(myID) == false)
                    {
                        toDelete.Add(myID);
                    }
                }
                rd.Close();

                foreach (string id in toDelete)
                {
                    cmd.CommandText = "select Quantity,QuantityAvailable,QuantityBooked " +
                        "from BookedItems,Equipments where BookingID = " +
                        myBooking.ID + " and BookedItems.EquipmentID = " + id +
                        " and BookedItems.EquipmentID = Equipments.EquipmentID";
                    rd = cmd.ExecuteReader();

                    if (rd.Read() == true)
                    {
                        oldQuantity = Convert.ToInt32(rd[0].ToString());
                        qtyAvailable = Convert.ToInt32(rd[1].ToString());
                        qtyBooked = Convert.ToInt32(rd[2].ToString());
                        rd.Close();

                        cmd.CommandText = "update Equipments set " +
                        "QuantityBooked = " + (qtyBooked - oldQuantity) +
                        ", QuantityAvailable = " + (qtyAvailable + oldQuantity) +
                        " where EquipmentID = " + id;
                        cmd.ExecuteNonQuery();
                    }
                    rd.Close();
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
        }

        private void dateTimeIssued_ValueChanged(object sender, EventArgs e)
        {
            myBooking.IssuedOn = dateTimeIssued.Value;
        }

        private void dateTimeDue_ValueChanged(object sender, EventArgs e)
        {
            myBooking.DueOn = dateTimeDue.Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateFields("Edit");
            UpdateComboBoxEquipment();
            state = "Edit";
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
                MessageBox.Show("State = ", "Unexpected value in btnNext");
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

                //try
                //{
                //    btnNext.PerformClick();
                //}
                //catch (Exception)
                //{
                //    try
                //    {
                //        btnPrevious.PerformClick();
                //    }
                //    catch (Exception)
                //    {
                //        Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
            }
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
            Equipment eq = (Equipment)comboBoxEquipment.SelectedItem;
            myEquipment.Description = eq.Description;
            txtAvailable.Text = eq.QtyAvailable.ToString();
            txtBooked.Text = eq.QtyBooked.ToString();

            btnAddEquipment.Enabled = comboBoxEquipment.SelectedIndex >= 0;
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
                btnAdd.Enabled = false;
                btnClose.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;

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
            }
            else if (s == "Empty")
            {
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
                btnAdd.Enabled = false;
                btnAddEquipment.Enabled = true;
                btnClose.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSave.Enabled = true;
                groupBoxBookedBy.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;
                listViewBooking.Enabled = true;
                txtNotes.Enabled = true;

                UpdateComboBoxEquipment();

                comboBoxID.Focus();
            }
            else if (s == "Edit")
            {
                btnAddEquipment.Enabled = false;
                btnAdd.Enabled = false;
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

                listViewBooking.Enabled = true;
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
                    "IssueDate,IssueTime,DueDate,DueTime from Bookings where BookingID = " + id;
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
                    str1 = rd[5].ToString();
                    str2 = rd[6].ToString();
                    myBooking.IssuedOn = DateTimeOf(date: str1, time: str2);
                    str1 = rd[7].ToString();
                    str2 = rd[8].ToString();
                    myBooking.DueOn = DateTimeOf(date: str1, time: str2);
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
                cmd.CommandText = "select Description,Quantity from BookedItems,Equipments" +
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
            string d = "";
            int qtyA, qtyB;

            try
            {
                comboBoxEquipment.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select Description,QuantityBooked,QuantityAvailable from Equipments order by Description";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    qtyA = Convert.ToInt32(rd[2].ToString());
                    qtyB = Convert.ToInt32(rd[1].ToString());
                    d = rd[0].ToString();
                    eq = new Equipment(qtyA, qtyB, d);
                    comboBoxEquipment.Items.Add(eq);
                }
                rd.Close();

                int width = comboBoxEquipment.DropDownWidth;
                int maxWidth = DropDownWidth(comboBoxEquipment);
                if (maxWidth > width)
                {
                    comboBoxEquipment.DropDownWidth = maxWidth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in UpdateComboBoxEquipment()");
            }
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
            DateTime dateTime;
            dateTime = Convert.ToDateTime(date);
            date = dateTime.ToString("dd-MM-yyyy");
            dateTime = Convert.ToDateTime(date + " " + time);
            //MessageBox.Show(dateTime.ToString());
            return dateTime;
        }

        public static string TimeOf(DateTime dateTime)
        {
            string str = dateTime.ToString("HH:mm:00");
            return str;
        }
    }
}
