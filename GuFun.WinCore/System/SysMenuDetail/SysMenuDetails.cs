using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class SysMenuDetails : CollectionBase
	{
		public SysMenuDetails()
			: base()
		{
		}

		public SysMenuDetail this[int index]
		{
			get { return (SysMenuDetail)base.List[index]; }
			set { base.List[index] = (SysMenuDetail)value; }
		}

		public void Add(SysMenuDetail item)
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
