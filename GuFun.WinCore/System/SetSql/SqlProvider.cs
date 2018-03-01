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
		public static DataTable GetSetSqlList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSql", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

    public static DataTable GetSetSqlList(string search)
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Custom_Sql", SqlDbType.NVarChar, 200, search));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Custom.ToString().ToLower()));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSql", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

		public static SetSql PopulateSetSql(IDataReader reader)
		{
			SetSql item = new SetSql();
			item.SqlID = reader["Sql_ID"] as string;
			item.SqlName = reader["Sql_Name"] as string;
			item.SqlType = (short)reader["Sql_Type"];
			if (reader["Sql_Text"] != DBNull.Value)
				item.SqlText = reader["Sql_Text"] as string;
			item.SqlMainTable = reader["Sql_Main_Table"] as string;
			if (reader["Sql_Keys"] != DBNull.Value)
				item.SqlKeys = reader["Sql_Keys"] as string;
			if (reader["Sql_Order"] != DBNull.Value)
				item.SqlOrder = reader["Sql_Order"] as string;
			if (reader["Sql_Group"] != DBNull.Value)
				item.SqlGroup = reader["Sql_Group"] as string;
			if (reader["Sql_Having"] != DBNull.Value)
				item.SqlHaving = reader["Sql_Having"] as string;
      if (reader["Sql_Dropdown"] != DBNull.Value)
        item.SqlDropdown = reader["Sql_Dropdown"] as string;
			item.CrtDate = Convert.ToDateTime(reader["Crt_Date"]);
			item.SqlPageSize = (short)reader["Sql_Page_Size"];
			item.SqlPageHeigh = (short)reader["Sql_Page_Heigh"];
			item.SqlPageWidth = (short)reader["Sql_Page_Width"];
			item.SqlOrietation = (short)reader["Sql_Orietation"];
			item.SqlTopMargin = (short)reader["Sql_Top_Margin"];
			item.SqlBottomMargin = (short)reader["Sql_Bottom_Margin"];
			item.SqlLeftMargin = (short)reader["Sql_Left_Margin"];
			item.SqlRightMargin = (short)reader["Sql_Right_Margin"];
			if (reader["Sql_Title"] != DBNull.Value)
				item.SqlTitle = reader["Sql_Title"] as string;
			if (reader["Sql_Top_Font"] != DBNull.Value)
				item.SqlTopFont = reader["Sql_Top_Font"] as string;
			if (reader["Sql_Font"] != DBNull.Value)
				item.SqlFont = reader["Sql_Font"] as string;
			if (reader["Sql_ISO"] != DBNull.Value)
				item.SqlISO = reader["Sql_ISO"] as string;
			item.IsPrintCompany = Convert.ToBoolean(reader["Is_Print_Company"]);
			item.SqlPrintSet = (short)reader["Sql_Print_Set"];

			return item;
		}

		public static SetSql GetSetSql(string sqlid)
		{
			SetSql item = new SetSql();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, sqlid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSql", paras);
				
				if (reader.Read())
				{
					item = PopulateSetSql(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

    public static SetSql GetFullSetSql(string sqlid)
    {
      SetSql item = new SetSql();

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, sqlid));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Condition.ToString().ToLower()));

        SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSql", paras);

        if (reader.Read())
        {
          item = PopulateSetSql(reader);
        }

        if (reader.NextResult())
        {
          while (reader.Read())
          {
            item.Items.Add(PopulateSetSqlDetail(reader));
          }
        }

        reader.Close();
      }
      catch { throw; }

      return item;
    }

		public static void CreateUpdateDeleteSetSql(SetSql item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, item.SqlID));
				paras.Add(DBUtils.MakeInParam("@Sql_Name", SqlDbType.NVarChar, 50, item.SqlName));
				paras.Add(DBUtils.MakeInParam("@Sql_Type", SqlDbType.SmallInt, item.SqlType));
				paras.Add(DBUtils.MakeInParam("@Sql_Text", SqlDbType.NVarChar, 512, item.SqlText));
				paras.Add(DBUtils.MakeInParam("@Sql_Main_Table", SqlDbType.NVarChar, 40, item.SqlMainTable));
				paras.Add(DBUtils.MakeInParam("@Sql_Keys", SqlDbType.NVarChar, 20, item.SqlKeys));
				paras.Add(DBUtils.MakeInParam("@Sql_Order", SqlDbType.NVarChar, 200, item.SqlOrder));
				paras.Add(DBUtils.MakeInParam("@Sql_Group", SqlDbType.NVarChar, 200, item.SqlGroup));
				paras.Add(DBUtils.MakeInParam("@Sql_Having", SqlDbType.NVarChar, 200, item.SqlHaving));
        paras.Add(DBUtils.MakeInParam("@Sql_Dropdown", SqlDbType.NVarChar, 60, item.SqlDropdown));
				paras.Add(DBUtils.MakeInParam("@Crt_Date", SqlDbType.DateTime, item.CrtDate));
				paras.Add(DBUtils.MakeInParam("@Sql_Page_Size", SqlDbType.SmallInt, item.SqlPageSize));
				paras.Add(DBUtils.MakeInParam("@Sql_Page_Heigh", SqlDbType.SmallInt, item.SqlPageHeigh));
				paras.Add(DBUtils.MakeInParam("@Sql_Page_Width", SqlDbType.SmallInt, item.SqlPageWidth));
				paras.Add(DBUtils.MakeInParam("@Sql_Orietation", SqlDbType.SmallInt, item.SqlOrietation));
				paras.Add(DBUtils.MakeInParam("@Sql_Top_Margin", SqlDbType.SmallInt, item.SqlTopMargin));
				paras.Add(DBUtils.MakeInParam("@Sql_Bottom_Margin", SqlDbType.SmallInt, item.SqlBottomMargin));
				paras.Add(DBUtils.MakeInParam("@Sql_Left_Margin", SqlDbType.SmallInt, item.SqlLeftMargin));
				paras.Add(DBUtils.MakeInParam("@Sql_Right_Margin", SqlDbType.SmallInt, item.SqlRightMargin));
				paras.Add(DBUtils.MakeInParam("@Sql_Title", SqlDbType.NVarChar, 80, item.SqlTitle));
				paras.Add(DBUtils.MakeInParam("@Sql_Top_Font", SqlDbType.NVarChar, 40, item.SqlTopFont));
				paras.Add(DBUtils.MakeInParam("@Sql_Font", SqlDbType.NVarChar, 40, item.SqlFont));
				paras.Add(DBUtils.MakeInParam("@Sql_ISO", SqlDbType.NVarChar, 30, item.SqlISO));
				paras.Add(DBUtils.MakeInParam("@Is_Print_Company", SqlDbType.Bit, item.IsPrintCompany));
				paras.Add(DBUtils.MakeInParam("@Sql_Print_Set", SqlDbType.SmallInt, item.SqlPrintSet));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SetSql", paras);

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
