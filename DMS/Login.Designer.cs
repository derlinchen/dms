namespace DMS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pLogin = new System.Windows.Forms.PictureBox();
            this.txtManID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chbRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pLogin
            // 
            this.pLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLogin.Image = ((System.Drawing.Image)(resources.GetObject("pLogin.Image")));
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(800, 600);
            this.pLogin.TabIndex = 0;
            this.pLogin.TabStop = false;
            // 
            // txtManID
            // 
            this.txtManID.Location = new System.Drawing.Point(532, 412);
            this.txtManID.MaxLength = 10;
            this.txtManID.Name = "txtManID";
            this.txtManID.Size = new System.Drawing.Size(117, 21);
            this.txtManID.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(532, 448);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(117, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // chbRemember
            // 
            this.chbRemember.AutoSize = true;
            this.chbRemember.Location = new System.Drawing.Point(670, 451);
            this.chbRemember.Name = "chbRemember";
            this.chbRemember.Size = new System.Drawing.Size(15, 14);
            this.chbRemember.TabIndex = 4;
            this.chbRemember.UseVisualStyleBackColor = true;
            this.chbRemember.Click += new System.EventHandler(this.chbRemember_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogin.Location = new System.Drawing.Point(509, 484);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(45, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnView.Location = new System.Drawing.Point(573, 484);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "查看注册号";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(667, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chbRemember);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtManID);
            this.Controls.Add(this.pLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ImeModeChanged += new System.EventHandler(this.Login_ImeModeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chbRemember;
        public System.Windows.Forms.TextBox txtManID;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCancel;
    }
}