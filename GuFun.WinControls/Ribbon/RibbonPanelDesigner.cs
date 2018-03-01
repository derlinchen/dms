using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace GuFun.WinControls
{
  internal class RibbonPanelDesigner
        : RibbonElementWithItemCollectionDesigner
  {

    public override Ribbon Ribbon
    {
      get
      {
        if (Component is RibbonPanel)
        {
          return (Component as RibbonPanel).Owner;
        }
        return null;
      }
    }

    public override RibbonItemCollection Collection
    {
      get
      {
        if (Component is RibbonPanel)
        {
          return (Component as RibbonPanel).Items;
        }
        return null;
      }
    }
  }
}
