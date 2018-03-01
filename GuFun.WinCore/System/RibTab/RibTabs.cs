using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class RibTabs : CollectionBase
	{
		public RibTabs()
			: base()
		{
		}

		public RibTab this[int index]
		{
			get { return (RibTab)base.List[index]; }
			set { base.List[index] = (RibTab)value; }
		}

		public void Add(RibTab item)
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

    public RibTab FindByRibTab(short id)
    {
      foreach (RibTab item in this.List)
      {
        if (item.ID == id)
          return item;
      }

      return null;
    }

    public RibTab this[string name]
    {
      get
      {
        foreach (RibTab item in this.List)
        {
          if (item.RibTabName == name)
            return item;
        }

        return null;
      }
    }
	}
}
