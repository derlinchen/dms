using System;
using System.Collections;

namespace GuFun.WinCore
{
  public class SysRoleMenus : CollectionBase
  {
    public SysRoleMenus()
      : base()
    {
    }

    public SysRoleMenu this[int index]
    {
      get { return (SysRoleMenu)base.List[index]; }
      set { base.List[index] = (SysRoleMenu)value; }
    }

    public void Add(SysRoleMenu item)
    {
      base.List.Add(item);

    }
    public void Remove(int index)
    {
      if (index > -1 && index < base.Count)
      {
        base.List.RemoveAt(index);
      }
    }
  }
}
