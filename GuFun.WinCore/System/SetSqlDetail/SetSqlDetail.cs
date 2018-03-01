using System;

namespace GuFun.WinCore
{
	public class SetSqlDetail
	{

		#region Properties

		private string _sqlID;

		public string SqlID
		{
			get { return _sqlID; }
			set { _sqlID = value; }
		}

		private short _colID;

		public short ColID
		{
			get { return _colID; }
			set { _colID = value; }
		}

		private string _colName;

		public string ColName
		{
			get { return _colName; }
			set { _colName = value; }
		}

		private string _colCode;

		public string ColCode
		{
			get { return _colCode; }
			set { _colCode = value; }
		}

		private string _colBaseCode;

		public string ColBaseCode
		{
			get { return _colBaseCode; }
			set { _colBaseCode = value; }
		}

		private short _colType;

		public short ColType
		{
			get { return _colType; }
			set { _colType = value; }
		}

		private short _dispSize;

		public short DispSize
		{
			get { return _dispSize; }
			set { _dispSize = value; }
		}

		private short _dispOrder;

		public short DispOrder
		{
			get { return _dispOrder; }
			set { _dispOrder = value; }
		}

		private short _dispAuth;

		public short DispAuth
		{
			get { return _dispAuth; }
			set { _dispAuth = value; }
		}

		private bool _isVisible;

		public bool IsVisible
		{
			get { return _isVisible; }
			set { _isVisible = value; }
		}

		private bool _isPrint;

		public bool IsPrint
		{
			get { return _isPrint; }
			set { _isPrint = value; }
		}

		private bool _isOrder;

		public bool IsOrder
		{
			get { return _isOrder; }
			set { _isOrder = value; }
		}

		private bool _isLock;

		public bool IsLock
		{
			get { return _isLock; }
			set { _isLock = value; }
		}

		private bool _isAlias;

		public bool IsAlias
		{
			get { return _isAlias; }
			set { _isAlias = value; }
		}

		private short _colFoot;

		public short ColFoot
		{
			get { return _colFoot; }
			set { _colFoot = value; }
		}

		private string _colFootValue;

		public string ColFootValue
		{
			get { return _colFootValue; }
			set { _colFootValue = value; }
		}

		private string _relaSql;

		public string RelaSql
		{
			get { return _relaSql; }
			set { _relaSql = value; }
		}

    private string _colFormat;

    public string ColFormat
    {
      get { return _colFormat; }
      set { _colFormat = value; }
    }

		#endregion Properties

		public SetSqlDetail()
		{
			_sqlID = String.Empty;
			_colID = 0;
			_colName = String.Empty;
			_colCode = String.Empty;
			_colBaseCode = String.Empty;
			_colType = 0;
			_dispSize = 0;
			_dispOrder = 0;
			_dispAuth = 0;
			_isVisible = false;
			_isPrint = false;
			_isOrder = false;
			_isLock = false;
			_isAlias = false;
			_colFoot = 0;
			_colFootValue = String.Empty;
			_relaSql = String.Empty;
      _colFormat = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[SqlID] = " + this.SqlID.ToString() + Environment.NewLine;
			rtn += "[ColID] = " + this.ColID.ToString() + Environment.NewLine;
			rtn += "[ColName] = " + this.ColName.ToString() + Environment.NewLine;
			rtn += "[ColCode] = " + this.ColCode.ToString() + Environment.NewLine;
			rtn += "[ColBaseCode] = " + this.ColBaseCode.ToString() + Environment.NewLine;
			rtn += "[ColType] = " + this.ColType.ToString() + Environment.NewLine;
			rtn += "[DispSize] = " + this.DispSize.ToString() + Environment.NewLine;
			rtn += "[DispOrder] = " + this.DispOrder.ToString() + Environment.NewLine;
			rtn += "[DispAuth] = " + this.DispAuth.ToString() + Environment.NewLine;
			rtn += "[IsVisible] = " + this.IsVisible.ToString() + Environment.NewLine;
			rtn += "[IsPrint] = " + this.IsPrint.ToString() + Environment.NewLine;
			rtn += "[IsOrder] = " + this.IsOrder.ToString() + Environment.NewLine;
			rtn += "[IsLock] = " + this.IsLock.ToString() + Environment.NewLine;
			rtn += "[IsAlias] = " + this.IsAlias.ToString() + Environment.NewLine;
			rtn += "[ColFoot] = " + this.ColFoot.ToString() + Environment.NewLine;
			rtn += "[ColFootValue] = " + this.ColFootValue.ToString() + Environment.NewLine;
			rtn += "[RelaSql] = " + this.RelaSql.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}