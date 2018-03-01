using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  /// <remarks>Ribbon rendering event data</remarks>
  public class RibbonRenderEventArgs
      : EventArgs
  {
    private Ribbon _ribbon;
    private System.Drawing.Rectangle _clipRectangle;
    private System.Drawing.Graphics _graphics;

    public RibbonRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip)
    {
      Ribbon = owner;
      Graphics = g;
      ClipRectangle = clip;      
    }

    /// <summary>
    /// Gets the Ribbon related to the render
    /// </summary>
    public Ribbon Ribbon
    {
      get
      {
        return _ribbon;
      }
      set
      {
        _ribbon = value;
      }
    }

    /// <summary>
    /// Gets the Device to draw into
    /// </summary>
    public System.Drawing.Graphics Graphics
    {
      get
      {
        return _graphics;
      }
      set
      {
        _graphics = value;
      }
    }

    /// <summary>
    /// Gets the Rectangle area where to draw into
    /// </summary>
    public System.Drawing.Rectangle ClipRectangle
    {
      get
      {
        return _clipRectangle;
      }
      set
      {
        _clipRectangle = value;
      }
    }
  }
}
