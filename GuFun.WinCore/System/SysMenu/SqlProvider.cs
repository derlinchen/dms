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
		public static DataTable GetSysMenuList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysMenu", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static SysMenu PopulateSysMenu(IDataReader reader)
		{
			SysMenu item = new SysMenu();
			item.MID = (short)reader["M_ID"];
			item.MName = reader["M_Name"] as string;
			item.MPID = (short)reader["M_PID"];
			item.MgID = (short)reader["Mg_ID"];
			item.MgName = reader["Mg_Name"] as string;
			item.MLevel = (short)reader["M_Level"];
			item.MDisp = (short)reader["M_Disp"];
			item.MAuth = (int)reader["M_Auth"];
			if (reader["M_Tip"] != DBNull.Value)
				item.MTip = reader["M_Tip"] as string;
			if (reader["M_Function"] != DBNull.Value)
				item.MFunction = reader["M_Function"] as string;
			item.IsLine = Convert.ToBoolean(reader["Is_Line"]);
			item.IsSub = Convert.ToBoolean(reader["Is_Sub"]);
			if (reader["M_SID"] != DBNull.Value)
				item.MSID = (short)reader["M_SID"];
			if (reader["M_Normal_Icon"] != DBNull.Value)
				item.MNormalIcon = reader["M_Normal_Icon"] as string;
			if (reader["M_Hot_Icon"] != DBNull.Value)
				item.MHotIcon = reader["M_Hot_Icon"] as string;
			if (reader["M_Disable_Icon"] != DBNull.Value)
				item.MDisableIcon = reader["M_Disable_Icon"] as string;
			item.MIconIndex = (short)reader["M_Icon_Index"];
			item.IsBase = Convert.ToBoolean(reader["Is_Base"]);
			item.MCode = reader["M_Code"] as string;
			item.MStatus = (short)reader["M_Status"];
			if (reader["M_Shortcut"] != DBNull.Value)
				item.MShortcut = reader["M_Shortcut"] as string;

			return item;
		}

		public static SysMenu GetSysMenu(short mid)
		{
			SysMenu item = new SysMenu();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, mid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysMenu", paras);
				
				if (reader.Read())
				{
					item = PopulateSysMenu(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteSysMenu(SysMenu item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, item.MID));
				paras.Add(DBUtils.MakeInParam("@M_Name", SqlDbType.NVarChar, 40, item.MName));
				paras.Add(DBUtils.MakeInParam("@M_PID", SqlDbType.SmallInt, item.MPID));
				paras.Add(DBUtils.MakeInParam("@Mg_ID", SqlDbType.SmallInt, item.MgID));
				paras.Add(DBUtils.MakeInParam("@M_Level", SqlDbType.SmallInt, item.MLevel));
				paras.Add(DBUtils.MakeInParam("@M_Disp", SqlDbType.SmallInt, item.MDisp));
				paras.Add(DBUtils.MakeInParam("@M_Auth", SqlDbType.Int, item.MAuth));
				paras.Add(DBUtils.MakeInParam("@M_Tip", SqlDbType.NVarChar, 120, item.MTip));
				paras.Add(DBUtils.MakeInParam("@M_Function", SqlDbType.NVarChar, 64, item.MFunction));
				paras.Add(DBUtils.MakeInParam("@Is_Line", SqlDbType.Bit, item.IsLine));
				paras.Add(DBUtils.MakeInParam("@Is_Sub", SqlDbType.Bit, item.IsSub));
				paras.Add(DBUtils.MakeInParam("@M_SID", SqlDbType.SmallInt, item.MSID));
				paras.Add(DBUtils.MakeInParam("@M_Normal_Icon", SqlDbType.NVarChar, 32, item.MNormalIcon));
				paras.Add(DBUtils.MakeInParam("@M_Hot_Icon", SqlDbType.NVarChar, 32, item.MHotIcon));
				paras.Add(DBUtils.MakeInParam("@M_Disable_Icon", SqlDbType.NVarChar, 32, item.MDisableIcon));
				paras.Add(DBUtils.MakeInParam("@M_Icon_Index", SqlDbType.SmallInt, item.MIconIndex));
				paras.Add(DBUtils.MakeInParam("@Is_Base", SqlDbType.Bit, item.IsBase));
				paras.Add(DBUtils.MakeInParam("@M_Code", SqlDbType.NVarChar, 12, item.MCode));
				paras.Add(DBUtils.MakeInParam("@M_Status", SqlDbType.SmallInt, item.MStatus));
				paras.Add(DBUtils.MakeInParam("@M_Shortcut", SqlDbType.NVarChar, 20, item.MShortcut));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysMenu", paras);

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
