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
		public static DataTable GetSysDeptList()
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList(); 
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 20, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysDept", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

    public static DataTable GetSimpleValidDept()
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 20, DataGetAction.SimpleValid.ToString().ToLower()));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysDept", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

    public static DataTable SelectSysDept(bool isvalid)
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Is_Valid", SqlDbType.Bit, isvalid));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Select_SysDept", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

    public static DataTable GetDeptByCountry()
    {
      DataTable tblMain;

      try
      {
        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysDeptByCountry");
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

    public static DataTable GetSysDeptList(string coid, DataGetAction get)
    {
      DataTable tblMain;

      try
      {
        ArrayList paras = new ArrayList();
        if (!String.IsNullOrEmpty(coid))
          paras.Add(DBUtils.MakeInParam("@Co_ID", SqlDbType.NVarChar, 4, coid));
        paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 20, get.ToString().ToLower()));

        tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysDept", paras);
        tblMain.TableName = "SelectMain";
      }
      catch { throw; }

      return tblMain;
    }

		public static SysDept PopulateSysDept(IDataReader reader)
		{
			SysDept item = new SysDept();
			item.DeptID = reader["Dept_ID"] as string;
			item.DeptName = reader["Dept_Name"] as string;
      item.DeptShort = reader["Dept_Short"] as string;
			item.CoID = reader["Co_ID"] as string;
			item.CoName = reader["Co_Name"] as string;
			item.DeptPID = reader["Dept_PID"] as string;
			item.CrtDate = Convert.ToDateTime(reader["Crt_Date"]);
			if (reader["Dept_Address"] != DBNull.Value)
				item.DeptAddress = reader["Dept_Address"] as string;
			if (reader["Dept_Post"] != DBNull.Value)
				item.DeptPost = reader["Dept_Post"] as string;
			if (reader["Dept_Tele"] != DBNull.Value)
				item.DeptTele = reader["Dept_Tele"] as string;
			if (reader["Dept_Fax"] != DBNull.Value)
				item.DeptFax = reader["Dept_Fax"] as string;
			if (reader["Dept_EMail"] != DBNull.Value)
				item.DeptEMail = reader["Dept_EMail"] as string;
			item.DeptMan = reader["Dept_Man"] as string;
			item.DeptLevel = (short)reader["Dept_Level"];
			item.DeptLevelName = reader["Dept_Level_Name"] as string;
			item.DeptType = (short)reader["Dept_Type"];
			item.DeptTypeName = reader["Dept_Type_Name"] as string;
			item.DeptDepth = (short)reader["Dept_Depth"];
			item.SortOrder = (short)reader["Sort_Order"];
			item.DeptStatus = (short)reader["Dept_Status"];
			item.DeptStatusName = reader["Dept_Status_Name"] as string;
			item.AuthDept = reader["Auth_Dept"] as string;
			if (reader["Remark"] != DBNull.Value)
				item.Remark = reader["Remark"] as string;

			return item;
		}

		public static SysDept GetSysDept(string deptid)
		{
			SysDept item = new SysDept();
			
			try
			{
				ArrayList paras = new ArrayList();
				paras.Add(DBUtils.MakeInParam("@Dept_ID", SqlDbType.NVarChar, 8, deptid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 20, DataGetAction.Row.ToString().ToLower()));

				SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysDept", paras);
				
				if (reader.Read())
				{
					item = PopulateSysDept(reader);
				}

				reader.Close();
			}
			catch { throw; }

			return item;
		}

    public static short GetDeptFlow(string deptid)
    {
      short rtn = 0;

      try
      {
        ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@Dept_ID", SqlDbType.NVarChar, 8, deptid));

        SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_DeptFlow", paras);

        if (reader.Read())
        {
          rtn = (short)reader["DEPT_FLOW"];
        }

        reader.Close();
      }
      catch { throw; }

      return rtn;
    }

		public static void SaveSysDept(SysDept item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@Dept_ID", SqlDbType.NVarChar, 8, item.DeptID));
				paras.Add(DBUtils.MakeInParam("@Dept_Name", SqlDbType.NVarChar, 30, item.DeptName));
                paras.Add(DBUtils.MakeInParam("@Dept_Short", SqlDbType.NVarChar, 4, item.DeptShort));
				paras.Add(DBUtils.MakeInParam("@Co_ID", SqlDbType.NVarChar, 4, item.CoID));
				paras.Add(DBUtils.MakeInParam("@Dept_PID", SqlDbType.NVarChar, 8, item.DeptPID));
				paras.Add(DBUtils.MakeInParam("@Crt_Date", SqlDbType.DateTime, item.CrtDate));
				paras.Add(DBUtils.MakeInParam("@Dept_Address", SqlDbType.NVarChar, 100, item.DeptAddress));
				paras.Add(DBUtils.MakeInParam("@Dept_Post", SqlDbType.NVarChar, 10, item.DeptPost));
				paras.Add(DBUtils.MakeInParam("@Dept_Tele", SqlDbType.NVarChar, 30, item.DeptTele));
				paras.Add(DBUtils.MakeInParam("@Dept_Fax", SqlDbType.NVarChar, 30, item.DeptFax));
				paras.Add(DBUtils.MakeInParam("@Dept_EMail", SqlDbType.NVarChar, 32, item.DeptEMail));
				paras.Add(DBUtils.MakeInParam("@Dept_Man", SqlDbType.NVarChar, 6, item.DeptMan));
				paras.Add(DBUtils.MakeInParam("@Dept_Level", SqlDbType.SmallInt, item.DeptLevel));
				paras.Add(DBUtils.MakeInParam("@Dept_Type", SqlDbType.SmallInt, item.DeptType));
				paras.Add(DBUtils.MakeInParam("@Dept_Depth", SqlDbType.SmallInt, item.DeptDepth));
				paras.Add(DBUtils.MakeInParam("@Sort_Order", SqlDbType.SmallInt, item.SortOrder));
				paras.Add(DBUtils.MakeInParam("@Dept_Status", SqlDbType.SmallInt, item.DeptStatus));
				paras.Add(DBUtils.MakeInParam("@Auth_Dept", SqlDbType.NVarChar, 8, item.AuthDept));
				paras.Add(DBUtils.MakeInParam("@Remark", SqlDbType.NVarChar, 20, item.Remark));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Save_SysDept", paras);

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

    public static void CreateDeptRela(string maindept, string reladept)
    {
      SqlConnection conn = DBUtils.GetConnection();
      SqlCommand cmd = DBUtils.GetCommand();

      try
      {
        cmd.Transaction = conn.BeginTransaction();

        ArrayList paras = new ArrayList();

        paras.Add(DBUtils.MakeInParam("@Main_Dept", SqlDbType.NVarChar, 8, maindept));
        paras.Add(DBUtils.MakeInParam("@Rela_Dept", SqlDbType.NVarChar, 8, reladept));

        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Create_DeptRela", paras);

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

    public static void DeleteDeptRela(string maindept, string reladept)
    {
      SqlConnection conn = DBUtils.GetConnection();
      SqlCommand cmd = DBUtils.GetCommand();

      try
      {
        cmd.Transaction = conn.BeginTransaction();

        ArrayList paras = new ArrayList();

        paras.Add(DBUtils.MakeInParam("@Main_Dept", SqlDbType.NVarChar, 8, maindept));
        paras.Add(DBUtils.MakeInParam("@Rela_Dept", SqlDbType.NVarChar, 8, reladept));

        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Delete_DeptRela", paras);

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
