using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GuFun.WinControls
{
  /// <summary>
  /// Exposes GetItems, to indicate that the type contains a collection of RibbonItems
  /// </summary>
  public interface IContainsSelectableRibbonItems
  {
    /// <summary>
    /// When implemented, must return an  enumerator to acces the items inside the type
    /// </summary>
    IEnumerable<RibbonItem> GetItems();

    /// <summary>
    /// When implemented, must return the bounds of the content where items are displayed
    /// </summary>
    /// <returns></returns>
    Rectangle GetContentBounds();
  }
}
