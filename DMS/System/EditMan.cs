using GuFun.Utils;
using GuFun.WinControls;
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
    public partial class EditMan : DMS.BaseEditForm
    {
        private short ml = 0;
        public string id = String.Empty;
        public ManMan parentForm;

        public EditMan()
        {
            InitializeComponent();
            this.Text = "员工管理";
            this.mCode = "0603";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;

            ml = SqlBaseProvider.GetSetManLevel();
        }

        private void EditMan_Load(object sender, EventArgs e)
        {
            ectDept.Tree.ComboTreeType = GuFun.WinControls.ComboTreeType.All;
            ectDept.Tree.TypeText = "所有部门";
            ectDept.Tree.DataSource = SqlBaseProvider.GetSimpleValidDept();
            ectDept.Tree.DisplayMember = "Dept_Name";
            ectDept.Tree.ValueMember = "Dept_ID";
            ectDept.Tree.ParentMember = "Dept_PID";
            ectDept.Tree.Height = 200;
            ectDept.AbsoluteChildrenSelectableOnly = false;


            CtrlHelper.SetDropDownList(ddlManType, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Man_Type order by Man_Type", SqlTextType.Text, "Man_Type_Name,Man_Type"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlManTitle, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Man_Title order by Man_Title", SqlTextType.Text, "Man_Title_Name,Man_Title"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlManLevel, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Man_Level order by Man_Level", SqlTextType.Text, "Man_Level_Name,Man_Level"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlManStatus, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Man_Status order by Man_Status", SqlTextType.Text, "Man_Status_Name,Man_Status"), DropAddType.New, DropAddFlag.Select); 


            this.allCtrls = new object[] { txtManID, txtManName, txtManTele, ddlManLevel, ddlManStatus, ddlManTitle, ddlManType, ectDept };
            this.editCtrls = new object[] { txtManID };
            OnInitData();
        }

        protected override void OnInitData()
        {
            base.OnInitData();

            try
            {
                Global.EnableComboxTree(ectDept);

                if (String.IsNullOrEmpty(id))
                {
                    txtManID.Text = String.Empty;
                    txtManName.Text = String.Empty;
                    txtManTele.Text = String.Empty;
                    CtrlHelper.SelectDropDownList(ddlManLevel, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlManStatus, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlManTitle, DropAddFlag.Select.ToString());
                    CtrlHelper.SelectDropDownList(ddlManType, DropAddFlag.Select.ToString());

                    if (Program.ManInfo.Man.ManLevel >= ml)
                        ectDept.SelectValue = Program.ManInfo.Man.DeptID;
                    else
                        ectDept.Text = String.Empty;
                    this.fState = FormState.Edit;
                }
                else
                {
                    SysMan item = SqlBaseProvider.GetSysMan(id);

                    if (String.IsNullOrEmpty(item.ManID))
                        throw new Exception("未找到编号为[" + id + "]的员工信息！");

                    txtManID.Text = item.ManID;
                    txtManName.Text = item.ManName;
                    txtManTele.Text = item.ManTele;

                    CtrlHelper.SelectDropDownList(ddlManLevel, item.ManLevel.ToString());
                    CtrlHelper.SelectDropDownList(ddlManStatus, item.ManStatus.ToString());
                    CtrlHelper.SelectDropDownList(ddlManTitle, item.ManTitle.ToString());
                    CtrlHelper.SelectDropDownList(ddlManType, item.ManType.ToString());
                    ectDept.SelectValue = item.DeptID;

                    int mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);


                    if (!CoreCtrls.CheckAuth(mAuth, AuthType.Edit))
                    {
                        this.OnDisplayAllCtrls(false);
                        Global.DisableComboxTree(ectDept);
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

                if (Program.ManInfo.Man.ManLevel >= ml)
                    Global.DisableComboxTree(ectDept);
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
                this.OnDisplayAllCtrls(false);
                Global.DisableComboxTree(ectDept);
                tsbCancel.Visible = false;
                tsbSave.Visible = false;
                tsbEdit.Visible = false;
                this.fState = FormState.Detail;
            }
        }

        protected override bool OnBeforeSave()
        {
            if (String.IsNullOrEmpty(txtManID.Text))
            {
                Global.ShowSysInfo("员工工号不能为空！");
                return false;
            }

            if (String.IsNullOrEmpty(txtManName.Text))
            {
                Global.ShowSysInfo("员工姓名不能为空！");
                return false;
            }

            if (ddlManLevel.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择员工级别！");
                return false;
            }

            if (ddlManType.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择员工岗位！");
                return false;
            }

            if (ddlManTitle.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择员工职务！");
                return false;
            }

            if (ddlManStatus.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择员工状态！");
                return false;
            }

            if (String.IsNullOrEmpty(ectDept.SelectValue) || (ectDept.SelectValue == ComboTreeType.All.ToString()))
            {
                Global.ShowSysInfo("请选择员工所属部门！");
                return false;
            }

            return true;
        }

        protected override bool OnSaveData()
        {

            try
            {
                SysMan item = new SysMan();

                item.ManID = txtManID.Text;
                item.ManName = txtManName.Text;
                item.CoID = Program.ManInfo.Man.CoID;
                item.DeptID = ectDept.SelectValue;
                item.ManType = Convert.ToInt16(ddlManType.SelectedValue);
                item.CrtDate = DateTime.Now;
                item.CrtOper = Program.ManInfo.Man.ManID;
                item.ManTele = txtManTele.Text;
                item.ManDate = DateTime.Now;
                item.ManLevel = Convert.ToInt16(ddlManLevel.SelectedValue);
                item.ManTitle = Convert.ToInt16(ddlManTitle.SelectedValue);
                item.ManSex = 1;
                item.ManStatus = Convert.ToInt16(ddlManStatus.SelectedValue);
                item.OperPassword = Crypto.MD5Crypto(txtManID.Text);
                item.OperSerial = 1;
                item.WorkDate = DateTime.Now.ToString("yyyyMMdd");
                item.PreWorkDate = item.WorkDate;

                if (String.IsNullOrEmpty(id))
                {
                    SqlBaseProvider.SaveSysMan(item, DataProviderAction.Create);
                    id = item.ManID;
                }
                else
                {
                    SqlBaseProvider.SaveSysMan(item, DataProviderAction.Update);
                }

                this.OnDisplayAllCtrls(false);
                Global.DisableComboxTree(ectDept);
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


    }
}
