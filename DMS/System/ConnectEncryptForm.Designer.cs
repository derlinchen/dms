namespace DMS
{
    partial class ConnectEncryptForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectEncryptForm));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.lbDBPassword = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.lbDBUser = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lbDBName = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.btnExit = new GuFun.WinControls.VistaButton();
            this.btnDecode = new GuFun.WinControls.VistaButton();
            this.btnEncode = new GuFun.WinControls.VistaButton();
            this.SuspendLayout();
            // 
            // ilTools
            // 
            this.ilTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTools.ImageStream")));
            this.ilTools.Images.SetKeyName(0, "exit.gif");
            this.ilTools.Images.SetKeyName(1, "first.gif");
            this.ilTools.Images.SetKeyName(2, "prev.gif");
            this.ilTools.Images.SetKeyName(3, "next.gif");
            this.ilTools.Images.SetKeyName(4, "last.gif");
            this.ilTools.Images.SetKeyName(5, "search.gif");
            this.ilTools.Images.SetKeyName(6, "detail.gif");
            this.ilTools.Images.SetKeyName(7, "add.gif");
            this.ilTools.Images.SetKeyName(8, "edit.gif");
            this.ilTools.Images.SetKeyName(9, "del.gif");
            this.ilTools.Images.SetKeyName(10, "copy.gif");
            this.ilTools.Images.SetKeyName(11, "save.gif");
            this.ilTools.Images.SetKeyName(12, "cancel.gif");
            this.ilTools.Images.SetKeyName(13, "print.gif");
            this.ilTools.Images.SetKeyName(14, "export.gif");
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(85, 77);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(654, 21);
            this.txtResult.TabIndex = 9;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(10, 80);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(41, 12);
            this.lbResult.TabIndex = 8;
            this.lbResult.Text = "结果：";
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(459, 47);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Size = new System.Drawing.Size(280, 21);
            this.txtDBPassword.TabIndex = 7;
            // 
            // lbDBPassword
            // 
            this.lbDBPassword.AutoSize = true;
            this.lbDBPassword.Location = new System.Drawing.Point(385, 50);
            this.lbDBPassword.Name = "lbDBPassword";
            this.lbDBPassword.Size = new System.Drawing.Size(41, 12);
            this.lbDBPassword.TabIndex = 6;
            this.lbDBPassword.Text = "密码：";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(85, 47);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(280, 21);
            this.txtDBUser.TabIndex = 5;
            // 
            // lbDBUser
            // 
            this.lbDBUser.AutoSize = true;
            this.lbDBUser.Location = new System.Drawing.Point(10, 50);
            this.lbDBUser.Name = "lbDBUser";
            this.lbDBUser.Size = new System.Drawing.Size(53, 12);
            this.lbDBUser.TabIndex = 4;
            this.lbDBUser.Text = "用户名：";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(459, 17);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(280, 21);
            this.txtDBName.TabIndex = 3;
            // 
            // lbDBName
            // 
            this.lbDBName.AutoSize = true;
            this.lbDBName.Location = new System.Drawing.Point(385, 20);
            this.lbDBName.Name = "lbDBName";
            this.lbDBName.Size = new System.Drawing.Size(77, 12);
            this.lbDBName.TabIndex = 2;
            this.lbDBName.Text = "数据库名称：";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(85, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(280, 21);
            this.txtServer.TabIndex = 1;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(10, 20);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(77, 12);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "服务器地址：";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BaseColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExit.ButtonText = "退出";
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(595, 110);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.BackColor = System.Drawing.Color.Transparent;
            this.btnDecode.BaseColor = System.Drawing.SystemColors.Highlight;
            this.btnDecode.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDecode.ButtonText = "解密";
            this.btnDecode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDecode.ForeColor = System.Drawing.Color.Black;
            this.btnDecode.Location = new System.Drawing.Point(340, 110);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 30);
            this.btnDecode.TabIndex = 11;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.BackColor = System.Drawing.Color.Transparent;
            this.btnEncode.BaseColor = System.Drawing.SystemColors.Highlight;
            this.btnEncode.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEncode.ButtonText = "加密";
            this.btnEncode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEncode.ForeColor = System.Drawing.Color.Black;
            this.btnEncode.Location = new System.Drawing.Point(85, 110);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 30);
            this.btnEncode.TabIndex = 10;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // ConnectEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(752, 152);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.txtDBPassword);
            this.Controls.Add(this.lbDBPassword);
            this.Controls.Add(this.txtDBUser);
            this.Controls.Add(this.lbDBUser);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.lbDBName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lbServer);
            this.Name = "ConnectEncryptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lbDBName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label lbDBUser;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label lbDBPassword;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox txtResult;
        private GuFun.WinControls.VistaButton btnEncode;
        private GuFun.WinControls.VistaButton btnDecode;
        private GuFun.WinControls.VistaButton btnExit;
    }
}
