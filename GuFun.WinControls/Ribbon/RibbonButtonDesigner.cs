using System;
using System.Collections.Generic;
using System.Text;

namespace GuFun.WinControls
{
  internal class RibbonButtonDesigner
        : RibbonElementWithItemCollectionDesigner
  {

    public override Ribbon Ribbon
    {
      get
      {
        if (Component is RibbonButton)
        {
          return (Component as RibbonButton).Owner;
        }
        return null;
      }
    }

    public override RibbonItemCollection Collection
    {
      get
      {
        if (Component is RibbonButton)
        {
          return (Component as RibbonButton).DropDownItems;
        }
        return null;
      }
    }

    protected override void AddButton(object sender, EventArgs e)
    {
      base.AddButton(sender, e);

    }
  }
}
