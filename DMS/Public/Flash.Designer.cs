namespace DMS
{
    partial class Flash
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
            this.pbWelcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWelcome
            // 
            this.pbWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbWelcome.Location = new System.Drawing.Point(0, 0);
            this.pbWelcome.Name = "pbWelcome";
            this.pbWelcome.Size = new System.Drawing.Size(800, 400);
            this.pbWelcome.TabIndex = 0;
            this.pbWelcome.TabStop = false;
            // 
            // Flash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.pbWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Flash";
            ((System.ComponentModel.ISupportInitialize)(this.pbWelcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWelcome;
    }
}