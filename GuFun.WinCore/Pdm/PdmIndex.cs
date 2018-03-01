using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmIndex
    {
        public PdmIndex()
        {
            this.OnInit();
        }

        public PdmIndex(IDataReader reader)
        {
            this.OnInit();
            this.OnPopulate(reader);
        }

        public int IndexID { get; set; }

        public string PdmID { get; set; }

        public string IndexName { get; set; }

        public string IndexCode { get; set; }

        public bool IsUnique { get; set; }

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
            this.IndexID = 0;
            this.PdmID = String.Empty;
            this.IndexName = String.Empty;
            this.IndexCode = String.Empty;
            this.IsUnique = false;
            this.DBID = 0;
            this.TableCode = String.Empty;
            this.Columns.Clear();
        }

        public void OnPopulate(IDataReader reader)
        {
            this.DBID = (int)reader["DBID"];
            this.TableCode = reader["TableCode"] as string;
            this.IndexID = (int)reader["IndexID"];
            this.IndexName = reader["IndexName"] as string;
            this.IndexCode = reader["IndexCode"] as string;
            this.IsUnique = Convert.ToBoolean(reader["IsUnique"]);
        }
    }
}
