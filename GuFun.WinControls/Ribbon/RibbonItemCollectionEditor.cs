using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel.Design;

namespace GuFun.WinControls
{
  public class RibbonItemCollectionEditor
        : CollectionEditor
  {
    public RibbonItemCollectionEditor()
      : base(typeof(RibbonItemCollection))
    {

    }

    protected override Type CreateCollectionItemType()
    {
      return typeof(RibbonButton);
    }

    protected override Type[] CreateNewItemTypes()
    {
      return new Type[] {
                typeof(RibbonButton),
                typeof(RibbonButtonList),
                typeof(RibbonItemGroup),
                typeof(RibbonSeparator)};
    }
  }
}
