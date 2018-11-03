using Utils;
using Utils.Enumerations;
using WinCore;
using WinCore.Pdm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS.Oracle
{
    public partial class ImportPdm : BaseDialogForm
    {
        public ImportPdm()
        {
            InitializeComponent();
            CtrlHelper.SetDropDownList(ddlProject, CoreCtrls.GetComboBoxItems("Select * from T_Bus_Project order by ProjectID", SqlTextType.Text, "ProjectName,ProjectID"), DropAddType.New, DropAddFlag.Select);
        }

        private void closefrom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择要导入的PDM文件";
            dialog.Filter = "数据库文件|*.pdm";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.filename.Text = dialog.FileName;
                this.dbname.Text = dialog.SafeFileName.Replace(".pdm", "");
                this.dbcode.Text = dialog.SafeFileName.Replace(".pdm", "");
            }

        }

        private void savefile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(filename.Text))
            {
                MessageBox.Show("数据库定义文件不能为空！");
                return;
            }

            if (String.IsNullOrEmpty(dbname.Text))
            {
                MessageBox.Show("数据库名称不能为空！");
                return;
            }

            if (String.IsNullOrEmpty(dbcode.Text))
            {
                 MessageBox.Show("数据库代码不能为空！");
                return;
            }

            if (ddlProject.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择所属项目！");
                return;
            }

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                PdmHelper pdm = new PdmHelper(filename.Text);
                pdm.InitData();
                conn = DBUtils.GetConnection();
                cmd = DBUtils.GetCommand();

                cmd.Transaction = conn.BeginTransaction();

                #region Save DB

                ArrayList paras = new ArrayList();
                paras.Add(DBUtils.MakeInParam("DBCode", SqlDbType.NVarChar, 40, dbcode.Text));
                SqlDataReader reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_DBByCode", paras);

                PdmDatabase db = new PdmDatabase();

                if (reader.Read())
                    db.OnPopulate(reader);

                reader.Close();

                if (String.IsNullOrEmpty(db.DBCode))
                {
                    db.DBCode = dbcode.Text;
                    db.DBName = dbname.Text;
                }

                db.ProjectID = ddlProject.SelectedValue.ToString();

                if (db.DBID > 0)
                {
                    paras.Clear();
                    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, db.DBID));
                    DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Delete_Info", paras);
                }

                //if (db.DBID <= 0)
                //{
                    // 新数据库文件
                    paras.Clear();
                    paras.Add(DBUtils.MakeOutParam("DBID", SqlDbType.Int));
                    paras.Add(DBUtils.MakeInParam("DBName", SqlDbType.NVarChar, 40, db.DBName));
                    paras.Add(DBUtils.MakeInParam("DBCode", SqlDbType.NVarChar, 40, db.DBCode));
                    paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, cbLog.Checked));
                    paras.Add(DBUtils.MakeInParam("DBType", SqlDbType.Int, DataBaseType.Oracle));
                    paras.Add(DBUtils.MakeInParam("ProjectID", SqlDbType.VarChar, db.ProjectID));
                    paras.Add(DBUtils.MakeInParam("ACTION", SqlDbType.Int, DataProviderAction.Create));

                    DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_DB", paras);

                    db.DBID = ((SqlParameter)paras[0]).Value != DBNull.Value ? Convert.ToInt32(((SqlParameter)paras[0]).Value) : 0;

                    db.DBSerial = 0;
                //}
                //else
                //{
                //    paras.Clear();
                //    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, db.DBID));
                //    paras.Add(DBUtils.MakeInParam("DBName", SqlDbType.NVarChar, 40, db.DBName));
                //    paras.Add(DBUtils.MakeInParam("DBCode", SqlDbType.NVarChar, 40, db.DBCode));
                //    paras.Add(DBUtils.MakeInParam("ProjectID", SqlDbType.VarChar, db.ProjectID));
                //    paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, cbLog.Checked));
                //    paras.Add(DBUtils.MakeInParam("ACTION", SqlDbType.Int, DataProviderAction.Update));

                //    DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_DB", paras);

                //    if (cbLog.Checked)
                //        db.DBSerial += 1;
                //}

                # endregion Save DB


                # region Save Table & Columns

                PdmTable oTable = new PdmTable();
                PdmColumn oColumn = new PdmColumn();

                foreach (PdmTable pTable in pdm.Tables)
                {
                    pTable.DBID = db.DBID;
                    oTable.OnInit();

                    // 判断该表是否已经存在

                    paras.Clear();
                    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, db.DBID));
                    paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode.ToLower()));

                    reader = DBUtils.ExecuteReader(conn, cmd, CommandType.StoredProcedure, "dbo.P_Get_TableByCode", paras);

                    if (reader.Read())
                        oTable.OnPopulate(reader);

                    reader.Close();

                    if ((pTable.TableCode.ToLower().IndexOf("_pmt_") >= 0) || (pTable.TableCode.ToLower().IndexOf("pm_") >= 0))
                        pTable.IsPmt = true;

                    // 保存表信息

                    paras.Clear();
                    paras.Add(DBUtils.MakeInParam("DBID", SqlDbType.Int, db.DBID));
                    paras.Add(DBUtils.MakeInParam("TableCode", SqlDbType.NVarChar, 40, pTable.TableCode));
                    paras.Add(DBUtils.MakeInParam("TableName", SqlDbType.NVarChar, 40, pTable.TableName));
                    paras.Add(DBUtils.MakeInParam("Comment", SqlDbType.NVarChar, 400, pTable.Comment));
                    paras.Add(DBUtils.MakeInParam("IsPmt", SqlDbType.Bit, pTable.IsPmt));
                    paras.Add(DBUtils.MakeInParam("IsLog", SqlDbType.Bit, cbLog.Checked));

                    if (String.IsNullOrEmpty(oTable.TableCode))
                        paras.Add(DBUtils.MakeInParam("ACTION", SqlDbType.Int, DataProviderAction.Create));
                    else
                        paras.Add(DBUtils.MakeInParam("ACTION", SqlDbType.Int, DataProviderAction.Update));

                    DBUtils.ExecuteNonQuery(conn, cmd, CommandType.StoredProcedure, "dbo.P_Save_Table", paras);

                    SqlBaseProvider.DeleteColumn(conn, cmd, pTable, cbLog.Checked);

                    foreach (PdmColumn pColumn in pTable.Columns)
                    {
                        pColumn.DBID = pTable.DBID;
                        pColumn.TableCode = pTable.TableCode;

                        SqlBaseProvider.SaveColumn(conn, cmd, pColumn);
                    }

                    if (String.IsNullOrEmpty(oTable.TableCode) || cbLog.Checked)
                        SqlBaseProvider.LogColumn(conn, cmd, pTable, true);

                    SqlBaseProvider.DeleteKey(conn, cmd, pTable, cbLog.Checked);

                    foreach (PdmKey pKey in pTable.Keys)
                    {
                        pKey.DBID = pTable.DBID;
                        pKey.TableCode = pTable.TableCode;

                        SqlBaseProvider.SaveKey(conn, cmd, pKey);

                        foreach (PdmColumn pColumn in pKey.Columns)
                        {
                            SqlBaseProvider.SaveKeyColumn(conn, cmd, pKey, pColumn);
                        }
                    }

                    if (String.IsNullOrEmpty(oTable.TableCode) || cbLog.Checked)
                        SqlBaseProvider.LogKey(conn, cmd, pTable, true);

                    SqlBaseProvider.DeleteIndex(conn, cmd, pTable);

                    foreach (PdmIndex pIndex in pTable.Indexs)
                    {
                        pIndex.DBID = pTable.DBID;
                        pIndex.TableCode = pTable.TableCode;

                        SqlBaseProvider.SaveIndex(conn, cmd, pIndex);

                        foreach (PdmColumn pColumn in pIndex.Columns)
                        {
                            SqlBaseProvider.SaveIndexColumn(conn, cmd, pIndex, pColumn);
                        }
                    }

                    if (String.IsNullOrEmpty(oTable.TableCode) || cbLog.Checked)
                        SqlBaseProvider.LogIndex(conn, cmd, pTable, true);
                }

                # endregion Save Table & Columns & Key  Index

                cmd.Transaction.Commit();

                MessageBox.Show("PDM文件加载成功！");

            }
            catch (Exception)
            {
                
                throw;
            }


        }
    }
}
