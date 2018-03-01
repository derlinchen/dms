namespace DMS
{
    partial class EditHours
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditHours));
            this.lbProject = new System.Windows.Forms.Label();
            this.ddlProject = new System.Windows.Forms.ComboBox();
            this.lbMan = new System.Windows.Forms.Label();
            this.ddlMan = new System.Windows.Forms.ComboBox();
            this.WorkStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbWorkEnd = new System.Windows.Forms.Label();
            this.WorkEnd = new System.Windows.Forms.DateTimePicker();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.WorkEnd);
            this.plEdit.Controls.Add(this.lbWorkEnd);
            this.plEdit.Controls.Add(this.label1);
            this.plEdit.Controls.Add(this.WorkStart);
            this.plEdit.Controls.Add(this.ddlMan);
            this.plEdit.Controls.Add(this.lbMan);
            this.plEdit.Controls.Add(this.ddlProject);
            this.plEdit.Controls.Add(this.lbProject);
            this.plEdit.Size = new System.Drawing.Size(551, 80);
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
            // lbProject
            // 
            this.lbProject.AutoSize = true;
            this.lbProject.Location = new System.Drawing.Point(20, 10);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(65, 12);
            this.lbProject.TabIndex = 6;
            this.lbProject.Text = "项目名称：";
            // 
            // ddlProject
            // 
            this.ddlProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProject.FormattingEnabled = true;
            this.ddlProject.Location = new System.Drawing.Point(84, 7);
            this.ddlProject.Name = "ddlProject";
            this.ddlProject.Size = new System.Drawing.Size(180, 20);
            this.ddlProject.TabIndex = 7;
            // 
            // lbMan
            // 
            this.lbMan.AutoSize = true;
            this.lbMan.Location = new System.Drawing.Point(286, 10);
            this.lbMan.Name = "lbMan";
            this.lbMan.Size = new System.Drawing.Size(65, 12);
            this.lbMan.TabIndex = 14;
            this.lbMan.Text = "开发人员：";
            // 
            // ddlMan
            // 
            this.ddlMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMan.FormattingEnabled = true;
            this.ddlMan.Location = new System.Drawing.Point(347, 7);
            this.ddlMan.Name = "ddlMan";
            this.ddlMan.Size = new System.Drawing.Size(180, 20);
            this.ddlMan.TabIndex = 15;
            // 
            // WorkStart
            // 
            this.WorkStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WorkStart.Location = new System.Drawing.Point(84, 33);
            this.WorkStart.Name = "WorkStart";
            this.WorkStart.Size = new System.Drawing.Size(180, 21);
            this.WorkStart.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "开始时间：";
            // 
            // lbWorkEnd
            // 
            this.lbWorkEnd.AutoSize = true;
            this.lbWorkEnd.Location = new System.Drawing.Point(288, 37);
            this.lbWorkEnd.Name = "lbWorkEnd";
            this.lbWorkEnd.Size = new System.Drawing.Size(65, 12);
            this.lbWorkEnd.TabIndex = 18;
            this.lbWorkEnd.Text = "结束时间：";
            // 
            // WorkEnd
            // 
            this.WorkEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WorkEnd.Location = new System.Drawing.Point(347, 33);
            this.WorkEnd.Name = "WorkEnd";
            this.WorkEnd.Size = new System.Drawing.Size(180, 21);
            this.WorkEnd.TabIndex = 19;
            // 
            // EditHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(551, 120);
            this.Name = "EditHours";
            this.Load += new System.EventHandler(this.EditProject_Load);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProject;
        private System.Windows.Forms.ComboBox ddlProject;
        private System.Windows.Forms.Label lbMan;
        private System.Windows.Forms.ComboBox ddlMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker WorkStart;
        private System.Windows.Forms.Label lbWorkEnd;
        private System.Windows.Forms.DateTimePicker WorkEnd;
    }
}
