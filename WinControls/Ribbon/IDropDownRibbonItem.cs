using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinControls
{
  public interface IDropDownRibbonItem
  {
    RibbonItemCollection DropDownItems { get;}

    Rectangle DropDownButtonBounds { get;}

    bool DropDownButtonVisible { get;}

    bool DropDownButtonSelected { get;}

    bool DropDownButtonPressed { get;}
  }
}
