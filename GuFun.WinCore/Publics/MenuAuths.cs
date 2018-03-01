using System;
using System.Collections;

namespace GuFun.WinCore
{
  public class MenuAuths : CollectionBase
  {
    public MenuAuths()
      : base()
    {
    }

    public MenuAuth this[int index]
    {
      get { return (MenuAuth)base.List[index]; }
      set { base.List[index] = (MenuAuth)value; }
    }

    public void Add(MenuAuth item)
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

    public int FindAuthByCode(string code)
    {
      foreach (MenuAuth item in base.List)
      {
        if (item.MCode == code)
          return item.Auth;
      }

      return 0;
    }
  }
}
