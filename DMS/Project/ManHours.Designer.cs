namespace DMS
{
    partial class ManHours
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
            this.lbProjectCode = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.lbManName = new System.Windows.Forms.Label();
            this.txtManName = new System.Windows.Forms.TextBox();
            this.plSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // plSearch
            // 
            this.plSearch.BackColor = System.Drawing.SystemColors.Control;
            this.plSearch.Controls.Add(this.txtManName);
            this.plSearch.Controls.Add(this.lbManName);
            this.plSearch.Controls.Add(this.txtProjectCode);
            this.plSearch.Controls.Add(this.lbProjectCode);
            this.plSearch.Size = new System.Drawing.Size(770, 38);
            // 
            // lbProjectCode
            // 
            this.lbProjectCode.AutoSize = true;
            this.lbProjectCode.Location = new System.Drawing.Point(17, 14);
            this.lbProjectCode.Name = "lbProjectCode";
            this.lbProjectCode.Size = new System.Drawing.Size(65, 12);
            this.lbProjectCode.TabIndex = 0;
            this.lbProjectCode.Text = "项目代号：";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(80, 9);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(135, 21);
            this.txtProjectCode.TabIndex = 1;
            // 
            // lbManName
            // 
            this.lbManName.AutoSize = true;
            this.lbManName.Location = new System.Drawing.Point(232, 14);
            this.lbManName.Name = "lbManName";
            this.lbManName.Size = new System.Drawing.Size(65, 12);
            this.lbManName.TabIndex = 2;
            this.lbManName.Text = "开发人员：";
            // 
            // txtManName
            // 
            this.txtManName.Location = new System.Drawing.Point(295, 9);
            this.txtManName.Name = "txtManName";
            this.txtManName.Size = new System.Drawing.Size(135, 21);
            this.txtManName.TabIndex = 3;
            // 
            // ManHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Name = "ManHours";
            this.Load += new System.EventHandler(this.ManHours_Load);
            this.plSearch.ResumeLayout(false);
            this.plSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProjectCode;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label lbManName;
        private System.Windows.Forms.TextBox txtManName;
    }
}
