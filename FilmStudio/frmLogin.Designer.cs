namespace FilmStudio
{
    partial class frmLogin
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPasskey = new System.Windows.Forms.Label();
            this.txtPasskey = new System.Windows.Forms.TextBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(113, 89);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPasskey
            // 
            this.lblPasskey.AutoSize = true;
            this.lblPasskey.Location = new System.Drawing.Point(6, 48);
            this.lblPasskey.Name = "lblPasskey";
            this.lblPasskey.Size = new System.Drawing.Size(50, 13);
            this.lblPasskey.TabIndex = 6;
            this.lblPasskey.Text = "Passkey:";
            // 
            // txtPasskey
            // 
            this.txtPasskey.Location = new System.Drawing.Point(70, 45);
            this.txtPasskey.Name = "txtPasskey";
            this.txtPasskey.PasswordChar = '*';
            this.txtPasskey.Size = new System.Drawing.Size(100, 20);
            this.txtPasskey.TabIndex = 2;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.txtPasskey);
            this.groupBoxLogin.Controls.Add(this.lblPasskey);
            this.groupBoxLogin.Controls.Add(this.txtUsername);
            this.groupBoxLogin.Controls.Add(this.lblUsername);
            this.groupBoxLogin.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(176, 71);
            this.groupBoxLogin.TabIndex = 3;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login Details";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxLogin);
            this.Controls.Add(this.btnLogin);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasskey;
        private System.Windows.Forms.TextBox txtPasskey;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button btnClose;
    }
}