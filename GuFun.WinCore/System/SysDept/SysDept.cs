using System;

namespace GuFun.WinCore
{
	public class SysDept
	{

		#region Properties

		private string _deptID;

		public string DeptID
		{
			get { return _deptID; }
			set { _deptID = value; }
		}

		private string _deptName;

		public string DeptName
		{
			get { return _deptName; }
			set { _deptName = value; }
		}

    private string _deptShort;

    public string DeptShort
    {
      get { return _deptShort; }
      set { _deptShort = value; }
    }

		private string _coID;

		public string CoID
		{
			get { return _coID; }
			set { _coID = value; }
		}

		private string _coName;

		public string CoName
		{
			get { return _coName; }
			set { _coName = value; }
		}

		private string _deptPID;

		public string DeptPID
		{
			get { return _deptPID; }
			set { _deptPID = value; }
		}

		private DateTime _crtDate;

		public DateTime CrtDate
		{
			get { return _crtDate; }
			set { _crtDate = value; }
		}

		private string _deptAddress;

		public string DeptAddress
		{
			get { return _deptAddress; }
			set { _deptAddress = value; }
		}

		private string _deptPost;

		public string DeptPost
		{
			get { return _deptPost; }
			set { _deptPost = value; }
		}

		private string _deptTele;

		public string DeptTele
		{
			get { return _deptTele; }
			set { _deptTele = value; }
		}

		private string _deptFax;

		public string DeptFax
		{
			get { return _deptFax; }
			set { _deptFax = value; }
		}

		private string _deptEMail;

		public string DeptEMail
		{
			get { return _deptEMail; }
			set { _deptEMail = value; }
		}

		private string _deptMan;

		public string DeptMan
		{
			get { return _deptMan; }
			set { _deptMan = value; }
		}

		private short _deptLevel;

		public short DeptLevel
		{
			get { return _deptLevel; }
			set { _deptLevel = value; }
		}

		private string _deptLevelName;

		public string DeptLevelName
		{
			get { return _deptLevelName; }
			set { _deptLevelName = value; }
		}

		private short _deptType;

		public short DeptType
		{
			get { return _deptType; }
			set { _deptType = value; }
		}

		private string _deptTypeName;

		public string DeptTypeName
		{
			get { return _deptTypeName; }
			set { _deptTypeName = value; }
		}

		private short _deptDepth;

		public short DeptDepth
		{
			get { return _deptDepth; }
			set { _deptDepth = value; }
		}

		private short _sortOrder;

		public short SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		private short _deptStatus;

		public short DeptStatus
		{
			get { return _deptStatus; }
			set { _deptStatus = value; }
		}

		private string _deptStatusName;

		public string DeptStatusName
		{
			get { return _deptStatusName; }
			set { _deptStatusName = value; }
		}

		private string _authDept;

		public string AuthDept
		{
			get { return _authDept; }
			set { _authDept = value; }
		}

		private string _remark;

		public string Remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

    private short _deptFlow;

    public short DeptFlow
    {
      get { return _deptFlow; }
      set { _deptFlow = value; }
    }

		#endregion Properties

		public SysDept()
		{
			_deptID = String.Empty;
			_deptName = String.Empty;
			_coID = String.Empty;
			_coName = String.Empty;
			_deptPID = String.Empty;
			_crtDate = DateTime.MinValue;
			_deptAddress = String.Empty;
			_deptPost = String.Empty;
			_deptTele = String.Empty;
			_deptFax = String.Empty;
			_deptEMail = String.Empty;
			_deptMan = String.Empty;
			_deptLevel = 0;
			_deptLevelName = String.Empty;
			_deptType = 0;
			_deptTypeName = String.Empty;
			_deptDepth = 0;
			_sortOrder = 0;
			_deptStatus = 0;
			_deptStatusName = String.Empty;
			_authDept = String.Empty;
			_remark = String.Empty;
      _deptShort = String.Empty;
      _deptFlow = 1;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[DeptID] = " + this.DeptID.ToString() + Environment.NewLine;
			rtn += "[DeptName] = " + this.DeptName.ToString() + Environment.NewLine;
			rtn += "[CoID] = " + this.CoID.ToString() + Environment.NewLine;
			rtn += "[CoName] = " + this.CoName.ToString() + Environment.NewLine;
			rtn += "[DeptPID] = " + this.DeptPID.ToString() + Environment.NewLine;
			rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
			rtn += "[DeptAddress] = " + this.DeptAddress.ToString() + Environment.NewLine;
			rtn += "[DeptPost] = " + this.DeptPost.ToString() + Environment.NewLine;
			rtn += "[DeptTele] = " + this.DeptTele.ToString() + Environment.NewLine;
			rtn += "[DeptFax] = " + this.DeptFax.ToString() + Environment.NewLine;
			rtn += "[DeptEMail] = " + this.DeptEMail.ToString() + Environment.NewLine;
			rtn += "[DeptMan] = " + this.DeptMan.ToString() + Environment.NewLine;
			rtn += "[DeptLevel] = " + this.DeptLevel.ToString() + Environment.NewLine;
			rtn += "[DeptLevelName] = " + this.DeptLevelName.ToString() + Environment.NewLine;
			rtn += "[DeptType] = " + this.DeptType.ToString() + Environment.NewLine;
			rtn += "[DeptTypeName] = " + this.DeptTypeName.ToString() + Environment.NewLine;
			rtn += "[DeptDepth] = " + this.DeptDepth.ToString() + Environment.NewLine;
			rtn += "[SortOrder] = " + this.SortOrder.ToString() + Environment.NewLine;
			rtn += "[DeptStatus] = " + this.DeptStatus.ToString() + Environment.NewLine;
			rtn += "[DeptStatusName] = " + this.DeptStatusName.ToString() + Environment.NewLine;
			rtn += "[AuthDept] = " + this.AuthDept.ToString() + Environment.NewLine;
			rtn += "[Remark] = " + this.Remark.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}