using System;

namespace GuFun.WinCore
{
	public class SysLog
	{

		#region Properties

		private int _logID;

		public int LogID
		{
			get { return _logID; }
			set { _logID = value; }
		}

		private DateTime _logDate;

		public DateTime LogDate
		{
			get { return _logDate; }
			set { _logDate = value; }
		}

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

		private string _menuCode;

		public string MenuCode
		{
			get { return _menuCode; }
			set { _menuCode = value; }
		}

		private short _logAction;

		public short LogAction
		{
			get { return _logAction; }
			set { _logAction = value; }
		}

		private string _logContent;

		public string LogContent
		{
			get { return _logContent; }
			set { _logContent = value; }
		}

		#endregion Properties

		public SysLog()
		{
			_logID = 0;
			_logDate = DateTime.MinValue;
			_manID = String.Empty;
			_manName = String.Empty;
			_menuCode = String.Empty;
			_logAction = 0;
			_logContent = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[LogID] = " + this.LogID.ToString() + Environment.NewLine;
			rtn += "[LogDate] = " + this.LogDate.ToString() + Environment.NewLine;
			rtn += "[ManID] = " + this.ManID.ToString() + Environment.NewLine;
			rtn += "[ManName] = " + this.ManName.ToString() + Environment.NewLine;
			rtn += "[MenuCode] = " + this.MenuCode.ToString() + Environment.NewLine;
			rtn += "[LogAction] = " + this.LogAction.ToString() + Environment.NewLine;
			rtn += "[LogContent] = " + this.LogContent.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}