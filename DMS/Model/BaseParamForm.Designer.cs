namespace DMS
{
    partial class BaseParamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseParamForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tssExit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tssModify = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tssSave = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.plMain = new GuFun.WinControls.ExPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMain = new GuFun.WinControls.ExDataGridView();
            this.tsMain.SuspendLayout();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
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
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tssExit,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDel,
            this.tssModify,
            this.tsbSave,
            this.tsbCancel,
            this.tssSave,
            this.tsbExport});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(517, 40);
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
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 37);
            this.tsbAdd.Text = "增加";
            this.tsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
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
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(36, 37);
            this.tsbDel.Text = "删除";
            this.tsbDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDel.Click += new System.EventHandler(this.btnDel_Click);
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
            // tssSave
            // 
            this.tssSave.Name = "tssSave";
            this.tssSave.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(36, 37);
            this.tsbExport.Text = "导出";
            this.tsbExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // plMain
            // 
            this.plMain.Border3DStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.plMain.Controls.Add(this.txtName);
            this.plMain.Controls.Add(this.lblName);
            this.plMain.Controls.Add(this.txtID);
            this.plMain.Controls.Add(this.lblID);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.plMain.Location = new System.Drawing.Point(0, 40);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(517, 50);
            this.plMain.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(207, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(206, 21);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(169, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "名称：";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(50, 15);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 21);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 18);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "编号：";
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.Width = 250;
            // 
            // colID
            // 
            this.colID.HeaderText = "编号";
            this.colID.Name = "colID";
            this.colID.Width = 120;
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 90);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(517, 295);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            // 
            // BaseParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(517, 385);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.tsMain);
            this.Name = "BaseParamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseParamForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseParamForm_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator tssSave;
        private System.Windows.Forms.ToolStripButton tsbExport;
        protected System.Windows.Forms.ToolStripSeparator tssModify;
        protected System.Windows.Forms.ToolStripSeparator tssExit;
        protected GuFun.WinControls.ExPanel plMain;
        private System.Windows.Forms.Label lblID;
        protected System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        protected GuFun.WinControls.ExDataGridView dgvMain;
        private System.Windows.Forms.ToolStripButton tsbDel;
    }
}
