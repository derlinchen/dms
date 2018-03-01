using System;
using System.Windows.Forms;
using System.Collections;

namespace GuFun.WinControls
{
  public class TreeNodeBounds : CollectionBase
  {
    public TreeNodeBounds()
			: base()
		{
		}

    public TreeNodeBound this[int index]
		{
      get { return (TreeNodeBound)base.List[index]; }
      set { base.List[index] = (TreeNode)value; }
		}

    public TreeNodeBound this[object value]
    {
      get 
      {
        foreach (TreeNodeBound tn in this.List)
        {
          if (tn.Value.ToString() == value.ToString())
            return tn;
        }

        return null;
      }
    }

    public void Add(TreeNode item)
		{
			base.List.Add(item);

		}

    public void Remove(object value)
    {
      int i = 0;
      foreach (TreeNodeBound tn in this.List)
      {
        if (tn.Value.ToString() == value.ToString())
        {
          Remove(i);
        }
        i++;
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
