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
		public static DataTable GetSysRegisterList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRegister", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static SysRegister PopulateSysRegister(IDataReader reader)
		{
			SysRegister item = new SysRegister();
			item.RegID = (short)reader["Reg_ID"];
			item.CpuCode = reader["Cpu_Code"] as string;
			item.RegNumber = reader["Reg_Number"] as string;
			if (reader["Reg_Code"] != DBNull.Value)
				item.RegCode = reader["Reg_Code"] as string;
			if (reader["Dept_ID"] != DBNull.Value)
				item.DeptID = reader["Dept_ID"] as string;
			item.DeptName = reader["Dept_Name"] as string;
			item.CrtDate = Convert.ToDateTime(reader["Crt_Date"]);

			return item;
		}

		public static SysRegister GetSysRegister(short regid)
		{
			SysRegister item = new SysRegister();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, regid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRegister", paras);
				
				if (reader.Read())
				{
					item = PopulateSysRegister(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

    public static SysRegister GetSysRegister(string regnumber)
    {
      SysRegister item = new SysRegister();

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Reg_Number", SqlDbType.NVarChar, 40, regnumber));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

        SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRegister", paras);

        if (reader.Read())
        {
          item = PopulateSysRegister(reader);
        }

        reader.Close();
      }
      catch { throw; }

      return item;
    }

		public static void SaveSysRegister(SysRegister item, DataProviderAction action)
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
					paras.Add(DBUtils.MakeOutParam("@Reg_ID", SqlDbType.SmallInt));
				}
				else
				{
					paras.Add(DBUtils.MakeInParam("@Reg_ID", SqlDbType.SmallInt, item.RegID));
				}
				paras.Add(DBUtils.MakeInParam("@Cpu_Code", SqlDbType.NVarChar, 40, item.CpuCode));
				paras.Add(DBUtils.MakeInParam("@Reg_Number", SqlDbType.NVarChar, 40, item.RegNumber));
				paras.Add(DBUtils.MakeInParam("@Reg_Code", SqlDbType.NVarChar, 40, item.RegCode));
				paras.Add(DBUtils.MakeInParam("@Dept_ID", SqlDbType.NVarChar, 8, item.DeptID));
				paras.Add(DBUtils.MakeInParam("@Crt_Date", SqlDbType.DateTime, item.CrtDate));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Save_SysRegister", paras);

				if (action == DataProviderAction.Create)
				{
					item.RegID = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt16(((SqlParameter)paras[0]).Value)) : (short)0);
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
