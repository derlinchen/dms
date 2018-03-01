using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class SetSqlDetails : CollectionBase
	{
		public SetSqlDetails()
			: base()
		{
		}

		public SetSqlDetail this[int index]
		{
			get { return (SetSqlDetail)base.List[index]; }
			set { base.List[index] = (SetSqlDetail)value; }
		}

		public void Add(SetSqlDetail item)
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
