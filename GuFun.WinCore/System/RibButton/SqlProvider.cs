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
		public static DataTable GetRibButtonList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibButton", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static RibButton PopulateRibButton(IDataReader reader)
		{
			RibButton item = new RibButton();
			item.RibBtn = (short)reader["Rib_Btn"];
			item.RibBtnName = reader["Rib_Btn_Name"] as string;
			item.RibBtnType = (short)reader["Rib_Btn_Type"];
			item.RibOrder = (short)reader["Rib_Order"];
			item.RibPanel = (short)reader["Rib_Panel"];
			item.RibPanelName = reader["Rib_Panel_Name"] as string;
			item.RibTab = (short)reader["Rib_Tab"];
			item.RibTabName = reader["Rib_Tab_Name"] as string;
			if (reader["Rib_Image"] != DBNull.Value)
				item.RibImage = reader["Rib_Image"] as string;
			item.RibImageIndex = (short)reader["Rib_Image_Index"];
			if (reader["M_Function"] != DBNull.Value)
				item.MFunction = reader["M_Function"] as string;
			if (reader["M_Code"] != DBNull.Value)
				item.MCode = reader["M_Code"] as string;
			item.MID = (short)reader["M_ID"];
			if (reader["Rib_Code"] != DBNull.Value)
				item.RibCode = reader["Rib_Code"] as string;

			return item;
		}

		public static RibButton GetRibButton(short ribbtn)
		{
			RibButton item = new RibButton();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Rib_Btn", SqlDbType.SmallInt, ribbtn));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RibButton", paras);
				
				if (reader.Read())
				{
					item = PopulateRibButton(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteRibButton(RibButton item, DataProviderAction action)
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
					paras.Add(DBUtils.MakeOutParam("@Rib_Btn", SqlDbType.SmallInt));
				}
				else
				{
					paras.Add(DBUtils.MakeInParam("@Rib_Btn", SqlDbType.SmallInt, item.RibBtn));
				}
				paras.Add(DBUtils.MakeInParam("@Rib_Btn_Name", SqlDbType.NVarChar, 20, item.RibBtnName));
				paras.Add(DBUtils.MakeInParam("@Rib_Btn_Type", SqlDbType.SmallInt, item.RibBtnType));
				paras.Add(DBUtils.MakeInParam("@Rib_Order", SqlDbType.SmallInt, item.RibOrder));
				paras.Add(DBUtils.MakeInParam("@Rib_Panel", SqlDbType.SmallInt, item.RibPanel));
				paras.Add(DBUtils.MakeInParam("@Rib_Tab", SqlDbType.SmallInt, item.RibTab));
				paras.Add(DBUtils.MakeInParam("@Rib_Image", SqlDbType.NVarChar, 20, item.RibImage));
				paras.Add(DBUtils.MakeInParam("@Rib_Image_Index", SqlDbType.SmallInt, item.RibImageIndex));
				paras.Add(DBUtils.MakeInParam("@M_Function", SqlDbType.NVarChar, 64, item.MFunction));
				paras.Add(DBUtils.MakeInParam("@M_Code", SqlDbType.NVarChar, 12, item.MCode));
				paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, item.MID));
				paras.Add(DBUtils.MakeInParam("@Rib_Code", SqlDbType.NVarChar, 12, item.RibCode));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_RibButton", paras);

				if (action == DataProviderAction.Create)
				{
					item.RibBtn = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt16(((SqlParameter)paras[0]).Value)) : (short)0);
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
