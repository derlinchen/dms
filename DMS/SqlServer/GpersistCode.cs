using GuFun.Utils;
using GuFun.Utils.Enumerations;
using GuFun.WinCore;
using GuFun.WinCore.Pdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS.SqlServer
{
    public partial class GpersistCode : DMS.BaseDialogForm
    {
        private PdmTable pTable;
        private bool isHours = false;
        public string keycolumn = String.Empty;
        public PdmColumn keyCol = new PdmColumn();
        private string[] Prefix = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public GpersistCode()
        {
            InitializeComponent();
            this.initForm();
        }

        private void initForm() 
        {
            CtrlHelper.SetDropDownList(ddlDB, SqlBaseProvider.GetDBForCombox(Convert.ToInt32(DataBaseType.SqlServer)), DropAddType.New, DropAddFlag.Select, String.Empty, "DBName,DBID");

            ddlDB.SelectedValueChanged += new EventHandler(ddlDB_SelectedIndexChanged);
            pTable = new PdmTable();
        }

        private void ddlDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dbid = ddlDB.SelectedValue.ToString().ToLower() == "select" ? 0 : Convert.ToInt32(ddlDB.SelectedValue);
            Program.DBID = dbid;

            BusProject project = SqlBaseProvider.GetBusProjectByDB(dbid);
            Program.ProjectCode = project.ProjectCode;

            CtrlHelper.SetDropDownList(ddlTable, SqlBaseProvider.GetTableNoPmtByDB(dbid), DropAddType.New, DropAddFlag.Select, String.Empty, "TableName,TableCode");

            pTable.OnInit();
            txtSet.Text = String.Empty;
            txtResult.Text = String.Empty;
            txtPackage.Text = String.Empty;
            txtPrefix.Text = String.Empty;
            txtCatalog.Text = String.Empty;
            txtClassName.Text = String.Empty;
            txtValue.Text = String.Empty;

            BusHours hours = SqlBaseProvider.GetHoursByDB(Program.DBID, Program.ManInfo.Man.ManID, Program.LoginDate);

            if (hours != null)
            {
                isHours = true;
            }
            else
            {
                isHours = false;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            BusHours item = SqlBaseProvider.GetHoursByDB(Program.DBID, Program.ManInfo.Man.ManID, Program.LoginDate);
            if (item != null)
            {
                item.DBID = Program.DBID;
                item.WorkEnd = DateTime.Now;
                SqlBaseProvider.SaveBusHours(item, DataProviderAction.Update);
            }

            this.Close();
        }

        private void ddlTable_SelectedIndexChanged(object sender, EventArgs e) 
        {
            try
            {
                DataTable columns = SqlBaseProvider.GetColumnByTable(Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());

                SqlBaseProvider.GetTableByCode(pTable, Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());
                PdmKeyColumn pkc = SqlBaseProvider.GetKeyColumn(Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());

                txtPackage.Text = Program.ProjectCode;
                txtSet.Text = pTable.TableSet;
                txtSet.Text = String.Empty;
                txtResult.Text = String.Empty;

                txtPrefix.Text = String.Empty;
                txtCatalog.Text = String.Empty;
                txtClassName.Text = String.Empty;
                txtValue.Text = String.Empty;
                string tablename = String.Empty;
                if (columns.Rows.Count > 0)
                {
                    string table = ddlTable.SelectedValue.ToString();
                    string[] tables = table.Split('_');

                    for (int i = 1; i < tables.Length; i++)
                    {
                        tablename += tables[i];
                    }
                    txtPrefix.Text = tables[1];
                    txtCatalog.Text = tables[1].ToLower();
                    txtClassName.Text = tablename;
                    txtValue.Text = tablename.ToLower();

                    if (pkc != null)
                    {
                        keycolumn = pkc.ColumnCode;
                        OnGetSave(keycolumn);
                    }
                    else
                    {
                        keyCol = pTable.Columns[0];
                        keycolumn = pTable.Columns[0].ColumnCode;
                    }

                    if (String.IsNullOrEmpty(pTable.TableSet))
                    {
                        if (pkc != null)
                        {
                            String txtSetText = "G|" + tablename + "|" + pkc.ColumnCode + PublicTools.WriteEnter(1);
                            txtSetText += "S|" + tablename + "|" + pkc.ColumnCode;
                            txtSet.Text = txtSetText;
                            saveConfig();
                        }
                        else
                        {
                            String txtSetText = "G|" + tablename + "|" + keycolumn + PublicTools.WriteEnter(1);
                            txtSetText += "S|" + tablename + "|" + keycolumn;
                            txtSet.Text = txtSetText;
                            saveConfig();
                        }
                    }
                    else
                    {
                        txtSet.Text = pTable.TableSet;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private bool verifyInfo()
        {
            if (ddlDB.SelectedValue.ToString().ToLower() == "select")
            {
                Global.ShowSysInfo("请选择数据库！");
                return false;
            }

            if (String.IsNullOrEmpty(txtPackage.Text))
            {
                Global.ShowSysInfo("请输入包名！");
                return false;
            }

            if (String.IsNullOrEmpty(txtPrefix.Text))
            {
                Global.ShowSysInfo("请输入前缀！");
                return false;
            }

            if (String.IsNullOrEmpty(txtCatalog.Text))
            {
                Global.ShowSysInfo("请输入类目录！");
                return false;
            }

            if (String.IsNullOrEmpty(txtClassName.Text))
            {
                Global.ShowSysInfo("请输入类名！");
                return false;
            }

            if (String.IsNullOrEmpty(txtValue.Text))
            {
                Global.ShowSysInfo("请输入变量！");
                return false;
            }

            if (String.IsNullOrEmpty(txtSet.Text.Trim()))
            {
                Global.ShowSysInfo("没有配置信息，请在左边富文本框输入配置信息！");
                return false;
            }
            return true;
        }

        private bool varifySet(string set)
        {
            string[] tablesets = PublicTools.TextReadToArr(set);

            foreach (string tableset in tablesets)
            {
                if (String.IsNullOrEmpty(tableset))
                {
                    Global.ShowSysInfo("请在左边富文本框，输入正确的配置信息！");
                    return false;
                }

                string[] sets = tableset.Split('|');

                if (sets[0].ToLower() != "g" && sets[0].ToLower() != "s" && sets[0].ToLower() != "c")
                {
                    Global.ShowSysInfo("请在左边富文本框，输入正确的配置信息！");
                    return false;
                }

                if (sets.Length != 3 && sets.Length != 5)
                {
                    Global.ShowSysInfo("请在左边富文本框，输入正确的配置信息！");
                    return false;
                }

                if (Array.IndexOf(sets, "") != -1)
                {
                    Global.ShowSysInfo("请在左边富文本框，输入正确的配置信息！");
                    return false;
                }

                if (sets[0].ToLower() == "c")
                {
                    if (sets.Length != 5)
                    {
                        Global.ShowSysInfo("请在左边富文本框，输入正确的配置信息！");
                        return false;
                    }

                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveConfig();
            Global.ShowSysInfo("配置信息保存成功！");
        }

        private bool saveConfig() 
        {
            try
            {
                if (!verifyInfo())
                {
                    return false;
                }

                if (!varifySet(txtSet.Text))
                {
                    return false;
                }

                pTable.TableSet = txtSet.Text;

                SqlBaseProvider.SaveTableSet(pTable);

                List<ColumnTable> cols = new List<ColumnTable>();

                foreach (PdmColumn pColumn in pTable.Columns)
                {
                    ColumnTable col = new ColumnTable();
                    col.DBID = pTable.DBID;
                    col.TableCode = pTable.TableCode;
                    col.ColumnCode = pColumn.ColumnCode;
                    col.ColumnSerial = 0;
                    col.Prefix = Prefix[0];
                    col.RelaTable = pTable.TableCode;
                    col.DisplayColumn = pColumn.ColumnCode;
                    col.RelaColumn = pColumn.ColumnCode;

                    cols.Add(col);
                }

                string[] tablesets = PublicTools.TextReadToArr(txtSet.Text);

                int prefixcnt = 1;
                int i = 0;
                int j = 0;

                foreach (string tableset in tablesets)
                {
                    string[] sets = tableset.Split('|');
                    if (sets[0].ToLower() == "c")
                    {
                        SqlBaseProvider.SavePmtSet(pTable.DBID, tableset);

                        string[] relacols = sets[4].Split(',');

                        for (i = relacols.Length - 1; i >= 0; i--)
                        {
                            ColumnTable col = new ColumnTable();
                            col.DBID = pTable.DBID;
                            col.TableCode = pTable.TableCode;
                            col.ColumnCode = sets[1];
                            col.ColumnSerial = 0;
                            col.Prefix = Prefix[prefixcnt];
                            col.RelaTable = sets[2];
                            col.DisplayColumn = relacols[i];
                            col.RelaColumn = sets[3];

                            for (j = 0; j < cols.Count; j++)
                            {
                                if (cols[j].ColumnCode.ToLower() == col.ColumnCode.ToLower())
                                {
                                    cols.Insert(j + 1, col);
                                    break;
                                }
                            }
                        }

                        prefixcnt++;
                    }
                }

                SqlBaseProvider.SaveColumnTable(pTable, cols);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                foreach (PdmColumn pColumn in pTable.Columns)
                {
                    pColumn.NowSerial = 0;
                }

                string[] tablesets = PublicTools.TextReadToArr(txtSet.Text);

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                Global.ShowSysInfo("配置信息填写正确！");

            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnBean_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                List<ColumnTable> pColumnTables = SqlBaseProvider.GetColumnTable(pTable.DBID, pTable.TableCode);

                txtResult.Text = PublicTools.WriteTab(0) + "package com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    txtResult.Text += PublicTools.WriteTab(0) + "." + txtCatalog.Text.Trim().ToLower();
                txtResult.Text += ";" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(0) + "import com.gpersist.entity.*;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "import com.gpersist.entity.publics.*;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "import com.gpersist.utils.*;" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(0) + "public class " + txtClassName.Text + " implements BaseBean {" + PublicTools.WriteEnter(2);

                foreach (ColumnTable c in pColumnTables)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "// " + c.ColumnName.ToLower() + ";" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "private " + PublicTools.GetJavaType(c.GetColType()) + " " + c.DisplayColumn.ToLower() + ";" + PublicTools.WriteEnter(2);
                }

                if (cbSearch.Checked)
                    txtResult.Text += PublicTools.WriteTab(1) + "private SearchParams search;" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "private DataDeal deal;" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "private SelectBean<" + txtClassName.Text + "> item;" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + "() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "this.OnInit();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public boolean OnBeforeSave(ErrorMsg msg) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "msg.setErrmsg(\"\");" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "boolean rtn = false;" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return rtn;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String OnDebug() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return ToolUtils.DebugProperty(this, this.OnProperties());" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String OnCompare(BaseBean item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return ToolUtils.CompareProperty((" + txtClassName.Text + ")item, this, this.OnProperties());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String[] OnProperties() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return new String[] {";

                foreach (ColumnTable c in pColumnTables)
                {
                    txtResult.Text += "\"" + c.ColumnName + ":" + c.DisplayColumn.ToLower() + "\", ";
                }

                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 2) + "};" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String[] OnExclusions() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return new String[] {\"deal\", \"item\"";
                if (cbSearch.Checked)
                    txtResult.Text += ", \"search\"";
                txtResult.Text += "};" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@Override" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public void OnInit() {" + PublicTools.WriteEnter(1);

                foreach (ColumnTable c in pColumnTables)
                {
                    txtResult.Text += PublicTools.WriteTab(2) + "this." + c.DisplayColumn.ToLower() + " = " + PublicTools.GetInitType(c.GetColType()) + ";" + PublicTools.WriteEnter(1);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                foreach (ColumnTable c in pColumnTables)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public " + PublicTools.GetJavaType(c.GetColType()) + " get" + PublicTools.GetFirstUpper(c.DisplayColumn.ToLower()) + "() {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "return " + c.DisplayColumn.ToLower() + ";" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                    txtResult.Text += PublicTools.WriteTab(1) + "public void set" + PublicTools.GetFirstUpper(c.DisplayColumn.ToLower()) + "(" + PublicTools.GetJavaType(c.GetColType()) + " " + c.DisplayColumn.ToLower() + ") {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "this." + c.DisplayColumn.ToLower() + "=" + c.DisplayColumn.ToLower() + ";" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                if (cbSearch.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public SearchParams getSearch() {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "if (search == null)" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "search = new SearchParams();" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "return search;" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(1) + "public void setSearch(SearchParams search) {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "this.search = search;" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "public DataDeal getDeal() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "if (deal == null)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "deal = new DataDeal();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return deal;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void setDeal(DataDeal deal) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "this.deal = deal;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public SelectBean<" + txtClassName.Text + "> getItem() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "if (item == null)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "item = new SelectBean<" + txtClassName.Text + ">();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return item;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void setItem(SelectBean<" + txtClassName.Text + "> item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "this.item = item;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(0) + "}" + PublicTools.WriteEnter(1);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        

        private void OnGetSave(string keycolumn)
        {
            foreach (PdmColumn item in pTable.Columns)
            {
                if (item.ColumnCode.ToLower() == keycolumn.ToLower())
                {
                    keyCol = item;
                    break;
                }
            }

        }

        private void btnMapper_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string packageclass = "com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                txtResult.Text = PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + " Get" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);

                if (cbNo.Checked)
                    txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "();" + PublicTools.WriteEnter(2);
                else
                    txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                if (cbSearch.Checked)
                    txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> Search" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void Save" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnDao_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string packageclass = "com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                txtResult.Text = PublicTools.WriteTab(1) + "// SqlServer Dao Functions" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public static " + txtClassName.Text + " Get" + txtClassName.Text + "(SqlSession session, " + txtClassName.Text + " item) { " + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper mapper = DBUtils.getMapper(session, com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper.class);	" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "item.getItem().setGetaction(ActionGetType.row.toString());" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return mapper.Get" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                if (cbNo.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "(SqlSession session) { " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper mapper = DBUtils.getMapper(session, com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper.class);	" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "return mapper.GetList" + txtClassName.Text + "();" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }
                else
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "(SqlSession session, " + txtClassName.Text + " item) { " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper mapper = DBUtils.getMapper(session, com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper.class);	" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "return mapper.GetList" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                if (cbSearch.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> Search" + txtClassName.Text + "(SqlSession session, " + txtClassName.Text + " item) { " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper mapper = DBUtils.getMapper(session, com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper.class);	" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "return mapper.Search" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "public static void Save" + txtClassName.Text + "(SqlSession session, " + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper mapper = DBUtils.getMapper(session, com." + txtPackage.Text + ".mapper.sqlserver." + txtPrefix.Text + "Mapper.class);	" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "mapper.Save" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// Dao Functions" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public static " + txtClassName.Text + " Get" + txtClassName.Text + "(" + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "SqlSession session = DBUtils.getFactory();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "try {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "return Sql" + txtPrefix.Text + "Dao.Get" + txtClassName.Text + "(session, item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "} catch (Exception e) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "return new " + txtClassName.Text + "();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "finally {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "session.close();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                if (cbNo.Checked)
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "() {" + PublicTools.WriteEnter(1);
                else
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> GetList" + txtClassName.Text + "(" + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "SqlSession session = DBUtils.getFactory();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "try {" + PublicTools.WriteEnter(1);
                if (cbNo.Checked)
                    txtResult.Text += PublicTools.WriteTab(3) + "return Sql" + txtPrefix.Text + "Dao.GetList" + txtClassName.Text + "(session);" + PublicTools.WriteEnter(1);
                else
                    txtResult.Text += PublicTools.WriteTab(3) + "return Sql" + txtPrefix.Text + "Dao.GetList" + txtClassName.Text + "(session, item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "} catch (Exception e) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "return new ArrayList<" + txtClassName.Text + ">();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "finally {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "session.close();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                if (cbSearch.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "public static List<" + txtClassName.Text + "> Search" + txtClassName.Text + "(" + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "SqlSession session = DBUtils.getFactory();" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "try {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "return Sql" + txtPrefix.Text + "Dao.Search" + txtClassName.Text + "(session, item);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "} catch (Exception e) {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "return new ArrayList<" + txtClassName.Text + ">();" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "finally {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "session.close();" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "public static void Save" + txtClassName.Text + "(SqlSession session, " + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "Sql" + txtPrefix.Text + "Dao.Save" + txtClassName.Text + "(session, item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string packageclass = "com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                txtResult.Text = PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public static void Save" + txtClassName.Text + "(" + txtClassName.Text + " item, ReturnValue rtv, TranLog log) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "rtv.setSuccess(false);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "SqlSession session = DBUtils.getFactory();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "try {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "ErrorMsg errmsg = new ErrorMsg();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(3) + "if (item.OnBeforeSave(errmsg)) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "rtv.setMsg(errmsg.getErrmsg());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "return;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(3) + txtPrefix.Text + "Dao.Save" + txtClassName.Text + "(session, item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(3) + "log.ActionToTran(item.getDeal().getAction());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "log.setTrandesc(\"\");" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "PublicDao.SaveTranLog(session, log);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(3) + "rtv.setSuccess(true);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "rtv.setMsg(Consts.STR_SAVE_S);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "session.commit();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "} catch (Exception e) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "session.rollback();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "rtv.setMsg(ToolUtils.GetErrorMessage(e, Consts.STR_SAVE_F));" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "} finally {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "session.close();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string packageclass = "com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                string tablename = pTable.TableName.Substring(pTable.TableName.IndexOf('-') + 1).Replace("参数", "").Replace("表", "");
                string hasdate = "false";

                foreach (PdmColumn pColumn in pTable.Columns)
                {
                    if (pColumn.GetColType() == ColType.DateTime)
                    {
                        hasdate = "true";
                        break;
                    }
                }

                txtResult.Text = PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "private " + txtClassName.Text + " " + txtValue.Text + ";" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + " get" + PublicTools.GetFirstUpper(txtValue.Text) + "() {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "if (" + txtValue.Text + " == null)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + txtValue.Text + " = new " + txtClassName.Text + "();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtValue.Text + ";" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void set" + PublicTools.GetFirstUpper(txtValue.Text) + "(" + txtClassName.Text + " " + txtValue.Text + ") {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "this." + txtValue.Text + " = " + txtValue.Text + ";" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@AuthMethod(Menus=\"\", Auth=MenuAuth.Browse, OutType=ActionOutType.Bean)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String Get" + txtClassName.Text + "() throws Exception {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "OnlineUser ou = ToolUtils.GetOnlineUser();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + txtClassName.Text + " rtn = new " + txtClassName.Text + "();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "if (ou != null) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "rtn = " + txtPrefix.Text + "Dao.Get" + txtClassName.Text + "(this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "ToolUtils.OutString(this.OutBean(rtn, " + hasdate + "));" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return null;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@AuthMethod(Menus=\"\", Auth=MenuAuth.BrowseExport, OutType=ActionOutType.Array)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String GetList" + txtClassName.Text + "() throws Exception {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "OnlineUser ou = ToolUtils.GetOnlineUser();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "if (ou != null) {" + PublicTools.WriteEnter(1);
                if (cbNo.Checked)
                    txtResult.Text += PublicTools.WriteTab(3) + "List<" + txtClassName.Text + "> lists = " + txtPrefix.Text + "Dao.GetList" + txtClassName.Text + "();" + PublicTools.WriteEnter(2);
                else
                    txtResult.Text += PublicTools.WriteTab(3) + "List<" + txtClassName.Text + "> lists = " + txtPrefix.Text + "Dao.GetList" + txtClassName.Text + "(this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "());" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(3) + "if (!hasexport) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "ToolUtils.OutString(this.OutLists(lists, lists.size(), false));" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "else {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "ExportSetting es = this.GetExportSetting(\"" + tablename + "\", false);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "this.OutExport(lists, es);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(4) + "return Consts.DEFAULT_EXCEL_RETURN;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "else {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "ToolUtils.OutString(Consts.DEFAULT_NULL_ARRAY);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return null;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                if (cbSearch.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "@AuthMethod(Menus=\"\", Auth=MenuAuth.BrowseExport, OutType=ActionOutType.Array)" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "public String Search" + txtClassName.Text + "() throws Exception {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "OnlineUser ou = ToolUtils.GetOnlineUser();" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "if (ou != null) {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "String search = \"\";" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(3) + "this.SetSearch(this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "().getSearch(), this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "().getItem(), ou, search);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "List<" + txtClassName.Text + "> lists = " + txtPrefix.Text + "Dao.Search" + txtClassName.Text + "(this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "());" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "if (!hasexport) {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(4) + "ToolUtils.OutString(this.OutLists(lists, this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "().getSearch().getTotal(), false));" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "else {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(4) + "ExportSetting es = this.GetExportSetting(\"" + tablename + "\", false);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(4) + "this.OutExport(lists, es);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(4) + "return Consts.DEFAULT_EXCEL_RETURN;" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "else {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "ToolUtils.OutString(Consts.DEFAULT_NULL_ARRAY);" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(2) + "return null;" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "@AuthMethod(Menus=\"\", Auth=MenuAuth.Modify, OutType=ActionOutType.Bean)" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public String Save" + txtClassName.Text + "() throws Exception {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "OnlineUser ou = ToolUtils.GetOnlineUser();" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "if (ou != null) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "TranLog log = ToolUtils.InitTranLog(\"\");" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + txtPrefix.Text + "Service.Save" + txtClassName.Text + "(this.get" + PublicTools.GetFirstUpper(txtValue.Text) + "(), this.getRtv(), log);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "ToolUtils.OutString(this.getRtv().toString());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "else" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "ToolUtils.OutString(this.NotLoginRtv());" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(2) + "return null;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnGetSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDB.SelectedValue.ToString().ToLower() == "select")
                {
                    Global.ShowSysInfo("请选择数据库！");
                    return;
                }

                if (String.IsNullOrEmpty(pTable.TableCode))
                {
                    Global.ShowSysInfo("请选择数据表！");
                    return;
                }

                if (String.IsNullOrEmpty(txtSet.Text.Trim()))
                {
                    Global.ShowSysInfo("没有配置信息，请在左边富文本框输入配置信息！");
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                List<ColumnTable> pColumnTables = SqlBaseProvider.GetColumnTable(pTable.DBID, pTable.TableCode);
                string othersql = String.Empty;
                bool hasColumn = false;

                if (cbPage.Checked)
                {
                    txtResult.Text = PublicTools.WriteTab(0) + "if (exists (select name from sysobjects where (name = N'P_Search_" + txtClassName.Text + "') and (type = 'P')))" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "drop procedure dbo.P_Search_" + txtClassName.Text + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(0) + "create procedure [dbo].P_Search_" + txtClassName.Text + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "(" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@search varchar(4000) = null, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@start int = null, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@end int = null, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@total int = null out, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@userid varchar(14) = null, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@getaction varchar(10) = null" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + ")" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "as" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "begin" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(1) + "if (@start is not null) and (@end is not null)" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "declare @Sql nvarchar(4000)" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "set @Sql = 'select @TOTAL = count(*) from '" + PublicTools.WriteEnter(1);

                    othersql = PublicTools.WriteTab(3) + "+ '";
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (othersql.IndexOf(item.RelaTable.ToLower()) < 0)
                            othersql += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                    }
                    othersql = othersql.Substring(0, othersql.Length - 2);
                    othersql += " '" + PublicTools.WriteEnter(1);

                    othersql += PublicTools.WriteTab(3) + "+ 'where ";
                    hasColumn = false;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.TableCode == item.RelaTable)
                            continue;

                        if (othersql.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                        {
                            othersql += "a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                            hasColumn = true;
                        }
                    }
                    if (hasColumn)
                        othersql = othersql.Substring(0, othersql.Length - 5);
                    else
                        othersql = othersql + " 1 = 1";
                    othersql += " '" + PublicTools.WriteEnter(1);

                    txtResult.Text += othersql;
                    txtResult.Text += PublicTools.WriteTab(2) + "if (@search is not null) and (@search != '')" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "set @Sql = @Sql + ' and ' +  @search" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "exec sp_executesql @Sql, N'@TOTAL int out', @total out" + PublicTools.WriteEnter(2);

                    txtResult.Text += PublicTools.WriteTab(2) + "set @Sql = 'select * from (select a.*";

                    hasColumn = false;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.Prefix != "a")
                        {
                            txtResult.Text += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                            hasColumn = true;
                        }
                    }
                    txtResult.Text += ", '" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "+ 'row_number() over (order by a." + keycolumn.ToLower() + " desc) as RN from '" + PublicTools.WriteEnter(1);
                    txtResult.Text += othersql;

                    txtResult.Text += PublicTools.WriteTab(2) + "if (@search is not null) and (@search != '')" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "set @Sql = @Sql + ' and ' +  @search" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "set @Sql = @Sql + ' ) SearchList where RN between ' + ltrim(str(@start)) + ' and ' + ltrim(str(@end))" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "exec(@Sql)" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);
                }
                else
                {
                    txtResult.Text = PublicTools.WriteTab(0) + "if (exists (select name from sysobjects where (name = N'P_Get_" + txtClassName.Text + "') and (type = 'P')))" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "drop procedure dbo.P_Get_" + txtClassName.Text + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(0) + "create procedure [dbo].P_Get_" + txtClassName.Text + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "(" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@" + keycolumn.ToLower() + " " + keyCol.DataType.ToLower() + " = null, " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "@getaction varchar(10) = null" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + ")" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "as" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "begin" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "if (@getaction = 'full') or (@getaction is null)" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "select a.*";
                    hasColumn = false;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.Prefix != "a")
                        {
                            txtResult.Text += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                            hasColumn = true;
                        }
                    }
                    txtResult.Text += " " + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(3) + "from ";
                    hasColumn = false;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (txtResult.Text.IndexOf(item.RelaTable.ToLower()) < 0)
                        {
                            txtResult.Text += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                            hasColumn = true;
                        }
                    }
                    txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 2);
                    txtResult.Text += PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(3) + "where ";
                    hasColumn = false;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.TableCode == item.RelaTable)
                            continue;

                        if (txtResult.Text.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                        {
                            txtResult.Text += "a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                            hasColumn = true;
                        }
                    }
                    if (hasColumn)
                        txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 5);
                    else
                        txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 10);
                    txtResult.Text += PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(3) + "order by a." + keycolumn.ToLower() + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "else if (@getaction = 'row')" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "if @" + keycolumn.ToLower() + " is not null " + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "begin" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "select a.*";
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.Prefix != "a")
                            txtResult.Text += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                    }
                    txtResult.Text += " " + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(3) + "from ";
                    othersql = String.Empty;
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (othersql.IndexOf(item.RelaTable.ToLower()) < 0)
                            othersql += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                    }
                    if (othersql.Length >= 2)
                        othersql = othersql.Substring(0, othersql.Length - 2);
                    othersql += PublicTools.WriteEnter(1);

                    othersql += PublicTools.WriteTab(3) + "where ";
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if (item.TableCode == item.RelaTable)
                            continue;

                        if (othersql.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                            othersql += "a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                    }
                    txtResult.Text += othersql + "a." + keycolumn.ToLower() + " = @" + keycolumn.ToLower() + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "end" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);
                }
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnSaveSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDB.SelectedValue.ToString().ToLower() == "select")
                {
                    Global.ShowSysInfo("请选择数据库！");
                    return;
                }

                if (String.IsNullOrEmpty(pTable.TableCode))
                {
                    Global.ShowSysInfo("请选择数据表！");
                    return;
                }

                if (String.IsNullOrEmpty(txtSet.Text.Trim()))
                {
                    Global.ShowSysInfo("没有配置信息，请在左边富文本框输入配置信息！");
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string dataType = keyCol.DataType;
                string defaultnum = "0000000001";

                if (dataType.IndexOf("(") < 0)
                {
                    Global.ShowSysInfo("主键生成必须有长度限定，请确认字段长度！");
                    return;
                }

                int length = Convert.ToInt32(dataType.Substring(dataType.IndexOf("(") + 1, dataType.Length - (dataType.IndexOf("(") + 1) - 1));

                txtResult.Text = PublicTools.WriteTab(0) + "if (exists (select name from sysobjects where (name = N'P_Create_" + keycolumn + "') and (type = 'P')))" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "drop procedure dbo.P_Create_" + keycolumn + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(0) + "create procedure [dbo].P_Create_" + keycolumn + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "(" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@" + keycolumn.ToLower() + " " + dataType + " out" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + ")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "as" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "begin" + PublicTools.WriteEnter(1);

                if (length > 10)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "declare @maxno int" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "select @maxno = max(right(" + keycolumn.ToLower() + "," + (length - 10) + ")) from " + pTable.TableCode + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + " where left(" + keycolumn.ToLower() + " ,10) = 'PK'+replace(convert(varchar(10),getdate(),120),'-','')" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "if @maxno is null" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "select @" + keycolumn.ToLower() + " = 'PK' + replace(convert(varchar(10),getdate(),120),'-','') +'" + defaultnum.Substring(defaultnum.Length - (length - 10), length - 10) + "'" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "else" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "select @" + keycolumn.ToLower() + " = 'PK'+ replace(convert(varchar(10),getdate(),120),'-','')" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "+replace(space(" + (length - 10) + "-len(@maxno+1)),space(1),'0')+ltrim(str(@maxno+1))" + PublicTools.WriteEnter(1);

                }
                else
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "declare @maxno int" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "select @maxno = max(" + keycolumn.ToLower() + ") from " + pTable.TableCode + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "if @maxno is null" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "select @" + keycolumn.ToLower() + " = '" + defaultnum.Substring(defaultnum.Length - length, length) + "'" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "else" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "select @" + keycolumn.ToLower() + " = " + "replace(space(" + length + "-len(@maxno+1)),space(1),'0')+ltrim(str(@maxno+1))" + PublicTools.WriteEnter(1);
                }
                txtResult.Text += PublicTools.WriteTab(0) + "end" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(2);

                List<ColumnTable> pColumnTables = SqlBaseProvider.GetColumnTable(pTable.DBID, pTable.TableCode);

                txtResult.Text += PublicTools.WriteTab(0) + "if (exists (select name from sysobjects where (name = N'P_Save_" + txtClassName.Text + "') and (type = 'P')))" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "drop procedure dbo.P_Save_" + txtClassName.Text + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(0) + "create procedure [dbo].P_Save_" + txtClassName.Text + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "(" + PublicTools.WriteEnter(1);

                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix == "a")
                    {
                        if (keycolumn.IndexOf(item.ColumnCode) >= 0)
                        {
                            txtResult.Text += PublicTools.WriteTab(1) + "@" + item.DisplayColumn.ToLower() + " " + item.DataType + " = null output," + PublicTools.WriteEnter(1);
                        }
                        else
                        {
                            txtResult.Text += PublicTools.WriteTab(1) + "@" + item.DisplayColumn.ToLower() + " " + item.DataType + " = null," + PublicTools.WriteEnter(1);
                        }
                    }
                }

                txtResult.Text += PublicTools.WriteTab(1) + "@action int" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + ")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "as" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "begin" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "if @action = 2" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(2) + "exec P_Create_" + keycolumn + " @" + keycolumn.ToLower() + " output" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(2) + "insert into " + pTable.TableCode + "(";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix == "a")
                        txtResult.Text += item.DisplayColumn.ToLower() + ", ";
                }
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 2);

                txtResult.Text += ")" + PublicTools.WriteEnter(1) + PublicTools.WriteTab(3) + "values (";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix == "a")
                        txtResult.Text += "@" + item.DisplayColumn.ToLower() + ", ";
                }
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 2) + ")";
                txtResult.Text += PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);

                if (cbEdit.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "else if @action = 3" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "update " + pTable.TableCode + " set ";
                    foreach (ColumnTable item in pColumnTables)
                    {
                        if ((item.Prefix == "a") && (item.DisplayColumn != keycolumn))
                            txtResult.Text += PublicTools.WriteEnter(1) + PublicTools.WriteTab(3) + item.DisplayColumn.ToLower() + " = @" + item.DisplayColumn.ToLower() + ",";
                    }
                    txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1) + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(3) + "where " + keycolumn.ToLower() + " = @" + keycolumn.ToLower() + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);
                }
                if (cbDelete.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "else if @action = 4" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "begin" + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(2) + "delete from " + pTable.TableCode + " where " + keycolumn.ToLower() + " = @" + keycolumn.ToLower() + PublicTools.WriteEnter(1);

                    txtResult.Text += PublicTools.WriteTab(1) + "end" + PublicTools.WriteEnter(1);
                }

                txtResult.Text += PublicTools.WriteTab(0) + "end" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "go" + PublicTools.WriteEnter(1);
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnJs_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDB.SelectedValue.ToString().ToLower() == "select")
                {
                    Global.ShowSysInfo("请选择数据库！");
                    return;
                }

                if (String.IsNullOrEmpty(pTable.TableCode))
                {
                    Global.ShowSysInfo("请选择数据表！");
                    return;
                }

                if (String.IsNullOrEmpty(txtSet.Text.Trim()))
                {
                    Global.ShowSysInfo("没有配置信息，请在左边富文本框输入配置信息！");
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                txtResult.Text = String.Empty;
                foreach (PdmColumn pColumn in pTable.Columns)
                {
                    txtResult.Text += "'" + pColumn.ColumnCode.ToLower() + "', ";
                }
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 2) + PublicTools.WriteEnter(2);

                foreach (PdmColumn pColumn in pTable.Columns)
                {
                    txtResult.Text += PublicTools.WriteTab(3) + "tools.SetValue(mep + '" + pColumn.ColumnCode.ToLower() + "', item." + pColumn.ColumnCode.ToLower() + ");" + PublicTools.WriteEnter(1);
                }
            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifyInfo())
                {
                    return;
                }

                if (!varifySet(txtSet.Text))
                {
                    return;
                }

                if (!isHours)
                {
                    Global.ShowSysInfo("请先打卡！");
                    return;
                }

                string packageclass = "com." + txtPackage.Text + ".entity";
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                txtResult.Text = PublicTools.WriteTab(1) + "<select id=\"Get" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultType=\"" + packageclass + "\" >" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "{call dbo.P_Get_" + txtClassName.Text + "(" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "#{" + keycolumn.ToLower() + ",javaType=" + PublicTools.GetJavaType(keyCol.GetColType()) + ",jdbcType=" + PublicTools.GetJdbcType(keyCol.GetColType()) + "}," + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "#{item.getaction,javaType=String,jdbcType=VARCHAR}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + ")}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(1) + "<select id=\"GetList" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultType=\"" + packageclass + "\" >" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "{call dbo.P_Get_" + txtClassName.Text + "(" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "#{" + keycolumn.ToLower() + ",javaType=" + PublicTools.GetJavaType(keyCol.GetColType()) + ",jdbcType=" + PublicTools.GetJdbcType(keyCol.GetColType()) + "}," + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "#{item.getaction,javaType=String,jdbcType=VARCHAR}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + ")}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(1);

                if (cbSearch.Checked)
                {
                    txtResult.Text += PublicTools.WriteTab(1) + "<select id=\"Search" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultType=\"" + packageclass + "\" >" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "{call dbo.P_Search_" + txtClassName.Text + "(" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.search,javaType=String,jdbcType=VARCHAR}," + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.start,javaType=int,jdbcType=INTEGER}," + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.end,javaType=int,jdbcType=INTEGER}," + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.total,javaType=int,jdbcType=INTEGER,mode=OUT}," + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.userid,javaType=String,jdbcType=VARCHAR}," + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(3) + "#{search.getaction,javaType=String,jdbcType=VARCHAR}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + ")}" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(1);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "<update id=\"Save" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" flushCache=\"true\">" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "{call dbo.P_Save_" + txtClassName.Text + "(" + PublicTools.WriteEnter(1);

                foreach (PdmColumn c in pTable.Columns)
                {
                    if (keycolumn.IndexOf(c.ColumnCode) >= 0)
                    {
                        txtResult.Text += PublicTools.WriteTab(3) + "#{" + c.ColumnCode.ToLower() + ",javaType=" + PublicTools.GetJavaType(c.GetColType()) + ",jdbcType=" + PublicTools.GetJdbcType(c.GetColType()) + ",mode=INOUT}," + PublicTools.WriteEnter(1);
                    }
                    else
                    {
                        txtResult.Text += PublicTools.WriteTab(3) + "#{" + c.ColumnCode.ToLower() + ",javaType=" + PublicTools.GetJavaType(c.GetColType()) + ",jdbcType=" + PublicTools.GetJdbcType(c.GetColType()) + "}," + PublicTools.WriteEnter(1);
                    }
                }
                txtResult.Text += PublicTools.WriteTab(3) + "#{deal.action,javaType=int,jdbcType=INTEGER}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + ")}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "</update>" + PublicTools.WriteEnter(1);

            }
            catch (Exception ex)
            {
                Global.ShowSysInfo(ex.Message);
            }
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDB.SelectedValue.ToString().ToLower() == "select")
                {
                    Global.ShowSysInfo("请选择数据库！");
                    return;
                }

                BusHours item = new BusHours();
                item.DBID = ddlDB.SelectedValue.ToString().ToLower() == "select" ? 0 : Convert.ToInt32(ddlDB.SelectedValue);
                item.ManID = Program.ManInfo.Man.ManID;
                item.WorkEnd = DateTime.Now;
                SqlBaseProvider.SaveBusHours(item, DataProviderAction.Create);
                isHours = true;
                Global.ShowSysInfo("打卡成功！");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cbPage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPage.Checked)
            {
                cbEdit.Checked = false;
                cbInsert.Checked = false;
                cbDelete.Checked = false;
                cbEdit.Enabled = false;
                cbDelete.Enabled = false;
            }
            else
            {
                cbEdit.Checked = true;
                cbInsert.Checked = true;
                cbDelete.Checked = true;
            }
        }

        private void cbInsert_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInsert.Checked)
            {
                cbPage.Checked = false;
                cbEdit.Enabled = true;
                cbDelete.Enabled = true;
            }
            else
            {
                cbPage.Checked = true;
            }
        }

        private void GpersistCode_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            this.initForm();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void GpersistCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BusHours item = SqlBaseProvider.GetHoursByDB(Program.DBID, Program.ManInfo.Man.ManID, Program.LoginDate);
                if (item != null)
                {
                    item.DBID = Program.DBID;
                    item.WorkEnd = DateTime.Now;
                    SqlBaseProvider.SaveBusHours(item, DataProviderAction.Update);
                    Program.DBID = -1;
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
