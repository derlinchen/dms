using System;

namespace GuFun.WinCore
{
	public class SysCompany
	{

		#region Properties

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

		private DateTime _crtDate;

		public DateTime CrtDate
		{
			get { return _crtDate; }
			set { _crtDate = value; }
		}

		private string _coAddress;

		public string CoAddress
		{
			get { return _coAddress; }
			set { _coAddress = value; }
		}

		private string _coPost;

		public string CoPost
		{
			get { return _coPost; }
			set { _coPost = value; }
		}

		private string _coTele;

		public string CoTele
		{
			get { return _coTele; }
			set { _coTele = value; }
		}

		private string _coFax;

		public string CoFax
		{
			get { return _coFax; }
			set { _coFax = value; }
		}

		private string _coEMail;

		public string CoEMail
		{
			get { return _coEMail; }
			set { _coEMail = value; }
		}

		private string _coMan;

		public string CoMan
		{
			get { return _coMan; }
			set { _coMan = value; }
		}

		private short _sortOrder;

		public short SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		private short _coStatus;

		public short CoStatus
		{
			get { return _coStatus; }
			set { _coStatus = value; }
		}

		private string _coStatusName;

		public string CoStatusName
		{
			get { return _coStatusName; }
			set { _coStatusName = value; }
		}

		private string _remark;

		public string Remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

		#endregion Properties

		public SysCompany()
		{
			_coID = String.Empty;
			_coName = String.Empty;
			_crtDate = DateTime.MinValue;
			_coAddress = String.Empty;
			_coPost = String.Empty;
			_coTele = String.Empty;
			_coFax = String.Empty;
			_coEMail = String.Empty;
			_coMan = String.Empty;
			_sortOrder = 0;
			_coStatus = 0;
			_coStatusName = String.Empty;
			_remark = String.Empty;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[CoID] = " + this.CoID.ToString() + Environment.NewLine;
			rtn += "[CoName] = " + this.CoName.ToString() + Environment.NewLine;
			rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
			rtn += "[CoAddress] = " + this.CoAddress.ToString() + Environment.NewLine;
			rtn += "[CoPost] = " + this.CoPost.ToString() + Environment.NewLine;
			rtn += "[CoTele] = " + this.CoTele.ToString() + Environment.NewLine;
			rtn += "[CoFax] = " + this.CoFax.ToString() + Environment.NewLine;
			rtn += "[CoEMail] = " + this.CoEMail.ToString() + Environment.NewLine;
			rtn += "[CoMan] = " + this.CoMan.ToString() + Environment.NewLine;
			rtn += "[SortOrder] = " + this.SortOrder.ToString() + Environment.NewLine;
			rtn += "[CoStatus] = " + this.CoStatus.ToString() + Environment.NewLine;
			rtn += "[CoStatusName] = " + this.CoStatusName.ToString() + Environment.NewLine;
			rtn += "[Remark] = " + this.Remark.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}