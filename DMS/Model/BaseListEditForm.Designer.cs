namespace DMS
{
    partial class BaseListEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseListEditForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tssExit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tssNav = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.miBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.miExact = new System.Windows.Forms.ToolStripMenuItem();
            this.miLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.tssSearch = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tssModify = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tssSave = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.ilTools = new System.Windows.Forms.ImageList(this.components);
            this.etcMain = new GuFun.WinControls.ExTabControl();
            this.tpList = new System.Windows.Forms.TabPage();
            this.dgvList = new GuFun.WinControls.ExDataGridView();
            this.plSearch = new GuFun.WinControls.ExPanel();
            this.tpEdit = new System.Windows.Forms.TabPage();
            this.plEdit = new GuFun.WinControls.ExPanel();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.bsList = new System.Windows.Forms.BindingSource(this.components);
            this.tsMain.SuspendLayout();
            this.etcMain.SuspendLayout();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tssExit,
            this.tsbFirst,
            this.tsbPrev,
            this.tsbNext,
            this.tsbLast,
            this.tssNav,
            this.tsbSearch,
            this.tsbDetail,
            this.tssSearch,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.tsbCopy,
            this.tssModify,
            this.tsbSave,
            this.tsbCancel,
            this.tssSave,
            this.tsbPrint,
            this.tsbExport});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(770, 40);
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
            this.tsbExit.ToolTipText = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tssExit
            // 
            this.tssExit.Name = "tssExit";
            this.tssExit.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(36, 37);
            this.tsbFirst.Text = "首条";
            this.tsbFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.ToolTipText = "首条";
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrev
            // 
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(36, 37);
            this.tsbPrev.Text = "上条";
            this.tsbPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrev.ToolTipText = "上条";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(36, 37);
            this.tsbNext.Text = "下条";
            this.tsbNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.ToolTipText = "下条";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(36, 37);
            this.tsbLast.Text = "末条";
            this.tsbLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.ToolTipText = "末条";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // tssNav
            // 
            this.tssNav.Name = "tssNav";
            this.tssNav.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbSearch
            // 
            this.tsbSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBlur,
            this.miExact,
            this.miLeft});
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(48, 37);
            this.tsbSearch.Text = "查询";
            this.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSearch.ToolTipText = "查询";
            this.tsbSearch.ButtonClick += new System.EventHandler(this.tsbSearch_ButtonClick);
            // 
            // miBlur
            // 
            this.miBlur.Checked = true;
            this.miBlur.CheckOnClick = true;
            this.miBlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miBlur.Name = "miBlur";
            this.miBlur.Size = new System.Drawing.Size(152, 22);
            this.miBlur.Text = "模糊查询";
            this.miBlur.Click += new System.EventHandler(this.miBlur_Click);
            // 
            // miExact
            // 
            this.miExact.CheckOnClick = true;
            this.miExact.Name = "miExact";
            this.miExact.Size = new System.Drawing.Size(152, 22);
            this.miExact.Text = "精确查询";
            this.miExact.Click += new System.EventHandler(this.miExact_Click);
            // 
            // miLeft
            // 
            this.miLeft.CheckOnClick = true;
            this.miLeft.Name = "miLeft";
            this.miLeft.Size = new System.Drawing.Size(152, 22);
            this.miLeft.Text = "左相似查询";
            this.miLeft.Click += new System.EventHandler(this.miLeft_Click);
            // 
            // tsbDetail
            // 
            this.tsbDetail.Image = ((System.Drawing.Image)(resources.GetObject("tsbDetail.Image")));
            this.tsbDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetail.Name = "tsbDetail";
            this.tsbDetail.Size = new System.Drawing.Size(36, 37);
            this.tsbDetail.Text = "明细";
            this.tsbDetail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDetail.Click += new System.EventHandler(this.tsbDetail_Click);
            // 
            // tssSearch
            // 
            this.tssSearch.Name = "tssSearch";
            this.tssSearch.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 37);
            this.tsbAdd.Text = "新增";
            this.tsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.ToolTipText = "新增";
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
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(36, 37);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(36, 37);
            this.tsbCopy.Text = "复制";
            this.tsbCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopy.ToolTipText = "复制";
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
            this.tsbSave.ToolTipText = "保存";
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
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(36, 37);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
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
            // ilTools
            // 
            this.ilTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTools.ImageStream")));
            this.ilTools.TransparentColor = System.Drawing.Color.Transparent;
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
            // etcMain
            // 
            this.etcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.etcMain.Controls.Add(this.tpList);
            this.etcMain.Controls.Add(this.tpEdit);
            this.etcMain.CustomBackColor = System.Drawing.SystemColors.Control;
            this.etcMain.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.etcMain.CustomFontColor = System.Drawing.Color.White;
            this.etcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etcMain.Location = new System.Drawing.Point(0, 40);
            this.etcMain.Name = "etcMain";
            this.etcMain.SelectedIndex = 0;
            this.etcMain.Size = new System.Drawing.Size(770, 366);
            this.etcMain.TabIndex = 1;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.dgvList);
            this.tpList.Controls.Add(this.plSearch);
            this.tpList.Location = new System.Drawing.Point(4, 29);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(762, 333);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "列表";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 68);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(756, 262);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // plSearch
            // 
            this.plSearch.Border3DStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.plSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.plSearch.Location = new System.Drawing.Point(3, 3);
            this.plSearch.Name = "plSearch";
            this.plSearch.Size = new System.Drawing.Size(756, 65);
            this.plSearch.TabIndex = 0;
            // 
            // tpEdit
            // 
            this.tpEdit.Controls.Add(this.plEdit);
            this.tpEdit.Location = new System.Drawing.Point(4, 29);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpEdit.Size = new System.Drawing.Size(762, 333);
            this.tpEdit.TabIndex = 1;
            this.tpEdit.Text = "明细";
            this.tpEdit.UseVisualStyleBackColor = true;
            // 
            // plEdit
            // 
            this.plEdit.Border3DStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.plEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plEdit.Location = new System.Drawing.Point(3, 3);
            this.plEdit.Name = "plEdit";
            this.plEdit.Size = new System.Drawing.Size(756, 327);
            this.plEdit.TabIndex = 0;
            // 
            // BaseListEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Controls.Add(this.etcMain);
            this.Controls.Add(this.tsMain);
            this.Name = "BaseListEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseListEditForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseListEditForm_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.etcMain.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tpEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripSeparator tssExit;
        protected System.Windows.Forms.ImageList ilTools;
        protected System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripSeparator tssNav;
        private System.Windows.Forms.ToolStripSplitButton tsbSearch;
        private System.Windows.Forms.ToolStripMenuItem miBlur;
        private System.Windows.Forms.ToolStripMenuItem miExact;
        private System.Windows.Forms.ToolStripMenuItem miLeft;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripSeparator tssSearch;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripSeparator tssModify;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator tssSave;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExport;
        protected GuFun.WinControls.ExTabControl etcMain;
        protected System.Windows.Forms.TabPage tpList;
        protected System.Windows.Forms.TabPage tpEdit;
        protected GuFun.WinControls.ExPanel plSearch;
        protected GuFun.WinControls.ExDataGridView dgvList;
        protected GuFun.WinControls.ExPanel plEdit;
        protected System.Windows.Forms.BindingSource bsList;
        private System.Windows.Forms.SaveFileDialog sfdExport;
    }
}
