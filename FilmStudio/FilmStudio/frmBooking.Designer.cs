﻿namespace FilmStudio
{
    partial class frmBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.dateTimeIssued = new System.Windows.Forms.DateTimePicker();
            this.lblIssued = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.dateTimeDue = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(79, 12);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(55, 20);
            this.txtStudentID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(184, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(440, 12);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 0;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(12, 15);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 1;
            this.lblStudentID.Text = "Student ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(140, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(387, 15);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(47, 13);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "Contact:";
            // 
            // dateTimeIssued
            // 
            this.dateTimeIssued.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeIssued.Location = new System.Drawing.Point(79, 38);
            this.dateTimeIssued.Name = "dateTimeIssued";
            this.dateTimeIssued.Size = new System.Drawing.Size(158, 20);
            this.dateTimeIssued.TabIndex = 4;
            this.dateTimeIssued.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            // 
            // lblIssued
            // 
            this.lblIssued.AutoSize = true;
            this.lblIssued.Location = new System.Drawing.Point(12, 44);
            this.lblIssued.Name = "lblIssued";
            this.lblIssued.Size = new System.Drawing.Size(58, 13);
            this.lblIssued.TabIndex = 5;
            this.lblIssued.Text = "Issued On:";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(243, 44);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(47, 13);
            this.lblDue.TabIndex = 6;
            this.lblDue.Text = "Due On:";
            // 
            // dateTimeDue
            // 
            this.dateTimeDue.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDue.Location = new System.Drawing.Point(296, 38);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(158, 20);
            this.dateTimeDue.TabIndex = 7;
            this.dateTimeDue.Value = new System.DateTime(2018, 11, 9, 13, 0, 0, 0);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 254);
            this.Controls.Add(this.dateTimeDue);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblIssued);
            this.Controls.Add(this.dateTimeIssued);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtStudentID);
            this.Name = "frmBooking";
            this.Text = "Booking Form";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.DateTimePicker dateTimeIssued;
        private System.Windows.Forms.Label lblIssued;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.DateTimePicker dateTimeDue;
    }
}