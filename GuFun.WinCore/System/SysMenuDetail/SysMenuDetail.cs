using System;

namespace GuFun.WinCore
{
	public class SysMenuDetail
	{

		#region Properties

		private short _authID;

		public short AuthID
		{
			get { return _authID; }
			set { _authID = value; }
		}

		private short _mID;

		public short MID
		{
			get { return _mID; }
			set { _mID = value; }
		}

		#endregion Properties

		public SysMenuDetail()
		{
			_authID = 0;
			_mID = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[AuthID] = " + this.AuthID.ToString() + Environment.NewLine;
			rtn += "[MID] = " + this.MID.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}