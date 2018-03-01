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
		public static DataTable GetSysMenuDetail(short mid)
		{
			DataTable tblMain;

			try
			{
				ArrayList paras = new ArrayList();
        paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, mid));
				paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

				tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysMenuDetail", paras);
				tblMain.TableName = "SelectMain";
			}
			catch { throw; }

			return tblMain;
		}

		public static void CreateUpdateDeleteSysMenuDetail(SysMenuDetail item, DataProviderAction action)
		{
			if (item == null)
				return;

			SqlConnection conn = DBUtils.GetConnection();
			SqlCommand cmd = DBUtils.GetCommand();

			try
			{
				cmd.Transaction = conn.BeginTransaction();

				ArrayList paras = new ArrayList();

				paras.Add(DBUtils.MakeInParam("@Auth_ID", SqlDbType.SmallInt, item.AuthID));
				paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, item.MID));
				paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

				DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysMenuDetail", paras);

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

    public static void CreateSysMenuDetail(SqlConnection conn, SqlCommand cmd, short mid, SysMenuDetails items)
    {
      try
      {
        ArrayList paras = new ArrayList();

        paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, mid));
        paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, DataProviderAction.Delete));

        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysMenuDetail", paras);

        foreach (SysMenuDetail item in items)
        {
          paras.Clear();
          paras.Add(DBUtils.MakeInParam("@Auth_ID", SqlDbType.SmallInt, item.AuthID));
          paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, item.MID));
          paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, DataProviderAction.Create));

          DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_CreateUpdateDelete_SysMenuDetail", paras);
        }
      }
      catch
      {
        throw;
      }
    }
	}
}
