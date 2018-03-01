using System;

namespace GuFun.WinCore
{
    public class SetSql
    {

        #region Properties

        private string _sqlID;

        public string SqlID
        {
            get { return _sqlID; }
            set { _sqlID = value; }
        }

        private string _sqlName;

        public string SqlName
        {
            get { return _sqlName; }
            set { _sqlName = value; }
        }

        private short _sqlType;

        public short SqlType
        {
            get { return _sqlType; }
            set { _sqlType = value; }
        }

        private string _sqlText;

        public string SqlText
        {
            get { return _sqlText; }
            set { _sqlText = value; }
        }

        private string _sqlMainTable;

        public string SqlMainTable
        {
            get { return _sqlMainTable; }
            set { _sqlMainTable = value; }
        }

        private string _sqlKeys;

        public string SqlKeys
        {
            get { return _sqlKeys; }
            set { _sqlKeys = value; }
        }

        private string _sqlOrder;

        public string SqlOrder
        {
            get { return _sqlOrder; }
            set { _sqlOrder = value; }
        }

        private string _sqlGroup;

        public string SqlGroup
        {
            get { return _sqlGroup; }
            set { _sqlGroup = value; }
        }

        private string _sqlHaving;

        public string SqlHaving
        {
            get { return _sqlHaving; }
            set { _sqlHaving = value; }
        }

        private string _sqlDropdown;

        public string SqlDropdown
        {
            get { return _sqlDropdown; }
            set { _sqlDropdown = value; }
        }

        private DateTime _crtDate;

        public DateTime CrtDate
        {
            get { return _crtDate; }
            set { _crtDate = value; }
        }

        private short _sqlPageSize;

        public short SqlPageSize
        {
            get { return _sqlPageSize; }
            set { _sqlPageSize = value; }
        }

        private short _sqlPageHeigh;

        public short SqlPageHeigh
        {
            get { return _sqlPageHeigh; }
            set { _sqlPageHeigh = value; }
        }

        private short _sqlPageWidth;

        public short SqlPageWidth
        {
            get { return _sqlPageWidth; }
            set { _sqlPageWidth = value; }
        }

        private short _sqlOrietation;

        public short SqlOrietation
        {
            get { return _sqlOrietation; }
            set { _sqlOrietation = value; }
        }

        private short _sqlTopMargin;

        public short SqlTopMargin
        {
            get { return _sqlTopMargin; }
            set { _sqlTopMargin = value; }
        }

        private short _sqlBottomMargin;

        public short SqlBottomMargin
        {
            get { return _sqlBottomMargin; }
            set { _sqlBottomMargin = value; }
        }

        private short _sqlLeftMargin;

        public short SqlLeftMargin
        {
            get { return _sqlLeftMargin; }
            set { _sqlLeftMargin = value; }
        }

        private short _sqlRightMargin;

        public short SqlRightMargin
        {
            get { return _sqlRightMargin; }
            set { _sqlRightMargin = value; }
        }

        private string _sqlTitle;

        public string SqlTitle
        {
            get { return _sqlTitle; }
            set { _sqlTitle = value; }
        }

        private string _sqlTopFont;

        public string SqlTopFont
        {
            get { return _sqlTopFont; }
            set { _sqlTopFont = value; }
        }

        private string _sqlFont;

        public string SqlFont
        {
            get { return _sqlFont; }
            set { _sqlFont = value; }
        }

        private string _sqlISO;

        public string SqlISO
        {
            get { return _sqlISO; }
            set { _sqlISO = value; }
        }

        private bool _isPrintCompany;

        public bool IsPrintCompany
        {
            get { return _isPrintCompany; }
            set { _isPrintCompany = value; }
        }

        private short _sqlPrintSet;

        public short SqlPrintSet
        {
            get { return _sqlPrintSet; }
            set { _sqlPrintSet = value; }
        }

        private SetSqlDetails _items;

