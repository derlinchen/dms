using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class SysMenus : CollectionBase
	{
		public SysMenus()
			: base()
		{
		}

		public SysMenu this[int index]
		{
			get { return (SysMenu)base.List[index]; }
			set { base.List[index] = (SysMenu)value; }
		}

		public void Add(SysMenu item)
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

    public SysMenu FindByMenuID(short id)
    {
      foreach (SysMenu item in this.List)
      {
        if (item.MID == id)
          return item;
      }

      return null;
    }

    public SysMenu FindByMenuName(string name)
    {
      foreach (SysMenu item in this.List)
      {
        if (item.MName == name)
          return item;
      }

      return null;
    }

    public SysMenu FindSubMenu(short menuid)
    {
      SysMenu sitem;

      foreach (SysMenu item in this.List)
      {
        if (item.MID == menuid)
          return item;

        if (item.SubMenus.Count > 0)
        {
          if ((sitem = item.SubMenus.FindSubMenu(menuid)) != null)
            return sitem;
        }
      }

      return null;
    }
	}
}
