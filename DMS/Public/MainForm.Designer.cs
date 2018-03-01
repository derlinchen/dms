namespace DMS
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ilTools = new System.Windows.Forms.ImageList(this.components);
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.ribMain = new GuFun.WinControls.Ribbon();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMan = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslDept = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmTime = new System.Windows.Forms.Timer(this.components);
            this.ilRibbon = new System.Windows.Forms.ImageList(this.components);
            this.tmOnline = new System.Windows.Forms.Timer(this.components);
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilTools
            // 
            this.ilTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTools.ImageStream")));
            this.ilTools.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTools.Images.SetKeyName(0, "add.gif");
            this.ilTools.Images.SetKeyName(1, "cancel.gif");
            this.ilTools.Images.SetKeyName(2, "copy.gif");
            this.ilTools.Images.SetKeyName(3, "del.gif");
            this.ilTools.Images.SetKeyName(4, "detail.gif");
            this.ilTools.Images.SetKeyName(5, "edit.gif");
            this.ilTools.Images.SetKeyName(6, "exit.gif");
            this.ilTools.Images.SetKeyName(7, "export.gif");
            this.ilTools.Images.SetKeyName(8, "first.gif");
            this.ilTools.Images.SetKeyName(9, "last.gif");
            this.ilTools.Images.SetKeyName(10, "next.gif");
            this.ilTools.Images.SetKeyName(11, "prev.gif");
            this.ilTools.Images.SetKeyName(12, "print.gif");
            this.ilTools.Images.SetKeyName(13, "save.gif");
            this.ilTools.Images.SetKeyName(14, "search.gif");
            // 
            // msMain
            // 
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(770, 24);
            this.msMain.TabIndex = 1;
            // 
            // ribMain
            // 
            this.ribMain.Location = new System.Drawing.Point(0, 24);
            this.ribMain.Minimized = false;
            this.ribMain.Name = "ribMain";
            // 
            // 
            // 
            this.ribMain.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribMain.OrbDropDown.Name = "";
            this.ribMain.OrbDropDown.NextPopup = null;
            this.ribMain.OrbDropDown.PreviousPopup = null;
            this.ribMain.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribMain.OrbDropDown.TabIndex = 0;
            this.ribMain.OrbDropDown.ToolStripDropDown = null;
            this.ribMain.OrbImage = null;
            this.ribMain.OrbVisible = false;
            this.ribMain.QuickAccessVisible = false;
            // 
            // 
            // 
            this.ribMain.QuickAcessToolbar.AltKey = null;
            this.ribMain.QuickAcessToolbar.Image = null;
            this.ribMain.QuickAcessToolbar.Tag = null;
            this.ribMain.QuickAcessToolbar.Text = null;
            this.ribMain.QuickAcessToolbar.ToolTip = null;
            this.ribMain.QuickAcessToolbar.ToolTipImage = null;
            this.ribMain.QuickAcessToolbar.ToolTipTitle = null;
            this.ribMain.Size = new System.Drawing.Size(770, 120);
            this.ribMain.TabIndex = 2;
            this.ribMain.TabSpacing = 6;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslTips,
            this.sslMan,
            this.sslDept,
            this.sslTime});
            this.ssMain.Location = new System.Drawing.Point(0, 380);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(770, 26);
            this.ssMain.TabIndex = 4;
            // 
            // sslTips
            // 
            this.sslTips.Name = "sslTips";
            this.sslTips.Size = new System.Drawing.Size(575, 21);
            this.sslTips.Spring = true;
            // 
            // sslMan
            // 
            this.sslMan.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.sslMan.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.sslMan.Name = "sslMan";
            this.sslMan.Size = new System.Drawing.Size(60, 21);
            this.sslMan.Text = "用户名：";
            // 
            // sslDept
            // 
            this.sslDept.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.sslDept.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.sslDept.Name = "sslDept";
            this.sslDept.Size = new System.Drawing.Size(48, 21);
            this.sslDept.Text = "部门：";
            // 
            // sslTime
            // 
            this.sslTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.sslTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.sslTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sslTime.Name = "sslTime";
            this.sslTime.Size = new System.Drawing.Size(72, 21);
            this.sslTime.Text = "当前日期：";
            this.sslTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmTime
            // 
            this.tmTime.Enabled = true;
            this.tmTime.Interval = 1000;
            this.tmTime.Tick += new System.EventHandler(this.tmTime_Tick);
            // 
            // ilRibbon
            // 
            this.ilRibbon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilRibbon.ImageStream")));
            this.ilRibbon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilRibbon.Images.SetKeyName(0, "1.gif");
            this.ilRibbon.Images.SetKeyName(1, "2.gif");
            this.ilRibbon.Images.SetKeyName(2, "3.gif");
            this.ilRibbon.Images.SetKeyName(3, "4.gif");
            this.ilRibbon.Images.SetKeyName(4, "5.gif");
            this.ilRibbon.Images.SetKeyName(5, "6.gif");
            this.ilRibbon.Images.SetKeyName(6, "7.gif");
            this.ilRibbon.Images.SetKeyName(7, "8.gif");
            this.ilRibbon.Images.SetKeyName(8, "9.gif");
            this.ilRibbon.Images.SetKeyName(9, "10.gif");
            this.ilRibbon.Images.SetKeyName(10, "11.gif");
            this.ilRibbon.Images.SetKeyName(11, "12.gif");
            this.ilRibbon.Images.SetKeyName(12, "13.gif");
            this.ilRibbon.Images.SetKeyName(13, "14.gif");
            this.ilRibbon.Images.SetKeyName(14, "15.gif");
            this.ilRibbon.Images.SetKeyName(15, "16.gif");
            this.ilRibbon.Images.SetKeyName(16, "17.gif");
            // 
            // tmOnline
            // 
            this.tmOnline.Interval = 180000;
            this.tmOnline.Tick += new System.EventHandler(this.tmOnline_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.ribMain);
            this.Controls.Add(this.msMain);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金禾软件开发平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private GuFun.WinControls.Ribbon ribMain;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel sslTips;
        private System.Windows.Forms.ToolStripStatusLabel sslMan;
        private System.Windows.Forms.ToolStripStatusLabel sslDept;
        private System.Windows.Forms.ToolStripStatusLabel sslTime;
        private System.Windows.Forms.Timer tmTime;
        private System.Windows.Forms.ImageList ilRibbon;
        protected System.Windows.Forms.ImageList ilTools;
        private System.Windows.Forms.Timer tmOnline;


    }
}