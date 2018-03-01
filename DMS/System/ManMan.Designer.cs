namespace DMS
{
    partial class ManMan
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
            this.lblDept = new System.Windows.Forms.Label();
            this.ectDept = new GuFun.WinControls.ExComboTree();
            this.lblManName = new System.Windows.Forms.Label();
            this.txtManName = new System.Windows.Forms.TextBox();
            this.plSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // plSearch
            // 
            this.plSearch.BackColor = System.Drawing.SystemColors.Control;
            this.plSearch.Controls.Add(this.txtManName);
            this.plSearch.Controls.Add(this.lblManName);
            this.plSearch.Controls.Add(this.ectDept);
            this.plSearch.Controls.Add(this.lblDept);
            this.plSearch.Size = new System.Drawing.Size(770, 38);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(17, 11);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(65, 12);
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "所属部门：";
            // 
            // ectDept
            // 
            this.ectDept.AbsoluteChildrenSelectableOnly = true;
            this.ectDept.BranchSeparator = null;
            this.ectDept.DisableBackColor = System.Drawing.Color.White;
            this.ectDept.Imagelist = null;
            this.ectDept.Location = new System.Drawing.Point(80, 8);
            this.ectDept.Name = "ectDept";
            this.ectDept.SelectValue = "";
            this.ectDept.Size = new System.Drawing.Size(178, 22);
            this.ectDept.TabIndex = 1;
            // 
            // lblManName
            // 
            this.lblManName.AutoSize = true;
            this.lblManName.Location = new System.Drawing.Point(261, 11);
            this.lblManName.Name = "lblManName";
            this.lblManName.Size = new System.Drawing.Size(65, 12);
            this.lblManName.TabIndex = 2;
            this.lblManName.Text = "员工姓名：";
            // 
            // txtManName
            // 
            this.txtManName.Location = new System.Drawing.Point(323, 8);
            this.txtManName.Name = "txtManName";
            this.txtManName.Size = new System.Drawing.Size(116, 21);
            this.txtManName.TabIndex = 3;
            // 
            // ManMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Name = "ManMan";
            this.Load += new System.EventHandler(this.ManMan_Load);
            this.plSearch.ResumeLayout(false);
            this.plSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDept;
        private GuFun.WinControls.ExComboTree ectDept;
        private System.Windows.Forms.Label lblManName;
        private System.Windows.Forms.TextBox txtManName;
    }
}
