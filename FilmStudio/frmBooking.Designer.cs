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
            this.txtHabibID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblHabibID = new System.Windows.Forms.Label();
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.listViewBooking = new System.Windows.Forms.ListView();
            this.colHeadEquipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimeDue = new System.Windows.Forms.DateTimePicker();
            this.btnAddEquipment = new System.Windows.Forms.Button();
            this.groupBoxBookedFor = new System.Windows.Forms.GroupBox();
            this.rbtnStaff = new System.Windows.Forms.RadioButton();
            this.rbtnInstructor = new System.Windows.Forms.RadioButton();
            this.rbtnStudent = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxBookedFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHabibID
            // 
            this.txtHabibID.Location = new System.Drawing.Point(76, 16);
            this.txtHabibID.Name = "txtHabibID";
            this.txtHabibID.Size = new System.Drawing.Size(100, 20);
            this.txtHabibID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(231, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(455, 16);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 2;
            // 
            // lblHabibID
            // 
            this.lblHabibID.AutoSize = true;
            this.lblHabibID.Location = new System.Drawing.Point(6, 19);
            this.lblHabibID.Name = "lblHabibID";
            this.lblHabibID.Size = new System.Drawing.Size(52, 13);
            this.lblHabibID.TabIndex = 103;
            this.lblHabibID.Text = "Habib ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(182, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 104;
            this.lblName.Text = "Name:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(395, 19);
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
            this.dateTimeIssued.Size = new System.Drawing.Size(210, 20);
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
            this.lblDue.Location = new System.Drawing.Point(304, 18);
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
            this.lblCourse.Location = new System.Drawing.Point(182, 45);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 107;
            this.lblCourse.Text = "Course:";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Location = new System.Drawing.Point(395, 45);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(54, 13);
            this.lblInstructor.TabIndex = 108;
            this.lblInstructor.Text = "Instructor:";
            // 
            // txtAssignment
            // 
            this.txtAssignment.Location = new System.Drawing.Point(76, 42);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(100, 20);
            this.txtAssignment.TabIndex = 3;
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(231, 42);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(158, 20);
            this.txtCourse.TabIndex = 4;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(455, 42);
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Size = new System.Drawing.Size(100, 20);
            this.txtInstructor.TabIndex = 5;
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(18, 163);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(60, 13);
            this.lblEquipment.TabIndex = 109;
            this.lblEquipment.Text = "Equipment:";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(88, 160);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(313, 20);
            this.txtEquipment.TabIndex = 6;
            this.txtEquipment.TextChanged += new System.EventHandler(this.txtEquipment_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(407, 163);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 110;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(467, 160);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 7;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblHabibID);
            this.groupBoxDetails.Controls.Add(this.txtHabibID);
            this.groupBoxDetails.Controls.Add(this.txtName);
            this.groupBoxDetails.Controls.Add(this.txtContact);
            this.groupBoxDetails.Controls.Add(this.lblName);
            this.groupBoxDetails.Controls.Add(this.txtInstructor);
            this.groupBoxDetails.Controls.Add(this.lblContact);
            this.groupBoxDetails.Controls.Add(this.txtCourse);
            this.groupBoxDetails.Controls.Add(this.txtAssignment);
            this.groupBoxDetails.Controls.Add(this.lblInstructor);
            this.groupBoxDetails.Controls.Add(this.lblCourse);
            this.groupBoxDetails.Controls.Add(this.lblAssignment);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 86);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(561, 68);
            this.groupBoxDetails.TabIndex = 102;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Booking Details";
            // 
            // listViewBooking
            // 
            this.listViewBooking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadEquipment,
            this.colHeadQuantity});
            this.listViewBooking.FullRowSelect = true;
            this.listViewBooking.GridLines = true;
            this.listViewBooking.HideSelection = false;
            this.listViewBooking.Location = new System.Drawing.Point(21, 215);
            this.listViewBooking.MultiSelect = false;
            this.listViewBooking.Name = "listViewBooking";
            this.listViewBooking.Size = new System.Drawing.Size(546, 97);
            this.listViewBooking.TabIndex = 9;
            this.listViewBooking.UseCompatibleStateImageBehavior = false;
            this.listViewBooking.View = System.Windows.Forms.View.Details;
            // 
            // colHeadEquipment
            // 
            this.colHeadEquipment.Text = "Equipment";
            this.colHeadEquipment.Width = 460;
            // 
            // colHeadQuantity
            // 
            this.colHeadQuantity.Text = "Quantity";
            // 
            // dateTimeDue
            // 
            this.dateTimeDue.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDue.Location = new System.Drawing.Point(357, 12);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(210, 20);
            this.dateTimeDue.TabIndex = 51;
            this.dateTimeDue.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            // 
            // btnAddEquipment
            // 
            this.btnAddEquipment.Location = new System.Drawing.Point(511, 186);
            this.btnAddEquipment.Name = "btnAddEquipment";
            this.btnAddEquipment.Size = new System.Drawing.Size(56, 23);
            this.btnAddEquipment.TabIndex = 8;
            this.btnAddEquipment.Text = "Add";
            this.btnAddEquipment.UseVisualStyleBackColor = true;
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);
            // 
            // groupBoxBookedFor
            // 
            this.groupBoxBookedFor.Controls.Add(this.rbtnStaff);
            this.groupBoxBookedFor.Controls.Add(this.rbtnInstructor);
            this.groupBoxBookedFor.Controls.Add(this.rbtnStudent);
            this.groupBoxBookedFor.Location = new System.Drawing.Point(12, 38);
            this.groupBoxBookedFor.Name = "groupBoxBookedFor";
            this.groupBoxBookedFor.Size = new System.Drawing.Size(561, 42);
            this.groupBoxBookedFor.TabIndex = 111;
            this.groupBoxBookedFor.TabStop = false;
            this.groupBoxBookedFor.Text = "Booked For";
            // 
            // rbtnStaff
            // 
            this.rbtnStaff.AutoSize = true;
            this.rbtnStaff.Location = new System.Drawing.Point(190, 19);
            this.rbtnStaff.Name = "rbtnStaff";
            this.rbtnStaff.Size = new System.Drawing.Size(47, 17);
            this.rbtnStaff.TabIndex = 2;
            this.rbtnStaff.TabStop = true;
            this.rbtnStaff.Text = "Staff";
            this.rbtnStaff.UseVisualStyleBackColor = true;
            this.rbtnStaff.CheckedChanged += new System.EventHandler(this.rbtnStaff_CheckedChanged);
            // 
            // rbtnInstructor
            // 
            this.rbtnInstructor.AutoSize = true;
            this.rbtnInstructor.Location = new System.Drawing.Point(95, 19);
            this.rbtnInstructor.Name = "rbtnInstructor";
            this.rbtnInstructor.Size = new System.Drawing.Size(69, 17);
            this.rbtnInstructor.TabIndex = 1;
            this.rbtnInstructor.TabStop = true;
            this.rbtnInstructor.Text = "Instructor";
            this.rbtnInstructor.UseVisualStyleBackColor = true;
            this.rbtnInstructor.CheckedChanged += new System.EventHandler(this.rbtnInstructor_CheckedChanged);
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.AutoSize = true;
            this.rbtnStudent.Location = new System.Drawing.Point(6, 19);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(62, 17);
            this.rbtnStudent.TabIndex = 0;
            this.rbtnStudent.TabStop = true;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = true;
            this.rbtnStudent.CheckedChanged += new System.EventHandler(this.rbtnStudent_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 112;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(93, 318);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 113;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(174, 318);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 114;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(255, 318);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 115;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 116;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 117;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(498, 318);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 118;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 353);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxBookedFor);
            this.Controls.Add(this.btnAddEquipment);
            this.Controls.Add(this.listViewBooking);
            this.Controls.Add(this.groupBoxDetails);
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
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxBookedFor.ResumeLayout(false);
            this.groupBoxBookedFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHabibID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblHabibID;
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
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.ListView listViewBooking;
        private System.Windows.Forms.ColumnHeader colHeadEquipment;
        private System.Windows.Forms.ColumnHeader colHeadQuantity;
        private System.Windows.Forms.DateTimePicker dateTimeDue;
        private System.Windows.Forms.Button btnAddEquipment;
        private System.Windows.Forms.GroupBox groupBoxBookedFor;
        private System.Windows.Forms.RadioButton rbtnStaff;
        private System.Windows.Forms.RadioButton rbtnInstructor;
        private System.Windows.Forms.RadioButton rbtnStudent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}