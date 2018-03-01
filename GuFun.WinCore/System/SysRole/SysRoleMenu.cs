using System;

namespace GuFun.WinCore
{
  public class SysRoleMenu
  {
    #region Properties

		private short _roleID;

		public short RoleID
		{
			get { return _roleID; }
			set { _roleID = value; }
		}

		private short _mID;

		public short MID
		{
			get { return _mID; }
			set { _mID = value; }
		}

    private int _mAuth;

    public int MAuth
    {
      get { return _mAuth; }
      set { _mAuth = value; }
    }

		#endregion Properties

    public SysRoleMenu()
		{
			_roleID = 0;
      _mID = 0;
      _mAuth = 0;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[RoleID] = " + this.RoleID.ToString() + Environment.NewLine;
			rtn += "[MID] = " + this.MID.ToString() + Environment.NewLine;
			rtn += "[MAuth] = " + this.MAuth.ToString() + Environment.NewLine;
			return rtn;
		}
  }
}
