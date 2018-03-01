using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmTable
    {
        public PdmTable()
        {
            this.OnInit();
        }

        public PdmTable(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int TableID { get; set; }

        public string PdmID { get; set; }

        public string TableName { get; set; }

        public string TableCode { get; set; }

        public bool IsPmt { get; set; }

        public string Comment { get; set; }

        public int DBID { get; set; }

        public int PreSerial { get; set; }

        public int NowSerial { get; set; }

        public string TableSet { get; set; }

        public void OnInit()
        {
            this.TableID = 0;
            this.PdmID = String.Empty;
            this.TableName = String.Empty;
            this.TableCode = String.Empty;
            this.IsPmt = false;
            this.DBID = 0;
            this.NowSerial = 0;
            this.PreSerial = 0;
            this.Comment = String.Empty;
            this.TableSet = String.Empty;

            this.Columns.Clear();
            this.Indexs.Clear();
            this.Keys.Clear();
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.NowSerial = (int)reader["NowSerial"];
            this.PreSerial = (int)reader["PreSerial"];
            this.TableName = reader["TableName"] as string;
            this.TableCode = reader["TableCode"] as string;
            this.IsPmt = Convert.ToBoolean(reader["IsPmt"]);
            if (reader["Comment"] != DBNull.Value)
                this.Comment = reader["Comment"] as string;
        }

        public bool OnEqual(PdmTable tbl)
        {
            return (tbl.TableName == this.TableName) && (tbl.TableCode == this.TableCode) && (tbl.DBID == this.DBID) && (tbl.Comment == this.Comment);
        }

        IList<PdmColumn> columns;

        public IList<PdmColumn> Columns
        {
            get
            {
                if (columns == null)
                    columns = new List<PdmColumn>();

                return columns;
            }
        }

        IList<PdmKey> keys;

        public IList<PdmKey> Keys
        {
            get
            {
                if (keys == null)
                    keys = new List<PdmKey>();

                return keys;
            }
        }

        IList<PdmIndex> indexs;

        public IList<PdmIndex> Indexs
        {
            get
            {
                if (indexs == null)
                    indexs = new List<PdmIndex>();

                return indexs;
            }
        }

        public void AddColumn(PdmColumn mColumn)
        {
            this.Columns.Add(mColumn);
        }

        public void AddKey(PdmKey mKey)
        {
            this.Keys.Add(mKey);
        }

        public void AddIndex(PdmIndex mKey)
        {
            this.Indexs.Add(mKey);
        }
    }
}
