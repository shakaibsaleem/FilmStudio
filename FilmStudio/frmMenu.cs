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
    public partial class frmMenu : Form
    {
        public string task, type;
        public User CurrentUser;
        bool allowExit = false;
        mySQLcon myCon;
        SqlConnection con;

        public frmMenu(User currentUser)
        {
            InitializeComponent();
            task = "";
            type = "";
            CurrentUser = currentUser;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;

            comboBoxType.Items.Add("Booking");
            comboBoxType.Items.Add("Course");
            comboBoxType.Items.Add("Enrolment");
            comboBoxType.Items.Add("Equipment");
            comboBoxType.Items.Add("Instructor");
            //comboBoxType.Items.Add("Staff");
            comboBoxType.Items.Add("Student");
            if (CurrentUser.IsAdmin)
            {
                comboBoxType.Items.Add("User");
            }
            rbtnAdd.Select();
            comboBoxType.SelectedIndex = 0;
            frmBooking frm = new frmBooking(CurrentUser);
            frm.Show();
            ShowBookings();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = comboBoxType.Items[comboBoxType.SelectedIndex].ToString();
        }

        private void rbtnAdd_CheckedChanged(object sender, EventArgs e)
        {
            task = "Add";
            comboBoxType.Select();
        }

        private void rbtnSearch_CheckedChanged(object sender, EventArgs e)
        {
            task = "Search";
            comboBoxType.Select();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            OpenForm(type, task);
        }

        private void frmMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pressing ESCAPE anywhere minimizes the form
            if (e.KeyChar == (char)Keys.Escape)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void comboBoxType_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pressing RETURN after selecting type launches the task
            if (e.KeyChar == (char)Keys.Return)
            {
                btnGo.PerformClick();
            }
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit)
            {
                notifyIconMenu.BalloonTipTitle = "Film Studio has been minimized";
                notifyIconMenu.BalloonTipText = "Double-click the FilmStudio icon to open menu again. Right-click to exit the application.";
                notifyIconMenu.BalloonTipIcon = ToolTipIcon.Info;
                notifyIconMenu.ShowBalloonTip(700);
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
                //this.Click += new EventHandler(Form1_Click);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowExit = true;
            Close();
        }

        private void notifyIconMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }

        public void OpenForm(string type, string task)
        {
            if (task == "Search")
            {
                if (type == "Booking")
                {
                    frmSearch frm = new frmSearch(type, CurrentUser);
                    frm.Show();
                }
            }
            else if (task == "Add")
            {
                if (type == "Booking")
                {
                    frmBooking frm = new frmBooking(CurrentUser);
                    frm.Show();
                }
                else if (type == "User")
                {
                    frmUser frm = new frmUser(CurrentUser);
                    frm.Show();
                }
                else if (type == "Course")
                {
                    frmCourse frm = new frmCourse(CurrentUser);
                    frm.Show();
                }
                else if (type == "Instructor")
                {
                    frmInstructor frm = new frmInstructor(CurrentUser);
                    frm.Show();
                }
                else if (type == "Student")
                {
                    frmStudent frm = new frmStudent(CurrentUser);
                    frm.Show();
                }
                else if (type == "Enrolment")
                {
                    frmEnrolment frm = new frmEnrolment(CurrentUser);
                    frm.Show();
                }
                else if (type == "Equipment")
                {
                    frmEquipment frm = new frmEquipment();
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Incorrect value for task: " + task, "Error in OpenForm()");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowBookings();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmBooking frm = new frmBooking(id, CurrentUser);
            frm.Show();
        }

        public void ShowBookings()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            //SqlDataReader rd;
            //cmd.CommandText = "select * from Bookings where IssueDate = '" + frmBooking.DateOf(DateTime.Now) +
            //        "' or DueDate = '" + frmBooking.DateOf(DateTime.Now) + "'";
            //rd = cmd.ExecuteReader();
            //rd.Close();

            cmd.CommandText = "select BookingID,IssueDate,DueDate,ReturnDate,BookedBy,Notes " +
                    "from Bookings where IssueDate < '" + frmBooking.DateOf(DateTime.Now) +
                    "' and DueDate > '" + frmBooking.DateOf(DateTime.Now) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
