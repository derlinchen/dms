using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExPanel : Panel
  {
    public ExPanel()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.DoubleBuffer |
                                  ControlStyles.AllPaintingInWmPaint |
                                  ControlStyles.OptimizedDoubleBuffer, true);
      this.UpdateStyles();
    }

    private Border3DStyle _border3DStyle = Border3DStyle.Sunken;

    [DefaultValue(Border3DStyle.Sunken)]
    [RefreshProperties(RefreshProperties.All)]
    public Border3DStyle Border3DStyle
    {
      get { return _border3DStyle; }
      set
      {
        if (_border3DStyle == value) return;

        _border3DStyle = value;

        this.UpdateStyles();
      }
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (this.BorderStyle == BorderStyle.None)
      {
        e.Graphics.Clear(this.BackColor);
        ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(Point.Empty, base.Size), this.Border3DStyle);
      }
    }

    protected override void OnResize(EventArgs eventargs)
    {
      base.OnResize(eventargs);      
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.UpdateStyles();
    }
  }
}
