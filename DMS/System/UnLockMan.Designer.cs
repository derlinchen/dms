namespace DMS
{
    partial class UnLockMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnLockMan));
            this.lblManID = new System.Windows.Forms.Label();
            this.txtManID = new System.Windows.Forms.TextBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
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
            // lblManID
            // 
            this.lblManID.AutoSize = true;
            this.lblManID.Location = new System.Drawing.Point(24, 21);
            this.lblManID.Name = "lblManID";
            this.lblManID.Size = new System.Drawing.Size(65, 12);
            this.lblManID.TabIndex = 0;
            this.lblManID.Text = "员工工号：";
            // 
            // txtManID
            // 
            this.txtManID.Location = new System.Drawing.Point(86, 17);
            this.txtManID.Name = "txtManID";
            this.txtManID.Size = new System.Drawing.Size(157, 21);
            this.txtManID.TabIndex = 1;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(54, 57);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 2;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(138, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UnLockMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(267, 96);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.txtManID);
            this.Controls.Add(this.lblManID);
            this.Name = "UnLockMan";
            this.Text = "员工解锁";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManID;
        private System.Windows.Forms.TextBox txtManID;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnExit;
    }
}
