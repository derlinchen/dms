using System;

namespace GuFun.WinCore
{
	public class SysRegister
	{

		#region Properties

		private short _regID;

		public short RegID
		{
			get { return _regID; }
			set { _regID = value; }
		}

		private string _cpuCode;

		public string CpuCode
		{
			get { return _cpuCode; }
			set { _cpuCode = value; }
		}

		private string _regNumber;

		public string RegNumber
		{
			get { return _regNumber; }
			set { _regNumber = value; }
		}

		private string _regCode;

		public string RegCode
		{
			get { return _regCode; }
			set { _regCode = value; }
		}

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

		private DateTime _crtDate;

		public DateTime CrtDate
		{
			get { return _crtDate; }
			set { _crtDate = value; }
		}

		#endregion Properties

		public SysRegister()
		{
			_regID = 0;
			_cpuCode = String.Empty;
			_regNumber = String.Empty;
			_regCode = String.Empty;
			_deptID = String.Empty;
			_deptName = String.Empty;
			_crtDate = DateTime.Now;
		}

		public string Debug()
		{
			string rtn = String.Empty;
			rtn += "[RegID] = " + this.RegID.ToString() + Environment.NewLine;
			rtn += "[CpuCode] = " + this.CpuCode.ToString() + Environment.NewLine;
			rtn += "[RegNumber] = " + this.RegNumber.ToString() + Environment.NewLine;
			rtn += "[RegCode] = " + this.RegCode.ToString() + Environment.NewLine;
			rtn += "[DeptID] = " + this.DeptID.ToString() + Environment.NewLine;
			rtn += "[DeptName] = " + this.DeptName.ToString() + Environment.NewLine;
			rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
			return rtn;
		}
	}
}