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

        public frmBooking()
        {
            InitializeComponent();
            myBooking = new Booking(1, issuedOn: DateTime.Now, dueOn: DateTime.Now, returnedOn: DateTime.Now, bookedOn: DateTime.Now, notes: "No Notes", project: "ProjectX");
        }

        public frmBooking(Booking bk)
        {
            myBooking = new Booking(
                bk.ID,
                bk.IssuedOn,
                bk.DueOn,
                bk.ReturnedOn,
                bk.BookedOn,
                bk.Notes,
                bk.Project
                );
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {

        }
    }
}
