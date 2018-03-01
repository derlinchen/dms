using System;

namespace GuFun.WinCore
{
	public class RibPanel
	{

		#region Properties

		private short _id;

		public short ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _ribPanelName;

		public string RibPanelName
		{
			get { return _ribPanelName; }
			set { _ribPanelName = value; }
		}

		private short _ribOrder;

		public short RibOrder
		{
			get { return _ribOrder; }
			set { _ribOrder = value; }
		}

		private short _ribTab;

		public short RibTab
		{
			get { return _ribTab; }
			set { _ribTab = value; }
		}

		private string _ribTabName;

		public string RibTabName
		{
			get { return _ribTabName; }
			set { _ribTabName = value; }
		}

    private RibButtons _buttons;

    public RibButtons Buttons
    {
      get
      {
        if (_buttons == null)
          _buttons = new RibButtons();

        return _buttons;
      }
    }

		#endregion Properties

		public RibPanel()
		{
			_id = 0;
			_ribPanelName = String.Empty;
			_ribOrder = 0;
			_ribTab = 0;
			_ribTabName = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[ID] = " + this.ID.ToString() + Environment.NewLine;
			rtn += "[RibPanelName] = " + this.RibPanelName.ToString() + Environment.NewLine;
			rtn += "[RibOrder] = " + this.RibOrder.ToString() + Environment.NewLine;
			rtn += "[RibTab] = " + this.RibTab.ToString() + Environment.NewLine;
			rtn += "[RibTabName] = " + this.RibTabName.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}