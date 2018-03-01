namespace DMS
{
    partial class BaseEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tssExit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssPrint = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.plEdit = new GuFun.WinControls.ExPanel();
            this.tsMain.SuspendLayout();
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
            this.tsbSave,
            this.tsbCancel,
            this.tssEdit,
            this.tsbEdit,
            this.tssPrint,
            this.tsbPreview,
            this.tsbPrint});
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
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tssExit
            // 
            this.tssExit.Name = "tssExit";
            this.tssExit.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 37);
            this.tsbSave.Text = "保存";
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
            this.tsbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tssEdit
            // 
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(36, 37);
            this.tsbEdit.Text = "修改";
            this.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tssPrint
            // 
            this.tssPrint.Name = "tssPrint";
            this.tssPrint.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbPreview
            // 
            this.tsbPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsbPreview.Image")));
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(36, 37);
            this.tsbPreview.Text = "预览";
            this.tsbPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(36, 37);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // plEdit
            // 
            this.plEdit.Border3DStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.plEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plEdit.Location = new System.Drawing.Point(0, 40);
            this.plEdit.Name = "plEdit";
            this.plEdit.Size = new System.Drawing.Size(770, 366);
            this.plEdit.TabIndex = 1;
            // 
            // BaseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Controls.Add(this.plEdit);
            this.Controls.Add(this.tsMain);
            this.Name = "BaseEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseEditForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseEditForm_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator tssExit;
        private System.Windows.Forms.ToolStripSeparator tssEdit;
        protected System.Windows.Forms.ToolStripButton tsbSave;
        protected System.Windows.Forms.ToolStripButton tsbCancel;
        protected System.Windows.Forms.ToolStripButton tsbEdit;
        protected System.Windows.Forms.ToolStripSeparator tssPrint;
        protected System.Windows.Forms.ToolStripButton tsbPreview;
        protected System.Windows.Forms.ToolStripButton tsbPrint;
        protected System.Windows.Forms.ToolStrip tsMain;
        protected GuFun.WinControls.ExPanel plEdit;
    }
}
