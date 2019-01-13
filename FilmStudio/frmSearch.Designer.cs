namespace FilmStudio
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.tabBooking = new System.Windows.Forms.TabPage();
            this.groupBoxBookingCriteria = new System.Windows.Forms.GroupBox();
            this.rbtnStudent = new System.Windows.Forms.RadioButton();
            this.rbtnEquip = new System.Windows.Forms.RadioButton();
            this.rbtnDue = new System.Windows.Forms.RadioButton();
            this.rbtnIssue = new System.Windows.Forms.RadioButton();
            this.rbtnReturn = new System.Windows.Forms.RadioButton();
            this.rbtnCourse = new System.Windows.Forms.RadioButton();
            this.rbtnInst = new System.Windows.Forms.RadioButton();
            this.rbtnStaff = new System.Windows.Forms.RadioButton();
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxEquip = new System.Windows.Forms.ComboBox();
            this.dateTimeDueF = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDueT = new System.Windows.Forms.DateTimePicker();
            this.dateTimeIssueF = new System.Windows.Forms.DateTimePicker();
            this.dateTimeIssueT = new System.Windows.Forms.DateTimePicker();
            this.dateTimeReturnF = new System.Windows.Forms.DateTimePicker();
            this.dateTimeReturnT = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxInst = new System.Windows.Forms.ComboBox();
            this.comboBoxStaff = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.tabBooking.SuspendLayout();
            this.groupBoxBookingCriteria.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Location = new System.Drawing.Point(12, 266);
            this.dataGridResults.MultiSelect = false;
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridResults.Size = new System.Drawing.Size(578, 150);
            this.dataGridResults.TabIndex = 1;
            this.dataGridResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellDoubleClick);
            // 
            // tabBooking
            // 
            this.tabBooking.BackColor = System.Drawing.SystemColors.Control;
            this.tabBooking.Controls.Add(this.comboBoxStaff);
            this.tabBooking.Controls.Add(this.comboBoxInst);
            this.tabBooking.Controls.Add(this.comboBoxCourse);
            this.tabBooking.Controls.Add(this.dateTimeReturnT);
            this.tabBooking.Controls.Add(this.dateTimeReturnF);
            this.tabBooking.Controls.Add(this.dateTimeIssueT);
            this.tabBooking.Controls.Add(this.dateTimeIssueF);
            this.tabBooking.Controls.Add(this.dateTimeDueT);
            this.tabBooking.Controls.Add(this.dateTimeDueF);
            this.tabBooking.Controls.Add(this.comboBoxEquip);
            this.tabBooking.Controls.Add(this.comboBoxStudent);
            this.tabBooking.Controls.Add(this.groupBoxBookingCriteria);
            this.tabBooking.Location = new System.Drawing.Point(4, 22);
            this.tabBooking.Name = "tabBooking";
            this.tabBooking.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooking.Size = new System.Drawing.Size(570, 222);
            this.tabBooking.TabIndex = 0;
            this.tabBooking.Text = "Booking";
            // 
            // groupBoxBookingCriteria
            // 
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnStaff);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnInst);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnCourse);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnReturn);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnIssue);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnDue);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnEquip);
            this.groupBoxBookingCriteria.Controls.Add(this.rbtnStudent);
            this.groupBoxBookingCriteria.Location = new System.Drawing.Point(6, 6);
            this.groupBoxBookingCriteria.Name = "groupBoxBookingCriteria";
            this.groupBoxBookingCriteria.Size = new System.Drawing.Size(144, 210);
            this.groupBoxBookingCriteria.TabIndex = 0;
            this.groupBoxBookingCriteria.TabStop = false;
            this.groupBoxBookingCriteria.Text = "Criteria";
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.AutoSize = true;
            this.rbtnStudent.Location = new System.Drawing.Point(6, 19);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(111, 17);
            this.rbtnStudent.TabIndex = 0;
            this.rbtnStudent.TabStop = true;
            this.rbtnStudent.Text = "Student\'s HabibID";
            this.rbtnStudent.UseVisualStyleBackColor = true;
            this.rbtnStudent.CheckedChanged += new System.EventHandler(this.rbtnStudent_CheckedChanged);
            // 
            // rbtnEquip
            // 
            this.rbtnEquip.AutoSize = true;
            this.rbtnEquip.Location = new System.Drawing.Point(6, 42);
            this.rbtnEquip.Name = "rbtnEquip";
            this.rbtnEquip.Size = new System.Drawing.Size(131, 17);
            this.rbtnEquip.TabIndex = 1;
            this.rbtnEquip.TabStop = true;
            this.rbtnEquip.Text = "Equipment Description";
            this.rbtnEquip.UseVisualStyleBackColor = true;
            this.rbtnEquip.CheckedChanged += new System.EventHandler(this.rbtnEquip_CheckedChanged);
            // 
            // rbtnDue
            // 
            this.rbtnDue.AutoSize = true;
            this.rbtnDue.Location = new System.Drawing.Point(6, 65);
            this.rbtnDue.Name = "rbtnDue";
            this.rbtnDue.Size = new System.Drawing.Size(112, 17);
            this.rbtnDue.TabIndex = 2;
            this.rbtnDue.TabStop = true;
            this.rbtnDue.Text = "Due Date (Range)";
            this.rbtnDue.UseVisualStyleBackColor = true;
            this.rbtnDue.CheckedChanged += new System.EventHandler(this.rbtnDue_CheckedChanged);
            // 
            // rbtnIssue
            // 
            this.rbtnIssue.AutoSize = true;
            this.rbtnIssue.Location = new System.Drawing.Point(6, 88);
            this.rbtnIssue.Name = "rbtnIssue";
            this.rbtnIssue.Size = new System.Drawing.Size(117, 17);
            this.rbtnIssue.TabIndex = 3;
            this.rbtnIssue.TabStop = true;
            this.rbtnIssue.Text = "Issue Date (Range)";
            this.rbtnIssue.UseVisualStyleBackColor = true;
            this.rbtnIssue.CheckedChanged += new System.EventHandler(this.rbtnIssue_CheckedChanged);
            // 
            // rbtnReturn
            // 
            this.rbtnReturn.AutoSize = true;
            this.rbtnReturn.Location = new System.Drawing.Point(6, 111);
            this.rbtnReturn.Name = "rbtnReturn";
            this.rbtnReturn.Size = new System.Drawing.Size(124, 17);
            this.rbtnReturn.TabIndex = 4;
            this.rbtnReturn.TabStop = true;
            this.rbtnReturn.Text = "Return Date (Range)";
            this.rbtnReturn.UseVisualStyleBackColor = true;
            this.rbtnReturn.CheckedChanged += new System.EventHandler(this.rbtnReturn_CheckedChanged);
            // 
            // rbtnCourse
            // 
            this.rbtnCourse.AutoSize = true;
            this.rbtnCourse.Location = new System.Drawing.Point(6, 134);
            this.rbtnCourse.Name = "rbtnCourse";
            this.rbtnCourse.Size = new System.Drawing.Size(105, 17);
            this.rbtnCourse.TabIndex = 5;
            this.rbtnCourse.TabStop = true;
            this.rbtnCourse.Text = "Student\'s Course";
            this.rbtnCourse.UseVisualStyleBackColor = true;
            this.rbtnCourse.CheckedChanged += new System.EventHandler(this.rbtnCourse_CheckedChanged);
            // 
            // rbtnInst
            // 
            this.rbtnInst.AutoSize = true;
            this.rbtnInst.Location = new System.Drawing.Point(6, 157);
            this.rbtnInst.Name = "rbtnInst";
            this.rbtnInst.Size = new System.Drawing.Size(69, 17);
            this.rbtnInst.TabIndex = 6;
            this.rbtnInst.TabStop = true;
            this.rbtnInst.Text = "Instructor";
            this.rbtnInst.UseVisualStyleBackColor = true;
            this.rbtnInst.CheckedChanged += new System.EventHandler(this.rbtnInst_CheckedChanged);
            // 
            // rbtnStaff
            // 
            this.rbtnStaff.AutoSize = true;
            this.rbtnStaff.Location = new System.Drawing.Point(6, 180);
            this.rbtnStaff.Name = "rbtnStaff";
            this.rbtnStaff.Size = new System.Drawing.Size(47, 17);
            this.rbtnStaff.TabIndex = 7;
            this.rbtnStaff.TabStop = true;
            this.rbtnStaff.Text = "Staff";
            this.rbtnStaff.UseVisualStyleBackColor = true;
            this.rbtnStaff.CheckedChanged += new System.EventHandler(this.rbtnStaff_CheckedChanged);
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(157, 25);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStudent.TabIndex = 1;
            this.comboBoxStudent.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudent_SelectedIndexChanged);
            // 
            // comboBoxEquip
            // 
            this.comboBoxEquip.FormattingEnabled = true;
            this.comboBoxEquip.Location = new System.Drawing.Point(157, 48);
            this.comboBoxEquip.Name = "comboBoxEquip";
            this.comboBoxEquip.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEquip.TabIndex = 2;
            this.comboBoxEquip.SelectedIndexChanged += new System.EventHandler(this.comboBoxEquip_SelectedIndexChanged);
            // 
            // dateTimeDueF
            // 
            this.dateTimeDueF.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeDueF.Location = new System.Drawing.Point(157, 71);
            this.dateTimeDueF.Name = "dateTimeDueF";
            this.dateTimeDueF.Size = new System.Drawing.Size(200, 20);
            this.dateTimeDueF.TabIndex = 3;
            this.dateTimeDueF.ValueChanged += new System.EventHandler(this.dateTimeDueF_ValueChanged);
            // 
            // dateTimeDueT
            // 
            this.dateTimeDueT.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeDueT.Location = new System.Drawing.Point(364, 71);
            this.dateTimeDueT.Name = "dateTimeDueT";
            this.dateTimeDueT.Size = new System.Drawing.Size(200, 20);
            this.dateTimeDueT.TabIndex = 4;
            this.dateTimeDueT.ValueChanged += new System.EventHandler(this.dateTimeDueT_ValueChanged);
            // 
            // dateTimeIssueF
            // 
            this.dateTimeIssueF.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeIssueF.Location = new System.Drawing.Point(157, 94);
            this.dateTimeIssueF.Name = "dateTimeIssueF";
            this.dateTimeIssueF.Size = new System.Drawing.Size(200, 20);
            this.dateTimeIssueF.TabIndex = 5;
            this.dateTimeIssueF.ValueChanged += new System.EventHandler(this.dateTimeIssueF_ValueChanged);
            // 
            // dateTimeIssueT
            // 
            this.dateTimeIssueT.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeIssueT.Location = new System.Drawing.Point(364, 94);
            this.dateTimeIssueT.Name = "dateTimeIssueT";
            this.dateTimeIssueT.Size = new System.Drawing.Size(200, 20);
            this.dateTimeIssueT.TabIndex = 6;
            this.dateTimeIssueT.ValueChanged += new System.EventHandler(this.dateTimeIssueT_ValueChanged);
            // 
            // dateTimeReturnF
            // 
            this.dateTimeReturnF.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeReturnF.Location = new System.Drawing.Point(157, 117);
            this.dateTimeReturnF.Name = "dateTimeReturnF";
            this.dateTimeReturnF.Size = new System.Drawing.Size(200, 20);
            this.dateTimeReturnF.TabIndex = 7;
            this.dateTimeReturnF.ValueChanged += new System.EventHandler(this.dateTimeReturnF_ValueChanged);
            // 
            // dateTimeReturnT
            // 
            this.dateTimeReturnT.CustomFormat = "dd/MM/yy dddd";
            this.dateTimeReturnT.Location = new System.Drawing.Point(364, 117);
            this.dateTimeReturnT.Name = "dateTimeReturnT";
            this.dateTimeReturnT.Size = new System.Drawing.Size(200, 20);
            this.dateTimeReturnT.TabIndex = 8;
            this.dateTimeReturnT.ValueChanged += new System.EventHandler(this.dateTimeReturnT_ValueChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(157, 140);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCourse.TabIndex = 9;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // comboBoxInst
            // 
            this.comboBoxInst.FormattingEnabled = true;
            this.comboBoxInst.Location = new System.Drawing.Point(157, 163);
            this.comboBoxInst.Name = "comboBoxInst";
            this.comboBoxInst.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInst.TabIndex = 10;
            this.comboBoxInst.SelectedIndexChanged += new System.EventHandler(this.comboBoxInst_SelectedIndexChanged);
            // 
            // comboBoxStaff
            // 
            this.comboBoxStaff.FormattingEnabled = true;
            this.comboBoxStaff.Location = new System.Drawing.Point(157, 186);
            this.comboBoxStaff.Name = "comboBoxStaff";
            this.comboBoxStaff.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStaff.TabIndex = 11;
            this.comboBoxStaff.SelectedIndexChanged += new System.EventHandler(this.comboBoxStaff_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBooking);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(578, 248);
            this.tabControl.TabIndex = 0;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 431);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.tabBooking.ResumeLayout(false);
            this.groupBoxBookingCriteria.ResumeLayout(false);
            this.groupBoxBookingCriteria.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.TabPage tabBooking;
        private System.Windows.Forms.ComboBox comboBoxStaff;
        private System.Windows.Forms.ComboBox comboBoxInst;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.DateTimePicker dateTimeReturnT;
        private System.Windows.Forms.DateTimePicker dateTimeReturnF;
        private System.Windows.Forms.DateTimePicker dateTimeIssueT;
        private System.Windows.Forms.DateTimePicker dateTimeIssueF;
        private System.Windows.Forms.DateTimePicker dateTimeDueT;
        private System.Windows.Forms.DateTimePicker dateTimeDueF;
        private System.Windows.Forms.ComboBox comboBoxEquip;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.GroupBox groupBoxBookingCriteria;
        private System.Windows.Forms.RadioButton rbtnStaff;
        private System.Windows.Forms.RadioButton rbtnInst;
        private System.Windows.Forms.RadioButton rbtnCourse;
        private System.Windows.Forms.RadioButton rbtnReturn;
        private System.Windows.Forms.RadioButton rbtnIssue;
        private System.Windows.Forms.RadioButton rbtnDue;
        private System.Windows.Forms.RadioButton rbtnEquip;
        private System.Windows.Forms.RadioButton rbtnStudent;
        private System.Windows.Forms.TabControl tabControl;
    }
}