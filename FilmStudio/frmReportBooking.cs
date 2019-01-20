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
            
            Microsoft.Reporting.WinForms.ReportParameter[] parameters =
                new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("IssuedOn",myBooking.IssuedOn.ToString("dd/MM/yy ddd hh:mm tt")),
                    new Microsoft.Reporting.WinForms.ReportParameter("DueOn",myBooking.DueOn.ToString("dd/MM/yy ddd hh:mm tt")),
                    new Microsoft.Reporting.WinForms.ReportParameter("HabibID",myBooking.Student.HabibID),
                    new Microsoft.Reporting.WinForms.ReportParameter("Name",myBooking.Student.Name),
                    new Microsoft.Reporting.WinForms.ReportParameter("Project",myBooking.Project),
                    new Microsoft.Reporting.WinForms.ReportParameter("Email",myBooking.Student.Email),
                    new Microsoft.Reporting.WinForms.ReportParameter("OffCampus",myBooking.OffCampus ? "Yes" : "No"),
                    new Microsoft.Reporting.WinForms.ReportParameter("Course",myBooking.Enrolment.Course.CourseName),
                    new Microsoft.Reporting.WinForms.ReportParameter("Instructor",myBooking.Enrolment.Instructor.Name),
                    new Microsoft.Reporting.WinForms.ReportParameter("Notes",myBooking.Notes)
                };
            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
            reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }
    }
}
