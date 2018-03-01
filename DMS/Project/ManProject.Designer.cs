namespace DMS
{
    partial class ManProject
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
            this.lbProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.plSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // plSearch
            // 
            this.plSearch.BackColor = System.Drawing.SystemColors.Control;
            this.plSearch.Controls.Add(this.txtProjectName);
            this.plSearch.Controls.Add(this.lbProjectName);
            this.plSearch.Size = new System.Drawing.Size(770, 38);
            // 
            // lbProjectName
            // 
            this.lbProjectName.AutoSize = true;
            this.lbProjectName.Location = new System.Drawing.Point(17, 11);
            this.lbProjectName.Name = "lbProjectName";
            this.lbProjectName.Size = new System.Drawing.Size(65, 12);
            this.lbProjectName.TabIndex = 0;
            this.lbProjectName.Text = "项目名称：";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(80, 8);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(144, 21);
            this.txtProjectName.TabIndex = 1;
            // 
            // ProjectManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Name = "ProjectManage";
            this.Load += new System.EventHandler(this.ProjectManage_Load);
            this.plSearch.ResumeLayout(false);
            this.plSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
    }
}
