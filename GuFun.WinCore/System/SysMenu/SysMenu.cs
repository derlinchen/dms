using System;

namespace GuFun.WinCore
{
	public class SysMenu
	{

		#region Properties

		private short _mID;

		public short MID
		{
			get { return _mID; }
			set { _mID = value; }
		}

		private string _mName;

		public string MName
		{
			get { return _mName; }
			set { _mName = value; }
		}

		private short _mPID;

		public short MPID
		{
			get { return _mPID; }
			set { _mPID = value; }
		}

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

		private short _mLevel;

		public short MLevel
		{
			get { return _mLevel; }
			set { _mLevel = value; }
		}

		private short _mDisp;

		public short MDisp
		{
			get { return _mDisp; }
			set { _mDisp = value; }
		}

		private int _mAuth;

		public int MAuth
		{
			get { return _mAuth; }
			set { _mAuth = value; }
		}

		private string _mTip;

		public string MTip
		{
			get { return _mTip; }
			set { _mTip = value; }
		}

		private string _mFunction;

		public string MFunction
		{
			get { return _mFunction; }
			set { _mFunction = value; }
		}

		private bool _isLine;

		public bool IsLine
		{
			get { return _isLine; }
			set { _isLine = value; }
		}

		private bool _isSub;

		public bool IsSub
		{
			get { return _isSub; }
			set { _isSub = value; }
		}

		private short _mSID;

		public short MSID
		{
			get { return _mSID; }
			set { _mSID = value; }
		}

		private string _mNormalIcon;

		public string MNormalIcon
		{
			get { return _mNormalIcon; }
			set { _mNormalIcon = value; }
		}

		private string _mHotIcon;

		public string MHotIcon
		{
			get { return _mHotIcon; }
			set { _mHotIcon = value; }
		}

		private string _mDisableIcon;

		public string MDisableIcon
		{
			get { return _mDisableIcon; }
			set { _mDisableIcon = value; }
		}

		private short _mIconIndex;

		public short MIconIndex
		{
			get { return _mIconIndex; }
			set { _mIconIndex = value; }
		}

		private bool _isBase;

		public bool IsBase
		{
			get { return _isBase; }
			set { _isBase = value; }
		}

		private string _mCode;

		public string MCode
		{
			get { return _mCode; }
			set { _mCode = value; }
		}

		private short _mStatus;

		public short MStatus
		{
			get { return _mStatus; }
			set { _mStatus = value; }
		}

		private string _mShortcut;

		public string MShortcut
		{
			get { return _mShortcut; }
			set { _mShortcut = value; }
		}

    private SysMenus _subMenus;

    public SysMenus SubMenus
    {
      get
      {
        if (_subMenus == null)
          _subMenus = new SysMenus();

        return _subMenus;
      }
    }

		#endregion Properties

		public SysMenu()
		{
			_mID = 0;
			_mName = String.Empty;
			_mPID = 0;
			_mgID = 0;
			_mgName = String.Empty;
			_mLevel = 0;
			_mDisp = 0;
			_mAuth = 0;
			_mTip = String.Empty;
			_mFunction = String.Empty;
			_isLine = false;
			_isSub = false;
			_mSID = 0;
			_mNormalIcon = String.Empty;
			_mHotIcon = String.Empty;
			_mDisableIcon = String.Empty;
			_mIconIndex = -1;
			_isBase = false;
			_mCode = String.Empty;
			_mStatus = 0;
			_mShortcut = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[MID] = " + this.MID.ToString() + Environment.NewLine;
			rtn += "[MName] = " + this.MName.ToString() + Environment.NewLine;
			rtn += "[MPID] = " + this.MPID.ToString() + Environment.NewLine;
			rtn += "[MgID] = " + this.MgID.ToString() + Environment.NewLine;
			rtn += "[MgName] = " + this.MgName.ToString() + Environment.NewLine;
			rtn += "[MLevel] = " + this.MLevel.ToString() + Environment.NewLine;
			rtn += "[MDisp] = " + this.MDisp.ToString() + Environment.NewLine;
			rtn += "[MAuth] = " + this.MAuth.ToString() + Environment.NewLine;
			rtn += "[MTip] = " + this.MTip.ToString() + Environment.NewLine;
			rtn += "[MFunction] = " + this.MFunction.ToString() + Environment.NewLine;
			rtn += "[IsLine] = " + this.IsLine.ToString() + Environment.NewLine;
			rtn += "[IsSub] = " + this.IsSub.ToString() + Environment.NewLine;
			rtn += "[MSID] = " + this.MSID.ToString() + Environment.NewLine;
			rtn += "[MNormalIcon] = " + this.MNormalIcon.ToString() + Environment.NewLine;
			rtn += "[MHotIcon] = " + this.MHotIcon.ToString() + Environment.NewLine;
			rtn += "[MDisableIcon] = " + this.MDisableIcon.ToString() + Environment.NewLine;
			rtn += "[MIconIndex] = " + this.MIconIndex.ToString() + Environment.NewLine;
			rtn += "[IsBase] = " + this.IsBase.ToString() + Environment.NewLine;
			rtn += "[MCode] = " + this.MCode.ToString() + Environment.NewLine;
			rtn += "[MStatus] = " + this.MStatus.ToString() + Environment.NewLine;
			rtn += "[MShortcut] = " + this.MShortcut.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}