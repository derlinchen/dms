using System;
using System.Collections;

namespace GuFun.WinCore
{
	public class RibPanels : CollectionBase
	{
		public RibPanels()
			: base()
		{
		}

		public RibPanel this[int index]
		{
			get { return (RibPanel)base.List[index]; }
			set { base.List[index] = (RibPanel)value; }
		}

		public void Add(RibPanel item)
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

    public RibPanel FindByRibPanel(short id)
    {
      foreach (RibPanel item in this.List)
      {
        if (item.ID == id)
          return item;
      }

      return null;
    }

    public RibPanel this[string name]
    {
      get
      {
        foreach (RibPanel item in this.List)
        {
          if (item.RibPanelName == name)
            return item;
        }

        return null;
      }
    }
	}
}
