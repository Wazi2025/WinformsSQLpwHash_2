namespace WinformsSQLpwHash_2
{
    partial class AddUserForm
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
            this.lblNewUserName = new System.Windows.Forms.Label();
            this.tbNewUser = new System.Windows.Forms.TextBox();
            this.lblNewUserPw = new System.Windows.Forms.Label();
            this.tbNewUserPw = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewUserName
            // 
            this.lblNewUserName.AutoSize = true;
            this.lblNewUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNewUserName.Location = new System.Drawing.Point(80, 19);
            this.lblNewUserName.Name = "lblNewUserName";
            this.lblNewUserName.Size = new System.Drawing.Size(58, 13);
            this.lblNewUserName.TabIndex = 0;
            this.lblNewUserName.Text = "User name";
            // 
            // tbNewUser
            // 
            this.tbNewUser.Location = new System.Drawing.Point(84, 35);
            this.tbNewUser.Name = "tbNewUser";
            this.tbNewUser.Size = new System.Drawing.Size(100, 20);
            this.tbNewUser.TabIndex = 1;
            // 
            // lblNewUserPw
            // 
            this.lblNewUserPw.AutoSize = true;
            this.lblNewUserPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNewUserPw.Location = new System.Drawing.Point(80, 76);
            this.lblNewUserPw.Name = "lblNewUserPw";
            this.lblNewUserPw.Size = new System.Drawing.Size(53, 13);
            this.lblNewUserPw.TabIndex = 2;
            this.lblNewUserPw.Text = "Password";
            // 
            // tbNewUserPw
            // 
            this.tbNewUserPw.Location = new System.Drawing.Point(84, 99);
            this.tbNewUserPw.Name = "tbNewUserPw";
            this.tbNewUserPw.Size = new System.Drawing.Size(100, 20);
            this.tbNewUserPw.TabIndex = 3;
            // 
            // btnAddUser
            // 
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddUser.Location = new System.Drawing.Point(84, 155);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // AddUserForm
            // 
            this.AcceptButton = this.btnAddUser;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(246, 244);
            this.Controls.Add(this.tbNewUserPw);
            this.Controls.Add(this.lblNewUserName);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.tbNewUser);
            this.Controls.Add(this.lblNewUserPw);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add user";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNewUserName;
        private System.Windows.Forms.TextBox tbNewUser;
        private System.Windows.Forms.Label lblNewUserPw;
        private System.Windows.Forms.TextBox tbNewUserPw;
        private System.Windows.Forms.Button btnAddUser;
    }
}