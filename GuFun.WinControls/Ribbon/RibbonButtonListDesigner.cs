using System;
using System.Collections.Generic;
using System.Text;

namespace GuFun.WinControls
{
  internal class RibbonButtonListDesigner
        : RibbonElementWithItemCollectionDesigner
  {
    public override Ribbon Ribbon
    {
      get
      {
        if (Component is RibbonButtonList)
        {
          return (Component as RibbonButtonList).Owner;
        }
        return null;
      }
    }

    public override RibbonItemCollection Collection
    {
      get
      {
        if (Component is RibbonButtonList)
        {
          return (Component as RibbonButtonList).Buttons;
        }
        return null;
      }
    }
  }
}
