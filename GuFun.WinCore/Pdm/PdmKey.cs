using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmKey
    {
        public PdmKey()
        {
            this.OnInit();
        }

        public PdmKey(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int KeyID { get; set; }

        public string PdmID { get; set; }

        public string KeyName { get; set; }

        public string KeyCode { get; set; }

        public bool IsPrimary { get; set; }

        public int DBID { get; set; }

        public string TableCode { get; set; }

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

        public void AddColumn(PdmColumn mColumn)
        {
            this.Columns.Add(mColumn);
        }

        public void OnInit()
        {
            this.KeyID = 0;
            this.PdmID = String.Empty;
            this.KeyName = String.Empty;
            this.KeyCode = String.Empty;
            this.IsPrimary = false;
            this.DBID = 0;
            this.TableCode = String.Empty;
            this.Columns.Clear();
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.TableCode = reader["TableCode"] as string;
            this.KeyID = (int)reader["KeyID"];
            this.KeyName = reader["KeyName"] as string;
            this.KeyCode = reader["KeyCode"] as string;
            this.IsPrimary = Convert.ToBoolean(reader["IsPrimary"]);
        }
    }
}
