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
		public static DataTable GetSysLogList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysLog", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static SysLog PopulateSysLog(IDataReader reader)
		{
			SysLog item = new SysLog();
			item.LogID = (int)reader["Log_ID"];
			item.LogDate = Convert.ToDateTime(reader["Log_Date"]);
			item.ManID = reader["Man_ID"] as string;
			item.ManName = reader["Man_Name"] as string;
			if (reader["Menu_Code"] != DBNull.Value)
				item.MenuCode = reader["Menu_Code"] as string;
			item.LogAction = (short)reader["Log_Action"];
			item.LogContent = reader["Log_Content"] as string;

			return item;
		}

		public static SysLog GetSysLog(int logid)
		{
			SysLog item = new SysLog();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Log_ID", SqlDbType.Int, logid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysLog", paras);
				
				if (reader.Read())
				{
					item = PopulateSysLog(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteSysLog(SysLog item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				if (action == DataProviderAction.Create)
				{
					paras.Add(DBUtils.MakeOutParam("@Log_ID", SqlDbType.Int));
				}
				else
				{
					paras.Add(DBUtils.MakeInParam("@Log_ID", SqlDbType.Int, item.LogID));
				}
				paras.Add(DBUtils.MakeInParam("@Log_Date", SqlDbType.DateTime, item.LogDate));
				paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, item.ManID));
				paras.Add(DBUtils.MakeInParam("@Menu_Code", SqlDbType.NVarChar, 4, item.MenuCode));
				paras.Add(DBUtils.MakeInParam("@Log_Action", SqlDbType.SmallInt, item.LogAction));
				paras.Add(DBUtils.MakeInParam("@Log_Content", SqlDbType.NVarChar, 100, item.LogContent));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysLog", paras);

				if (action == DataProviderAction.Create)
				{
					item.LogID = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt32(((SqlParameter)paras[0]).Value)) : (int)0);
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

    public static void CreateUpdateDeleteSysLog(SqlConnection conn, SqlCommand cmd, SysLog item, DataProviderAction action)
    {
      if (item == null)
        return;

      try
      {
        ArrayList paras = new ArrayList();

        if (action == DataProviderAction.Create)
        {
          paras.Add(DBUtils.MakeOutParam("@Log_ID", SqlDbType.Int));
        }
        else
        {
          paras.Add(DBUtils.MakeInParam("@Log_ID", SqlDbType.Int, item.LogID));
        }
        paras.Add(DBUtils.MakeInParam("@Log_Date", SqlDbType.DateTime, item.LogDate));
        paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, item.ManID));
        paras.Add(DBUtils.MakeInParam("@Menu_Code", SqlDbType.NVarChar, 4, item.MenuCode));
        paras.Add(DBUtils.MakeInParam("@Log_Action", SqlDbType.SmallInt, item.LogAction));
        paras.Add(DBUtils.MakeInParam("@Log_Content", SqlDbType.NVarChar, 100, item.LogContent));
        paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysLog", paras);

        if (action == DataProviderAction.Create)
        {
          item.LogID = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt32(((SqlParameter)paras[0]).Value)) : (int)0);
        }
      }
      catch
      {
        throw;
      }
    }
	}
}
