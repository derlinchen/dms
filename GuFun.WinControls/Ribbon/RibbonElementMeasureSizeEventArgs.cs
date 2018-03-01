using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GuFun.WinControls
{
  /// <summary>
  /// Holds data and tools to measure the sieze
  /// </summary>
  public class RibbonElementMeasureSizeEventArgs
      : EventArgs
  {
    private RibbonElementSizeMode _sizeMode;
    private System.Drawing.Graphics _graphics;

    /// <summary>
    /// Creates a new RibbonElementMeasureSizeEventArgs object
    /// </summary>
    /// <param name="graphics">Device info to draw and measure</param>
    /// <param name="sizeMode">Size mode to measure</param>
    internal RibbonElementMeasureSizeEventArgs(System.Drawing.Graphics graphics, RibbonElementSizeMode sizeMode)
    {
      _graphics = graphics;
      _sizeMode = sizeMode;
    }

    /// <summary>
    /// Gets the size mode to measure
    /// </summary>
    public RibbonElementSizeMode SizeMode
    {
      get
      {
        return _sizeMode;
      }
    }

    /// <summary>
    /// Gets the device to measure objects
    /// </summary>
    public Graphics Graphics
    {
      get
      {
        return _graphics;
      }
    }
  }
}
