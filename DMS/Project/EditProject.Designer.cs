namespace DMS
{
    partial class EditProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProject));
            this.lbProjectCode = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lbProjectType = new System.Windows.Forms.Label();
            this.ddlProjectType = new System.Windows.Forms.ComboBox();
            this.lbProjectManager = new System.Windows.Forms.Label();
            this.ddlProjectManager = new System.Windows.Forms.ComboBox();
            this.lbWorkDate = new System.Windows.Forms.Label();
            this.txtWorkDate = new System.Windows.Forms.TextBox();
            this.lbWorkUtil = new System.Windows.Forms.Label();
            this.ddlWorkUnit = new System.Windows.Forms.ComboBox();
            this.lbProjectDesc = new System.Windows.Forms.Label();
            this.txtProjectDesc = new System.Windows.Forms.RichTextBox();
            this.lbProjectStatus = new System.Windows.Forms.Label();
            this.ddlProjectStatus = new System.Windows.Forms.ComboBox();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.ddlProjectStatus);
            this.plEdit.Controls.Add(this.lbProjectStatus);
            this.plEdit.Controls.Add(this.txtProjectDesc);
            this.plEdit.Controls.Add(this.lbProjectDesc);
            this.plEdit.Controls.Add(this.ddlWorkUnit);
            this.plEdit.Controls.Add(this.lbWorkUtil);
            this.plEdit.Controls.Add(this.txtWorkDate);
            this.plEdit.Controls.Add(this.lbWorkDate);
            this.plEdit.Controls.Add(this.ddlProjectManager);
            this.plEdit.Controls.Add(this.lbProjectManager);
            this.plEdit.Controls.Add(this.ddlProjectType);
            this.plEdit.Controls.Add(this.lbProjectType);
            this.plEdit.Controls.Add(this.txtProjectName);
            this.plEdit.Controls.Add(this.label1);
            this.plEdit.Controls.Add(this.txtProjectCode);
            this.plEdit.Controls.Add(this.lbProjectCode);
            this.plEdit.Size = new System.Drawing.Size(716, 197);
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
            // lbProjectCode
            // 
            this.lbProjectCode.AutoSize = true;
            this.lbProjectCode.Location = new System.Drawing.Point(20, 10);
            this.lbProjectCode.Name = "lbProjectCode";
            this.lbProjectCode.Size = new System.Drawing.Size(65, 12);
            this.lbProjectCode.TabIndex = 0;
            this.lbProjectCode.Text = "项目代码：";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(82, 7);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(160, 21);
            this.txtProjectCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "项目名称：";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(310, 7);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(160, 21);
            this.txtProjectName.TabIndex = 3;
            // 
            // lbProjectType
            // 
            this.lbProjectType.AutoSize = true;
            this.lbProjectType.Location = new System.Drawing.Point(475, 10);
            this.lbProjectType.Name = "lbProjectType";
            this.lbProjectType.Size = new System.Drawing.Size(65, 12);
            this.lbProjectType.TabIndex = 4;
            this.lbProjectType.Text = "项目类型：";
            // 
            // ddlProjectType
            // 
            this.ddlProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProjectType.FormattingEnabled = true;
            this.ddlProjectType.Location = new System.Drawing.Point(535, 7);
            this.ddlProjectType.Name = "ddlProjectType";
            this.ddlProjectType.Size = new System.Drawing.Size(160, 20);
            this.ddlProjectType.TabIndex = 5;
            // 
            // lbProjectManager
            // 
            this.lbProjectManager.AutoSize = true;
            this.lbProjectManager.Location = new System.Drawing.Point(20, 40);
            this.lbProjectManager.Name = "lbProjectManager";
            this.lbProjectManager.Size = new System.Drawing.Size(65, 12);
            this.lbProjectManager.TabIndex = 6;
            this.lbProjectManager.Text = "项目经理：";
            // 
            // ddlProjectManager
            // 
            this.ddlProjectManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProjectManager.FormattingEnabled = true;
            this.ddlProjectManager.Location = new System.Drawing.Point(82, 37);
            this.ddlProjectManager.Name = "ddlProjectManager";
            this.ddlProjectManager.Size = new System.Drawing.Size(160, 20);
            this.ddlProjectManager.TabIndex = 7;
            // 
            // lbWorkDate
            // 
            this.lbWorkDate.AutoSize = true;
            this.lbWorkDate.Location = new System.Drawing.Point(250, 40);
            this.lbWorkDate.Name = "lbWorkDate";
            this.lbWorkDate.Size = new System.Drawing.Size(65, 12);
            this.lbWorkDate.TabIndex = 8;
            this.lbWorkDate.Text = "预计工时：";
            // 
            // txtWorkDate
            // 
            this.txtWorkDate.Location = new System.Drawing.Point(310, 37);
            this.txtWorkDate.Name = "txtWorkDate";
            this.txtWorkDate.Size = new System.Drawing.Size(160, 21);
            this.txtWorkDate.TabIndex = 9;
            // 
            // lbWorkUtil
            // 
            this.lbWorkUtil.AutoSize = true;
            this.lbWorkUtil.Location = new System.Drawing.Point(475, 40);
            this.lbWorkUtil.Name = "lbWorkUtil";
            this.lbWorkUtil.Size = new System.Drawing.Size(65, 12);
            this.lbWorkUtil.TabIndex = 10;
            this.lbWorkUtil.Text = "工时单位：";
            // 
            // ddlWorkUnit
            // 
            this.ddlWorkUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWorkUnit.FormattingEnabled = true;
            this.ddlWorkUnit.Location = new System.Drawing.Point(535, 37);
            this.ddlWorkUnit.Name = "ddlWorkUnit";
            this.ddlWorkUnit.Size = new System.Drawing.Size(160, 20);
            this.ddlWorkUnit.TabIndex = 11;
            // 
            // lbProjectDesc
            // 
            this.lbProjectDesc.AutoSize = true;
            this.lbProjectDesc.Location = new System.Drawing.Point(20, 100);
            this.lbProjectDesc.Name = "lbProjectDesc";
            this.lbProjectDesc.Size = new System.Drawing.Size(65, 12);
            this.lbProjectDesc.TabIndex = 12;
            this.lbProjectDesc.Text = "项目描述：";
            // 
            // txtProjectDesc
            // 
            this.txtProjectDesc.Location = new System.Drawing.Point(82, 100);
            this.txtProjectDesc.Name = "txtProjectDesc";
            this.txtProjectDesc.Size = new System.Drawing.Size(613, 85);
            this.txtProjectDesc.TabIndex = 13;
            this.txtProjectDesc.Text = "";
            // 
            // lbProjectStatus
            // 
            this.lbProjectStatus.AutoSize = true;
            this.lbProjectStatus.Location = new System.Drawing.Point(20, 70);
            this.lbProjectStatus.Name = "lbProjectStatus";
            this.lbProjectStatus.Size = new System.Drawing.Size(65, 12);
            this.lbProjectStatus.TabIndex = 14;
            this.lbProjectStatus.Text = "项目状态：";
            // 
            // ddlProjectStatus
            // 
            this.ddlProjectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProjectStatus.FormattingEnabled = true;
            this.ddlProjectStatus.Location = new System.Drawing.Point(82, 67);
            this.ddlProjectStatus.Name = "ddlProjectStatus";
            this.ddlProjectStatus.Size = new System.Drawing.Size(160, 20);
            this.ddlProjectStatus.TabIndex = 15;
            // 
            // EditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(716, 237);
            this.Name = "EditProject";
            this.Load += new System.EventHandler(this.EditProject_Load);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProjectCode;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lbProjectType;
        private System.Windows.Forms.ComboBox ddlProjectType;
        private System.Windows.Forms.Label lbProjectManager;
        private System.Windows.Forms.ComboBox ddlProjectManager;
        private System.Windows.Forms.Label lbWorkDate;
        private System.Windows.Forms.TextBox txtWorkDate;
        private System.Windows.Forms.Label lbWorkUtil;
        private System.Windows.Forms.ComboBox ddlWorkUnit;
        private System.Windows.Forms.Label lbProjectDesc;
        private System.Windows.Forms.RichTextBox txtProjectDesc;
        private System.Windows.Forms.Label lbProjectStatus;
        private System.Windows.Forms.ComboBox ddlProjectStatus;
    }
}
