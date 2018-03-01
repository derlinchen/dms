namespace DMS
{
    partial class EditSetRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSetRole));
            this.lblInfo = new System.Windows.Forms.Label();
            this.clRole = new System.Windows.Forms.CheckedListBox();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.lblInfo);
            this.plEdit.Controls.Add(this.clRole);
            this.plEdit.Size = new System.Drawing.Size(281, 251);
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
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 13);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 1;
            // 
            // clRole
            // 
            this.clRole.CheckOnClick = true;
            this.clRole.FormattingEnabled = true;
            this.clRole.Location = new System.Drawing.Point(12, 37);
            this.clRole.Name = "clRole";
            this.clRole.Size = new System.Drawing.Size(257, 212);
            this.clRole.TabIndex = 0;
            this.clRole.SelectedIndexChanged += new System.EventHandler(this.clRole_SelectedIndexChanged);
            // 
            // EditSetRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(281, 291);
            this.Name = "EditSetRole";
            this.Load += new System.EventHandler(this.EditSetRole_Load);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckedListBox clRole;
    }
}
