using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class RibButtons : CollectionBase
	{
		public RibButtons()
			: base()
		{
		}

		public RibButton this[int index]
		{
			get { return (RibButton)base.List[index]; }
			set { base.List[index] = (RibButton)value; }
		}

		public void Add(RibButton item)
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

    public RibButton FindByRibButton(short id)
    {
      foreach (RibButton item in this.List)
      {
        if (item.RibBtn == id)
          return item;
      }

      return null;
    }

    public RibButton this[string name]
    {
      get
      {
        foreach (RibButton item in this.List)
        {
          if (item.RibBtnName == name)
            return item;
        }

        return null;
      }
    }
	}
}
