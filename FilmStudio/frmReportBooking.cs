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
    public partial class frmReportBooking : Form
    {
        Booking myBooking;
        Equipment myEquipment;
        List<MyItem> myItems;

        public frmReportBooking(Booking booking, List<MyItem> items)
        {
            InitializeComponent();
            myBooking = booking;
            myItems = items;
        }

        private void frmReportBooking_Load(object sender, EventArgs e)
        {
            //DataSet
            //BindingSource bindingSource = new BindingSource(myItems,)
            //datase
            //Boo
            //BindingSource

            //string[] eqs = new string[]
            //{
            //    "a", "b"
            //};

            //string[] qty = new string[]
            //{
            //    "1", "2"
            //};

            //Microsoft.Reporting.WinForms.ReportParameter p1 = new Microsoft.Reporting.WinForms.ReportParameter("Equipment", eqs);
            //Microsoft.Reporting.WinForms.ReportParameter p2 = new Microsoft.Reporting.WinForms.ReportParameter("Quantity", qty);

            List<Microsoft.Reporting.WinForms.ReportParameter> parametersList = new List<Microsoft.Reporting.WinForms.ReportParameter>();

            parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("IssuedOn", myBooking.IssuedOn.ToString("dd/MM/yy ddd hh:mm tt")));
            parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("DueOn", myBooking.DueOn.ToString("dd/MM/yy ddd hh:mm tt")));

            if (myBooking.BookedBy == "Student")
            {
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("HabibID", myBooking.Student.HabibID));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Name", myBooking.Student.Name));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Project", myBooking.Project));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Email", myBooking.Student.Email));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("OffCampus", myBooking.OffCampus ? "Yes" : "No"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Course", myBooking.Enrolment.Course.CourseName));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Instructor", myBooking.Enrolment.Instructor.Name));
            }
            else if (myBooking.BookedBy == "Instructor")
            {
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("HabibID", myBooking.Instructor.HabibID));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Name", myBooking.Instructor.Name));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Project", "NA"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Email", myBooking.Instructor.Email));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("OffCampus", myBooking.OffCampus ? "Yes" : "No"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Course", "NA"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Instructor", "NA"));
            }
            else if (myBooking.BookedBy == "Staff")
            {
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("HabibID", myBooking.Staff.HabibID));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Name", myBooking.Staff.Name));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Project", "NA"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Email", myBooking.Staff.Email));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("OffCampus", myBooking.OffCampus ? "Yes" : "No"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Course", "NA"));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Instructor", "NA"));
            }
            else
            {
                MessageBox.Show("Unexpected value for booked by","Error in load report");
            }

            parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Notes", myBooking.Notes));

            int c = myItems.Count;

            for (int i = 1; i <= c && i <= 9; i++)
            {
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Equipment" + i.ToString(), myItems[i-1].Description));
                parametersList.Add(new Microsoft.Reporting.WinForms.ReportParameter("Quantity" + i.ToString(), myItems[i-1].Quantity.ToString()));
            }

            //Microsoft.Reporting.WinForms.ReportParameter[] parameters =
            //    new Microsoft.Reporting.WinForms.ReportParameter[]
            //    {
            //        new Microsoft.Reporting.WinForms.ReportParameter("IssuedOn",myBooking.IssuedOn.ToString("dd/MM/yy ddd hh:mm tt")),
            //        new Microsoft.Reporting.WinForms.ReportParameter("DueOn",myBooking.DueOn.ToString("dd/MM/yy ddd hh:mm tt")),
            //        new Microsoft.Reporting.WinForms.ReportParameter("HabibID",myBooking.Student.HabibID),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Name",myBooking.Student.Name),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Project",myBooking.Project),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Email",myBooking.Student.Email),
            //        new Microsoft.Reporting.WinForms.ReportParameter("OffCampus",myBooking.OffCampus ? "Yes" : "No"),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Course",myBooking.Enrolment.Course.CourseName),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Instructor",myBooking.Enrolment.Instructor.Name),
            //        new Microsoft.Reporting.WinForms.ReportParameter("Notes",myBooking.Notes)//,
            //        //new Microsoft.Reporting.WinForms.ReportParameter("Equipment", eqs),
            //        //new Microsoft.Reporting.WinForms.ReportParameter("Quantity", qty)
            //    };

            reportViewer.LocalReport.SetParameters(parametersList);
            reportViewer.RefreshReport();
            reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }
    }
}
