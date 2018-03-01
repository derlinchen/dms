using System;
using System.Collections;

namespace GuFun.WinCore
{
  public class CacheParameters : CollectionBase
  {
    public CacheParameters()
      : base()
    {
    }

    public CacheParameter this[int index]
    {
      get { return (CacheParameter)base.List[index]; }
      set { base.List[index] = (CacheParameter)value; }
    }

    public void Add(CacheParameter item)
    {
      base.List.Add(item);

    }

    public CacheParameter this[string index]
    {
      get 
      {
        foreach (CacheParameter item in base.List)
        {
          if (item.Name == index)
            return item;
        }

        return null;
      }
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
