namespace DMS
{
    partial class EditRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRole));
            this.exPanel1 = new GuFun.WinControls.ExPanel();
            this.txtRoleDesc = new System.Windows.Forms.TextBox();
            this.lblRoleDesc = new System.Windows.Forms.Label();
            this.ddlData = new System.Windows.Forms.ComboBox();
            this.lbdata = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lbrole = new System.Windows.Forms.Label();
            this.tcEdit = new System.Windows.Forms.TabControl();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.scEdit = new System.Windows.Forms.SplitContainer();
            this.clMenu = new System.Windows.Forms.CheckedListBox();
            this.clAuth = new System.Windows.Forms.CheckedListBox();
            this.tpNav = new System.Windows.Forms.TabPage();
            this.clNav = new System.Windows.Forms.CheckedListBox();
            this.plEdit.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.tcEdit.SuspendLayout();
            this.tpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).BeginInit();
            this.scEdit.Panel1.SuspendLayout();
            this.scEdit.Panel2.SuspendLayout();
            this.scEdit.SuspendLayout();
            this.tpNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.tcEdit);
            this.plEdit.Controls.Add(this.exPanel1);
            this.plEdit.Size = new System.Drawing.Size(484, 510);
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
            // exPanel1
            // 
            this.exPanel1.Controls.Add(this.txtRoleDesc);
            this.exPanel1.Controls.Add(this.lblRoleDesc);
            this.exPanel1.Controls.Add(this.ddlData);
            this.exPanel1.Controls.Add(this.lbdata);
            this.exPanel1.Controls.Add(this.txtRoleName);
            this.exPanel1.Controls.Add(this.lbrole);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.exPanel1.Location = new System.Drawing.Point(0, 0);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Size = new System.Drawing.Size(484, 68);
            this.exPanel1.TabIndex = 0;
            // 
            // txtRoleDesc
            // 
            this.txtRoleDesc.Location = new System.Drawing.Point(75, 39);
            this.txtRoleDesc.Name = "txtRoleDesc";
            this.txtRoleDesc.Size = new System.Drawing.Size(397, 21);
            this.txtRoleDesc.TabIndex = 5;
            // 
            // lblRoleDesc
            // 
            this.lblRoleDesc.AutoSize = true;
            this.lblRoleDesc.Location = new System.Drawing.Point(12, 43);
            this.lblRoleDesc.Name = "lblRoleDesc";
            this.lblRoleDesc.Size = new System.Drawing.Size(65, 12);
            this.lblRoleDesc.TabIndex = 4;
            this.lblRoleDesc.Text = "角色说明：";
            // 
            // ddlData
            // 
            this.ddlData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlData.FormattingEnabled = true;
            this.ddlData.Location = new System.Drawing.Point(304, 11);
            this.ddlData.Name = "ddlData";
            this.ddlData.Size = new System.Drawing.Size(168, 20);
            this.ddlData.TabIndex = 3;
            // 
            // lbdata
            // 
            this.lbdata.AutoSize = true;
            this.lbdata.Location = new System.Drawing.Point(209, 15);
            this.lbdata.Name = "lbdata";
            this.lbdata.Size = new System.Drawing.Size(95, 12);
            this.lbdata.TabIndex = 2;
            this.lbdata.Text = "数据库访问范围:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(75, 11);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(128, 21);
            this.txtRoleName.TabIndex = 1;
            // 
            // lbrole
            // 
            this.lbrole.AutoSize = true;
            this.lbrole.Location = new System.Drawing.Point(12, 15);
            this.lbrole.Name = "lbrole";
            this.lbrole.Size = new System.Drawing.Size(65, 12);
            this.lbrole.TabIndex = 0;
            this.lbrole.Text = "角色名称：";
            // 
            // tcEdit
            // 
            this.tcEdit.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcEdit.Controls.Add(this.tpMenu);
            this.tcEdit.Controls.Add(this.tpNav);
            this.tcEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEdit.Location = new System.Drawing.Point(0, 68);
            this.tcEdit.Name = "tcEdit";
            this.tcEdit.SelectedIndex = 0;
            this.tcEdit.Size = new System.Drawing.Size(484, 442);
            this.tcEdit.TabIndex = 1;
            // 
            // tpMenu
            // 
            this.tpMenu.Controls.Add(this.scEdit);
            this.tpMenu.Location = new System.Drawing.Point(4, 25);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(476, 413);
            this.tpMenu.TabIndex = 0;
            this.tpMenu.Text = "菜单分配";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // scEdit
            // 
            this.scEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scEdit.Location = new System.Drawing.Point(3, 3);
            this.scEdit.Name = "scEdit";
            // 
            // scEdit.Panel1
            // 
            this.scEdit.Panel1.Controls.Add(this.clMenu);
            // 
            // scEdit.Panel2
            // 
            this.scEdit.Panel2.Controls.Add(this.clAuth);
            this.scEdit.Size = new System.Drawing.Size(470, 407);
            this.scEdit.SplitterDistance = 290;
            this.scEdit.SplitterWidth = 10;
            this.scEdit.TabIndex = 0;
            // 
            // clMenu
            // 
            this.clMenu.CheckOnClick = true;
            this.clMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clMenu.FormattingEnabled = true;
            this.clMenu.Location = new System.Drawing.Point(0, 0);
            this.clMenu.Name = "clMenu";
            this.clMenu.Size = new System.Drawing.Size(290, 407);
            this.clMenu.TabIndex = 0;
            this.clMenu.SelectedIndexChanged += new System.EventHandler(this.clMenu_SelectedIndexChanged);
            // 
            // clAuth
            // 
            this.clAuth.CheckOnClick = true;
            this.clAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clAuth.FormattingEnabled = true;
            this.clAuth.Location = new System.Drawing.Point(0, 0);
            this.clAuth.Name = "clAuth";
            this.clAuth.Size = new System.Drawing.Size(170, 407);
            this.clAuth.TabIndex = 0;
            this.clAuth.SelectedIndexChanged += new System.EventHandler(this.clAuth_SelectedIndexChanged);
            // 
            // tpNav
            // 
            this.tpNav.Controls.Add(this.clNav);
            this.tpNav.Location = new System.Drawing.Point(4, 25);
            this.tpNav.Name = "tpNav";
            this.tpNav.Padding = new System.Windows.Forms.Padding(3);
            this.tpNav.Size = new System.Drawing.Size(476, 413);
            this.tpNav.TabIndex = 1;
            this.tpNav.Text = "导航分配";
            this.tpNav.UseVisualStyleBackColor = true;
            // 
            // clNav
            // 
            this.clNav.CheckOnClick = true;
            this.clNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clNav.FormattingEnabled = true;
            this.clNav.Location = new System.Drawing.Point(3, 3);
            this.clNav.Name = "clNav";
            this.clNav.Size = new System.Drawing.Size(470, 407);
            this.clNav.TabIndex = 0;
            this.clNav.SelectedIndexChanged += new System.EventHandler(this.clNav_SelectedIndexChanged);
            this.clNav.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clNav_MouseDoubleClick);
            // 
            // EditRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(484, 550);
            this.Name = "EditRole";
            this.Load += new System.EventHandler(this.EditRole_Load);
            this.plEdit.ResumeLayout(false);
            this.exPanel1.ResumeLayout(false);
            this.exPanel1.PerformLayout();
            this.tcEdit.ResumeLayout(false);
            this.tpMenu.ResumeLayout(false);
            this.scEdit.Panel1.ResumeLayout(false);
            this.scEdit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scEdit)).EndInit();
            this.scEdit.ResumeLayout(false);
            this.tpNav.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GuFun.WinControls.ExPanel exPanel1;
        private System.Windows.Forms.ComboBox ddlData;
        private System.Windows.Forms.Label lbdata;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lbrole;
        private System.Windows.Forms.TabControl tcEdit;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpNav;
        private System.Windows.Forms.SplitContainer scEdit;
        private System.Windows.Forms.CheckedListBox clMenu;
        private System.Windows.Forms.CheckedListBox clAuth;
        private System.Windows.Forms.CheckedListBox clNav;
        private System.Windows.Forms.Label lblRoleDesc;
        protected System.Windows.Forms.TextBox txtRoleDesc;
    }
}
