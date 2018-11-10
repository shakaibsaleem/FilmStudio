using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudio
{
    public partial class frmBooking : Form
    {
        public Booking myBooking;
        public Equipment myEquipment;

        public frmBooking()
        {
            InitializeComponent();
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentEnrolment: new Enrolment(),
                currentUser: new User(),
                iD: 1,
                issuedOn: DateTime.Now,
                dueOn: DateTime.Now,
                returnedOn: DateTime.Now,
                bookedOn: DateTime.Now,
                notes: "No Notes",
                project: "ProjectX"
                );
        }

        public frmBooking(Booking bk)
        {
            myEquipment = new Equipment();
            myBooking = new Booking(
                currentEnrolment: new Enrolment(),
                currentUser: new User(),
                iD: bk.ID,
                issuedOn: bk.IssuedOn,
                dueOn: bk.DueOn,
                returnedOn: bk.ReturnedOn,
                bookedOn: bk.BookedOn,
                notes: bk.Notes,
                project: bk.Project
                );
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            txtStudentID.Text = myBooking.CurrentEnrolment.MyStudent.HUID;
            txtName.Text = myBooking.CurrentEnrolment.MyStudent.FirstName + " "
                + myBooking.CurrentEnrolment.MyStudent.MiddleName + " "
                + myBooking.CurrentEnrolment.MyStudent.LastName;
            txtContact.Text = myBooking.CurrentEnrolment.MyStudent.Contact;
            dateTimeIssued.Value = myBooking.IssuedOn;
            dateTimeDue.Value = myBooking.DueOn;
            txtAssignment.Text = "FYP";
            txtCourse.Text = myBooking.CurrentEnrolment.MyCourse.CourseName;
            txtInstructor.Text = myBooking.CurrentEnrolment.MyInstructor.InstructorName;

            txtEquipment.Text = myEquipment.Description;
            txtQuantity.Text = 12.ToString();
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            // Adding values from text boxes to list view
            ListViewItem listViewItem = new ListViewItem(txtEquipment.Text);
            listViewItem.SubItems.Add(txtQuantity.Text);
            listViewBooking.Items.Add(listViewItem);
            txtEquipment.Clear();
            txtQuantity.Clear();
            // stop it from adding emoty items
            // check for duplication, update quantity instead of addidng the existing item again
        }
    }
}
