using System;

namespace GuFun.WinCore
{
	public class SysMenuGroup
	{

		#region Properties

		private short _mgID;

		public short MgID
		{
			get { return _mgID; }
			set { _mgID = value; }
		}

		private string _mgName;

		public string MgName
		{
			get { return _mgName; }
			set { _mgName = value; }
		}

		private string _mgTip;

		public string MgTip
		{
			get { return _mgTip; }
			set { _mgTip = value; }
		}

		private string _mgNormalIcon;

		public string MgNormalIcon
		{
			get { return _mgNormalIcon; }
			set { _mgNormalIcon = value; }
		}

		private string _mgHotIcon;

		public string MgHotIcon
		{
			get { return _mgHotIcon; }
			set { _mgHotIcon = value; }
		}

		private string _mgDisableIcon;

		public string MgDisableIcon
		{
			get { return _mgDisableIcon; }
			set { _mgDisableIcon = value; }
		}

		private short _mgIconIndex;

		public short MgIconIndex
		{
			get { return _mgIconIndex; }
			set { _mgIconIndex = value; }
		}

		private string _mgFunction;

		public string MgFunction
		{
			get { return _mgFunction; }
			set { _mgFunction = value; }
		}

		private short _mgStatus;

		public short MgStatus
		{
			get { return _mgStatus; }
			set { _mgStatus = value; }
		}

		private short _mgOrder;

		public short MgOrder
		{
			get { return _mgOrder; }
			set { _mgOrder = value; }
		}

    private SysMenus _menus;

    public SysMenus Menus
    {
      get
      {
        if (_menus == null)
          _menus = new SysMenus();

        return _menus;
      }
    }

		#endregion Properties

		public SysMenuGroup()
		{
			_mgID = 0;
			_mgName = String.Empty;
			_mgTip = String.Empty;
			_mgNormalIcon = String.Empty;
			_mgHotIcon = String.Empty;
			_mgDisableIcon = String.Empty;
			_mgIconIndex = -1;
			_mgFunction = String.Empty;
			_mgStatus = 0;
			_mgOrder = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[MgID] = " + this.MgID.ToString() + Environment.NewLine;
			rtn += "[MgName] = " + this.MgName.ToString() + Environment.NewLine;
			rtn += "[MgTip] = " + this.MgTip.ToString() + Environment.NewLine;
			rtn += "[MgNormalIcon] = " + this.MgNormalIcon.ToString() + Environment.NewLine;
			rtn += "[MgHotIcon] = " + this.MgHotIcon.ToString() + Environment.NewLine;
			rtn += "[MgDisableIcon] = " + this.MgDisableIcon.ToString() + Environment.NewLine;
			rtn += "[MgIconIndex] = " + this.MgIconIndex.ToString() + Environment.NewLine;
			rtn += "[MgFunction] = " + this.MgFunction.ToString() + Environment.NewLine;
			rtn += "[MgStatus] = " + this.MgStatus.ToString() + Environment.NewLine;
			rtn += "[MgOrder] = " + this.MgOrder.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}