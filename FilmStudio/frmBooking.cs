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
                iD: 1,
                issuedOn: DateTime.Now,
                dueOn: DateTime.Now.AddDays(1),
                returnedOn: DateTime.Now,
                bookedOn: DateTime.Now,
                notes: "No Notes",
                BookedBy: "Student"
                );
        }

        public frmBooking(Booking bk)
        {
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentUser: new User(),
                iD: bk.ID,
                issuedOn: bk.IssuedOn,
                dueOn: bk.DueOn,
                returnedOn: bk.ReturnedOn,
                bookedOn: bk.BookedOn,
                notes: bk.Notes,
                BookedBy: bk.BookedBy
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
            rbtnStudent.Select();
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
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Bookings (Name, Passkey, isAdmin, Username) values('Shakaib Saleem', 'admin', 1, 'shakaib')";
            cmd.ExecuteNonQuery();
        }
    }
}
