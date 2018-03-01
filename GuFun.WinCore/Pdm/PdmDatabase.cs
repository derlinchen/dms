using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmDatabase
    {
        public PdmDatabase()
        {
            this.OnInit();
        }

        public PdmDatabase(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int DBID { get; set; }

        public string DBName { get; set; }

        public string DBCode { get; set; }

        public int DBSerial { get; set; }

        public string ProjectID { get; set; }

        public void OnInit()
        {
            this.DBID = 0;
            this.DBName = String.Empty;
            this.DBCode = String.Empty;
            this.DBSerial = 0;
            this.ProjectID = String.Empty;
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.DBName = reader["DBName"] as string;
            this.DBCode = reader["DBCode"] as string;
            this.DBSerial = (int)reader["DBSerial"];
            this.ProjectID = reader["ProjectID"] as string;
        }
    }
}
