﻿namespace FilmStudio
{
    partial class frmEnrolment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnrolment));
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxInstructor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.btnInstructor = new System.Windows.Forms.Button();
            this.btnEnrolment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(100, 12);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(163, 21);
            this.comboBoxStudent.TabIndex = 0;
            this.comboBoxStudent.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudent_SelectedIndexChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(100, 39);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(163, 21);
            this.comboBoxCourse.TabIndex = 1;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // comboBoxInstructor
            // 
            this.comboBoxInstructor.FormattingEnabled = true;
            this.comboBoxInstructor.Location = new System.Drawing.Point(100, 66);
            this.comboBoxInstructor.Name = "comboBoxInstructor";
            this.comboBoxInstructor.Size = new System.Drawing.Size(163, 21);
            this.comboBoxInstructor.TabIndex = 2;
            this.comboBoxInstructor.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstructor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Instructor Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Term";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 20);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(269, 10);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(75, 23);
            this.btnStudent.TabIndex = 8;
            this.btnStudent.Text = "Add New";
            this.btnStudent.UseVisualStyleBackColor = true;
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(269, 37);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(75, 23);
            this.btnCourse.TabIndex = 9;
            this.btnCourse.Text = "Add New";
            this.btnCourse.UseVisualStyleBackColor = true;
            // 
            // btnInstructor
            // 
            this.btnInstructor.Location = new System.Drawing.Point(269, 64);
            this.btnInstructor.Name = "btnInstructor";
            this.btnInstructor.Size = new System.Drawing.Size(75, 23);
            this.btnInstructor.TabIndex = 10;
            this.btnInstructor.Text = "Add New";
            this.btnInstructor.UseVisualStyleBackColor = true;
            // 
            // btnEnrolment
            // 
            this.btnEnrolment.Location = new System.Drawing.Point(136, 119);
            this.btnEnrolment.Name = "btnEnrolment";
            this.btnEnrolment.Size = new System.Drawing.Size(85, 23);
            this.btnEnrolment.TabIndex = 11;
            this.btnEnrolment.Text = "Add Enrolment";
            this.btnEnrolment.UseVisualStyleBackColor = true;
            // 
            // frmEnrolment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 149);
            this.Controls.Add(this.btnEnrolment);
            this.Controls.Add(this.btnInstructor);
            this.Controls.Add(this.btnCourse);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxInstructor);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.comboBoxStudent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEnrolment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Enrolment";
            this.Load += new System.EventHandler(this.frmEnrolment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.ComboBox comboBoxInstructor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnInstructor;
        private System.Windows.Forms.Button btnEnrolment;
    }
}