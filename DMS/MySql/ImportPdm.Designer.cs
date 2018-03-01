namespace DMS.MySql
{
    partial class ImportPdm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPdm));
            this.lbtitle = new System.Windows.Forms.Label();
            this.lbdbname = new System.Windows.Forms.Label();
            this.lbdbcode = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.TextBox();
            this.dbname = new System.Windows.Forms.TextBox();
            this.dbcode = new System.Windows.Forms.TextBox();
            this.choosefile = new GuFun.WinControls.VistaButton();
            this.savefile = new GuFun.WinControls.VistaButton();
            this.closefrom = new GuFun.WinControls.VistaButton();
            this.cbLog = new System.Windows.Forms.CheckBox();
            this.lbProject = new System.Windows.Forms.Label();
            this.ddlProject = new System.Windows.Forms.ComboBox();
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
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Location = new System.Drawing.Point(38, 21);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(191, 12);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "请选择数据库定义文件(PDM文件)：";
            // 
            // lbdbname
            // 
            this.lbdbname.AutoSize = true;
            this.lbdbname.Location = new System.Drawing.Point(38, 83);
            this.lbdbname.Name = "lbdbname";
            this.lbdbname.Size = new System.Drawing.Size(77, 12);
            this.lbdbname.TabIndex = 1;
            this.lbdbname.Text = "数据库名称：";
            // 
            // lbdbcode
            // 
            this.lbdbcode.AutoSize = true;
            this.lbdbcode.Location = new System.Drawing.Point(255, 83);
            this.lbdbcode.Name = "lbdbcode";
            this.lbdbcode.Size = new System.Drawing.Size(77, 12);
            this.lbdbcode.TabIndex = 2;
            this.lbdbcode.Text = "数据库代码：";
            // 
            // filename
            // 
            this.filename.Location = new System.Drawing.Point(40, 46);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(632, 21);
            this.filename.TabIndex = 6;
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(110, 80);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(140, 21);
            this.dbname.TabIndex = 7;
            // 
            // dbcode
            // 
            this.dbcode.Location = new System.Drawing.Point(325, 80);
            this.dbcode.Name = "dbcode";
            this.dbcode.Size = new System.Drawing.Size(140, 21);
            this.dbcode.TabIndex = 8;
            // 
            // choosefile
            // 
            this.choosefile.BackColor = System.Drawing.Color.Transparent;
            this.choosefile.BaseColor = System.Drawing.SystemColors.Highlight;
            this.choosefile.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.choosefile.ButtonText = "选择文件";
            this.choosefile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.choosefile.ForeColor = System.Drawing.Color.Black;
            this.choosefile.Location = new System.Drawing.Point(40, 113);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(115, 31);
            this.choosefile.TabIndex = 9;
            this.choosefile.Click += new System.EventHandler(this.choosefile_Click);
            // 
            // savefile
            // 
            this.savefile.BackColor = System.Drawing.Color.Transparent;
            this.savefile.BaseColor = System.Drawing.SystemColors.Highlight;
            this.savefile.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.savefile.ButtonText = "保存数据库设计";
            this.savefile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.savefile.ForeColor = System.Drawing.Color.Black;
            this.savefile.Location = new System.Drawing.Point(212, 113);
            this.savefile.Name = "savefile";
            this.savefile.Size = new System.Drawing.Size(150, 31);
            this.savefile.TabIndex = 10;
            this.savefile.Click += new System.EventHandler(this.savefile_Click);
            // 
            // closefrom
            // 
            this.closefrom.BackColor = System.Drawing.Color.Transparent;
            this.closefrom.BaseColor = System.Drawing.SystemColors.Highlight;
            this.closefrom.ButtonColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.closefrom.ButtonText = "退出";
            this.closefrom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closefrom.ForeColor = System.Drawing.Color.Black;
            this.closefrom.Location = new System.Drawing.Point(416, 113);
            this.closefrom.Name = "closefrom";
            this.closefrom.Size = new System.Drawing.Size(101, 31);
            this.closefrom.TabIndex = 11;
            this.closefrom.Click += new System.EventHandler(this.closefrom_Click);
            // 
            // cbLog
            // 
            this.cbLog.AutoSize = true;
            this.cbLog.Location = new System.Drawing.Point(570, 120);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(96, 16);
            this.cbLog.TabIndex = 12;
            this.cbLog.Text = "是否保留痕迹";
            this.cbLog.UseVisualStyleBackColor = true;
            // 
            // lbProject
            // 
            this.lbProject.AutoSize = true;
            this.lbProject.Location = new System.Drawing.Point(471, 83);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(65, 12);
            this.lbProject.TabIndex = 13;
            this.lbProject.Text = "所属项目：";
            // 
            // ddlProject
            // 
            this.ddlProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProject.FormattingEnabled = true;
            this.ddlProject.Location = new System.Drawing.Point(532, 80);
            this.ddlProject.Name = "ddlProject";
            this.ddlProject.Size = new System.Drawing.Size(140, 20);
            this.ddlProject.TabIndex = 14;
            // 
            // ImportPdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 162);
            this.Controls.Add(this.ddlProject);
            this.Controls.Add(this.lbProject);
            this.Controls.Add(this.cbLog);
            this.Controls.Add(this.closefrom);
            this.Controls.Add(this.savefile);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.dbcode);
            this.Controls.Add(this.dbname);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.lbdbcode);
            this.Controls.Add(this.lbdbname);
            this.Controls.Add(this.lbtitle);
            this.Name = "ImportPdm";
            this.Text = "导入PDM至数据库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Label lbdbname;
        private System.Windows.Forms.Label lbdbcode;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.TextBox dbcode;
        private GuFun.WinControls.VistaButton choosefile;
        private GuFun.WinControls.VistaButton savefile;
        private GuFun.WinControls.VistaButton closefrom;
        private System.Windows.Forms.CheckBox cbLog;
        private System.Windows.Forms.Label lbProject;
        private System.Windows.Forms.ComboBox ddlProject;
    }
}