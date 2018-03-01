using System;

namespace GuFun.WinCore
{
	public class RibTab
	{

		#region Properties

		private short _id;

		public short ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _ribTabName;

		public string RibTabName
		{
			get { return _ribTabName; }
			set { _ribTabName = value; }
		}

		private short _ribOrder;

		public short RibOrder
		{
			get { return _ribOrder; }
			set { _ribOrder = value; }
		}

    private RibPanels _panels;

    public RibPanels Panels
    {
      get
      {
        if (_panels == null)
          _panels = new RibPanels();

        return _panels;
      }
    }

		#endregion Properties

		public RibTab()
		{
			_id = 0;
			_ribTabName = String.Empty;
			_ribOrder = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[ID] = " + this.ID.ToString() + Environment.NewLine;
			rtn += "[RibTabName] = " + this.RibTabName.ToString() + Environment.NewLine;
			rtn += "[RibOrder] = " + this.RibOrder.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}