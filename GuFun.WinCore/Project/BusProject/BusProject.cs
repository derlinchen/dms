using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuFun.WinCore
{
    public class BusProject
    {
        private string _projectID;

        public string ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }

        private string _projectCode;

        public string ProjectCode
        {
            get { return _projectCode; }
            set { _projectCode = value; }
        }

        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        private string _projectType;

        public string ProjectType
        {
            get { return _projectType; }
            set { _projectType = value; }
        }

        private string _projectStatus;

        public string ProjectStatus
        {
            get { return _projectStatus; }
            set { _projectStatus = value; }
        }

        private string _projectManager;

        public string ProjectManager
        {
            get { return _projectManager; }
            set { _projectManager = value; }
        }

        private double _workDate;

        public double WorkDate
        {
            get { return _workDate; }
            set { _workDate = value; }
        }

        private string _workUnit;

        public string WorkUnit
        {
            get { return _workUnit; }
            set { _workUnit = value; }
        }

        private string _projectDesc;

        public string ProjectDesc
        {
            get { return _projectDesc; }
            set { _projectDesc = value; }
        }

        private DateTime _tranDate;

        public DateTime TranDate
        {
            get { return _tranDate; }
            set { _tranDate = value; }
        }

        private string _tranUser;

        public string TranUser
        {
            get { return _tranUser; }
            set { _tranUser = value; }
        }

        public BusProject()
        {
            this._projectID = String.Empty;
            this._projectCode = String.Empty;
            this._projectName = String.Empty;
            this._projectType = String.Empty;
            this._projectStatus = String.Empty;
            this._projectManager = String.Empty;
            this._workDate = 0;
            this._workUnit = String.Empty;
            this._projectDesc = String.Empty;
            this._tranDate = DateTime.MinValue;
            this._tranUser = String.Empty;
        }

        public string Debug()
        {
            string rtn = String.Empty;
            rtn += "[ProjectID] = " + this.ProjectID.ToString() + Environment.NewLine;
            rtn += "[ProjectCode] = " + this.ProjectCode.ToString() + Environment.NewLine;
            rtn += "[ProjectName] = " + this.ProjectName.ToString() + Environment.NewLine;
            rtn += "[ProjectType] = " + this.ProjectType.ToString() + Environment.NewLine;
            rtn += "[ProjectStatus] = " + this.ProjectStatus.ToString() + Environment.NewLine;
            rtn += "[ProjectManager] = " + this.ProjectManager.ToString() + Environment.NewLine;
            rtn += "[WorkDate] = " + this.WorkDate.ToString() + Environment.NewLine;
            rtn += "[WorkUnit] = " + this.WorkUnit.ToString() + Environment.NewLine;
            rtn += "[ProjectDesc] = " + this.ProjectDesc.ToString() + Environment.NewLine;
            rtn += "[TranDate] = " + this.TranDate.ToString() + Environment.NewLine;
            rtn += "[TranUser] = " + this.TranUser.ToString() + Environment.NewLine;
            return rtn;

        }
    }
}
