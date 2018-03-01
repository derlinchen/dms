using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GuFun.WinCore
{
    public class BusHours
    {

        private string _hoursID;

        public string HoursID
        {
            get { return _hoursID; }
            set { _hoursID = value; }
        }

        private string _manID;

        public string ManID
        {
            get { return _manID; }
            set { _manID = value; }
        }

        private string _projectID;

        public string ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }

        private DateTime _workStart;

        public DateTime WorkStart
        {
            get { return _workStart; }
            set { _workStart = value; }
        }

        private DateTime _workEnd;

        public DateTime WorkEnd
        {
            get { return _workEnd; }
            set { _workEnd = value; }
        }

        private double _workCount;

        public double WorkCount
        {
            get { return _workCount; }
            set { _workCount = value; }
        }

        private int _dbID;

        public int DBID
        {
            get { return _dbID; }
            set { _dbID = value; }
        }

        public BusHours()
        {
            this._hoursID = String.Empty;
            this._manID = String.Empty;
            this._projectID = String.Empty;
            this._workStart  = DateTime.MinValue;
            this._workEnd = DateTime.MinValue;
            this._workCount = 0;
            this._dbID = 0;
        }


        public void OnPopulate(SqlDataReader reader)
        {
            this.HoursID = reader["HoursID"] as string;
            this.ManID = reader["ManID"] as string;
            this.ProjectID = reader["ProjectID"] as string;
            if (reader["WorkStart"] != DBNull.Value)
            {
                this.WorkStart = Convert.ToDateTime(reader["WorkStart"]);
            }
            if (reader["WorkEnd"] != DBNull.Value)
            {
                this.WorkEnd = Convert.ToDateTime(reader["WorkEnd"]);
            }
            if (reader["WorkCount"] != DBNull.Value)
            {
                this.WorkCount = Double.Parse(reader["WorkCount"].ToString());
            }
        }
    }
}
