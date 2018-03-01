namespace DMS
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.ctbInfo = new System.Windows.Forms.RichTextBox();
            this.lblRegNumber = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.ectDept = new GuFun.WinControls.ExComboTree();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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
            // ctbInfo
            // 
            this.ctbInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctbInfo.Location = new System.Drawing.Point(12, 7);
            this.ctbInfo.Name = "ctbInfo";
            this.ctbInfo.ReadOnly = true;
            this.ctbInfo.Size = new System.Drawing.Size(295, 113);
            this.ctbInfo.TabIndex = 0;
            this.ctbInfo.Text = "    该终端还未在系统进行注册，请您选择您所在的部门进行系统注册。选择部门注册成功后，将会限制外部门无授权人员在本机操作本系统！如部门选择错误或者需要重新更改注" +
    "册部门，请提交本机注册号与系统管理员联系！正常注册后在登录窗口点击查看注册号进行注册号的查询！";
            // 
            // lblRegNumber
            // 
            this.lblRegNumber.AutoSize = true;
            this.lblRegNumber.Location = new System.Drawing.Point(12, 132);
            this.lblRegNumber.Name = "lblRegNumber";
            this.lblRegNumber.Size = new System.Drawing.Size(101, 12);
            this.lblRegNumber.TabIndex = 1;
            this.lblRegNumber.Text = "本终端注册号为：";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(12, 163);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(65, 12);
            this.lblDept.TabIndex = 2;
            this.lblDept.Text = "所属部门：";
            // 
            // ectDept
            // 
            this.ectDept.AbsoluteChildrenSelectableOnly = true;
            this.ectDept.BranchSeparator = null;
            this.ectDept.DisableBackColor = System.Drawing.Color.White;
            this.ectDept.Imagelist = null;
            this.ectDept.Location = new System.Drawing.Point(77, 158);
            this.ectDept.Name = "ectDept";
            this.ectDept.SelectValue = "";
            this.ectDept.Size = new System.Drawing.Size(230, 22);
            this.ectDept.TabIndex = 3;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(43, 199);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 23);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "系统注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 199);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(319, 241);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.ectDept);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblRegNumber);
            this.Controls.Add(this.ctbInfo);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ctbInfo;
        private System.Windows.Forms.Label lblRegNumber;
        private System.Windows.Forms.Label lblDept;
        private GuFun.WinControls.ExComboTree ectDept;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClose;
    }
}
