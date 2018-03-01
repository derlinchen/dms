using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GuFun.Utils;

namespace GuFun.WinCore
{
    public partial class SqlBaseProvider
    {
        public static DataTable GetSysOnlineList()
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysOnline", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static SysOnline PopulateSysOnline(IDataReader reader)
        {
            SysOnline item = new SysOnline();
            item.ManID = reader["Man_ID"] as string;
            item.ManName = reader["Man_Name"] as string;
            item.LoginDate = Convert.ToDateTime(reader["Login_Date"]);
            item.OnlineDate = Convert.ToDateTime(reader["Online_Date"]);
            if (reader["Menu_Code"] != DBNull.Value)
                item.MenuCode = reader["Menu_Code"] as string;
            item.RegID = (short)reader["Reg_ID"];

            return item;
        }

        public static SysOnline GetSysOnline(string manid)
        {
            SysOnline item = new SysOnline();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));
                paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysOnline", paras);

                if (reader.Read())
                {
                    item = PopulateSysOnline(reader);
                }

                reader.Close();
            }
            catch { throw; }

            return item;
        }

        public static SysOnline ContinueOnline(string manid, short regid)
        {
            SysOnline item = new SysOnline();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));
                paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, regid));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Continue_Online", paras);

                if (reader.Read())
                {
                    item = PopulateSysOnline(reader);
                }

                reader.Close();
            }
            catch { throw; }

            return item;
        }

        public static void CreateUpdateDeleteSysOnline(SysOnline item, DataProviderAction action)
        {
            if (item == null)
                return;

            SqlConnection conn = DBUtils.GetConnection();
            SqlCommand cmd = DBUtils.GetCommand();

            try
            {
                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();

                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, item.ManID));
                paras.Add(DBUtils.MakeInParam("@Login_Date", SqlDbType.DateTime, Publics.GetDataDateTime(item.LoginDate)));
                paras.Add(DBUtils.MakeInParam("@Online_Date", SqlDbType.DateTime, Publics.GetDataDateTime(item.OnlineDate)));
                paras.Add(DBUtils.MakeInParam("@Menu_Code", SqlDbType.NVarChar, 4, item.MenuCode));
                paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, item.RegID));
                paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysOnline", paras);

                if (action != DataProviderAction.Update)
                {
                    SysLog sl = new SysLog();
                    sl.LogDate = DateTime.Now;
                    sl.ManID = item.ManID;
                    sl.LogAction = (short)LoginAction.Info;
                    if (action == DataProviderAction.Create)
                        sl.LogContent = "登录系统";
                    else
                        sl.LogContent = "退出系统";

                    SqlBaseProvider.CreateUpdateDeleteSysLog(sl, DataProviderAction.Create);
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

        public static void LoginSysOnline(SysOnline item, DataProviderAction action)
        {
            if (item == null)
                return;

            SqlConnection conn = DBUtils.GetConnection();
            SqlCommand cmd = DBUtils.GetCommand();

            try
            {
                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();

                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, item.ManID));
                paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, item.RegID));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Login_SysOnline", paras);

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

        public static void LoginOutSysOnline(string manid, short regid)
        {
            SqlConnection conn = DBUtils.GetConnection();
            SqlCommand cmd = DBUtils.GetCommand();

            try
            {
                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();

                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));
                paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, regid));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_LoginOut_SysOnline", paras);

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
    }
}
