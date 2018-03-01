namespace DMS
{
    partial class ManCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManCompany));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCoID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCoName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCoAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCoPost = new System.Windows.Forms.TextBox();
            this.txtCoTele = new System.Windows.Forms.TextBox();
            this.txtCoFax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMan = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlCoStatus = new System.Windows.Forms.ComboBox();
            this.txtCoEMail = new System.Windows.Forms.TextBox();
            this.txtCoOrder = new System.Windows.Forms.TextBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printView = new System.Windows.Forms.PrintPreviewDialog();
            this.txtCoMan = new GuFun.WinControls.ExTextBox(this.components);
            this.etcMain.SuspendLayout();
            this.tpList.SuspendLayout();
            this.tpEdit.SuspendLayout();
            this.plEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).BeginInit();
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
            // tpList
            // 
            this.tpList.BackColor = System.Drawing.SystemColors.Control;
            this.tpList.UseVisualStyleBackColor = false;
            // 
            // tpEdit
            // 
            this.tpEdit.BackColor = System.Drawing.SystemColors.Control;
            this.tpEdit.UseVisualStyleBackColor = false;
            // 
            // plSearch
            // 
            this.plSearch.BackColor = System.Drawing.SystemColors.Control;
            // 
            // plEdit
            // 
            this.plEdit.BackColor = System.Drawing.SystemColors.Control;
            this.plEdit.Controls.Add(this.txtCoMan);
            this.plEdit.Controls.Add(this.txtCoOrder);
            this.plEdit.Controls.Add(this.txtCoEMail);
            this.plEdit.Controls.Add(this.ddlCoStatus);
            this.plEdit.Controls.Add(this.label10);
            this.plEdit.Controls.Add(this.label9);
            this.plEdit.Controls.Add(this.btnMan);
            this.plEdit.Controls.Add(this.label8);
            this.plEdit.Controls.Add(this.label7);
            this.plEdit.Controls.Add(this.txtCoFax);
            this.plEdit.Controls.Add(this.txtCoTele);
            this.plEdit.Controls.Add(this.txtCoPost);
            this.plEdit.Controls.Add(this.label6);
            this.plEdit.Controls.Add(this.label5);
            this.plEdit.Controls.Add(this.label4);
            this.plEdit.Controls.Add(this.txtCoAddress);
            this.plEdit.Controls.Add(this.label3);
            this.plEdit.Controls.Add(this.txtCoName);
            this.plEdit.Controls.Add(this.label2);
            this.plEdit.Controls.Add(this.txtCoID);
            this.plEdit.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司编号：";
            // 
            // txtCoID
            // 
            this.txtCoID.Location = new System.Drawing.Point(79, 14);
            this.txtCoID.MaxLength = 10;
            this.txtCoID.Name = "txtCoID";
            this.txtCoID.Size = new System.Drawing.Size(100, 21);
            this.txtCoID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "公司名称：";
            // 
            // txtCoName
            // 
            this.txtCoName.Location = new System.Drawing.Point(250, 14);
            this.txtCoName.Name = "txtCoName";
            this.txtCoName.Size = new System.Drawing.Size(372, 21);
            this.txtCoName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "公司地址：";
            // 
            // txtCoAddress
            // 
            this.txtCoAddress.Location = new System.Drawing.Point(79, 46);
            this.txtCoAddress.Name = "txtCoAddress";
            this.txtCoAddress.Size = new System.Drawing.Size(543, 21);
            this.txtCoAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "公司邮编：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "联系电话：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "联系传真：";
            // 
            // txtCoPost
            // 
            this.txtCoPost.Location = new System.Drawing.Point(79, 78);
            this.txtCoPost.Name = "txtCoPost";
            this.txtCoPost.Size = new System.Drawing.Size(100, 21);
            this.txtCoPost.TabIndex = 9;
            // 
            // txtCoTele
            // 
            this.txtCoTele.Location = new System.Drawing.Point(250, 78);
            this.txtCoTele.Name = "txtCoTele";
            this.txtCoTele.Size = new System.Drawing.Size(157, 21);
            this.txtCoTele.TabIndex = 10;
            // 
            // txtCoFax
            // 
            this.txtCoFax.Location = new System.Drawing.Point(476, 78);
            this.txtCoFax.Name = "txtCoFax";
            this.txtCoFax.Size = new System.Drawing.Size(146, 21);
            this.txtCoFax.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "E-Mail：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "负责人：";
            // 
            // btnMan
            // 
            this.btnMan.Image = ((System.Drawing.Image)(resources.GetObject("btnMan.Image")));
            this.btnMan.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnMan.Location = new System.Drawing.Point(446, 109);
            this.btnMan.Name = "btnMan";
            this.btnMan.Size = new System.Drawing.Size(24, 22);
            this.btnMan.TabIndex = 14;
            this.btnMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMan.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(476, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "排序序号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "公司状态：";
            // 
            // ddlCoStatus
            // 
            this.ddlCoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCoStatus.FormattingEnabled = true;
            this.ddlCoStatus.Location = new System.Drawing.Point(79, 142);
            this.ddlCoStatus.Name = "ddlCoStatus";
            this.ddlCoStatus.Size = new System.Drawing.Size(121, 20);
            this.ddlCoStatus.TabIndex = 17;
            // 
            // txtCoEMail
            // 
            this.txtCoEMail.Location = new System.Drawing.Point(79, 110);
            this.txtCoEMail.Name = "txtCoEMail";
            this.txtCoEMail.Size = new System.Drawing.Size(168, 21);
            this.txtCoEMail.TabIndex = 18;
            // 
            // txtCoOrder
            // 
            this.txtCoOrder.Location = new System.Drawing.Point(538, 110);
            this.txtCoOrder.Name = "txtCoOrder";
            this.txtCoOrder.Size = new System.Drawing.Size(84, 21);
            this.txtCoOrder.TabIndex = 20;
            // 
            // printView
            // 
            this.printView.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printView.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printView.ClientSize = new System.Drawing.Size(400, 300);
            this.printView.Enabled = true;
            this.printView.Icon = ((System.Drawing.Icon)(resources.GetObject("printView.Icon")));
            this.printView.Name = "printView";
            this.printView.Visible = false;
            // 
            // txtCoMan
            // 
            this.txtCoMan.CodeText = null;
            this.txtCoMan.Location = new System.Drawing.Point(304, 110);
            this.txtCoMan.Name = "txtCoMan";
            this.txtCoMan.NameText = null;
            this.txtCoMan.Size = new System.Drawing.Size(138, 21);
            this.txtCoMan.TabIndex = 21;
            // 
            // ManCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Name = "ManCompany";
            this.Load += new System.EventHandler(this.ManCompany_Load);
            this.etcMain.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            this.tpEdit.ResumeLayout(false);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCoID;
        private System.Windows.Forms.TextBox txtCoName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCoAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCoFax;
        private System.Windows.Forms.TextBox txtCoTele;
        private System.Windows.Forms.TextBox txtCoPost;
        private System.Windows.Forms.ComboBox ddlCoStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCoOrder;
        private System.Windows.Forms.TextBox txtCoEMail;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printView;
        private GuFun.WinControls.ExTextBox txtCoMan;
    }
}
