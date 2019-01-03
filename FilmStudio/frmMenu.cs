﻿using System;
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
    public partial class frmMenu : Form
    {
        public string task, type;
        public frmMenu()
        {
            InitializeComponent();
            task = "";
            type = "";
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add("Booking");
            comboBoxType.Items.Add("Course");
            comboBoxType.Items.Add("Enrolment");
            comboBoxType.Items.Add("Equipment");
            comboBoxType.Items.Add("Instructor");
            comboBoxType.Items.Add("Staff");
            comboBoxType.Items.Add("Student");
            comboBoxType.Items.Add("User");
            rbtnAdd.Select();
            comboBoxType.SelectedIndex = 0;
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
            DialogResult dialogResult = MessageBox.Show(task + " " + type, "Confirm?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                OpenForm(type, task);
                //Close();
            }
        }

        public void OpenForm(string type, string task)
        {
            if (type == "Booking")
            {
                if (task == "Add")
                {
                    frmBooking frm = new frmBooking("Add");
                    frm.Show();
                }
                else if (task == "Search")
                {
                    MessageBox.Show("Search");
                }
                else
                {
                    MessageBox.Show("Incorrect value for task: " + task, "Error in OpenForm()");
                }
            }
        }

        private void frmMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pressing ESCAPE anywhere closes the form
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Press YES to Exit.", "Are you sure you want to Exit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
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
    }
}