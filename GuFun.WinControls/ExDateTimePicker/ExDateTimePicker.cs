using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GuFun.WinControls
{
  public partial class ExDateTimePicker : DateTimePicker
  {
    public ExDateTimePicker()
      : base()
    {
      this.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics;

      Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, 17);
      Brush bkgBrush = new SolidBrush(this.BackColor);
      ButtonState visualState;

      if (this.Enabled)
      {        
        visualState = ButtonState.Normal;
      }
      else
      {
        visualState = ButtonState.Inactive;
      }

      g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);

      g.DrawString(this.Text, this.Font, Brushes.Black, 0, 2);

      System.Windows.Forms.ControlPaint.DrawComboButton(g, dropDownRectangle, visualState);
      bkgBrush.Dispose();
    }
  }
}
