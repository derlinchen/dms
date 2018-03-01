using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class PdmKeyColumn
    {
        public int DBID { get; set; }

        public string TableCode { get; set; }

        public string KeyCode { get; set; }

        public string ColumnCode { get; set; }

        public PdmKeyColumn()
        {
            this.DBID = 0;
            this.TableCode = String.Empty;
            this.KeyCode = String.Empty;
            this.ColumnCode = String.Empty;
        }

        public void OnPopulate(SqlDataReader reader)
        {
            this.DBID = Convert.ToInt16(reader["DBID"]);
            this.TableCode = reader["TableCode"] as string;
            this.KeyCode = reader["KeyCode"] as string;
            this.ColumnCode = reader["ColumnCode"] as string;
        }
    }
}
