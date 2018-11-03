namespace FilmStudio
{
    partial class frmEquipment
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
            this.lblItemId = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtQtyAvailable = new System.Windows.Forms.TextBox();
            this.txtQtyBooked = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQtyAvailable = new System.Windows.Forms.Label();
            this.lblQtyBooked = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBoxItem = new System.Windows.Forms.GroupBox();
            this.groupBoxItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(6, 22);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(42, 13);
            this.lblItemId.TabIndex = 0;
            this.lblItemId.Text = "Item Id:";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(107, 19);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(75, 20);
            this.txtItemId.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(107, 97);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(448, 46);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(233, 45);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(322, 20);
            this.txtMake.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(233, 71);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(322, 20);
            this.txtModel.TabIndex = 5;
            // 
            // txtQtyAvailable
            // 
            this.txtQtyAvailable.Location = new System.Drawing.Point(107, 45);
            this.txtQtyAvailable.Name = "txtQtyAvailable";
            this.txtQtyAvailable.Size = new System.Drawing.Size(75, 20);
            this.txtQtyAvailable.TabIndex = 6;
            // 
            // txtQtyBooked
            // 
            this.txtQtyBooked.Location = new System.Drawing.Point(107, 71);
            this.txtQtyBooked.Name = "txtQtyBooked";
            this.txtQtyBooked.Size = new System.Drawing.Size(75, 20);
            this.txtQtyBooked.TabIndex = 7;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(107, 149);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(448, 46);
            this.txtRemarks.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Make:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Model:";
            // 
            // lblQtyAvailable
            // 
            this.lblQtyAvailable.AutoSize = true;
            this.lblQtyAvailable.Location = new System.Drawing.Point(6, 48);
            this.lblQtyAvailable.Name = "lblQtyAvailable";
            this.lblQtyAvailable.Size = new System.Drawing.Size(95, 13);
            this.lblQtyAvailable.TabIndex = 11;
            this.lblQtyAvailable.Text = "Quantity Available:";
            // 
            // lblQtyBooked
            // 
            this.lblQtyBooked.AutoSize = true;
            this.lblQtyBooked.Location = new System.Drawing.Point(6, 74);
            this.lblQtyBooked.Name = "lblQtyBooked";
            this.lblQtyBooked.Size = new System.Drawing.Size(89, 13);
            this.lblQtyBooked.TabIndex = 12;
            this.lblQtyBooked.Text = "Quantity Booked:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(6, 152);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 13;
            this.lblRemarks.Text = "Remarks:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(93, 219);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(174, 219);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(255, 219);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(498, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // groupBoxItem
            // 
            this.groupBoxItem.Controls.Add(this.lblItemId);
            this.groupBoxItem.Controls.Add(this.txtItemId);
            this.groupBoxItem.Controls.Add(this.txtDescription);
            this.groupBoxItem.Controls.Add(this.lblDescription);
            this.groupBoxItem.Controls.Add(this.txtMake);
            this.groupBoxItem.Controls.Add(this.txtModel);
            this.groupBoxItem.Controls.Add(this.txtQtyAvailable);
            this.groupBoxItem.Controls.Add(this.txtQtyBooked);
            this.groupBoxItem.Controls.Add(this.lblRemarks);
            this.groupBoxItem.Controls.Add(this.txtRemarks);
            this.groupBoxItem.Controls.Add(this.lblQtyBooked);
            this.groupBoxItem.Controls.Add(this.label1);
            this.groupBoxItem.Controls.Add(this.lblQtyAvailable);
            this.groupBoxItem.Controls.Add(this.label2);
            this.groupBoxItem.Location = new System.Drawing.Point(12, 12);
            this.groupBoxItem.Name = "groupBoxItem";
            this.groupBoxItem.Size = new System.Drawing.Size(561, 201);
            this.groupBoxItem.TabIndex = 21;
            this.groupBoxItem.TabStop = false;
            this.groupBoxItem.Text = "Item Details";
            // 
            // frmEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 254);
            this.Controls.Add(this.groupBoxItem);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnClose);
            this.Name = "frmEquipment";
            this.Text = "Equipment Form";
            this.Load += new System.EventHandler(this.frmEquipment_Load);
            this.groupBoxItem.ResumeLayout(false);
            this.groupBoxItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtQtyAvailable;
        private System.Windows.Forms.TextBox txtQtyBooked;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtyAvailable;
        private System.Windows.Forms.Label lblQtyBooked;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBoxItem;
    }
}

