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
        public static DataTable GetSysRoleList()
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Full.ToString().ToLower()));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRole", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetSysRoleByMan(string setman, string manid)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Set_Man", SqlDbType.NVarChar, 6, setman));
                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRoleByMan", paras);
                tblMain.TableName = "SelectMain";
            }
            catch (Exception ex)
            { 
                throw; 
            }

            return tblMain;
        }

        public static DataTable GetRoleMenu(short roleid)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, roleid));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RoleMenu", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetRoleMenu()
        {
            DataTable tblMain;

            try
            {
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RoleMenu");
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetRoleNav(short roleid)
        {
            DataTable tblMain;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, roleid));

                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RoleNav", paras);
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static DataTable GetRoleNav()
        {
            DataTable tblMain;

            try
            {
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_RoleNav");
                tblMain.TableName = "SelectMain";
            }
            catch { throw; }

            return tblMain;
        }

        public static SysRole PopulateSysRole(IDataReader reader)
        {
            SysRole item = new SysRole();
            item.RoleID = (short)reader["Role_ID"];
            item.RoleName = reader["Role_Name"] as string;
            if (reader["Role_Desc"] != DBNull.Value)
                item.RoleDesc = reader["Role_Desc"] as string;
            item.CrtDate = Convert.ToDateTime(reader["Crt_Date"]);
            item.RoleMan = reader["Role_Man"] as string;
            item.AuthBound = (short)reader["Auth_Bound"];

            return item;
        }

        public static SysRole GetSysRole(short roleid)
        {
            SysRole item = new SysRole();

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, roleid));
                paras.Add(DBUtils.MakeInParam("@Get_Action", SqlDbType.NVarChar, 10, DataGetAction.Row.ToString().ToLower()));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Get_SysRole", paras);

                if (reader.Read())
                {
                    item = PopulateSysRole(reader);
                }

                reader.Close();
            }
            catch { throw; }

            return item;
        }

        public static void SaveSysRole(SysRole item, DataTable menus, DataTable navs, DataProviderAction action)
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
                    paras.Add(DBUtils.MakeOutParam("@Role_ID", SqlDbType.SmallInt));
                }
                else
                {
                    paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, item.RoleID));
                }
                paras.Add(DBUtils.MakeInParam("@Role_Name", SqlDbType.NVarChar, 16, item.RoleName));
                paras.Add(DBUtils.MakeInParam("@Role_Desc", SqlDbType.NVarChar, 60, item.RoleDesc));
                paras.Add(DBUtils.MakeInParam("@Crt_Date", SqlDbType.DateTime, item.CrtDate));
                paras.Add(DBUtils.MakeInParam("@Role_Man", SqlDbType.NVarChar, 6, item.RoleMan));
                paras.Add(DBUtils.MakeInParam("@Auth_Bound", SqlDbType.SmallInt, item.AuthBound));
                paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Save_SysRole", paras);

                if (action == DataProviderAction.Create)
                {
                    item.RoleID = ((((SqlParameter)paras[0]).Value != null) ? (Convert.ToInt16(((SqlParameter)paras[0]).Value)) : (short)0);
                }

                paras.Clear();
                paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, item.RoleID));

                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Delete_RoleMenuAndNav", paras);

                foreach (DataRow menu in menus.Rows)
                {
                    if (Convert.ToBoolean(menu["Is_Select"]))
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, item.RoleID));
                        paras.Add(DBUtils.MakeInParam("@M_ID", SqlDbType.SmallInt, Convert.ToInt16(menu["M_ID"])));
                        paras.Add(DBUtils.MakeInParam("@M_Auth", SqlDbType.Int, Convert.ToInt32(menu["Role_Auth"])));

                        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Insert_RoleMenu", paras);
                    }
                }

                foreach (DataRow nav in navs.Rows)
                {
                    if (Convert.ToBoolean(nav["Is_Select"]))
                    {
                        paras.Clear();
                        paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, item.RoleID));
                        paras.Add(DBUtils.MakeInParam("@Rib_Btn", SqlDbType.SmallInt, Convert.ToInt16(nav["Rib_Btn"])));

                        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Insert_RoleNav", paras);
                    }
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

        public static void InsertOperRole(string manid, DataTable roles)
        {
            if (String.IsNullOrEmpty(manid))
                return;

            SqlConnection conn = DBUtils.GetConnection();
            SqlCommand cmd = DBUtils.GetCommand();

            try
            {
                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));
                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Delete_OperRole", paras);

                foreach (DataRow dr in roles.Rows)
                {
                    paras.Clear();

                    if (Convert.ToBoolean(dr["Is_Select"]))
                    {
                        paras.Add(DBUtils.MakeInParam("@Role_ID", SqlDbType.SmallInt, Convert.ToInt16(dr["Role_ID"])));
                        paras.Add(DBUtils.MakeInParam("@Man_ID", SqlDbType.NVarChar, 6, manid));
                        DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Insert_OperRole", paras);
                    }
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
