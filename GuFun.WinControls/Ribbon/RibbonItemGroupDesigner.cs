using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace GuFun.WinControls
{
  internal class RibbonItemGroupDesigner
        : RibbonElementWithItemCollectionDesigner
  {
    public override Ribbon Ribbon
    {
      get
      {
        if (Component is RibbonItemGroup)
        {
          return (Component as RibbonItemGroup).Owner;
        }
        return null;
      }
    }

    public override RibbonItemCollection Collection
    {
      get
      {
        if (Component is RibbonItemGroup)
        {
          return (Component as RibbonItemGroup).Items;
        }
        return null;
      }
    }
  }
}
