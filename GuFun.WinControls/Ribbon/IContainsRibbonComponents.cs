using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GuFun.WinControls
{
  /// <summary>
  /// Used to extract all child components from RibbonItem objects
  /// </summary>
  public interface IContainsRibbonComponents
  {
    IEnumerable<Component> GetAllChildComponents();
  }
}
