using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GuFun.WinControls
{
  public sealed class RibbonTabRenderEventArgs : RibbonRenderEventArgs
  {
    private RibbonTab _tab;

    public RibbonTabRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonTab tab)
      : base(owner, g, clip)
    {
      Tab = tab;
    }

    /// <summary>
    /// Gets or sets the RibbonTab related to the evennt
    /// </summary>
    public RibbonTab Tab
    {
      get
      {
        return _tab;
      }
      set
      {
        _tab = value;
      }
    }
  }
}
