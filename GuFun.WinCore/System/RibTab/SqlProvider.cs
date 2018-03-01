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
		public static DataTable GetRibTabList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibTab", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static RibTab PopulateRibTab(IDataReader reader)
		{
			RibTab item = new RibTab();
			item.ID = (short)reader["Rib_Tab"];
			item.RibTabName = reader["Rib_Tab_Name"] as string;
			item.RibOrder = (short)reader["Rib_Order"];

			return item;
		}

		public static RibTab GetRibTab(short id)
		{
			RibTab item = new RibTab();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Rib_Tab", SqlDbType.SmallInt, id));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibTab", paras);
				
				if (reader.Read())
				{
					item = PopulateRibTab(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteRibTab(RibTab item, DataProviderAction action)
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
					paras.Add(DBUtils.MakeOutParam("@Rib_Tab", SqlDbType.SmallInt));
				}
				else
				{
					paras.Add(DBUtils.MakeInParam("@Rib_Tab", SqlDbType.SmallInt, item.ID));
				}
				paras.Add(DBUtils.MakeInParam("@Rib_Tab_Name", SqlDbType.NVarChar, 12, item.RibTabName));
				paras.Add(DBUtils.MakeInParam("@Rib_Order", SqlDbType.SmallInt, item.RibOrder));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_RibTab", paras);

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
