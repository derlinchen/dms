using System;

namespace GuFun.WinCore
{
    public class SysMan
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

        private short _manType;

        public short ManType
        {
            get { return _manType; }
            set { _manType = value; }
        }

        private string _manTypeName;

        public string ManTypeName
        {
            get { return _manTypeName; }
            set { _manTypeName = value; }
        }

        private DateTime _crtDate;

        public DateTime CrtDate
        {
            get { return _crtDate; }
            set { _crtDate = value; }
        }

        private string _crtOper;

        public string CrtOper
        {
            get { return _crtOper; }
            set { _crtOper = value; }
        }

        private string _manTele;

        public string ManTele
        {
            get { return _manTele; }
            set { _manTele = value; }
        }

        private string _manEMail;

        public string ManEMail
        {
            get { return _manEMail; }
            set { _manEMail = value; }
        }

        private DateTime _manDate;

        public DateTime ManDate
        {
            get { return _manDate; }
            set { _manDate = value; }
        }

        private short _manLevel;

        public short ManLevel
        {
            get { return _manLevel; }
            set { _manLevel = value; }
        }

        private string _manLevelName;

        public string ManLevelName
        {
            get { return _manLevelName; }
            set { _manLevelName = value; }
        }

        private short _manTitle;

        public short ManTitle
        {
            get { return _manTitle; }
            set { _manTitle = value; }
        }

        private string _manTitleName;

        public string ManTitleName
        {
            get { return _manTitleName; }
            set { _manTitleName = value; }
        }

        private short _manSex;

        public short ManSex
        {
            get { return _manSex; }
            set { _manSex = value; }
        }

        private string _manSexName;

        public string ManSexName
        {
            get { return _manSexName; }
            set { _manSexName = value; }
        }

        private short _manStatus;

        public short ManStatus
        {
            get { return _manStatus; }
            set { _manStatus = value; }
        }

        private string _manStatusName;

        public string ManStatusName
        {
            get { return _manStatusName; }
            set { _manStatusName = value; }
        }

        private string _operPassword;

        public string OperPassword
        {
            get { return _operPassword; }
            set { _operPassword = value; }
        }

        private int _operSerial;

        public int OperSerial
        {
            get { return _operSerial; }
            set { _operSerial = value; }
        }

        private string _workDate;

        public string WorkDate
        {
            get { return _workDate; }
            set { _workDate = value; }
        }

        private short _authBound;

        public short AuthBound
        {
            get { return _authBound; }
            set { _authBound = value; }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private double _backCash;

        public double BackCash
        {
            get { return _backCash; }
            set { _backCash = value; }
        }

        private double _nowCash;

        public double NowCash
        {
            get { return _nowCash; }
            set { _nowCash = value; }
        }

        private string _preWorkDate;

        public string PreWorkDate
        {
            get { return _preWorkDate; }
            set { _preWorkDate = value; }
        }

        private bool _isLock;

        public bool IsLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }

        private bool _isFirst;

        public bool IsFirst
        {
            get { return _isFirst; }
            set { _isFirst = value; }
        }

        private bool _isBack;

        public bool IsBack
        {
            get { return _isBack; }
            set { _isBack = value; }
        }

        private bool _isDayCash;

        public bool IsDayCash
        {
            get { return _isDayCash; }
            set { _isDayCash = value; }
        }

        #endregion Properties

        public SysMan()
        {
            _manID = String.Empty;
            _manName = String.Empty;
            _coID = String.Empty;
            _coName = String.Empty;
            _deptID = String.Empty;
            _deptName = String.Empty;
            _manType = 0;
            _manTypeName = String.Empty;
            _crtDate = DateTime.MinValue;
            _crtOper = String.Empty;
            _manTele = String.Empty;
            _manEMail = String.Empty;
            _manDate = DateTime.MinValue;
            _manLevel = 0;
            _manLevelName = String.Empty;
            _manTitle = 0;
            _manTitleName = String.Empty;
            _manSex = 0;
            _manSexName = String.Empty;
            _manStatus = 0;
            _manStatusName = String.Empty;
            _operPassword = String.Empty;
            _operSerial = 0;
            _workDate = String.Empty;
            _authBound = 0;
            _isAdmin = false;
            _remark = String.Empty;
            _backCash = 0;
            _nowCash = 0;
            _preWorkDate = String.Empty;
            _isLock = false;
            _isFirst = false;
            _isDayCash = true;
            _isBack = true;
        }

        public string Debug()
        {
            string rtn = String.Empty;
            rtn += "[ManID] = " + this.ManID.ToString() + Environment.NewLine;
            rtn += "[ManName] = " + this.ManName.ToString() + Environment.NewLine;
            rtn += "[CoID] = " + this.CoID.ToString() + Environment.NewLine;
            rtn += "[CoName] = " + this.CoName.ToString() + Environment.NewLine;
            rtn += "[DeptID] = " + this.DeptID.ToString() + Environment.NewLine;
            rtn += "[DeptName] = " + this.DeptName.ToString() + Environment.NewLine;
            rtn += "[ManType] = " + this.ManType.ToString() + Environment.NewLine;
            rtn += "[ManTypeName] = " + this.ManTypeName.ToString() + Environment.NewLine;
            rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
            rtn += "[CrtOper] = " + this.CrtOper.ToString() + Environment.NewLine;
            rtn += "[ManTele] = " + this.ManTele.ToString() + Environment.NewLine;
            rtn += "[ManEMail] = " + this.ManEMail.ToString() + Environment.NewLine;
            rtn += "[ManDate] = " + this.ManDate.ToString() + Environment.NewLine;
            rtn += "[ManLevel] = " + this.ManLevel.ToString() + Environment.NewLine;
            rtn += "[ManLevelName] = " + this.ManLevelName.ToString() + Environment.NewLine;
            rtn += "[ManTitle] = " + this.ManTitle.ToString() + Environment.NewLine;
            rtn += "[ManTitleName] = " + this.ManTitleName.ToString() + Environment.NewLine;
            rtn += "[ManSex] = " + this.ManSex.ToString() + Environment.NewLine;
            rtn += "[ManSexName] = " + this.ManSexName.ToString() + Environment.NewLine;
            rtn += "[ManStatus] = " + this.ManStatus.ToString() + Environment.NewLine;
            rtn += "[ManStatusName] = " + this.ManStatusName.ToString() + Environment.NewLine;
            rtn += "[OperPassword] = " + this.OperPassword.ToString() + Environment.NewLine;
            rtn += "[OperSerial] = " + this.OperSerial.ToString() + Environment.NewLine;
            rtn += "[WorkDate] = " + this.WorkDate.ToString() + Environment.NewLine;
            rtn += "[AuthBound] = " + this.AuthBound.ToString() + Environment.NewLine;
            rtn += "[IsAdmin] = " + this.IsAdmin.ToString() + Environment.NewLine;
            rtn += "[Remark] = " + this.Remark.ToString() + Environment.NewLine;
            rtn += "[BackCash] = " + this.BackCash.ToString() + Environment.NewLine;
            return rtn;
        }
    }
}