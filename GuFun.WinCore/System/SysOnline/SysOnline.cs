using System;

namespace GuFun.WinCore
{
	public class SysOnline
	{

		#region Properties

		private string _manID;

		public string ManID
		{
			get { return _manID; }
			set { _manID = value; }
		}

		private string _manName;

		public string ManName
		{
			get { return _manName; }
			set { _manName = value; }
		}

		private DateTime _loginDate;

		public DateTime LoginDate
		{
			get { return _loginDate; }
			set { _loginDate = value; }
		}

		private DateTime _onlineDate;

		public DateTime OnlineDate
		{
			get { return _onlineDate; }
			set { _onlineDate = value; }
		}

		private string _menuCode;

		public string MenuCode
		{
			get { return _menuCode; }
			set { _menuCode = value; }
		}

		private short _regID;

		public short RegID
		{
			get { return _regID; }
			set { _regID = value; }
		}

		#endregion Properties

		public SysOnline()
		{
			_manID = String.Empty;
			_manName = String.Empty;
			_loginDate = DateTime.MinValue;
			_onlineDate = DateTime.MinValue;
			_menuCode = String.Empty;
			_regID = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[ManID] = " + this.ManID.ToString() + Environment.NewLine;
			rtn += "[ManName] = " + this.ManName.ToString() + Environment.NewLine;
			rtn += "[LoginDate] = " + this.LoginDate.ToString() + Environment.NewLine;
			rtn += "[OnlineDate] = " + this.OnlineDate.ToString() + Environment.NewLine;
			rtn += "[MenuCode] = " + this.MenuCode.ToString() + Environment.NewLine;
			rtn += "[RegID] = " + this.RegID.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}