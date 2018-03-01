namespace DMS
{
    partial class EditDeveloper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDeveloper));
            this.lbInfo = new System.Windows.Forms.Label();
            this.clMan = new System.Windows.Forms.CheckedListBox();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.clMan);
            this.plEdit.Controls.Add(this.lbInfo);
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
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(13, 18);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 12);
            this.lbInfo.TabIndex = 0;
            // 
            // clMan
            // 
            this.clMan.CheckOnClick = true;
            this.clMan.FormattingEnabled = true;
            this.clMan.Location = new System.Drawing.Point(12, 37);
            this.clMan.Name = "clMan";
            this.clMan.Size = new System.Drawing.Size(257, 212);
            this.clMan.TabIndex = 1;
            this.clMan.SelectedIndexChanged += new System.EventHandler(this.clMan_SelectedIndexChanged);
            // 
            // EditDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(281, 291);
            this.Name = "EditDeveloper";
            this.Load += new System.EventHandler(this.EditDeveloper_Load);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.CheckedListBox clMan;


    }
}
