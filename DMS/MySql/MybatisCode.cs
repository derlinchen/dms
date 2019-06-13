using Utils;
using Utils.Enumerations;
using WinCore;
using WinCore.Pdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DMS.MySql
{
    public partial class MybatisCode : DMS.BaseDialogForm
    {
        private PdmTable pTable;
        public string keycolumn = String.Empty;
        public PdmColumn keyCol = new PdmColumn();
        private bool isHours = false;

        private string[] Prefix = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public MybatisCode()
        {
            InitializeComponent();
            this.initForm();
        }

        private void initForm()
        {
            CtrlHelper.SetDropDownList(ddlDB, SqlBaseProvider.GetDBForCombox(Convert.ToInt32(DataBaseType.MySql)), DropAddType.New, DropAddFlag.Select, String.Empty, "DBName,DBID");
            ddlDB.SelectedValueChanged += new EventHandler(ddlDB_SelectedIndexChanged);
            pTable = new PdmTable();
        }

        private void ddlDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dbid = ddlDB.SelectedValue.ToString().ToLower() == "select" ? 0 : Convert.ToInt32(ddlDB.SelectedValue);
            string manid = Program.ManInfo.Man.ManID;
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

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (ddlDB.SelectedValue.ToString().ToLower() == "select")
            {
                Global.ShowSysInfo("请选择数据库！");
                return;
            }

            if (ddlTable.SelectedValue.ToString().ToLower() == "select")
            {
                Global.ShowSysInfo("请选择数据表！");
                return;
            }

            try
            {
                DataTable tabels = SqlBaseProvider.GetColumnByTable(Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());
                SqlBaseProvider.GetTableByCode(pTable, Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());

                txtSet.Text = pTable.TableSet;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveConfig())
            {
                Global.ShowSysInfo("配置信息保存成功！");
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

                string tablename = pTable.TableName.Substring(pTable.TableName.IndexOf('-') + 1).Replace("参数", "").Replace("表", "");
                txtResult.Text += PublicTools.WriteTab(0) + "@ApiModel(value=\"" + txtClassName.Text + "\", description=\"" + tablename + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "public class " + txtClassName.Text + "{" + PublicTools.WriteEnter(2);

                foreach (ColumnTable c in pColumnTables)
                {
                    string example = "";
                    if (PublicTools.GetJavaType(c.GetColType()).Equals("int"))
                    {
                        example = ", example=\"0\"";
                    }
                    txtResult.Text += PublicTools.WriteTab(1) + "@ApiModelProperty(value=\"" + c.ColumnName.ToLower() + "\""+ example + ")" + PublicTools.WriteEnter(1);
                    string propertyname = "";
                    string[] columns = c.DisplayColumn.Split('_');
                    for(int i = 0; i < columns.Length; i++)
                    {
                        propertyname += columns[i].Substring(0,1).ToUpper() + columns[i].Substring(1).ToLower();
                    }
                    propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "private " + PublicTools.GetJavaType(c.GetColType()) + " " + propertyname + ";" + PublicTools.WriteEnter(2);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + "() {" + PublicTools.WriteEnter(1);

                foreach (ColumnTable c in pColumnTables)
                {
                    string propertyname = "";
                    string[] columns = c.DisplayColumn.Split('_');
                    for (int i = 0; i < columns.Length; i++)
                    {
                        propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                    }
                    propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "this." + propertyname + " = " + PublicTools.GetInitType(c.GetColType()) + ";" + PublicTools.WriteEnter(1);
                }

                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                foreach (ColumnTable c in pColumnTables)
                {
                    string propertyname = "";
                    string[] columns = c.DisplayColumn.Split('_');
                    for (int i = 0; i < columns.Length; i++)
                    {
                        propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                    }
                    propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "public " + PublicTools.GetJavaType(c.GetColType()) + " get" + propertyname.Substring(0, 1).ToUpper() + propertyname.Substring(1) + "() {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "return " + propertyname + ";" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                    txtResult.Text += PublicTools.WriteTab(1) + "public void set" + propertyname.Substring(0, 1).ToUpper() + propertyname.Substring(1) + "(" + PublicTools.GetJavaType(c.GetColType()) + " " + propertyname + ") {" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(2) + "this." + propertyname + "=" + propertyname + ";" + PublicTools.WriteEnter(1);
                    txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);
                }
                txtResult.Text += "}" + PublicTools.WriteEnter(2);
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

                txtResult.Text = "@Mapper" + PublicTools.WriteEnter(1);
                txtResult.Text += "public interface " + txtPrefix.Text.Trim() + "Mapper {" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + " get" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> get" + txtClassName.Text + "List(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> search" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void save" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void delete" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "public void update" + txtClassName.Text + "(" + txtClassName.Text + " item);" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
                txtResult.Text += "}" + PublicTools.WriteEnter(1);
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


                txtResult.Text = "@Service" + PublicTools.WriteEnter(1);
                txtResult.Text += "public class " + txtPrefix.Text.Trim() + "Service {" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "@Autowired" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "private " + txtPrefix.Text.Trim() + "Mapper " + txtCatalog.Text.Trim() + "mapper;" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + " get" + txtClassName.Text + "("+txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "mapper.get" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> get" + txtClassName.Text + "List(" + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "mapper.get" + txtClassName.Text + "List(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                txtResult.Text += PublicTools.WriteTab(1) + "public PageInfo<" + txtClassName.Text + "> search" + txtClassName.Text + "(PageSearch<" + txtClassName.Text + "> item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "PageHelper.offsetPage(item.getPageNum(), item.getPageSize());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "List<" + txtClassName.Text + "> lists = " + txtCatalog.Text.Trim() + "mapper.search" + txtClassName.Text + "(item.getItem());" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "PageInfo<" + txtClassName.Text + "> pageInfo = new PageInfo<" + txtClassName.Text + ">(lists);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return pageInfo;" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "public ReturnValue save" + txtClassName.Text + "(" + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "ReturnValue rtv = new ReturnValue();" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "try {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + txtCatalog.Text.Trim() + "mapper.save" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "} catch (Exception e) {" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(3) + "rtv.setSuccess(false);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(3) + "rtv.setMsg(\"保存失败\");" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "}" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return rtv;" + PublicTools.WriteEnter(1);

                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(1);

                txtResult.Text += "}" + PublicTools.WriteEnter(2);
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

                txtResult.Text = "@Api(tags = \"" + tablename + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += "@RestController" + PublicTools.WriteEnter(1);
                txtResult.Text += "@RequestMapping(value = \"/" + txtCatalog.Text.Trim() + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += "public class " + txtPrefix.Text.Trim() + "Controller {" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "@Autowired" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "private " + txtPrefix.Text.Trim() + "Service " + txtCatalog.Text.Trim() + "service;" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "// region " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
                txtResult.Text += PublicTools.WriteTab(1) + "@ApiOperation(value=\"获取单条" + tablename + "信息\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@GetMapping(value=\"/get" + txtClassName.Text + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@ResponseBody" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public " + txtClassName.Text + " get" + txtClassName.Text + "(@ApiParam(required=true, name=\"item\",value=\"" + tablename + "信息\") " + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "service.get" + txtClassName.Text +"(item);"+ PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@ApiOperation(value=\"获取" + tablename + "列表\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@GetMapping(value=\"/get" + txtClassName.Text + "List\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@ResponseBody" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public List<" + txtClassName.Text + "> get" + txtClassName.Text + "List(@ApiParam(required=true, name=\"item\",value=\"" + tablename + "信息\") " + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "service.get" + txtClassName.Text + "List(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "@ApiOperation(value=\"获取分页" + tablename + "列表\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@PostMapping(value=\"/search" + txtClassName.Text + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@ResponseBody" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public PageInfo<" + txtClassName.Text + "> search" + txtClassName.Text + "(@ApiParam(required=true, name=\"item\",value=\"查询" + tablename + "条件\") @RequestBody PageSearch<" + txtClassName.Text + "> item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "service.search" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);


                txtResult.Text += PublicTools.WriteTab(1) + "@ApiOperation(value=\"保存" + tablename + "列表信息\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@PostMapping(value=\"/save" + txtClassName.Text + "\")" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "@ResponseBody" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "public ReturnValue save" + txtClassName.Text + "(@ApiParam(required=true, name=\"item\",value=\"" + tablename + "信息\") @RequestBody " + txtClassName.Text + " item) {" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(2) + "return " + txtCatalog.Text.Trim() + "service.save" + txtClassName.Text + "(item);" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(1) + "}" + PublicTools.WriteEnter(2);

                txtResult.Text += PublicTools.WriteTab(1) + "// endregion " + txtClassName.Text + " Methods" + PublicTools.WriteEnter(2);
                txtResult.Text += "}" + PublicTools.WriteEnter(1);

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

                string package = "com." + txtPackage.Text;
                string packageclass = package + ".entity";
                string propertyname = "";
                string[] columns = null;
                if (!String.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    packageclass += "." + txtCatalog.Text.Trim().ToLower();
                packageclass += "." + txtClassName.Text;

                string packagemapper = package + ".mapper." + txtCatalog.Text + "." +txtPrefix.Text + "Mapper";

                List<ColumnTable> pColumnTables = SqlBaseProvider.GetColumnTable(pTable.DBID, pTable.TableCode);
                string othersql = String.Empty;
                bool hasColumn = false;

                txtResult.Text = PublicTools.WriteTab(0) + "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "<!DOCTYPE mapper PUBLIC \" -//mybatis.org//DTD Mapper 3.0//EN\" \"http://mybatis.org/dtd/mybatis-3-mapper.dtd\" >" + PublicTools.WriteEnter(1);
                txtResult.Text += PublicTools.WriteTab(0) + "<mapper namespace=\"" + packagemapper + "\" >" + PublicTools.WriteEnter(2);

                string code = PublicTools.WriteTab(1) + "<resultMap id=\"BaseResultMap\" type=\""+ packageclass + "\" >" + PublicTools.WriteEnter(1);
                foreach (ColumnTable item in pColumnTables)
                {
                    propertyname = "";
                    columns = item.ColumnCode.Split('_');
                    for (int i = 0; i < columns.Length; i++)
                    {
                        propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                    }
                    propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);

                    if (item.ColumnCode.Equals(keycolumn))
                    {
                        code += PublicTools.WriteTab(2) + "<id column=\""+ item.ColumnCode + "\" property=\""+ propertyname + "\" jdbcType=\""+ PublicTools.GetJdbcType(item.GetColType()) + "\" />" + PublicTools.WriteEnter(1);
                    }
                    else
                    {
                        code += PublicTools.WriteTab(2) + "<result column=\"" + item.ColumnCode + "\" property=\"" + propertyname + "\" jdbcType=\"" + PublicTools.GetJdbcType(item.GetColType()) + "\" />" + PublicTools.WriteEnter(1);
                    }

                }
                code += PublicTools.WriteTab(1) + "</resultMap>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;



                code = PublicTools.WriteTab(1) + "<select id=\"get" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultMap=\"BaseResultMap\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "select a.*";
                hasColumn = false;

                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix != "a")
                    {
                        code += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                        hasColumn = true;
                    }
                }
                code += " " + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(3) + "from ";
                hasColumn = false;
                string tablename = "";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (tablename.IndexOf(item.RelaTable.ToLower()) < 0)
                    {
                        tablename += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                        hasColumn = true;
                    }
                }
                code += tablename;
                code = code.Substring(0, code.Length - 2);
                code += PublicTools.WriteEnter(1);
                columns = keycolumn.Split('_');
                propertyname = "";
                for (int i = 0; i < columns.Length; i++)
                {
                    propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                }
                propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                code += PublicTools.WriteTab(3) + "where a." + keycolumn.ToLower() + "=" + "#{" + propertyname + "}";
                hasColumn = false;
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.TableCode == item.RelaTable)
                        continue;

                    if (code.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                    {
                        code += " and a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                        hasColumn = true;
                    }
                }
                if (hasColumn)
                {
                    code = code.Substring(0, code.Length - 5);
                }
                code += PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(3) + "order by a." + keycolumn.ToLower() + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;

                code = PublicTools.WriteTab(1) + "<select id=\"get" + txtClassName.Text + "List\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultMap=\"BaseResultMap\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "select a.*";
                hasColumn = false;
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix != "a")
                    {
                        code += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                        hasColumn = true;
                    }
                }
                code  += " " + PublicTools.WriteEnter(1);

                code  += PublicTools.WriteTab(3) + "from ";
                hasColumn = false;
                tablename = "";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (tablename.IndexOf(item.RelaTable.ToLower()) < 0)
                    {
                        tablename += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                        hasColumn = true;
                    }
                }
                code += tablename;
                code = code.Substring(0, code.Length - 2);
                code += PublicTools.WriteEnter(1);

                code += PublicTools.WriteTab(3) + "where ";
                hasColumn = false;
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.TableCode == item.RelaTable)
                        continue;

                    if (code.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                    {
                        code += "a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                        hasColumn = true;
                    }
                }
                if (hasColumn)
                    code = code.Substring(0, code.Length - 5) + PublicTools.WriteEnter(1);
                else
                    code = code.Substring(0, code.Length - 9);
                code += PublicTools.WriteTab(3) + "order by a." + keycolumn.ToLower() + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;


                code = PublicTools.WriteTab(1) + "<select id=\"search" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" resultMap=\"BaseResultMap\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "select a.*";
                hasColumn = false;
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix != "a")
                    {
                        code += ", " + item.Prefix.ToLower() + "." + item.DisplayColumn.ToLower();
                        hasColumn = true;
                    }
                }
                code += " " + PublicTools.WriteEnter(1);

                code += PublicTools.WriteTab(3) + "from ";
                hasColumn = false;
                tablename = "";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (tablename.IndexOf(item.RelaTable.ToLower()) < 0)
                    {
                        tablename += item.RelaTable.ToLower() + " " + item.Prefix.ToLower() + ", ";
                        hasColumn = true;
                    }
                }
                code += tablename;
                code = code.Substring(0, code.Length - 2);
                code += PublicTools.WriteEnter(1);

                code += PublicTools.WriteTab(3) + "where ";
                hasColumn = false;
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.TableCode == item.RelaTable)
                        continue;

                    if (code.IndexOf("a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower()) < 0)
                    {
                        code += "a." + item.ColumnCode.ToLower() + " = " + item.Prefix.ToLower() + "." + item.RelaColumn.ToLower() + " and ";
                        hasColumn = true;
                    }
                }
                if (hasColumn)
                {
                    code = code.Substring(0, code.Length - 5) + PublicTools.WriteEnter(1);
                }
                else
                {
                    code = code.Substring(0, code.Length - 10);
                    code += PublicTools.WriteTab(3) + "where 1 = 1" + PublicTools.WriteEnter(1);
                }

                columns = keycolumn.Split('_');
                propertyname = "";
                for (int i = 0; i < columns.Length; i++)
                {
                    propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                }
                propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);

                code += PublicTools.WriteTab(3) + "<if test=\"" + propertyname + " != null and " + propertyname + " != ''\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(3) + "and a." + keycolumn.ToLower() + "=" + "#{" + propertyname + "}" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(3) + "</if>" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</select>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;


                code = PublicTools.WriteTab(1) + "<insert id=\"save" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" flushCache=\"true\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "insert into " + pTable.TableCode.ToLower() + "(";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix == "a")
                        code += item.DisplayColumn.ToLower() + ", ";
                }
                code = code.Substring(0, code.Length - 2);

                code += ")" + PublicTools.WriteEnter(1) + PublicTools.WriteTab(3) + "values (";
                foreach (ColumnTable item in pColumnTables)
                {
                    if (item.Prefix == "a")
                    {
                        propertyname = "";
                        columns = item.DisplayColumn.Split('_');
                        for (int i = 0; i < columns.Length; i++)
                        {
                            propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                        }
                        propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                        code += "#{" + propertyname + "}, ";
                    }
                }
                code = code.Substring(0, code.Length - 2) + ");";
                code += PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</insert>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;

                code = PublicTools.WriteTab(1) + "<delete id=\"delete" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" flushCache=\"true\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "delete from " + pTable.TableCode.ToLower() + PublicTools.WriteEnter(1);
                columns = keycolumn.Split('_');
                propertyname = "";
                for (int i = 0; i < columns.Length; i++)
                {
                    propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                }
                propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                code += PublicTools.WriteTab(3) + "where " + keycolumn.ToLower() + "=" + "#{" + propertyname + "};" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</delete>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;


                code = PublicTools.WriteTab(1) + "<update id=\"update" + txtClassName.Text + "\" statementType=\"CALLABLE\" parameterType=\"" + packageclass + "\" flushCache=\"true\">" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(2) + "update " + pTable.TableCode.ToLower() + " set";
                foreach (ColumnTable item in pColumnTables)
                {
                    if ((item.Prefix == "a") && (item.DisplayColumn != keycolumn))
                    {
                        propertyname = "";
                        columns = item.DisplayColumn.Split('_');
                        for (int i = 0; i < columns.Length; i++)
                        {
                            propertyname += columns[i].Substring(0, 1).ToUpper() + columns[i].Substring(1).ToLower();
                        }
                        propertyname = propertyname.Substring(0, 1).ToLower() + propertyname.Substring(1);
                        code += PublicTools.WriteEnter(1) + PublicTools.WriteTab(3) + item.DisplayColumn.ToLower() + " = #{" + propertyname + "},";
                    }
                }
                code = code.Substring(0, code.Length - 1) + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(3) + "where " + keycolumn.ToLower() + " = #{" + keycolumn.ToLower() + "};" + PublicTools.WriteEnter(1);
                code += PublicTools.WriteTab(1) + "</update>" + PublicTools.WriteEnter(2);
                txtResult.Text += code;

                txtResult.Text += PublicTools.WriteTab(0) + "</mapper>" + PublicTools.WriteEnter(1);
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

       

        private void MybatisCode_Load(object sender, EventArgs e)
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

        private void MybatisCode_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ddlTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable columns = SqlBaseProvider.GetColumnByTable(Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());

                SqlBaseProvider.GetTableByCode(pTable, Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());
                PdmKeyColumn pkc = SqlBaseProvider.GetKeyColumn(Convert.ToInt32(ddlDB.SelectedValue), ddlTable.SelectedValue.ToString());
                txtPackage.Text = Program.ProjectCode;
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
                    if(table.IndexOf("T_") >= 0)
                    {
                        string[] tables = table.Split('_');

                        for (int i = 1; i < tables.Length; i++)
                        {
                            tablename += tables[i];
                        }
                        txtPrefix.Text = tables[1];
                        txtCatalog.Text = tables[1].ToLower();
                        txtClassName.Text = tablename;
                        txtValue.Text = tablename.ToLower();

                        
                    }
                    else
                    {
                        string[] tables = table.Split('_');
                        for (int i = 0; i < tables.Length; i++)
                        {
                            tablename += tables[i].Substring(0, 1).ToUpper() + tables[i].Substring(1).ToLower();
                        }

                        txtPrefix.Text = tables[0].Substring(0, 1).ToUpper() + tables[0].Substring(1).ToLower();
                        txtCatalog.Text = tables[0].ToLower();
                        txtClassName.Text = tablename;
                        txtValue.Text = tablename.ToLower();

                    }

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

    }
}
