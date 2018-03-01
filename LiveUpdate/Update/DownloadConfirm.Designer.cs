namespace LiveUpdate
{
  partial class DownloadConfirm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadConfirm));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label1 = new System.Windows.Forms.Label();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.listDownloadFile = new System.Windows.Forms.ListView();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "最新版本";
      this.columnHeader2.Width = 110;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "大小";
      this.columnHeader3.Width = 100;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(113, 12);
      this.label1.TabIndex = 6;
      this.label1.Text = "以下文件需要更新：";
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "文件名";
      this.columnHeader1.Width = 160;
      // 
      // listDownloadFile
      // 
      this.listDownloadFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.listDownloadFile.Location = new System.Drawing.Point(12, 35);
      this.listDownloadFile.Name = "listDownloadFile";
      this.listDownloadFile.Size = new System.Drawing.Size(410, 176);
      this.listDownloadFile.TabIndex = 5;
      this.listDownloadFile.UseCompatibleStateImageBehavior = false;
      this.listDownloadFile.View = System.Windows.Forms.View.Details;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(347, 220);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "以后再说";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(258, 220);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "马上更新";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // DownloadConfirm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(434, 252);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.listDownloadFile);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "DownloadConfirm";
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "版本更新";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.DownloadConfirm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ListView listDownloadFile;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
  }
}
