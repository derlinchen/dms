using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExDataGridView : DataGridView
  {
    public ExDataGridView()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.DoubleBuffer |
                                  ControlStyles.AllPaintingInWmPaint |
                                  ControlStyles.OptimizedDoubleBuffer, true);
      this.UpdateStyles();
      this.RowPostPaint += new DataGridViewRowPostPaintEventHandler(ExDataGridView_RowPostPaint);
      this.KeyPress += new KeyPressEventHandler(ExDataGridView_KeyPress);
    }

    void ExDataGridView_KeyPress(object sender, KeyPressEventArgs e)
    {
      //if (e.KeyChar == 13)
      //{
      //  mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
      //  mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
      //  e.Handled = false;
      //}
    }

    public virtual void ExDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
      Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
        e.RowBounds.Location.Y,
        this.RowHeadersWidth - 4,
        e.RowBounds.Height);

      TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
          this.RowHeadersDefaultCellStyle.Font,
          rectangle,
          this.RowHeadersDefaultCellStyle.ForeColor,
          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);  
    }

    //[System.Runtime.InteropServices.DllImport("user32")]
    //private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo); 

    //const int MOUSEEVENTF_LEFTDOWN = 0x0002;  
    //const int MOUSEEVENTF_LEFTUP = 0x0004;  

    

    
  }
}
