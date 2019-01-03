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

        string mode;

        public frmBooking()
        {
            InitializeComponent();
            myEquipment = new Equipment();
            myBooking = new Booking();
            mode = "Add";
        }

        public frmBooking(string m)
        {
            InitializeComponent();
            myEquipment = new Equipment();
            myBooking = new Booking();
            mode = m;
        }

        public frmBooking(Booking bk, string m)
        {
            InitializeComponent();
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentUser: new User(),
                currentCourse: new Course(),
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
                bookedBy: bk.BookedBy,
                project: bk.Project
                );
            mode = m;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;

            dateTimeIssued.Value = myBooking.IssuedOn;
            dateTimeDue.Value = myBooking.DueOn;
            txtAssignment.Text = myBooking.Project;
            numQuantity.Value = 1;
            rbtnStudent.Select();
            btnAdd.Select();
            UpdateEnabled("Load");
            //mode = "Load";
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
            if (mode == "Edit" || mode == "Add" || mode == "Load")
            {
                DialogResult dialogResult = MessageBox.Show("Any unsaved changes will be lost.", 
                    "Are you sure you want to close?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    btnSave.Select();
                }
            }
            else if (mode == "Save")
            {
                Close();
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
                UpdateComboBoxEquipment();
                mode = "Add";
                groupBoxBookedFor.Focus();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error in btnAdd");
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

        private int DropDownWidth(ComboBox myCombo)
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

        public string DateOf(DateTime dateTime)
        {
            string str = dateTime.ToString("yyyy-MM-dd");
            return str;
        }

        public DateTime DateTimeOf(string date, string time)
        {
            DateTime dateTime;
            dateTime = Convert.ToDateTime(date);
            date = dateTime.ToString("dd-MM-yyyy");
            dateTime = Convert.ToDateTime(date + " " + time);
            //MessageBox.Show(dateTime.ToString());
            return dateTime;
        }

        public string TimeOf(DateTime dateTime)
        {
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

                cmd.CommandText = "update Bookings set " +
                    "   UserID = " + myBooking.CurrentUser.UserID +
                    " , Notes = '" + myBooking.Notes +
                    "', BookedBy = '" + myBooking.BookedBy +
                    "', BookingDate = '" + DateOf(myBooking.BookedOn) +
                    "', BookingTime = '" + TimeOf(myBooking.BookedOn) +
                    "', IssueDate = '" + DateOf(myBooking.IssuedOn) +
                    "', IssueTime = '" + TimeOf(myBooking.IssuedOn) +
                    "', DueDate = '" + DateOf(myBooking.DueOn) +
                    "', DueTime = '" + TimeOf(myBooking.DueOn) +
                    "', ReturnDate = '" + DateOf(myBooking.ReturnedOn) +
                    "', ReturnTime = '" + TimeOf(myBooking.ReturnedOn) +
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
                //MessageBox.Show("Press OK to continue", "Saved successfully");
                UpdateEnabled("Save");
                mode = "Save";
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
                btnAddEquipment.Enabled = false;
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

                listViewBooking.Enabled = false;
            }
            else if (e == "Add")
            {
                btnAddEquipment.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = false;

                groupBoxBookedFor.Enabled = true;
                groupBoxBooking.Enabled = true;
                groupBoxEquipment.Enabled = true;

                txtNotes.Enabled = true;

                listViewBooking.Enabled = true;
            }
            else if (e == "Load")
            {
                btnAddEquipment.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;

                txtHabibID.Visible = false;
                txtCourse.Visible = false;
                txtInstructor.Visible = false;

                groupBoxBookedFor.Enabled = true;
                groupBoxBooking.Enabled = false;
                groupBoxEquipment.Enabled = false;

                txtNotes.Enabled = false;

                listViewBooking.Enabled = true;
            }
            else if (e == "Edit")
            {
                btnAddEquipment.Enabled = false;
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

                listViewBooking.Enabled = true;
            }
            else if (e == "Student")
            {
                btnSave.Enabled = false;
                //comboBoxID.Enabled = true;
                txtAssignment.Enabled = true;
                comboBoxCourse.Enabled = true;
                comboBoxInstructor.Enabled = true;
            }
            else if (e == "Instructor")
            {
                btnSave.Enabled = false;
                //comboBoxID.Enabled = false;
                txtAssignment.Enabled = false;
                comboBoxCourse.Enabled = false;
                comboBoxInstructor.Enabled = false;
            }
            else if (e == "Staff")
            {
                btnSave.Enabled = false;
                //comboBoxID.Enabled = false;
                txtAssignment.Enabled = false;
                comboBoxCourse.Enabled = false;
                comboBoxInstructor.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid argument: " + e, "Error in UpdateEnabled()");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateEnabled("Edit");
            UpdateComboBoxEquipment();
            mode = "Edit";
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
            if (mode == "Edit" || mode == "Load" || mode == "Add")
            {
                DialogResult dialogResult = MessageBox.Show("Any unsaved changes will be lost.",
                    "Are you sure you want to close?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AdvanceTo("NextRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    btnSave.Select();
                }
            }
            else if (mode == "Save")
            {
                AdvanceTo("NextRecord", myBooking.ID);
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
                        else
                        {
                            MessageBox.Show(id, "Next record found");
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Next record not found");
                    }
                    rd.Close();
                    //MessageBox.Show("ID = " + id, "Loading next record");
                    //LoadRecord(id: id);
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
                        else
                        {
                            MessageBox.Show(id, "Previous record found");
                        }
                    }
                    else
                    {
                        MessageBox.Show(id, "Previous record not found");
                    }
                    rd.Close();
                    //MessageBox.Show("ID = " + id, "Loading previous record");
                }
                else
                {
                    MessageBox.Show("Incorrect value for record: " + record, "Error in AdvanceTo()");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error in AdvanceTo()");
            }
            LoadRecord(id: id);
        }

        public void LoadRecord(string id)
        {
            SqlDataReader rd;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
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
                    myBooking.BookedOn = DateTimeOf(date: date,time: time);
                    date = rd[5].ToString();
                    time = rd[6].ToString();
                    myBooking.IssuedOn = DateTimeOf(date: date, time: time);
                    date = rd[7].ToString();
                    time = rd[8].ToString();
                    myBooking.DueOn = DateTimeOf(date: date, time: time);
                    date = rd[9].ToString();
                    time = rd[10].ToString();
                    myBooking.ReturnedOn = DateTimeOf(date: date, time: time);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in LoadRecord()");
            }
            UpdateEnabled(myBooking.BookedBy);
            UpdateBookingDetails(myBooking.BookedBy);
            dateTimeIssued.Value = myBooking.IssuedOn;
            dateTimeDue.Value = myBooking.DueOn;
            //if (rbtnInstructor.Checked)
            //{
            //    myBooking.BookedBy = "Instructor";
            //    txtHabibID.Text = myBooking.CurrentInstructor.HabibID;
            //    txtName.Text = myBooking.CurrentInstructor.Name;
            //    txtContact.Text = myBooking.CurrentInstructor.Contact;
            //    txtHabibID.Visible = true;
            //    txtCourse.Visible = true;
            //    txtInstructor.Visible = true;
            //}
            //else if (rbtnStudent.Checked)
            //{
            //    myBooking.BookedBy = "Student";
            //}
            //else if (rbtnStaff.Checked)
            //{
            //    myBooking.BookedBy = "Staff";
            //    txtHabibID.Text = myBooking.CurrentStaff.HabibID;
            //    txtName.Text = myBooking.CurrentStaff.Name;
            //    txtContact.Text = myBooking.CurrentStaff.Contact;
            //}
            //set remaining fields
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (mode == "Edit" || mode == "Load" || mode == "Add")
            {
                DialogResult dialogResult = MessageBox.Show("Any unsaved changes will be lost.",
                    "Are you sure you want to close?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AdvanceTo("PrevRecord", myBooking.ID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    btnSave.Select();
                }
            }
            else if (mode == "Save")
            {
                AdvanceTo("PrevRecord", myBooking.ID);
            }
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
                comboBoxCourse.Items.Clear();
                comboBoxCourse.ResetText();
                comboBoxInstructor.Items.Clear();
                comboBoxInstructor.ResetText();

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
                        myBooking.CurrentStudent = new Student(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.CurrentStudent = new Student();
                    }
                    rd.Close();
                    txtName.Text = myBooking.CurrentStudent.Name;
                    txtContact.Text = myBooking.CurrentStudent.Contact;

                    btnSave.Enabled = false;

                    comboBoxCourse.Items.Clear();
                    comboBoxCourse.ResetText();
                    comboBoxInstructor.Items.Clear();
                    comboBoxInstructor.ResetText();

                    //fetching and displaying courses of selected student
                    cmd.CommandText = "select distinct CourseName from Courses, Enrolments " +
                        "where Courses.CourseID=Enrolments.CourseID and StudentID = " +
                        myBooking.CurrentStudent.ID;
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
                        myBooking.CurrentInstructor = new Instructor(iD, habibID, name, email, contact);
                    }
                    else
                    {
                        myBooking.CurrentInstructor = new Instructor();
                    }
                    rd.Close();
                    txtName.Text = myBooking.CurrentInstructor.Name;
                    txtContact.Text = myBooking.CurrentInstructor.Contact;
                    btnSave.Enabled = true;
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
                    rd.Close();
                    txtName.Text = myBooking.CurrentStaff.Name;
                    txtContact.Text = myBooking.CurrentStaff.Contact;
                    btnSave.Enabled = true;
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
                    myBooking.CurrentCourse = new Course(iD, name, code);
                }
                else
                {
                    myBooking.CurrentCourse = new Course();
                }
                rd.Close();

                btnSave.Enabled = false;
                comboBoxInstructor.Items.Clear();
                comboBoxInstructor.ResetText();

                //fetching and displaying Instructor of student's selected course
                cmd.CommandText = "select distinct Instructors.Name from Courses, Enrolments, Instructors " +
                    "where Courses.CourseID = Enrolments.CourseID and " +
                    "Instructors.InstructorID = Enrolments.InstructorID and " +
                    "StudentID = " + myBooking.CurrentStudent.ID +
                    " and Enrolments.CourseID = " + myBooking.CurrentCourse.ID;
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
                    myBooking.CurrentInstructor = new Instructor(iD, habibID, name, email,contact);
                }
                else
                {
                    myBooking.CurrentInstructor = new Instructor();
                }
                rd.Close();
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
                    "where CourseID = " + myBooking.CurrentCourse.ID +
                    " and StudentID = " + myBooking.CurrentStudent.ID +
                    " and InstructorID = " + myBooking.CurrentInstructor.ID;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    enrolments.Add(new Enrolment(
                        rd["EnrolmentID"].ToString(), 
                        myBooking.CurrentStudent, 
                        myBooking.CurrentCourse, 
                        myBooking.CurrentInstructor, 
                        rd["Term"].ToString()
                        ));
                }
                rd.Close();

                if (enrolments.Count == 1)
                {
                    myBooking.CurrentEnrolment = enrolments[0];
                    btnSave.Enabled = true;
                }
                else if (enrolments.Count == 0)
                {
                    MessageBox.Show("No enrolment records found", "Error in fetching enrolments");
                }
                else
                {
                    myBooking.CurrentEnrolment = enrolments.Last<Enrolment>();
                    btnSave.Enabled = true;
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
    }
}
