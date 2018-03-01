using GuFun.Utils;
using GuFun.WinCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class EditProject : DMS.BaseEditForm
    {
        private short ml = 0;
        public string id = String.Empty;
        public ManProject parentForm;

        public EditProject()
        {
            InitializeComponent();

            this.Text = "员工管理";
            this.mCode = "0401";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;

            ml = SqlBaseProvider.GetSetManLevel();
        }

        private void EditProject_Load(object sender, EventArgs e)
        {
            CtrlHelper.SetDropDownList(ddlProjectType, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Project_Type order by ProjectType", SqlTextType.Text, "ProjectTypeName,ProjectType"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlWorkUnit, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Work_Unit order by WorkUnit", SqlTextType.Text, "WorkUnitName,WorkUnit"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlProjectManager, CoreCtrls.GetComboBoxItems("select b.Man_ID, b.Man_Name from T_Sys_Oper_Role a, T_Sys_Man b where a.Man_ID = b.Man_ID and  a.Role_ID = '1'", SqlTextType.Text, "Man_Name,Man_ID"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlProjectStatus, CoreCtrls.GetComboBoxItems("Select ProjectStatus, ProjectStatusName from T_Pmt_Project_Status order by ProjectStatus", SqlTextType.Text, "ProjectStatusName,ProjectStatus"), DropAddType.New, DropAddFlag.Select);
            this.allCtrls = new object[] { txtProjectCode, txtProjectName, ddlProjectType, ddlProjectStatus, ddlProjectManager, txtWorkDate, ddlWorkUnit, txtProjectDesc };
            this.editCtrls = new object[] { };
            OnInitData(); 
        }

        protected override bool OnSaveData()
        {
            try
            {
                BusProject item = new BusProject();
                item.ProjectID = id;
                item.ProjectCode = txtProjectCode.Text;
                item.ProjectName = txtProjectName.Text;
                item.ProjectType = ddlProjectType.SelectedValue.ToString();
                item.ProjectStatus = ddlProjectStatus.SelectedValue.ToString();
                item.ProjectManager = ddlProjectManager.SelectedValue.ToString();
                item.WorkDate = Double.Parse(txtWorkDate.Text);
                item.WorkUnit = ddlWorkUnit.SelectedValue.ToString();
                item.ProjectDesc = txtProjectDesc.Text;
                item.TranDate = DateTime.Now;
                item.TranUser = Program.ManInfo.Man.ManID;
                if (String.IsNullOrEmpty(id))
                {
                    SqlBaseProvider.SaveBusProject(item, DataProviderAction.Create);
                    id = item.ProjectID;
                }
                else
                {
                    SqlBaseProvider.SaveBusProject(item, DataProviderAction.Update);
                }
                this.OnDisplayAllCtrls(false);
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
                fState = FormState.Detail;
                if (parentForm != null)
                {
                    parentForm.RefreshForm();
                }
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
                return false;
            }

            return true;
        }

        protected override void OnInitData()
        {
            base.OnInitData();
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    id = String.Empty;
                    txtProjectCode.Text = String.Empty;
                    txtProjectName.Text = String.Empty;
                    txtProjectDesc.Text = String.Empty;
                    txtWorkDate.Text = String.Empty;
                    CtrlHelper.SelectDropDownList(ddlProjectType, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlProjectStatus, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlProjectManager, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlWorkUnit, DropAddFlag.Select.ToString());
                }
                else
                {
                    BusProject item = SqlBaseProvider.GetBusProject(id);

                    if (String.IsNullOrEmpty(item.ProjectID))
                        throw new Exception("未找到编号为[" + id + "]的员工信息！");

                    id = item.ProjectID;
                    txtProjectCode.Text = item.ProjectCode;
                    txtProjectName.Text = item.ProjectName;
                    txtWorkDate.Text = item.WorkDate.ToString();
                    txtProjectDesc.Text = item.ProjectDesc;

                    CtrlHelper.SelectDropDownList(ddlProjectManager, item.ProjectManager.ToString());
                    CtrlHelper.SelectDropDownList(ddlProjectType, item.ProjectType.ToString());
                    CtrlHelper.SelectDropDownList(ddlProjectStatus, item.ProjectStatus.ToString());
                    CtrlHelper.SelectDropDownList(ddlWorkUnit, item.WorkUnit.ToString());

                    int mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);


                    if (!CoreCtrls.CheckAuth(mAuth, AuthType.Edit))
                    {
                        this.OnDisplayAllCtrls(false);
                        tsbCancel.Visible = false;
                        tsbSave.Visible = false;
                        tsbEdit.Visible = false;
                        this.fState = FormState.Detail;
                    }
                    else
                    {
                        this.OnDisplayEditCtrls(false);
                        this.fState = FormState.Edit;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
    }
}
