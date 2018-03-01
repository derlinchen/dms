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
		public static DataTable GetSysMenuGroupList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysMenuGroup", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static SysMenuGroup PopulateSysMenuGroup(IDataReader reader)
		{
			SysMenuGroup item = new SysMenuGroup();
			item.MgID = (short)reader["Mg_ID"];
			item.MgName = reader["Mg_Name"] as string;
			if (reader["Mg_Tip"] != DBNull.Value)
				item.MgTip = reader["Mg_Tip"] as string;
			if (reader["Mg_Normal_Icon"] != DBNull.Value)
				item.MgNormalIcon = reader["Mg_Normal_Icon"] as string;
			if (reader["Mg_Hot_Icon"] != DBNull.Value)
				item.MgHotIcon = reader["Mg_Hot_Icon"] as string;
			if (reader["Mg_Disable_Icon"] != DBNull.Value)
				item.MgDisableIcon = reader["Mg_Disable_Icon"] as string;
			item.MgIconIndex = (short)reader["Mg_Icon_Index"];
			if (reader["Mg_Function"] != DBNull.Value)
				item.MgFunction = reader["Mg_Function"] as string;
			item.MgStatus = (short)reader["Mg_Status"];
			item.MgOrder = (short)reader["Mg_Order"];

			return item;
		}

		public static SysMenuGroup GetSysMenuGroup(short mgid)
		{
			SysMenuGroup item = new SysMenuGroup();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Mg_ID", SqlDbType.SmallInt, mgid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysMenuGroup", paras);
				
				if (reader.Read())
				{
					item = PopulateSysMenuGroup(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteSysMenuGroup(SysMenuGroup item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@Mg_ID", SqlDbType.SmallInt, item.MgID));
				paras.Add(DBUtils.MakeInParam("@Mg_Name", SqlDbType.NVarChar, 40, item.MgName));
				paras.Add(DBUtils.MakeInParam("@Mg_Tip", SqlDbType.NVarChar, 80, item.MgTip));
				paras.Add(DBUtils.MakeInParam("@Mg_Normal_Icon", SqlDbType.NVarChar, 32, item.MgNormalIcon));
				paras.Add(DBUtils.MakeInParam("@Mg_Hot_Icon", SqlDbType.NVarChar, 32, item.MgHotIcon));
				paras.Add(DBUtils.MakeInParam("@Mg_Disable_Icon", SqlDbType.NVarChar, 32, item.MgDisableIcon));
				paras.Add(DBUtils.MakeInParam("@Mg_Icon_Index", SqlDbType.SmallInt, item.MgIconIndex));
				paras.Add(DBUtils.MakeInParam("@Mg_Function", SqlDbType.NVarChar, 64, item.MgFunction));
				paras.Add(DBUtils.MakeInParam("@Mg_Status", SqlDbType.SmallInt, item.MgStatus));
				paras.Add(DBUtils.MakeInParam("@Mg_Order", SqlDbType.SmallInt, item.MgOrder));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysMenuGroup", paras);

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
