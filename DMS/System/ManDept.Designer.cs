namespace DMS
{
    partial class ManDept
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManDept));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tssExit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbAddChild = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssModify = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tvDept = new GuFun.WinControls.TreeViewBound();
            this.plEdit = new GuFun.WinControls.ExPanel();
            this.txtDeptShort = new System.Windows.Forms.TextBox();
            this.ddlDeptStatus = new System.Windows.Forms.ComboBox();
            this.ddlDeptLevel = new System.Windows.Forms.ComboBox();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.btnMan = new System.Windows.Forms.Button();
            this.ilTools = new System.Windows.Forms.ImageList(this.components);
            this.txtDeptEMail = new System.Windows.Forms.TextBox();
            this.txtDeptFax = new System.Windows.Forms.TextBox();
            this.txtDeptTele = new System.Windows.Forms.TextBox();
            this.txtDeptPost = new System.Windows.Forms.TextBox();
            this.txtDeptAddress = new System.Windows.Forms.TextBox();
            this.ddlDeptType = new System.Windows.Forms.ComboBox();
            this.txtDeptPID = new System.Windows.Forms.TextBox();
            this.ddlCoID = new System.Windows.Forms.ComboBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtDeptID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeptMan = new GuFun.WinControls.ExTextBox(this.components);
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.plEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tssExit,
            this.tsbRefresh,
            this.tssRefresh,
            this.tsbAdd,
            this.tsbAddChild,
            this.tsbEdit,
            this.tssModify,
            this.tsbSave,
            this.tsbCancel});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(872, 40);
            this.tsMain.TabIndex = 0;
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(36, 37);
            this.tsbExit.Text = "退出";
            this.tsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tssExit
            // 
            this.tssExit.Name = "tssExit";
            this.tssExit.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(36, 37);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tssRefresh
            // 
            this.tssRefresh.Name = "tssRefresh";
            this.tssRefresh.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(60, 37);
            this.tsbAdd.Text = "增加同级";
            this.tsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbAddChild
            // 
            this.tsbAddChild.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddChild.Image")));
            this.tsbAddChild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddChild.Name = "tsbAddChild";
            this.tsbAddChild.Size = new System.Drawing.Size(60, 37);
            this.tsbAddChild.Text = "增加下级";
            this.tsbAddChild.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAddChild.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAddChild.Click += new System.EventHandler(this.tsbAddChild_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(36, 37);
            this.tsbEdit.Text = "修改";
            this.tsbEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tssModify
            // 
            this.tssModify.Name = "tssModify";
            this.tssModify.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 37);
            this.tsbSave.Text = "保存";
            this.tsbSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(36, 37);
            this.tsbCancel.Text = "取消";
            this.tsbCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 40);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tvDept);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.plEdit);
            this.scMain.Size = new System.Drawing.Size(872, 370);
            this.scMain.SplitterDistance = 232;
            this.scMain.TabIndex = 1;
            // 
            // tvDept
            // 
            this.tvDept.ComboTreeType = GuFun.WinControls.ComboTreeType.None;
            this.tvDept.DisplayMember = null;
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDept.Location = new System.Drawing.Point(0, 0);
            this.tvDept.Name = "tvDept";
            this.tvDept.ParentMember = null;
            this.tvDept.RootParentValue = ((object)(resources.GetObject("tvDept.RootParentValue")));
            this.tvDept.Size = new System.Drawing.Size(232, 370);
            this.tvDept.TabIndex = 0;
            this.tvDept.TypeText = "";
            this.tvDept.ValueMember = null;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            this.tvDept.Click += new System.EventHandler(this.tvDept_Click);
            // 
            // plEdit
            // 
            this.plEdit.Border3DStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.plEdit.Controls.Add(this.txtDeptMan);
            this.plEdit.Controls.Add(this.txtDeptShort);
            this.plEdit.Controls.Add(this.ddlDeptStatus);
            this.plEdit.Controls.Add(this.ddlDeptLevel);
            this.plEdit.Controls.Add(this.txtSortOrder);
            this.plEdit.Controls.Add(this.btnMan);
            this.plEdit.Controls.Add(this.txtDeptEMail);
            this.plEdit.Controls.Add(this.txtDeptFax);
            this.plEdit.Controls.Add(this.txtDeptTele);
            this.plEdit.Controls.Add(this.txtDeptPost);
            this.plEdit.Controls.Add(this.txtDeptAddress);
            this.plEdit.Controls.Add(this.ddlDeptType);
            this.plEdit.Controls.Add(this.txtDeptPID);
            this.plEdit.Controls.Add(this.ddlCoID);
            this.plEdit.Controls.Add(this.txtDeptName);
            this.plEdit.Controls.Add(this.txtDeptID);
            this.plEdit.Controls.Add(this.label15);
            this.plEdit.Controls.Add(this.label14);
            this.plEdit.Controls.Add(this.label13);
            this.plEdit.Controls.Add(this.label12);
            this.plEdit.Controls.Add(this.label11);
            this.plEdit.Controls.Add(this.label10);
            this.plEdit.Controls.Add(this.label9);
            this.plEdit.Controls.Add(this.label8);
            this.plEdit.Controls.Add(this.label7);
            this.plEdit.Controls.Add(this.label6);
            this.plEdit.Controls.Add(this.label5);
            this.plEdit.Controls.Add(this.label4);
            this.plEdit.Controls.Add(this.label3);
            this.plEdit.Controls.Add(this.label2);
            this.plEdit.Controls.Add(this.label1);
            this.plEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plEdit.Location = new System.Drawing.Point(0, 0);
            this.plEdit.Name = "plEdit";
            this.plEdit.Size = new System.Drawing.Size(636, 370);
            this.plEdit.TabIndex = 0;
            // 
            // txtDeptShort
            // 
            this.txtDeptShort.Location = new System.Drawing.Point(498, 167);
            this.txtDeptShort.Name = "txtDeptShort";
            this.txtDeptShort.Size = new System.Drawing.Size(121, 21);
            this.txtDeptShort.TabIndex = 30;
            // 
            // ddlDeptStatus
            // 
            this.ddlDeptStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptStatus.FormattingEnabled = true;
            this.ddlDeptStatus.Location = new System.Drawing.Point(301, 167);
            this.ddlDeptStatus.Name = "ddlDeptStatus";
            this.ddlDeptStatus.Size = new System.Drawing.Size(126, 20);
            this.ddlDeptStatus.TabIndex = 29;
            // 
            // ddlDeptLevel
            // 
            this.ddlDeptLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptLevel.FormattingEnabled = true;
            this.ddlDeptLevel.Location = new System.Drawing.Point(76, 167);
            this.ddlDeptLevel.Name = "ddlDeptLevel";
            this.ddlDeptLevel.Size = new System.Drawing.Size(157, 20);
            this.ddlDeptLevel.TabIndex = 28;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.Location = new System.Drawing.Point(498, 136);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Size = new System.Drawing.Size(121, 21);
            this.txtSortOrder.TabIndex = 27;
            // 
            // btnMan
            // 
            this.btnMan.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnMan.ImageIndex = 1;
            this.btnMan.ImageList = this.ilTools;
            this.btnMan.Location = new System.Drawing.Point(404, 135);
            this.btnMan.Name = "btnMan";
            this.btnMan.Size = new System.Drawing.Size(24, 22);
            this.btnMan.TabIndex = 26;
            this.btnMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMan.UseVisualStyleBackColor = true;
            // 
            // ilTools
            // 
            this.ilTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTools.ImageStream")));
            this.ilTools.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTools.Images.SetKeyName(0, "exit.gif");
            this.ilTools.Images.SetKeyName(1, "search.gif");
            this.ilTools.Images.SetKeyName(2, "add.gif");
            this.ilTools.Images.SetKeyName(3, "edit.gif");
            this.ilTools.Images.SetKeyName(4, "save.gif");
            this.ilTools.Images.SetKeyName(5, "cancel.gif");
            // 
            // txtDeptEMail
            // 
            this.txtDeptEMail.Location = new System.Drawing.Point(76, 136);
            this.txtDeptEMail.Name = "txtDeptEMail";
            this.txtDeptEMail.Size = new System.Drawing.Size(157, 21);
            this.txtDeptEMail.TabIndex = 24;
            // 
            // txtDeptFax
            // 
            this.txtDeptFax.Location = new System.Drawing.Point(498, 105);
            this.txtDeptFax.Name = "txtDeptFax";
            this.txtDeptFax.Size = new System.Drawing.Size(121, 21);
            this.txtDeptFax.TabIndex = 23;
            // 
            // txtDeptTele
            // 
            this.txtDeptTele.Location = new System.Drawing.Point(301, 105);
            this.txtDeptTele.Name = "txtDeptTele";
            this.txtDeptTele.Size = new System.Drawing.Size(126, 21);
            this.txtDeptTele.TabIndex = 22;
            // 
            // txtDeptPost
            // 
            this.txtDeptPost.Location = new System.Drawing.Point(76, 105);
            this.txtDeptPost.Name = "txtDeptPost";
            this.txtDeptPost.Size = new System.Drawing.Size(157, 21);
            this.txtDeptPost.TabIndex = 21;
            // 
            // txtDeptAddress
            // 
            this.txtDeptAddress.Location = new System.Drawing.Point(76, 74);
            this.txtDeptAddress.Name = "txtDeptAddress";
            this.txtDeptAddress.Size = new System.Drawing.Size(543, 21);
            this.txtDeptAddress.TabIndex = 20;
            // 
            // ddlDeptType
            // 
            this.ddlDeptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptType.FormattingEnabled = true;
            this.ddlDeptType.Location = new System.Drawing.Point(498, 43);
            this.ddlDeptType.Name = "ddlDeptType";
            this.ddlDeptType.Size = new System.Drawing.Size(121, 20);
            this.ddlDeptType.TabIndex = 19;
            // 
            // txtDeptPID
            // 
            this.txtDeptPID.Location = new System.Drawing.Point(301, 43);
            this.txtDeptPID.Name = "txtDeptPID";
            this.txtDeptPID.Size = new System.Drawing.Size(126, 21);
            this.txtDeptPID.TabIndex = 18;
            // 
            // ddlCoID
            // 
            this.ddlCoID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCoID.FormattingEnabled = true;
            this.ddlCoID.Location = new System.Drawing.Point(76, 43);
            this.ddlCoID.Name = "ddlCoID";
            this.ddlCoID.Size = new System.Drawing.Size(157, 20);
            this.ddlCoID.TabIndex = 17;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(301, 12);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(318, 21);
            this.txtDeptName.TabIndex = 16;
            // 
            // txtDeptID
            // 
            this.txtDeptID.Location = new System.Drawing.Point(76, 12);
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(157, 21);
            this.txtDeptID.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Brown;
            this.label15.Location = new System.Drawing.Point(436, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "部门简称：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Brown;
            this.label14.Location = new System.Drawing.Point(237, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "部门状态：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Brown;
            this.label13.Location = new System.Drawing.Point(14, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "部门级别：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Brown;
            this.label12.Location = new System.Drawing.Point(436, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "排序序号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(237, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "负 责 人：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "电子邮件：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "联系传真：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "联系电话：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "邮编编码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "部门地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(436, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "部门类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "上级部门：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "所属公司：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(237, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "部门名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门编号：";
            // 
            // txtDeptMan
            // 
            this.txtDeptMan.CodeText = null;
            this.txtDeptMan.Location = new System.Drawing.Point(301, 136);
            this.txtDeptMan.Name = "txtDeptMan";
            this.txtDeptMan.NameText = null;
            this.txtDeptMan.Size = new System.Drawing.Size(97, 21);
            this.txtDeptMan.TabIndex = 31;
            // 
            // ManDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(872, 410);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tsMain);
            this.Name = "ManDept";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManDept_FormClosing);
            this.Load += new System.EventHandler(this.ManDept_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator tssExit;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator tssRefresh;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbAddChild;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator tssModify;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.SplitContainer scMain;
        private GuFun.WinControls.TreeViewBound tvDept;
        private GuFun.WinControls.ExPanel plEdit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeptShort;
        private System.Windows.Forms.ComboBox ddlDeptStatus;
        private System.Windows.Forms.ComboBox ddlDeptLevel;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.Button btnMan;
        private System.Windows.Forms.TextBox txtDeptEMail;
        private System.Windows.Forms.TextBox txtDeptFax;
        private System.Windows.Forms.TextBox txtDeptTele;
        private System.Windows.Forms.TextBox txtDeptPost;
        private System.Windows.Forms.TextBox txtDeptAddress;
        private System.Windows.Forms.ComboBox ddlDeptType;
        private System.Windows.Forms.TextBox txtDeptPID;
        private System.Windows.Forms.ComboBox ddlCoID;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtDeptID;
        private System.Windows.Forms.ImageList ilTools;
        private GuFun.WinControls.ExTextBox txtDeptMan;

    }
}
