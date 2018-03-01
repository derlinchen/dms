using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class SysMenuGroups : CollectionBase
	{
		public SysMenuGroups()
			: base()
		{
		}

		public SysMenuGroup this[int index]
		{
			get { return (SysMenuGroup)base.List[index]; }
			set { base.List[index] = (SysMenuGroup)value; }
		}

		public void Add(SysMenuGroup item)
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

    public SysMenuGroup FindByGroupID(short id)
    {
      foreach (SysMenuGroup item in this.List)
      {
        if (item.MgID == id)
          return item;
      }

      return null;
    }
	}
}
