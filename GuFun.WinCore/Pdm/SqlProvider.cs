using GuFun.Utils;
using GuFun.WinCore.Pdm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GuFun.WinCore
{
    public partial class SqlBaseProvider
    {
        public static DataTable GetDBForCombox(int DBType)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBType", SqlDbType.VarChar, DBType));
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, "dbo.P_Get_DBForCombox", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }


        public static DataTable GetTableByDB(int DBID)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, "dbo.P_Get_TableByDB", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetTableNoPmtByDB(int DBID)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, "dbo.P_Get_TableNoPmtByDB", paras);
                if (tblMain.Rows.Count == 0)
                {
                    tblMain = null;
                }
                else
                {
                    tblMain.TableName = "SelectMain";
                }
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetPmtSetByDB(int DBID)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, "dbo.P_Get_PmtSetByDB", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static void GetTableByDB(IList<PdmTable> PdmTables, int DBID)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DBUtils.GetConnection();
                cmd = DBUtils.GetCommand();

                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                SqlDataReader reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_TableByDB", paras);

                while (reader.Read())
                {
                    PdmTable item = new PdmTable(reader);
                    PdmTables.Add(item);
                }

                reader.Close();

                foreach (PdmTable pTable in PdmTables)
                {
                    paras.Clear();
                    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                    paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByTable", paras);

                    while (reader.Read())
                    {
                        PdmColumn item = new PdmColumn(reader);
                        pTable.AddColumn(item);
                    }

                    reader.Close();

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_KeyByTable", paras);

                    while (reader.Read())
                    {
                        PdmKey item = new PdmKey(reader);
                        pTable.AddKey(item);
                    }

                    reader.Close();

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_IndexByTable", paras);

                    while (reader.Read())
                    {
                        PdmIndex item = new PdmIndex(reader);
                        pTable.AddIndex(item);
                    }

                    reader.Close();
                }

                foreach (PdmTable pTable in PdmTables)
                {
                    foreach (PdmKey pKey in pTable.Keys)
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                        paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
                        paras.Add(DBUtils.MakeInParam("KeyCode", SqlDbType.NVarChar, 40, pKey.KeyCode));

                        reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByKey", paras);

                        while (reader.Read())
                        {
                            foreach (PdmColumn pColumn in pTable.Columns)
                            {
                                if (pColumn.ColumnCode == reader["ColumnCode"].ToString())
                                {
                                    pKey.AddColumn(pColumn);
                                    break;
                                }
                            }
                        }

                        reader.Close();
                    }

                    foreach (PdmIndex pIndex in pTable.Indexs)
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                        paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
                        paras.Add(DBUtils.MakeInParam("IndexCode", SqlDbType.NVarChar, 40, pIndex.IndexCode));

                        reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByIndex", paras);

                        while (reader.Read())
                        {
                            foreach (PdmColumn pColumn in pTable.Columns)
                            {
                                if (pColumn.ColumnCode == reader["ColumnCode"].ToString())
                                {
                                    pIndex.AddColumn(pColumn);
                                    break;
                                }
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch { throw; }
            finally
            {
                DBUtils.SetDispose(conn, cmd);
            }
        }


        public static void GetTableByCode(PdmTable pTable, int DBID, string TableCode)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DBUtils.GetConnection();
                cmd = DBUtils.GetCommand();

                ArrayList paras = new ArrayList();
                paras.Clear();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, TableCode));

                SqlDataReader reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_TableByCode", paras);

                pTable.OnInit();

                if (reader.Read())
                    pTable.OnPopulate(reader);

                reader.Close();

                if (!String.IsNullOrEmpty(pTable.TableCode))
                {
                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_SetByCode", paras);

                    if (reader.Read())
                        pTable.TableSet = reader["TableSet"] as string;
                    else
                        pTable.TableSet = String.Empty;

                    reader.Close();

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByTable", paras);

                    while (reader.Read())
                    {
                        PdmColumn item = new PdmColumn(reader);
                        pTable.AddColumn(item);
                    }

                    reader.Close();

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_KeyByTable", paras);

                    while (reader.Read())
                    {
                        PdmKey item = new PdmKey(reader);
                        pTable.AddKey(item);
                    }

                    reader.Close();

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_IndexByTable", paras);

                    while (reader.Read())
                    {
                        PdmIndex item = new PdmIndex(reader);
                        pTable.AddIndex(item);
                    }

                    reader.Close();

                    foreach (PdmKey pKey in pTable.Keys)
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                        paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
                        paras.Add(DBUtils.MakeInParam("KeyCode", SqlDbType.NVarChar, 40, pKey.KeyCode));

                        reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByKey", paras);

                        while (reader.Read())
                        {
                            foreach (PdmColumn pColumn in pTable.Columns)
                            {
                                if (pColumn.ColumnCode == reader["ColumnCode"].ToString())
                                {
                                    pKey.AddColumn(pColumn);
                                    break;
                                }
                            }
                        }

                        reader.Close();
                    }

                    foreach (PdmIndex pIndex in pTable.Indexs)
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, DBID));
                        paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
                        paras.Add(DBUtils.MakeInParam("IndexCode", SqlDbType.NVarChar, 40, pIndex.IndexCode));

                        reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByIndex", paras);

                        while (reader.Read())
                        {
                            foreach (PdmColumn pColumn in pTable.Columns)
                            {
                                if (pColumn.ColumnCode == reader["ColumnCode"].ToString())
                                {
                                    pIndex.AddColumn(pColumn);
                                    break;
                                }
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch { throw; }
            finally
            {
                DBUtils.SetDispose(conn, cmd);
            }
        }

        public static DataTable GetColumnByTable(SqlConnection conn, SqlCommand cmd, PdmTable pTable)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));

                tblMain = DBUtils.ExecuteDataTable(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByTable", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetColumnByTable(int dbid, string tablecode)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, tablecode));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, "dbo.P_Get_ColumnByTable", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetColumnByTable(PdmTable pTable)
        {
            return GetColumnByTable(null, null, pTable);
        }

        public static PdmColumn GetColumnByID(PdmColumn pColumn)
        {
            return GetColumnByID(null, null, pColumn);
        }

        public static PdmColumn GetColumnByID(SqlConnection conn, SqlCommand cmd, PdmColumn pColumn)
        {
            PdmColumn rtn = new PdmColumn();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pColumn.DBID));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pColumn.TableCode));
                paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, pColumn.ColumnCode));

                SqlDataReader reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_ColumnByID", paras);

                if (reader.Read())
                    rtn.OnPopulate(reader);

                reader.Close();
            }
            catch { throw; }

            return rtn;
        }

        public static PdmColumn GetColumnByID(int dbid, string tablecode, string columncode)
        {
            PdmColumn rtn = new PdmColumn();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, tablecode));
                paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, columncode));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, "dbo.P_Get_ColumnByID", paras);

                if (reader.Read())
                    rtn.OnPopulate(reader);

                reader.Close();
            }
            catch { throw; }

            return rtn;
        }


        public static void LogColumn(SqlConnection conn, SqlCommand cmd, PdmTable pTable, bool islog)
        {
            PdmColumn rtn = new PdmColumn();

            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, islog));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Log_Column", paras);
        }

        public static void DeleteColumn(SqlConnection conn, SqlCommand cmd, PdmTable pTable, bool islog)
        {
            PdmColumn rtn = new PdmColumn();

            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, islog));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Delete_Column", paras);
        }

        public static void SaveColumn(SqlConnection conn, SqlCommand cmd, PdmColumn pColumn)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pColumn.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pColumn.TableCode));
            paras.Add(DBUtils.MakeInParam("ColumnID", SqlDbType.Int, pColumn.ColumnID));
            paras.Add(DBUtils.MakeInParam("ColumnName", SqlDbType.NVarChar, 40, pColumn.ColumnName));
            paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, pColumn.ColumnCode));
            paras.Add(DBUtils.MakeInParam("DataType", SqlDbType.NVarChar, 40, pColumn.DataType));
            paras.Add(DBUtils.MakeInParam("ColumnLength", SqlDbType.Int, pColumn.Length));
            paras.Add(DBUtils.MakeInParam("ColumnPrecision", SqlDbType.Int, pColumn.Precision));
            paras.Add(DBUtils.MakeInParam("ColumnIdentity", SqlDbType.Bit, pColumn.Identity));
            paras.Add(DBUtils.MakeInParam("ColumnNotNull", SqlDbType.Bit, pColumn.NotNull));
            paras.Add(DBUtils.MakeInParam("PreSerial", SqlDbType.Int, pColumn.PreSerial));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_Column", paras);
        }

        public static void DeleteKey(SqlConnection conn, SqlCommand cmd, PdmTable pTable, bool islog)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, islog));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Delete_Key", paras);
        }

        public static void LogKey(SqlConnection conn, SqlCommand cmd, PdmTable pTable, bool islog)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, islog));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Log_Key", paras);
        }

        public static void SaveKey(SqlConnection conn, SqlCommand cmd, PdmKey pKey)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pKey.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pKey.TableCode));
            paras.Add(DBUtils.MakeInParam("KeyID", SqlDbType.Int, pKey.KeyID));
            paras.Add(DBUtils.MakeInParam("KeyName", SqlDbType.NVarChar, 40, pKey.KeyName));
            paras.Add(DBUtils.MakeInParam("KeyCode", SqlDbType.NVarChar, 40, pKey.KeyCode));
            paras.Add(DBUtils.MakeInParam("IsPrimary", SqlDbType.Bit, pKey.IsPrimary));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_Key", paras);
        }

        public static void SaveKeyColumn(SqlConnection conn, SqlCommand cmd, PdmKey pKey, PdmColumn pColumn)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pKey.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pKey.TableCode));
            paras.Add(DBUtils.MakeInParam("KeyCode", SqlDbType.NVarChar, 40, pKey.KeyCode));
            paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, pColumn.ColumnCode));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_KeyColumn", paras);
        }

        public static PdmKeyColumn GetKeyColumn(int dbid, string tablecode)
        {
            PdmKeyColumn rtn = null;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, tablecode));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, "dbo.P_Get_KeyColumn", paras);

                if (reader.Read())
                {
                    rtn = new PdmKeyColumn();
                    rtn.OnPopulate(reader);
                }
                    

                reader.Close();
            }
            catch { throw; }

            return rtn;
        }

        public static void DeleteIndex(SqlConnection conn, SqlCommand cmd, PdmTable pTable)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Delete_Index", paras);
        }

        public static void LogIndex(SqlConnection conn, SqlCommand cmd, PdmTable pTable, bool islog)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, islog));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Log_Index", paras);
        }

        public static void SaveIndex(SqlConnection conn, SqlCommand cmd, PdmIndex pIndex)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pIndex.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pIndex.TableCode));
            paras.Add(DBUtils.MakeInParam("IndexID", SqlDbType.Int, pIndex.IndexID));
            paras.Add(DBUtils.MakeInParam("IndexName", SqlDbType.NVarChar, 40, pIndex.IndexName));
            paras.Add(DBUtils.MakeInParam("IndexCode", SqlDbType.NVarChar, 40, pIndex.IndexCode));
            paras.Add(DBUtils.MakeInParam("IsUnique", SqlDbType.Bit, pIndex.IsUnique));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_Index", paras);
        }

        public static void SaveIndexColumn(SqlConnection conn, SqlCommand cmd, PdmIndex pIndex, PdmColumn pColumn)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pIndex.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pIndex.TableCode));
            paras.Add(DBUtils.MakeInParam("IndexCode", SqlDbType.NVarChar, 40, pIndex.IndexCode));
            paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, pColumn.ColumnCode));

            DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_IndexColumn", paras);
        }


        public static void SaveTableSet(PdmTable pTable)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
            paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
            paras.Add(DBUtils.MakeInParam("TableSet", SqlDbType.NVarChar, 1000, pTable.TableSet));

            DBUtils.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.P_Save_TableSet", paras);
        }

        public static void SavePmtSet(int dbid, string set)
        {
            ArrayList paras = new ArrayList();
            paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
            paras.Add(DBUtils.MakeInParam("TableSet", SqlDbType.NVarChar, 400, set));

            DBUtils.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.P_Save_PmtSet", paras);
        }

        public static void SaveColumnTable(PdmTable pTable, List<ColumnTable> items)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DBUtils.GetConnection();
                cmd = DBUtils.GetCommand();

                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();
                paras.Clear();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, pTable.DBID));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Delete_ColumnTable", paras);

                int i = 1;
                foreach (ColumnTable item in items)
                {
                    paras.Clear();
                    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, item.DBID));
                    paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, item.TableCode));
                    paras.Add(DBUtils.MakeInParam("ColumnSerial", SqlDbType.Int, i));
                    paras.Add(DBUtils.MakeInParam("ColumnCode", SqlDbType.NVarChar, 40, item.ColumnCode));
                    paras.Add(DBUtils.MakeInParam("RelaTable", SqlDbType.NVarChar, 40, item.RelaTable));
                    paras.Add(DBUtils.MakeInParam("RelaColumn", SqlDbType.NVarChar, 40, item.RelaColumn));
                    paras.Add(DBUtils.MakeInParam("DisplayColumn", SqlDbType.NVarChar, 40, item.DisplayColumn));
                    paras.Add(DBUtils.MakeInParam("Prefix", SqlDbType.NVarChar, 2, item.Prefix));

                    DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_ColumnTable", paras);

                    i++;
                }

                cmd.Transaction.Commit();
            }
            catch
            {
                cmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                DBUtils.SetDispose(conn, cmd);
            }
        }

        public static List<ColumnTable> GetColumnTable(int dbid, string tablecode)
        {
            List<ColumnTable> rtn = new List<ColumnTable>();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
                paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, tablecode));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, "dbo.P_Get_ColumnTable", paras);

                while (reader.Read())
                {
                    rtn.Add(new ColumnTable(reader));
                }

                reader.Close();
            }
            catch { throw; }

            return rtn;
        }
       
    }
}
