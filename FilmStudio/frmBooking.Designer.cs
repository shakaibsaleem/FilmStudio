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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
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
            this.lblEquipment = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.groupBoxBooking = new System.Windows.Forms.GroupBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.txtInstructor = new System.Windows.Forms.TextBox();
            this.txtHabibID = new System.Windows.Forms.TextBox();
            this.comboBoxInstructor = new System.Windows.Forms.ComboBox();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.listViewBooking = new System.Windows.Forms.ListView();
            this.colHeadEquipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimeDue = new System.Windows.Forms.DateTimePicker();
            this.btnAddEquipment = new System.Windows.Forms.Button();
            this.groupBoxBookedBy = new System.Windows.Forms.GroupBox();
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
            this.groupBoxEquipment = new System.Windows.Forms.GroupBox();
            this.lblBooked = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.comboBoxEquipment = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.checkBoxOffCampus = new System.Windows.Forms.CheckBox();
            this.checkBoxReturned = new System.Windows.Forms.CheckBox();
            this.dateTimeReturned = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxBooking.SuspendLayout();
            this.groupBoxBookedBy.SuspendLayout();
            this.groupBoxEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(231, 16);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(455, 16);
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
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
            this.dateTimeIssued.Location = new System.Drawing.Point(82, 12);
            this.dateTimeIssued.Name = "dateTimeIssued";
            this.dateTimeIssued.Size = new System.Drawing.Size(189, 20);
            this.dateTimeIssued.TabIndex = 50;
            this.dateTimeIssued.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            this.dateTimeIssued.ValueChanged += new System.EventHandler(this.dateTimeIssued_ValueChanged);
            // 
            // lblIssued
            // 
            this.lblIssued.AutoSize = true;
            this.lblIssued.Location = new System.Drawing.Point(18, 15);
            this.lblIssued.Name = "lblIssued";
            this.lblIssued.Size = new System.Drawing.Size(58, 13);
            this.lblIssued.TabIndex = 100;
            this.lblIssued.Text = "Issued On:";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(325, 15);
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
            this.txtAssignment.TabIndex = 57;
            this.txtAssignment.TextChanged += new System.EventHandler(this.txtAssignment_TextChanged);
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(6, 22);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(60, 13);
            this.lblEquipment.TabIndex = 109;
            this.lblEquipment.Text = "Equipment:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(395, 22);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 110;
            this.lblQuantity.Text = "Quantity:";
            // 
            // groupBoxBooking
            // 
            this.groupBoxBooking.Controls.Add(this.txtCourse);
            this.groupBoxBooking.Controls.Add(this.txtInstructor);
            this.groupBoxBooking.Controls.Add(this.txtHabibID);
            this.groupBoxBooking.Controls.Add(this.comboBoxInstructor);
            this.groupBoxBooking.Controls.Add(this.comboBoxID);
            this.groupBoxBooking.Controls.Add(this.comboBoxCourse);
            this.groupBoxBooking.Controls.Add(this.lblHabibID);
            this.groupBoxBooking.Controls.Add(this.txtName);
            this.groupBoxBooking.Controls.Add(this.txtContact);
            this.groupBoxBooking.Controls.Add(this.lblName);
            this.groupBoxBooking.Controls.Add(this.lblContact);
            this.groupBoxBooking.Controls.Add(this.txtAssignment);
            this.groupBoxBooking.Controls.Add(this.lblInstructor);
            this.groupBoxBooking.Controls.Add(this.lblCourse);
            this.groupBoxBooking.Controls.Add(this.lblAssignment);
            this.groupBoxBooking.Location = new System.Drawing.Point(12, 86);
            this.groupBoxBooking.Name = "groupBoxBooking";
            this.groupBoxBooking.Size = new System.Drawing.Size(561, 69);
            this.groupBoxBooking.TabIndex = 56;
            this.groupBoxBooking.TabStop = false;
            this.groupBoxBooking.Text = "Booking Details";
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(231, 43);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.ReadOnly = true;
            this.txtCourse.Size = new System.Drawing.Size(158, 20);
            this.txtCourse.TabIndex = 124;
            this.txtCourse.Visible = false;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(455, 43);
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.ReadOnly = true;
            this.txtInstructor.Size = new System.Drawing.Size(100, 20);
            this.txtInstructor.TabIndex = 123;
            this.txtInstructor.Visible = false;
            // 
            // txtHabibID
            // 
            this.txtHabibID.Location = new System.Drawing.Point(76, 16);
            this.txtHabibID.Name = "txtHabibID";
            this.txtHabibID.ReadOnly = true;
            this.txtHabibID.Size = new System.Drawing.Size(100, 20);
            this.txtHabibID.TabIndex = 122;
            this.txtHabibID.Visible = false;
            // 
            // comboBoxInstructor
            // 
            this.comboBoxInstructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInstructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInstructor.DropDownHeight = 80;
            this.comboBoxInstructor.FormattingEnabled = true;
            this.comboBoxInstructor.IntegralHeight = false;
            this.comboBoxInstructor.Location = new System.Drawing.Point(455, 42);
            this.comboBoxInstructor.Name = "comboBoxInstructor";
            this.comboBoxInstructor.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInstructor.TabIndex = 59;
            this.comboBoxInstructor.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstructor_SelectedIndexChanged);
            // 
            // comboBoxID
            // 
            this.comboBoxID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxID.DropDownHeight = 80;
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.IntegralHeight = false;
            this.comboBoxID.Location = new System.Drawing.Point(76, 15);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(100, 21);
            this.comboBoxID.TabIndex = 56;
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCourse.DropDownHeight = 80;
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.IntegralHeight = false;
            this.comboBoxCourse.Location = new System.Drawing.Point(231, 42);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(158, 21);
            this.comboBoxCourse.TabIndex = 58;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // listViewBooking
            // 
            this.listViewBooking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadEquipment,
            this.colHeadQuantity});
            this.listViewBooking.FullRowSelect = true;
            this.listViewBooking.GridLines = true;
            this.listViewBooking.HideSelection = false;
            this.listViewBooking.Location = new System.Drawing.Point(12, 241);
            this.listViewBooking.MultiSelect = false;
            this.listViewBooking.Name = "listViewBooking";
            this.listViewBooking.Size = new System.Drawing.Size(561, 97);
            this.listViewBooking.TabIndex = 9;
            this.listViewBooking.UseCompatibleStateImageBehavior = false;
            this.listViewBooking.View = System.Windows.Forms.View.Details;
            this.listViewBooking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewBooking_KeyDown);
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
            this.dateTimeDue.Location = new System.Drawing.Point(378, 12);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(189, 20);
            this.dateTimeDue.TabIndex = 51;
            this.dateTimeDue.Value = new System.DateTime(2018, 11, 8, 12, 30, 0, 0);
            this.dateTimeDue.ValueChanged += new System.EventHandler(this.dateTimeDue_ValueChanged);
            // 
            // btnAddEquipment
            // 
            this.btnAddEquipment.Location = new System.Drawing.Point(480, 45);
            this.btnAddEquipment.Name = "btnAddEquipment";
            this.btnAddEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnAddEquipment.TabIndex = 62;
            this.btnAddEquipment.Text = "Add to list";
            this.btnAddEquipment.UseVisualStyleBackColor = true;
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);
            // 
            // groupBoxBookedBy
            // 
            this.groupBoxBookedBy.Controls.Add(this.rbtnStaff);
            this.groupBoxBookedBy.Controls.Add(this.rbtnInstructor);
            this.groupBoxBookedBy.Controls.Add(this.rbtnStudent);
            this.groupBoxBookedBy.Location = new System.Drawing.Point(12, 38);
            this.groupBoxBookedBy.Name = "groupBoxBookedBy";
            this.groupBoxBookedBy.Size = new System.Drawing.Size(202, 42);
            this.groupBoxBookedBy.TabIndex = 52;
            this.groupBoxBookedBy.TabStop = false;
            this.groupBoxBookedBy.Text = "Booked By";
            // 
            // rbtnStaff
            // 
            this.rbtnStaff.AutoSize = true;
            this.rbtnStaff.Location = new System.Drawing.Point(149, 19);
            this.rbtnStaff.Name = "rbtnStaff";
            this.rbtnStaff.Size = new System.Drawing.Size(47, 17);
            this.rbtnStaff.TabIndex = 52;
            this.rbtnStaff.TabStop = true;
            this.rbtnStaff.Text = "Staff";
            this.rbtnStaff.UseVisualStyleBackColor = true;
            this.rbtnStaff.CheckedChanged += new System.EventHandler(this.rbtnStaff_CheckedChanged);
            // 
            // rbtnInstructor
            // 
            this.rbtnInstructor.AutoSize = true;
            this.rbtnInstructor.Location = new System.Drawing.Point(74, 19);
            this.rbtnInstructor.Name = "rbtnInstructor";
            this.rbtnInstructor.Size = new System.Drawing.Size(69, 17);
            this.rbtnInstructor.TabIndex = 52;
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
            this.rbtnStudent.TabIndex = 52;
            this.rbtnStudent.TabStop = true;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = true;
            this.rbtnStudent.CheckedChanged += new System.EventHandler(this.rbtnStudent_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(93, 370);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 68;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(174, 370);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 67;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(255, 370);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 63;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 370);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(498, 370);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 54;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBoxEquipment
            // 
            this.groupBoxEquipment.Controls.Add(this.lblBooked);
            this.groupBoxEquipment.Controls.Add(this.txtTotal);
            this.groupBoxEquipment.Controls.Add(this.txtAvailable);
            this.groupBoxEquipment.Controls.Add(this.lblAvailable);
            this.groupBoxEquipment.Controls.Add(this.comboBoxEquipment);
            this.groupBoxEquipment.Controls.Add(this.numQuantity);
            this.groupBoxEquipment.Controls.Add(this.btnAddEquipment);
            this.groupBoxEquipment.Controls.Add(this.lblQuantity);
            this.groupBoxEquipment.Controls.Add(this.lblEquipment);
            this.groupBoxEquipment.Location = new System.Drawing.Point(12, 161);
            this.groupBoxEquipment.Name = "groupBoxEquipment";
            this.groupBoxEquipment.Size = new System.Drawing.Size(561, 74);
            this.groupBoxEquipment.TabIndex = 60;
            this.groupBoxEquipment.TabStop = false;
            this.groupBoxEquipment.Text = "Equipment Details";
            // 
            // lblBooked
            // 
            this.lblBooked.AutoSize = true;
            this.lblBooked.Location = new System.Drawing.Point(182, 50);
            this.lblBooked.Name = "lblBooked";
            this.lblBooked.Size = new System.Drawing.Size(34, 13);
            this.lblBooked.TabIndex = 115;
            this.lblBooked.Text = "Total:";
            this.lblBooked.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(231, 47);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 114;
            this.txtTotal.Visible = false;
            // 
            // txtAvailable
            // 
            this.txtAvailable.Location = new System.Drawing.Point(76, 47);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.ReadOnly = true;
            this.txtAvailable.Size = new System.Drawing.Size(100, 20);
            this.txtAvailable.TabIndex = 113;
            this.txtAvailable.Text = "0";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(6, 50);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(53, 13);
            this.lblAvailable.TabIndex = 112;
            this.lblAvailable.Text = "Available:";
            // 
            // comboBoxEquipment
            // 
            this.comboBoxEquipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEquipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEquipment.DropDownHeight = 80;
            this.comboBoxEquipment.FormattingEnabled = true;
            this.comboBoxEquipment.IntegralHeight = false;
            this.comboBoxEquipment.Location = new System.Drawing.Point(76, 18);
            this.comboBoxEquipment.Name = "comboBoxEquipment";
            this.comboBoxEquipment.Size = new System.Drawing.Size(313, 21);
            this.comboBoxEquipment.TabIndex = 60;
            this.comboBoxEquipment.SelectedIndexChanged += new System.EventHandler(this.comboBoxEquipment_SelectedIndexChanged);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(455, 19);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 61;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            this.numQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numQuantity_KeyPress);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(56, 344);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(517, 20);
            this.txtNotes.TabIndex = 62;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // checkBoxOffCampus
            // 
            this.checkBoxOffCampus.AutoSize = true;
            this.checkBoxOffCampus.Location = new System.Drawing.Point(220, 58);
            this.checkBoxOffCampus.Name = "checkBoxOffCampus";
            this.checkBoxOffCampus.Size = new System.Drawing.Size(81, 17);
            this.checkBoxOffCampus.TabIndex = 53;
            this.checkBoxOffCampus.Text = "Off Campus";
            this.checkBoxOffCampus.UseVisualStyleBackColor = true;
            this.checkBoxOffCampus.CheckedChanged += new System.EventHandler(this.checkBoxOffCampus_CheckedChanged);
            // 
            // checkBoxReturned
            // 
            this.checkBoxReturned.AutoSize = true;
            this.checkBoxReturned.Enabled = false;
            this.checkBoxReturned.Location = new System.Drawing.Point(307, 58);
            this.checkBoxReturned.Name = "checkBoxReturned";
            this.checkBoxReturned.Size = new System.Drawing.Size(73, 17);
            this.checkBoxReturned.TabIndex = 54;
            this.checkBoxReturned.Text = "Returned:";
            this.checkBoxReturned.UseVisualStyleBackColor = true;
            this.checkBoxReturned.CheckedChanged += new System.EventHandler(this.checkBoxReturned_CheckedChanged);
            // 
            // dateTimeReturned
            // 
            this.dateTimeReturned.CustomFormat = "dd/MM/yy ddd hh:mm tt";
            this.dateTimeReturned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeReturned.Location = new System.Drawing.Point(378, 56);
            this.dateTimeReturned.Name = "dateTimeReturned";
            this.dateTimeReturned.Size = new System.Drawing.Size(189, 20);
            this.dateTimeReturned.TabIndex = 55;
            this.dateTimeReturned.Visible = false;
            this.dateTimeReturned.ValueChanged += new System.EventHandler(this.dateTimeReturned_ValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(498, 370);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 64;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 267);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Declaration:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "__________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "__________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Signature - Film Studio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Signature - Booked By";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(549, 110);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 128;
            this.label5.Text = "Notes:";
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 400);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dateTimeReturned);
            this.Controls.Add(this.checkBoxReturned);
            this.Controls.Add(this.checkBoxOffCampus);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.groupBoxEquipment);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxBookedBy);
            this.Controls.Add(this.listViewBooking);
            this.Controls.Add(this.groupBoxBooking);
            this.Controls.Add(this.dateTimeIssued);
            this.Controls.Add(this.dateTimeDue);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblIssued);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Form";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.groupBoxBooking.ResumeLayout(false);
            this.groupBoxBooking.PerformLayout();
            this.groupBoxBookedBy.ResumeLayout(false);
            this.groupBoxBookedBy.PerformLayout();
            this.groupBoxEquipment.ResumeLayout(false);
            this.groupBoxEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.GroupBox groupBoxBooking;
        private System.Windows.Forms.ListView listViewBooking;
        private System.Windows.Forms.ColumnHeader colHeadEquipment;
        private System.Windows.Forms.ColumnHeader colHeadQuantity;
        private System.Windows.Forms.DateTimePicker dateTimeDue;
        private System.Windows.Forms.Button btnAddEquipment;
        private System.Windows.Forms.GroupBox groupBoxBookedBy;
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
        private System.Windows.Forms.GroupBox groupBoxEquipment;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.ComboBox comboBoxInstructor;
        private System.Windows.Forms.ComboBox comboBoxEquipment;
        private System.Windows.Forms.Label lblBooked;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.TextBox txtInstructor;
        private System.Windows.Forms.TextBox txtHabibID;
        private System.Windows.Forms.CheckBox checkBoxOffCampus;
        private System.Windows.Forms.CheckBox checkBoxReturned;
        private System.Windows.Forms.DateTimePicker dateTimeReturned;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}