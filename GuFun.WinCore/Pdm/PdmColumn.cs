using GuFun.WinCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmColumn
    {
        public PdmColumn()
        {
            this.OnInit();
        }

        public PdmColumn(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int ColumnID { get; set; }

        public string PdmID { get; set; }

        public string ColumnName { get; set; }

        public string ColumnCode { get; set; }

        public string ColumnComment { get; set; }

        public string DataType { get; set; }

        public int Length { get; set; }

        public int Precision { get; set; }

        public bool Identity { get; set; }

        public bool NotNull { get; set; }

        public int DBID { get; set; }

        public string TableCode { get; set; }

        public int PreSerial { get; set; }

        public int NowSerial { get; set; }

        public ColType GetColType()
        {
            return PublicTools.CheckColumnType(this.DataType);
        }

        public PdmColumn Copy()
        {
            PdmColumn rtn = new PdmColumn();

            rtn.ColumnID = this.ColumnID;
            rtn.PdmID = this.PdmID;
            rtn.ColumnName = this.ColumnName;
            rtn.ColumnCode = this.ColumnCode;
            rtn.ColumnComment = this.ColumnComment;
            rtn.DataType = this.DataType;
            rtn.Length = this.Length;
            rtn.Precision = this.Precision;
            rtn.Identity = this.Identity;
            rtn.Identity = this.Identity;

            return rtn;
        }

        public void OnInit()
        {
            this.ColumnID = 0;
            this.PdmID = String.Empty;
            this.ColumnName = String.Empty;
            this.ColumnCode = String.Empty;
            this.ColumnComment = String.Empty;
            this.DataType = String.Empty;
            this.Length = 0;
            this.Precision = 0;
            this.Identity = false;
            this.NotNull = false;
            this.DBID = 0;
            this.TableCode = String.Empty;
            this.NowSerial = 0;
            this.Precision = 0;
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.NowSerial = (int)reader["NowSerial"];
            this.PreSerial = (int)reader["PreSerial"];
            this.TableCode = reader["TableCode"] as string;

            this.ColumnID = (int)reader["ColumnID"];
            this.ColumnName = reader["ColumnName"] as string;
            this.ColumnCode = reader["ColumnCode"] as string;
            this.DataType = reader["DataType"] as string;
            this.Length = (int)reader["ColumnLength"];
            this.Precision = (int)reader["ColumnPrecision"];
            this.Identity = Convert.ToBoolean(reader["ColumnIdentity"]);
            this.NotNull = Convert.ToBoolean(reader["ColumnNotNull"]);
        }

        public bool OnEqual(PdmColumn col)
        {
            return (col.TableCode == this.TableCode) && (col.ColumnName == this.ColumnName) && (col.DBID == this.DBID)
                && (col.ColumnCode == this.ColumnCode) && (col.ColumnID == this.ColumnID) && (col.DataType == this.DataType) && (col.Length == this.Length)
                && (col.Precision == this.Precision) && (col.Identity == this.Identity) && (col.NotNull == this.NotNull);
        }
    }
}
