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
		public static DataTable GetSetSqlDetailList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSqlDetail", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

    public static DataTable GetSetSqlDetailList(string sqlid)
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, sqlid));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.ListRows.ToString().ToLower()));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSqlDetail", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

		public static SetSqlDetail PopulateSetSqlDetail(IDataReader reader)
		{
			SetSqlDetail item = new SetSqlDetail();
			item.SqlID = reader["Sql_ID"] as string;
			item.ColID = (short)reader["Col_ID"];
			item.ColName = reader["Col_Name"] as string;
			item.ColCode = reader["Col_Code"] as string;
			item.ColBaseCode = reader["Col_Base_Code"] as string;
			item.ColType = (short)reader["Col_Type"];
			item.DispSize = (short)reader["Disp_Size"];
			item.DispOrder = (short)reader["Disp_Order"];
			item.DispAuth = (short)reader["Disp_Auth"];
			item.IsVisible = Convert.ToBoolean(reader["Is_Visible"]);
			item.IsPrint = Convert.ToBoolean(reader["Is_Print"]);
			item.IsOrder = Convert.ToBoolean(reader["Is_Order"]);
			item.IsLock = Convert.ToBoolean(reader["Is_Lock"]);
			item.IsAlias = Convert.ToBoolean(reader["Is_Alias"]);
			if (reader["Col_Foot"] != DBNull.Value)
				item.ColFoot = (short)reader["Col_Foot"];
			if (reader["Col_Foot_Value"] != DBNull.Value)
				item.ColFootValue = reader["Col_Foot_Value"] as string;
			if (reader["Rela_Sql"] != DBNull.Value)
				item.RelaSql = reader["Rela_Sql"] as string;
      if (reader["Col_Format"] != DBNull.Value)
        item.ColFormat = reader["Col_Format"] as string;

			return item;
		}

		public static SetSqlDetail GetSetSqlDetail(string sqlid, short colid)
		{
			SetSqlDetail item = new SetSqlDetail();
			
			try
			{
				ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, sqlid));
        paras.Add(DBUtils.MakeInParam("@Col_ID", SqlDbType.SmallInt, colid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SetSqlDetail", paras);
				
				if (reader.Read())
				{
					item = PopulateSetSqlDetail(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void CreateUpdateDeleteSetSqlDetail(SetSqlDetail item, DataProviderAction action)
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
				paras.Add(DBUtils.MakeInParam("@Col_ID", SqlDbType.SmallInt, item.ColID));
				paras.Add(DBUtils.MakeInParam("@Col_Name", SqlDbType.NVarChar, 20, item.ColName));
				paras.Add(DBUtils.MakeInParam("@Col_Code", SqlDbType.NVarChar, 20, item.ColCode));
				paras.Add(DBUtils.MakeInParam("@Col_Base_Code", SqlDbType.NVarChar, 20, item.ColBaseCode));
				paras.Add(DBUtils.MakeInParam("@Col_Type", SqlDbType.SmallInt, item.ColType));
				paras.Add(DBUtils.MakeInParam("@Disp_Size", SqlDbType.SmallInt, item.DispSize));
				paras.Add(DBUtils.MakeInParam("@Disp_Order", SqlDbType.SmallInt, item.DispOrder));
				paras.Add(DBUtils.MakeInParam("@Disp_Auth", SqlDbType.SmallInt, item.DispAuth));
				paras.Add(DBUtils.MakeInParam("@Is_Visible", SqlDbType.Bit, item.IsVisible));
				paras.Add(DBUtils.MakeInParam("@Is_Print", SqlDbType.Bit, item.IsPrint));
				paras.Add(DBUtils.MakeInParam("@Is_Order", SqlDbType.Bit, item.IsOrder));
				paras.Add(DBUtils.MakeInParam("@Is_Lock", SqlDbType.Bit, item.IsLock));
				paras.Add(DBUtils.MakeInParam("@Is_Alias", SqlDbType.Bit, item.IsAlias));
				paras.Add(DBUtils.MakeInParam("@Col_Foot", SqlDbType.SmallInt, item.ColFoot));
				paras.Add(DBUtils.MakeInParam("@Col_Foot_Value", SqlDbType.NVarChar, 30, item.ColFootValue));
				paras.Add(DBUtils.MakeInParam("@Rela_Sql", SqlDbType.NVarChar, 20, item.RelaSql));
        paras.Add(DBUtils.MakeInParam("@Col_Format", SqlDbType.NVarChar, 30, item.ColFormat));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SetSqlDetail", paras);

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

    public static void DeleteSetSqlDetail(SqlConnection conn, SqlCommand cmd, string sqlid)
    {
      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Sql_ID", SqlDbType.NVarChar, 30, sqlid));

        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Delete_SetSqlDetail", paras);
      }
      catch
      {
        throw;
      }
    }
	}
}
