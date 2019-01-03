namespace FilmStudio
{
    partial class frmMenu
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
            this.groupBoxTask = new System.Windows.Forms.GroupBox();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.rbtnSearch = new System.Windows.Forms.RadioButton();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBoxTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add(this.rbtnSearch);
            this.groupBoxTask.Controls.Add(this.rbtnAdd);
            this.groupBoxTask.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size(109, 72);
            this.groupBoxTask.TabIndex = 0;
            this.groupBoxTask.TabStop = false;
            this.groupBoxTask.Text = "Task:";
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(6, 19);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(82, 17);
            this.rbtnAdd.TabIndex = 0;
            this.rbtnAdd.TabStop = true;
            this.rbtnAdd.Text = "Add Record";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.CheckedChanged += new System.EventHandler(this.rbtnAdd_CheckedChanged);
            // 
            // rbtnSearch
            // 
            this.rbtnSearch.AutoSize = true;
            this.rbtnSearch.Location = new System.Drawing.Point(6, 42);
            this.rbtnSearch.Name = "rbtnSearch";
            this.rbtnSearch.Size = new System.Drawing.Size(97, 17);
            this.rbtnSearch.TabIndex = 1;
            this.rbtnSearch.TabStop = true;
            this.rbtnSearch.Text = "Search Record";
            this.rbtnSearch.UseVisualStyleBackColor = true;
            this.rbtnSearch.CheckedChanged += new System.EventHandler(this.rbtnSearch_CheckedChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(205, 30);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            this.comboBoxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxType_KeyPress);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(280, 61);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(46, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(127, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(72, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Record Type:";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 96);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.groupBoxTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMenu_KeyPress);
            this.groupBoxTask.ResumeLayout(false);
            this.groupBoxTask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.RadioButton rbtnSearch;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblType;
    }
}