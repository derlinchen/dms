namespace DMS
{
    partial class DeleteRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteRegister));
            this.lblReg = new System.Windows.Forms.Label();
            this.txtRegNum = new System.Windows.Forms.TextBox();
            this.btnDelReg = new System.Windows.Forms.Button();
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
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(29, 11);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(53, 12);
            this.lblReg.TabIndex = 0;
            this.lblReg.Text = "注册号：";
            // 
            // txtRegNum
            // 
            this.txtRegNum.Location = new System.Drawing.Point(80, 6);
            this.txtRegNum.Name = "txtRegNum";
            this.txtRegNum.Size = new System.Drawing.Size(210, 21);
            this.txtRegNum.TabIndex = 1;
            // 
            // btnDelReg
            // 
            this.btnDelReg.Location = new System.Drawing.Point(67, 45);
            this.btnDelReg.Name = "btnDelReg";
            this.btnDelReg.Size = new System.Drawing.Size(86, 23);
            this.btnDelReg.TabIndex = 2;
            this.btnDelReg.Text = "删除注册信息";
            this.btnDelReg.UseVisualStyleBackColor = true;
            this.btnDelReg.Click += new System.EventHandler(this.btnDelReg_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(168, 45);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DeleteRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(318, 84);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelReg);
            this.Controls.Add(this.txtRegNum);
            this.Controls.Add(this.lblReg);
            this.Name = "DeleteRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.TextBox txtRegNum;
        private System.Windows.Forms.Button btnDelReg;
        private System.Windows.Forms.Button btnExit;
    }
}
