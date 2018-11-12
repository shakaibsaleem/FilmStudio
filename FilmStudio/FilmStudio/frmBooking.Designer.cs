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
            this.groupBoxBooking = new System.Windows.Forms.GroupBox();
            this.listViewBooking = new System.Windows.Forms.ListView();
            this.colHeadEquipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimeDue = new System.Windows.Forms.DateTimePicker();
            this.btnAddEquipment = new System.Windows.Forms.Button();
            this.groupBoxBooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(76, 16);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(55, 20);
            this.txtStudentID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(186, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(397, 16);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 2;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(6, 19);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 103;
            this.lblStudentID.Text = "Student ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(137, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 104;
            this.lblName.Text = "Name:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(337, 19);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(47, 13);
            this.lblContact.TabIndex = 105;
            this.lblContact.Text = "Contact:";
            // 
            // dateTimeIssued
            // 
            this.dateTimeIssued.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeIssued.Location = new System.Drawing.Point(88, 12);
            this.dateTimeIssued.Name = "dateTimeIssued";
            this.dateTimeIssued.Size = new System.Drawing.Size(181, 20);
            this.dateTimeIssued.TabIndex = 50;
            this.dateTimeIssued.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            // 
            // lblIssued
            // 
            this.lblIssued.AutoSize = true;
            this.lblIssued.Location = new System.Drawing.Point(18, 18);
            this.lblIssued.Name = "lblIssued";
            this.lblIssued.Size = new System.Drawing.Size(58, 13);
            this.lblIssued.TabIndex = 100;
            this.lblIssued.Text = "Issued On:";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(275, 18);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(47, 13);
            this.lblDue.TabIndex = 101;
            this.lblDue.Text = "Due On:";
            // 
            // lblAssignment
            // 
            this.lblAssignment.AutoSize = true;
            this.lblAssignment.Location = new System.Drawing.Point(6, 45);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(64, 13);
            this.lblAssignment.TabIndex = 106;
            this.lblAssignment.Text = "Assignment:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(137, 45);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 107;
            this.lblCourse.Text = "Course:";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Location = new System.Drawing.Point(337, 45);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(54, 13);
            this.lblInstructor.TabIndex = 108;
            this.lblInstructor.Text = "Instructor:";
            // 
            // txtAssignment
            // 
            this.txtAssignment.Location = new System.Drawing.Point(76, 42);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(55, 20);
            this.txtAssignment.TabIndex = 3;
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(186, 42);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(145, 20);
            this.txtCourse.TabIndex = 4;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(397, 42);
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Size = new System.Drawing.Size(100, 20);
            this.txtInstructor.TabIndex = 5;
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(18, 115);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(60, 13);
            this.lblEquipment.TabIndex = 109;
            this.lblEquipment.Text = "Equipment:";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(88, 112);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(255, 20);
            this.txtEquipment.TabIndex = 6;
            this.txtEquipment.TextChanged += new System.EventHandler(this.txtEquipment_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(349, 115);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 110;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(409, 112);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 7;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // groupBoxBooking
            // 
            this.groupBoxBooking.Controls.Add(this.lblStudentID);
            this.groupBoxBooking.Controls.Add(this.txtStudentID);
            this.groupBoxBooking.Controls.Add(this.txtName);
            this.groupBoxBooking.Controls.Add(this.txtContact);
            this.groupBoxBooking.Controls.Add(this.lblName);
            this.groupBoxBooking.Controls.Add(this.txtInstructor);
            this.groupBoxBooking.Controls.Add(this.lblContact);
            this.groupBoxBooking.Controls.Add(this.txtCourse);
            this.groupBoxBooking.Controls.Add(this.txtAssignment);
            this.groupBoxBooking.Controls.Add(this.lblInstructor);
            this.groupBoxBooking.Controls.Add(this.lblCourse);
            this.groupBoxBooking.Controls.Add(this.lblAssignment);
            this.groupBoxBooking.Location = new System.Drawing.Point(12, 38);
            this.groupBoxBooking.Name = "groupBoxBooking";
            this.groupBoxBooking.Size = new System.Drawing.Size(503, 68);
            this.groupBoxBooking.TabIndex = 102;
            this.groupBoxBooking.TabStop = false;
            this.groupBoxBooking.Text = "Booking Details";
            // 
            // listViewBooking
            // 
            this.listViewBooking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadEquipment,
            this.colHeadQuantity});
            this.listViewBooking.FullRowSelect = true;
            this.listViewBooking.GridLines = true;
            this.listViewBooking.HideSelection = false;
            this.listViewBooking.Location = new System.Drawing.Point(21, 167);
            this.listViewBooking.MultiSelect = false;
            this.listViewBooking.Name = "listViewBooking";
            this.listViewBooking.Size = new System.Drawing.Size(488, 97);
            this.listViewBooking.TabIndex = 9;
            this.listViewBooking.UseCompatibleStateImageBehavior = false;
            this.listViewBooking.View = System.Windows.Forms.View.Details;
            // 
            // colHeadEquipment
            // 
            this.colHeadEquipment.Text = "Equipment";
            this.colHeadEquipment.Width = 407;
            // 
            // colHeadQuantity
            // 
            this.colHeadQuantity.Text = "Quantity";
            // 
            // dateTimeDue
            // 
            this.dateTimeDue.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDue.Location = new System.Drawing.Point(328, 12);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(181, 20);
            this.dateTimeDue.TabIndex = 51;
            this.dateTimeDue.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            // 
            // btnAddEquipment
            // 
            this.btnAddEquipment.Location = new System.Drawing.Point(453, 138);
            this.btnAddEquipment.Name = "btnAddEquipment";
            this.btnAddEquipment.Size = new System.Drawing.Size(56, 23);
            this.btnAddEquipment.TabIndex = 8;
            this.btnAddEquipment.Text = "Add";
            this.btnAddEquipment.UseVisualStyleBackColor = true;
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 503);
            this.Controls.Add(this.btnAddEquipment);
            this.Controls.Add(this.listViewBooking);
            this.Controls.Add(this.groupBoxBooking);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtEquipment);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.dateTimeIssued);
            this.Controls.Add(this.dateTimeDue);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblIssued);
            this.Name = "frmBooking";
            this.Text = "Booking Form";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.groupBoxBooking.ResumeLayout(false);
            this.groupBoxBooking.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxBooking;
        private System.Windows.Forms.ListView listViewBooking;
        private System.Windows.Forms.ColumnHeader colHeadEquipment;
        private System.Windows.Forms.ColumnHeader colHeadQuantity;
        private System.Windows.Forms.DateTimePicker dateTimeDue;
        private System.Windows.Forms.Button btnAddEquipment;
    }
}