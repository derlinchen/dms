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
		public static DataTable GetRibPanelList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibPanel", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static RibPanel PopulateRibPanel(IDataReader reader)
		{
			RibPanel item = new RibPanel();
			item.ID = (short)reader["Rib_Panel"];
			item.RibPanelName = reader["Rib_Panel_Name"] as string;
			item.RibOrder = (short)reader["Rib_Order"];
			item.RibTab = (short)reader["Rib_Tab"];
			item.RibTabName = reader["Rib_Tab_Name"] as string;

			return item;
		}

		public static RibPanel GetRibPanel(short id)
		{
			RibPanel item = new RibPanel();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Rib_Panel", SqlDbType.SmallInt, id));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibPanel", paras);
				
				if (reader.Read())
				{
					item = PopulateRibPanel(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteRibPanel(RibPanel item, DataProviderAction action)
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
					paras.Add(DBUtils.MakeOutParam("@Rib_Panel", SqlDbType.SmallInt));
				}
				else
				{
					paras.Add(DBUtils.MakeInParam("@Rib_Panel", SqlDbType.SmallInt, item.ID));
				}
				paras.Add(DBUtils.MakeInParam("@Rib_Panel_Name", SqlDbType.NVarChar, 12, item.RibPanelName));
				paras.Add(DBUtils.MakeInParam("@Rib_Order", SqlDbType.SmallInt, item.RibOrder));
				paras.Add(DBUtils.MakeInParam("@Rib_Tab", SqlDbType.SmallInt, item.RibTab));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_RibPanel", paras);

				if (action == DataProviderAction.Create)
				{
					item.ID = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt16(((SqlParameter)paras[0]).Value)) : (short)0);
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
	}
}
