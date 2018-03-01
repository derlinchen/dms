using System;

namespace GuFun.WinCore
{
	public class RibButton
	{

		#region Properties

		private short _ribBtn;

		public short RibBtn
		{
			get { return _ribBtn; }
			set { _ribBtn = value; }
		}

		private string _ribBtnName;

		public string RibBtnName
		{
			get { return _ribBtnName; }
			set { _ribBtnName = value; }
		}

		private short _ribBtnType;

		public short RibBtnType
		{
			get { return _ribBtnType; }
			set { _ribBtnType = value; }
		}

		private short _ribOrder;

		public short RibOrder
		{
			get { return _ribOrder; }
			set { _ribOrder = value; }
		}

		private short _ribPanel;

		public short RibPanel
		{
			get { return _ribPanel; }
			set { _ribPanel = value; }
		}

		private string _ribPanelName;

		public string RibPanelName
		{
			get { return _ribPanelName; }
			set { _ribPanelName = value; }
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

		private string _ribImage;

		public string RibImage
		{
			get { return _ribImage; }
			set { _ribImage = value; }
		}

		private short _ribImageIndex;

		public short RibImageIndex
		{
			get { return _ribImageIndex; }
			set { _ribImageIndex = value; }
		}

		private string _mFunction;

		public string MFunction
		{
			get { return _mFunction; }
			set { _mFunction = value; }
		}

		private string _mCode;

		public string MCode
		{
			get { return _mCode; }
			set { _mCode = value; }
		}

		private short _mID;

		public short MID
		{
			get { return _mID; }
			set { _mID = value; }
		}

		private string _ribCode;

		public string RibCode
		{
			get { return _ribCode; }
			set { _ribCode = value; }
		}

		#endregion Properties

		public RibButton()
		{
			_ribBtn = 0;
			_ribBtnName = String.Empty;
			_ribBtnType = 0;
			_ribOrder = 0;
			_ribPanel = 0;
			_ribPanelName = String.Empty;
			_ribTab = 0;
			_ribTabName = String.Empty;
			_ribImage = String.Empty;
			_ribImageIndex = 0;
			_mFunction = String.Empty;
			_mCode = String.Empty;
			_mID = 0;
			_ribCode = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[RibBtn] = " + this.RibBtn.ToString() + Environment.NewLine;
			rtn += "[RibBtnName] = " + this.RibBtnName.ToString() + Environment.NewLine;
			rtn += "[RibBtnType] = " + this.RibBtnType.ToString() + Environment.NewLine;
			rtn += "[RibOrder] = " + this.RibOrder.ToString() + Environment.NewLine;
			rtn += "[RibPanel] = " + this.RibPanel.ToString() + Environment.NewLine;
			rtn += "[RibPanelName] = " + this.RibPanelName.ToString() + Environment.NewLine;
			rtn += "[RibTab] = " + this.RibTab.ToString() + Environment.NewLine;
			rtn += "[RibTabName] = " + this.RibTabName.ToString() + Environment.NewLine;
			rtn += "[RibImage] = " + this.RibImage.ToString() + Environment.NewLine;
			rtn += "[RibImageIndex] = " + this.RibImageIndex.ToString() + Environment.NewLine;
			rtn += "[MFunction] = " + this.MFunction.ToString() + Environment.NewLine;
			rtn += "[MCode] = " + this.MCode.ToString() + Environment.NewLine;
			rtn += "[MID] = " + this.MID.ToString() + Environment.NewLine;
			rtn += "[RibCode] = " + this.RibCode.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}