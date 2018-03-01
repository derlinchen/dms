using GuFun.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinCore
{
    public partial class SqlBaseProvider
    {

        public static BusHours GetHoursByDB(int dbid, string ManID, string WorkDate)
        {
            BusHours rtn = null;

            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, dbid));
                paras.Add(DBUtils.MakeInParam("ManID", SqlDbType.NVarChar, ManID));
                paras.Add(DBUtils.MakeInParam("WorkDate", SqlDbType.DateTime, Convert.ToDateTime(WorkDate)));

                SqlDataReader reader = DBUtils.ExecuteReader(CommandType.StoredProcedure, "dbo.P_Get_HoursByDB", paras);

                if (reader.Read())
                {
                    rtn = new BusHours();
                    rtn.OnPopulate(reader);
                }

                reader.Close();
            }
            catch { throw; }

            return rtn;
        }

        public static void SaveBusHours(BusHours item, DataProviderAction action)
        {
            if (item == null)
                return;

            SqlConnection conn = DBUtils.GetConnection();
            SqlCommand cmd = DBUtils.GetCommand();

            try
            {
                cmd.Transaction = conn.BeginTransaction();

                ArrayList paras = new ArrayList();

                paras.Add(DBUtils.MakeInParam("@DBID", SqlDbType.Int, item.DBID));
                paras.Add(DBUtils.MakeInParam("@ManID", SqlDbType.NVarChar, 6, item.ManID));
                paras.Add(DBUtils.MakeInParam("@WorkEnd", SqlDbType.DateTime, item.WorkEnd));
                paras.Add(DBUtils.MakeInParam("@Action", SqlDbType.Int, action));
                DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Save_BusHours", paras);

                cmd.Transaction.Commit();
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                DBUtils.SetDispose(conn, cmd);
            }

        }


        public static DataTable SearchBusHours(PageBusHours item)
        {
            DataTable tblMain;
            try
            {
                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("@Search", SqlDbType.NVarChar, 200, item.Search));
                paras.Add(DBUtils.MakeInParam("@Start", SqlDbType.Int, item.Start));
                paras.Add(DBUtils.MakeInParam("@End", SqlDbType.Int, item.End));
                paras.Add(DBUtils.MakeOutParam("@Total", SqlDbType.Int));
                paras.Add(DBUtils.MakeInParam("@GetAction", SqlDbType.VarChar, 10, item.GetAction));
                tblMain = DBUtils.ExecuteDataTable(CommandType.StoredProcedure, PublicConsts.DatabaseOwner + ".P_Search_BusHours", paras);
                tblMain.TableName = "SelectMain";

                if (paras.Count > 0)
                {
                    item.Total = ((((SqlParameter)paras[paras.Count - 2]).Value != DBNull.Value) ? (Convert.ToInt32(((SqlParameter)paras[paras.Count - 2]).Value)) : (int)0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PublicConsts.PC_Tip);
                throw;
            }
            return tblMain;
        }
    }
}
