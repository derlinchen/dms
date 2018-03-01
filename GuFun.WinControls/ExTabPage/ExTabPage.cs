using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExTabPage : TabPage
  {
    public ExTabPage()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.DoubleBuffer |
                                  ControlStyles.AllPaintingInWmPaint |
                                  ControlStyles.OptimizedDoubleBuffer, true);
      this.UpdateStyles();
    }
  }
}
