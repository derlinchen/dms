namespace DMS
{
    partial class EditMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMan));
            this.lbManID = new System.Windows.Forms.Label();
            this.lbManName = new System.Windows.Forms.Label();
            this.lbManTitle = new System.Windows.Forms.Label();
            this.lbdept = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTele = new System.Windows.Forms.Label();
            this.lbManLevel = new System.Windows.Forms.Label();
            this.lbManStatus = new System.Windows.Forms.Label();
            this.txtManID = new System.Windows.Forms.TextBox();
            this.txtManName = new System.Windows.Forms.TextBox();
            this.txtManTele = new System.Windows.Forms.TextBox();
            this.ddlManTitle = new System.Windows.Forms.ComboBox();
            this.ddlManLevel = new System.Windows.Forms.ComboBox();
            this.ddlManType = new System.Windows.Forms.ComboBox();
            this.ddlManStatus = new System.Windows.Forms.ComboBox();
            this.ectDept = new GuFun.WinControls.ExComboTree();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.ectDept);
            this.plEdit.Controls.Add(this.ddlManStatus);
            this.plEdit.Controls.Add(this.ddlManType);
            this.plEdit.Controls.Add(this.ddlManLevel);
            this.plEdit.Controls.Add(this.ddlManTitle);
            this.plEdit.Controls.Add(this.txtManTele);
            this.plEdit.Controls.Add(this.txtManName);
            this.plEdit.Controls.Add(this.txtManID);
            this.plEdit.Controls.Add(this.lbManStatus);
            this.plEdit.Controls.Add(this.lbManLevel);
            this.plEdit.Controls.Add(this.lbTele);
            this.plEdit.Controls.Add(this.label4);
            this.plEdit.Controls.Add(this.lbdept);
            this.plEdit.Controls.Add(this.lbManTitle);
            this.plEdit.Controls.Add(this.lbManName);
            this.plEdit.Controls.Add(this.lbManID);
            this.plEdit.Size = new System.Drawing.Size(711, 97);
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
            // lbManID
            // 
            this.lbManID.AutoSize = true;
            this.lbManID.Location = new System.Drawing.Point(20, 10);
            this.lbManID.Name = "lbManID";
            this.lbManID.Size = new System.Drawing.Size(65, 12);
            this.lbManID.TabIndex = 0;
            this.lbManID.Text = "员工工号：";
            // 
            // lbManName
            // 
            this.lbManName.AutoSize = true;
            this.lbManName.Location = new System.Drawing.Point(282, 10);
            this.lbManName.Name = "lbManName";
            this.lbManName.Size = new System.Drawing.Size(65, 12);
            this.lbManName.TabIndex = 1;
            this.lbManName.Text = "员工姓名：";
            // 
            // lbManTitle
            // 
            this.lbManTitle.AutoSize = true;
            this.lbManTitle.Location = new System.Drawing.Point(490, 10);
            this.lbManTitle.Name = "lbManTitle";
            this.lbManTitle.Size = new System.Drawing.Size(65, 12);
            this.lbManTitle.TabIndex = 2;
            this.lbManTitle.Text = "员工职务：";
            // 
            // lbdept
            // 
            this.lbdept.AutoSize = true;
            this.lbdept.Location = new System.Drawing.Point(20, 38);
            this.lbdept.Name = "lbdept";
            this.lbdept.Size = new System.Drawing.Size(65, 12);
            this.lbdept.TabIndex = 3;
            this.lbdept.Text = "所属部门：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "员工岗位：";
            // 
            // lbTele
            // 
            this.lbTele.AutoSize = true;
            this.lbTele.Location = new System.Drawing.Point(490, 38);
            this.lbTele.Name = "lbTele";
            this.lbTele.Size = new System.Drawing.Size(65, 12);
            this.lbTele.TabIndex = 5;
            this.lbTele.Text = "联系电话：";
            // 
            // lbManLevel
            // 
            this.lbManLevel.AutoSize = true;
            this.lbManLevel.Location = new System.Drawing.Point(20, 66);
            this.lbManLevel.Name = "lbManLevel";
            this.lbManLevel.Size = new System.Drawing.Size(65, 12);
            this.lbManLevel.TabIndex = 6;
            this.lbManLevel.Text = "员工级别：";
            // 
            // lbManStatus
            // 
            this.lbManStatus.AutoSize = true;
            this.lbManStatus.Location = new System.Drawing.Point(282, 66);
            this.lbManStatus.Name = "lbManStatus";
            this.lbManStatus.Size = new System.Drawing.Size(65, 12);
            this.lbManStatus.TabIndex = 7;
            this.lbManStatus.Text = "员工状态：";
            // 
            // txtManID
            // 
            this.txtManID.Location = new System.Drawing.Point(82, 7);
            this.txtManID.Name = "txtManID";
            this.txtManID.Size = new System.Drawing.Size(195, 21);
            this.txtManID.TabIndex = 8;
            // 
            // txtManName
            // 
            this.txtManName.Location = new System.Drawing.Point(345, 7);
            this.txtManName.Name = "txtManName";
            this.txtManName.Size = new System.Drawing.Size(139, 21);
            this.txtManName.TabIndex = 9;
            // 
            // txtManTele
            // 
            this.txtManTele.Location = new System.Drawing.Point(555, 35);
            this.txtManTele.Name = "txtManTele";
            this.txtManTele.Size = new System.Drawing.Size(134, 21);
            this.txtManTele.TabIndex = 10;
            // 
            // ddlManTitle
            // 
            this.ddlManTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlManTitle.FormattingEnabled = true;
            this.ddlManTitle.Location = new System.Drawing.Point(555, 7);
            this.ddlManTitle.Name = "ddlManTitle";
            this.ddlManTitle.Size = new System.Drawing.Size(134, 20);
            this.ddlManTitle.TabIndex = 11;
            // 
            // ddlManLevel
            // 
            this.ddlManLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlManLevel.FormattingEnabled = true;
            this.ddlManLevel.Location = new System.Drawing.Point(82, 62);
            this.ddlManLevel.Name = "ddlManLevel";
            this.ddlManLevel.Size = new System.Drawing.Size(195, 20);
            this.ddlManLevel.TabIndex = 12;
            // 
            // ddlManType
            // 
            this.ddlManType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlManType.FormattingEnabled = true;
            this.ddlManType.Location = new System.Drawing.Point(345, 35);
            this.ddlManType.Name = "ddlManType";
            this.ddlManType.Size = new System.Drawing.Size(139, 20);
            this.ddlManType.TabIndex = 13;
            // 
            // ddlManStatus
            // 
            this.ddlManStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlManStatus.FormattingEnabled = true;
            this.ddlManStatus.Location = new System.Drawing.Point(345, 62);
            this.ddlManStatus.Name = "ddlManStatus";
            this.ddlManStatus.Size = new System.Drawing.Size(139, 20);
            this.ddlManStatus.TabIndex = 14;
            // 
            // ectDept
            // 
            this.ectDept.AbsoluteChildrenSelectableOnly = true;
            this.ectDept.BranchSeparator = null;
            this.ectDept.DisableBackColor = System.Drawing.Color.White;
            this.ectDept.Imagelist = null;
            this.ectDept.Location = new System.Drawing.Point(82, 34);
            this.ectDept.Name = "ectDept";
            this.ectDept.SelectValue = "";
            this.ectDept.Size = new System.Drawing.Size(195, 22);
            this.ectDept.TabIndex = 15;
            // 
            // EditMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(711, 137);
            this.Name = "EditMan";
            this.Load += new System.EventHandler(this.EditMan_Load);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbManID;
        private System.Windows.Forms.Label lbManStatus;
        private System.Windows.Forms.Label lbManLevel;
        private System.Windows.Forms.Label lbTele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbdept;
        private System.Windows.Forms.Label lbManTitle;
        private System.Windows.Forms.Label lbManName;
        private GuFun.WinControls.ExComboTree ectDept;
        private System.Windows.Forms.ComboBox ddlManStatus;
        private System.Windows.Forms.ComboBox ddlManType;
        private System.Windows.Forms.ComboBox ddlManLevel;
        private System.Windows.Forms.ComboBox ddlManTitle;
        private System.Windows.Forms.TextBox txtManTele;
        private System.Windows.Forms.TextBox txtManName;
        private System.Windows.Forms.TextBox txtManID;
    }
}
