using System;

namespace GuFun.WinCore
{
	public class SysRole
	{

		#region Properties

		private short _roleID;

		public short RoleID
		{
			get { return _roleID; }
			set { _roleID = value; }
		}

		private string _roleName;

		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value; }
		}

		private string _roleDesc;

		public string RoleDesc
		{
			get { return _roleDesc; }
			set { _roleDesc = value; }
		}

		private DateTime _crtDate;

		public DateTime CrtDate
		{
			get { return _crtDate; }
			set { _crtDate = value; }
		}

		private string _roleMan;

		public string RoleMan
		{
			get { return _roleMan; }
			set { _roleMan = value; }
		}

    private short _authBound;

    public short AuthBound
    {
      get { return _authBound; }
      set { _authBound = value; }
    }

		#endregion Properties

		public SysRole()
		{
			_roleID = 0;
			_roleName = String.Empty;
			_roleDesc = String.Empty;
			_crtDate = DateTime.MinValue;
			_roleMan = String.Empty;
      _authBound = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[RoleID] = " + this.RoleID.ToString() + Environment.NewLine;
			rtn += "[RoleName] = " + this.RoleName.ToString() + Environment.NewLine;
			rtn += "[RoleDesc] = " + this.RoleDesc.ToString() + Environment.NewLine;
			rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
			rtn += "[RoleMan] = " + this.RoleMan.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}