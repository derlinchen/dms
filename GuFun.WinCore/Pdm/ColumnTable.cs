using GuFun.WinCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class ColumnTable
    {
        public ColumnTable()
        {
            this.OnInit();
        }

        public ColumnTable(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int DBID { get; set; }
        public int ColumnSerial { get; set; }
        public string TableCode { get; set; }
        public string ColumnCode { get; set; }
        public string DisplayColumn { get; set; }
        public string RelaTable { get; set; }
        public string RelaColumn { get; set; }
        public string Prefix { get; set; }
        public string DataType { get; set; }
        public string ColumnName { get; set; }
        public int ColumnLength { get; set; }
        public bool ColumnNotNull { get; set; }

        public ColType GetColType()
        {
            return PublicTools.CheckColumnType(this.DataType);
        }

        public void OnInit()
        {
            this.DBID = 0;
            this.ColumnSerial = 0;
            this.TableCode = String.Empty;
            this.ColumnCode = String.Empty;
            this.RelaTable = String.Empty;
            this.RelaColumn = String.Empty;
            this.DisplayColumn = String.Empty;
            this.Prefix = String.Empty;
            this.DataType = String.Empty;
            this.ColumnName = String.Empty;
            this.ColumnLength = 0;
            this.ColumnNotNull = true;
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.ColumnSerial = (int)reader["ColumnSerial"];
            this.TableCode = reader["TableCode"] as string;

            this.ColumnCode = reader["ColumnCode"] as string;
            this.RelaTable = reader["RelaTable"] as string;
            this.RelaColumn = reader["RelaColumn"] as string;
            this.DisplayColumn = reader["DisplayColumn"] as string;
            this.Prefix = reader["Prefix"] as string;
            this.DataType = reader["DataType"] as string;
            this.ColumnName = reader["ColumnName"] as string;
            this.ColumnLength = (int)reader["ColumnLength"];
            this.ColumnNotNull = Convert.ToBoolean(reader["ColumnNotNull"]);
        }
    }
}
