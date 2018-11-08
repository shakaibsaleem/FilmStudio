namespace FilmStudio
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
            this.lblAssignment = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.txtAssignment = new System.Windows.Forms.TextBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.txtInstructor = new System.Windows.Forms.TextBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
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
            this.txtName.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(440, 12);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 2;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(12, 15);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 10;
            this.lblStudentID.Text = "Student ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(140, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(387, 15);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(47, 13);
            this.lblContact.TabIndex = 10;
            this.lblContact.Text = "Contact:";
            // 
            // dateTimeIssued
            // 
            this.dateTimeIssued.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeIssued.Location = new System.Drawing.Point(79, 38);
            this.dateTimeIssued.Name = "dateTimeIssued";
            this.dateTimeIssued.Size = new System.Drawing.Size(158, 20);
            this.dateTimeIssued.TabIndex = 3;
            this.dateTimeIssued.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            // 
            // lblIssued
            // 
            this.lblIssued.AutoSize = true;
            this.lblIssued.Location = new System.Drawing.Point(12, 44);
            this.lblIssued.Name = "lblIssued";
            this.lblIssued.Size = new System.Drawing.Size(58, 13);
            this.lblIssued.TabIndex = 10;
            this.lblIssued.Text = "Issued On:";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(243, 44);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(47, 13);
            this.lblDue.TabIndex = 10;
            this.lblDue.Text = "Due On:";
            // 
            // dateTimeDue
            // 
            this.dateTimeDue.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDue.Location = new System.Drawing.Point(296, 38);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(158, 20);
            this.dateTimeDue.TabIndex = 4;
            this.dateTimeDue.Value = new System.DateTime(2018, 11, 9, 13, 0, 0, 0);
            // 
            // lblAssignment
            // 
            this.lblAssignment.AutoSize = true;
            this.lblAssignment.Location = new System.Drawing.Point(12, 67);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(64, 13);
            this.lblAssignment.TabIndex = 10;
            this.lblAssignment.Text = "Assignment:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(188, 67);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 10;
            this.lblCourse.Text = "Course:";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Location = new System.Drawing.Point(343, 67);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(54, 13);
            this.lblInstructor.TabIndex = 10;
            this.lblInstructor.Text = "Instructor:";
            // 
            // txtAssignment
            // 
            this.txtAssignment.Location = new System.Drawing.Point(82, 64);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(100, 20);
            this.txtAssignment.TabIndex = 5;
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(237, 64);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(100, 20);
            this.txtCourse.TabIndex = 6;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(400, 64);
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Size = new System.Drawing.Size(100, 20);
            this.txtInstructor.TabIndex = 7;
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(12, 93);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(60, 13);
            this.lblEquipment.TabIndex = 10;
            this.lblEquipment.Text = "Equipment:";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(82, 90);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(255, 20);
            this.txtEquipment.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(343, 93);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(400, 91);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 9;
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 254);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtEquipment);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.txtInstructor);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.txtAssignment);
            this.Controls.Add(this.lblInstructor);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblAssignment);
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
        private System.Windows.Forms.Label lblAssignment;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.TextBox txtAssignment;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.TextBox txtInstructor;
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.TextBox txtEquipment;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
    }
}