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
		public static DataTable GetSysCompanyList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysCompany", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

    public static DataTable GetSysCompanyList(string coid, DataGetAction get)
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        if (!String.IsNullOrEmpty(coid))
          paras.Add(DBUtils.MakeInParam("@Co_ID", SqlDbType.NVarChar, 4, coid));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, get.ToString().ToLower()));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysCompany", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

		public static SysCompany PopulateSysCompany(IDataReader reader)
		{
			SysCompany item = new SysCompany();
			item.CoID = reader["Co_ID"] as string;
			item.CoName = reader["Co_Name"] as string;
			item.CrtDate = Convert.ToDateTime(reader["Crt_Date"]);
			if (reader["Co_Address"] != DBNull.Value)
				item.CoAddress = reader["Co_Address"] as string;
			if (reader["Co_Post"] != DBNull.Value)
				item.CoPost = reader["Co_Post"] as string;
			if (reader["Co_Tele"] != DBNull.Value)
				item.CoTele = reader["Co_Tele"] as string;
			if (reader["Co_Fax"] != DBNull.Value)
				item.CoFax = reader["Co_Fax"] as string;
			if (reader["Co_EMail"] != DBNull.Value)
				item.CoEMail = reader["Co_EMail"] as string;
			if (reader["Co_Man"] != DBNull.Value)
				item.CoMan = reader["Co_Man"] as string;
			item.SortOrder = (short)reader["Sort_Order"];
			item.CoStatus = (short)reader["Co_Status"];
			item.CoStatusName = reader["Co_Status_Name"] as string;
			if (reader["Remark"] != DBNull.Value)
				item.Remark = reader["Remark"] as string;

			return item;
		}

		public static SysCompany GetSysCompany(string coid)
		{
			SysCompany item = new SysCompany();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Co_ID", SqlDbType.NVarChar, 4, coid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysCompany", paras);
				
				if (reader.Read())
				{
					item = PopulateSysCompany(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

		public static void SaveSysCompany(SysCompany item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@Co_ID", SqlDbType.NVarChar, 4, item.CoID));
				paras.Add(DBUtils.MakeInParam("@Co_Name", SqlDbType.NVarChar, 40, item.CoName));
				paras.Add(DBUtils.MakeInParam("@Crt_Date", SqlDbType.DateTime, item.CrtDate));
				paras.Add(DBUtils.MakeInParam("@Co_Address", SqlDbType.NVarChar, 100, item.CoAddress));
				paras.Add(DBUtils.MakeInParam("@Co_Post", SqlDbType.NVarChar, 10, item.CoPost));
				paras.Add(DBUtils.MakeInParam("@Co_Tele", SqlDbType.NVarChar, 30, item.CoTele));
				paras.Add(DBUtils.MakeInParam("@Co_Fax", SqlDbType.NVarChar, 30, item.CoFax));
				paras.Add(DBUtils.MakeInParam("@Co_EMail", SqlDbType.NVarChar, 32, item.CoEMail));
				paras.Add(DBUtils.MakeInParam("@Co_Man", SqlDbType.NVarChar, 6, item.CoMan));
				paras.Add(DBUtils.MakeInParam("@Sort_Order", SqlDbType.SmallInt, item.SortOrder));
				paras.Add(DBUtils.MakeInParam("@Co_Status", SqlDbType.SmallInt, item.CoStatus));
				paras.Add(DBUtils.MakeInParam("@Remark", SqlDbType.NVarChar, 20, item.Remark));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Save_SysCompany", paras);

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