        public SetSqlDetails Items
        {
            get
            {
                if (_items == null)
                    _items = new SetSqlDetails();

                return _items;
            }
            set { _items = value; }
        }

        #endregion Properties

        public SetSql()
        {
            _sqlID = String.Empty;
            _sqlName = String.Empty;
            _sqlType = 0;
            _sqlText = String.Empty;
            _sqlMainTable = String.Empty;
            _sqlKeys = String.Empty;
            _sqlOrder = String.Empty;
            _sqlGroup = String.Empty;
            _sqlHaving = String.Empty;
            _sqlDropdown = String.Empty;
            _crtDate = DateTime.MinValue;
            _sqlPageSize = 0;
            _sqlPageHeigh = 0;
            _sqlPageWidth = 0;
            _sqlOrietation = 0;
            _sqlTopMargin = 0;
            _sqlBottomMargin = 0;
            _sqlLeftMargin = 0;
            _sqlRightMargin = 0;
            _sqlTitle = String.Empty;
            _sqlTopFont = String.Empty;
            _sqlFont = String.Empty;
            _sqlISO = String.Empty;
            _isPrintCompany = false;
            _sqlPrintSet = 0;
        }

        public string Debug()
        {
            string rtn = String.Empty;
            rtn += "[SqlID] = " + this.SqlID.ToString() + Environment.NewLine;
            rtn += "[SqlName] = " + this.SqlName.ToString() + Environment.NewLine;
            rtn += "[SqlType] = " + this.SqlType.ToString() + Environment.NewLine;
            rtn += "[SqlText] = " + this.SqlText.ToString() + Environment.NewLine;
            rtn += "[SqlMainTable] = " + this.SqlMainTable.ToString() + Environment.NewLine;
            rtn += "[SqlKeys] = " + this.SqlKeys.ToString() + Environment.NewLine;
            rtn += "[SqlOrder] = " + this.SqlOrder.ToString() + Environment.NewLine;
            rtn += "[SqlGroup] = " + this.SqlGroup.ToString() + Environment.NewLine;
            rtn += "[SqlHaving] = " + this.SqlHaving.ToString() + Environment.NewLine;
            rtn += "[SqlDropdown] = " + this.SqlDropdown.ToString() + Environment.NewLine;
            rtn += "[CrtDate] = " + this.CrtDate.ToString() + Environment.NewLine;
            rtn += "[SqlPageSize] = " + this.SqlPageSize.ToString() + Environment.NewLine;
            rtn += "[SqlPageHeigh] = " + this.SqlPageHeigh.ToString() + Environment.NewLine;
            rtn += "[SqlPageWidth] = " + this.SqlPageWidth.ToString() + Environment.NewLine;
            rtn += "[SqlOrietation] = " + this.SqlOrietation.ToString() + Environment.NewLine;
            rtn += "[SqlTopMargin] = " + this.SqlTopMargin.ToString() + Environment.NewLine;
            rtn += "[SqlBottomMargin] = " + this.SqlBottomMargin.ToString() + Environment.NewLine;
            rtn += "[SqlLeftMargin] = " + this.SqlLeftMargin.ToString() + Environment.NewLine;
            rtn += "[SqlRightMargin] = " + this.SqlRightMargin.ToString() + Environment.NewLine;
            rtn += "[SqlTitle] = " + this.SqlTitle.ToString() + Environment.NewLine;
            rtn += "[SqlTopFont] = " + this.SqlTopFont.ToString() + Environment.NewLine;
            rtn += "[SqlFont] = " + this.SqlFont.ToString() + Environment.NewLine;
            rtn += "[SqlISO] = " + this.SqlISO.ToString() + Environment.NewLine;
            rtn += "[IsPrintCompany] = " + this.IsPrintCompany.ToString() + Environment.NewLine;
            rtn += "[SqlPrintSet] = " + this.SqlPrintSet.ToString() + Environment.NewLine;
            return rtn;
        }
    }
}