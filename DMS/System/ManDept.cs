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
    public partial class ManDept : DMS.BaseForm
    {
        public FormState fState = FormState.List;
        public string mCode = String.Empty;
        public int mAuth = 0;
        public object[] allCtrls;
        public object[] editCtrls;
        public object[] newCtrls;
        private bool isRefresh = false;

        public ManDept()
        {
            InitializeComponent();
            tsMain.Renderer = new Office2007Renderer();
            tsMain.ImageList = ilTools;
            tsbExit.ImageIndex = 0;
            tsbRefresh.ImageIndex = 1;
            tsbAdd.ImageIndex = 2;
            tsbAddChild.ImageIndex = 2;
            tsbEdit.ImageIndex = 3;
            tsbSave.ImageIndex = 4;
            tsbCancel.ImageIndex = 5;
            btnMan.BackColor = SystemColors.Control;

            this.allCtrls = new object[] { txtDeptShort, txtDeptAddress, txtDeptEMail, txtDeptFax, txtDeptID, txtDeptMan, txtDeptName, txtDeptPID, txtDeptPost, txtDeptTele, txtSortOrder, ddlCoID, ddlDeptLevel, ddlDeptType, btnMan, ddlDeptStatus };
            this.editCtrls = new object[] { txtDeptID, txtDeptPID, ddlCoID };
            this.newCtrls = new object[] { txtDeptPID, ddlCoID };
            txtDeptMan.ReadOnly = true;
            this.mCode = "0602";
        }

        private void ManDept_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                OnInitAuth();

            CtrlHelper.SetDropDownList(ddlDeptStatus, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Dept_Status order by Dept_Status", SqlTextType.Text, "Dept_Status_Name,Dept_Status"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlDeptType, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Dept_Type order by Dept_Type", SqlTextType.Text, "Dept_Type_Name,Dept_Type"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlDeptLevel, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Dept_Level order by Dept_Level", SqlTextType.Text, "Dept_Level_Name,Dept_Level"), DropAddType.New, DropAddFlag.Select);
            CtrlHelper.SetDropDownList(ddlCoID, CoreCtrls.GetComboBoxItems("Select * from T_Sys_Company order by Co_ID", SqlTextType.Text, "Co_Name,Co_ID"), DropAddType.New, DropAddFlag.Select); 

            OnBindData();
            OnInitData();
            CtrlHelper.DisableCtrls(allCtrls);
            tsbCancel.Visible = false;
            tsbSave.Visible = false;
        }

        private void OnInitAuth()
        {
            mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.New))
            {
                tsbAdd.Visible = false;
                tsbAddChild.Visible = false;
            }

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Edit))
                tsbEdit.Visible = false;

            if (!(CoreCtrls.CheckAuth(mAuth, AuthType.New) || CoreCtrls.CheckAuth(mAuth, AuthType.Edit)))
            {
                tssModify.Visible = false;
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
            }
        }

        protected void OnBindData()
        {
            tvDept.ComboTreeType = GuFun.WinControls.ComboTreeType.None;
            tvDept.DataSource = SqlBaseProvider.SelectSysDept(true);
            tvDept.DisplayMember = "Dept_Name";
            tvDept.ValueMember = "Dept_ID";
            tvDept.ParentMember = "Dept_PID";
            tvDept.ExpandAll();

            if (isRefresh)
            {
                TreeNode[] tns = tvDept.Nodes.Find(txtDeptID.Text, true);
                if (tns.Length > 0)
                {
                    tvDept.SelectedNode = tns[0];
                }
            }
        }

        protected void OnInitData()
        {
            txtDeptAddress.Text = String.Empty;
            txtDeptEMail.Text = String.Empty;
            txtDeptFax.Text = String.Empty;
            txtDeptID.Text = String.Empty;
            txtDeptMan.Text = String.Empty;
            txtDeptName.Text = String.Empty;
            txtDeptPID.Text = String.Empty;
            txtDeptPost.Text = String.Empty;
            txtDeptTele.Text = String.Empty;
            txtSortOrder.Text = String.Empty;
            txtDeptShort.Text = String.Empty;

            CtrlHelper.SelectDropDownList(ddlCoID, DropAddFlag.Select.ToString());
            CtrlHelper.SelectDropDownList(ddlDeptType, DropAddFlag.Select.ToString());
            CtrlHelper.SelectDropDownList(ddlDeptLevel, DropAddFlag.Select.ToString());
            CtrlHelper.SelectDropDownList(ddlDeptStatus, DropAddFlag.Select.ToString());
        }

        private void ManDept_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((fState == FormState.Edit) || (fState == FormState.New))
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，是否继续退出？", PublicConsts.PC_Tip, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    e.Cancel = true;
            }
        }

        private bool IsCancelModify()
        {
            if ((fState == FormState.Edit) || (fState == FormState.New))
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，当前操作将会放弃正在编辑的数据？", "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    return false;
            }

            fState = FormState.List;

            return true;
        }

        protected void OnLoadData()
        {
            try
            {
                SysDept sd = SqlBaseProvider.GetSysDept(tvDept.SelectedValue.ToString());

                txtDeptID.Text = sd.DeptID;
                txtDeptPID.Text = sd.DeptPID;
                txtDeptAddress.Text = sd.DeptAddress;
                txtDeptName.Text = sd.DeptName;
                if (!String.IsNullOrEmpty(sd.DeptMan))
                {
                    txtDeptMan.CodeText = sd.DeptMan;
                    SysMan sm = SqlBaseProvider.GetSysMan(sd.DeptMan);
                    txtDeptMan.NameText = sm.ManName;
                }
                else
                {
                    txtDeptMan.CodeText = String.Empty;
                    txtDeptMan.NameText = String.Empty;
                }
                txtDeptEMail.Text = sd.DeptEMail;
                txtDeptFax.Text = sd.DeptFax;
                txtDeptPost.Text = sd.DeptPost;
                txtDeptTele.Text = sd.DeptTele;
                txtSortOrder.Text = sd.SortOrder.ToString();
                txtDeptShort.Text = sd.DeptShort;

                CtrlHelper.SelectDropDownList(ddlCoID, sd.CoID);
                CtrlHelper.SelectDropDownList(ddlDeptType, sd.DeptType.ToString());
                CtrlHelper.SelectDropDownList(ddlDeptStatus, sd.DeptStatus.ToString());
                CtrlHelper.SelectDropDownList(ddlDeptLevel, sd.DeptLevel.ToString());
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isRefresh)
            {
                isRefresh = false;
                return;
            }

            if (!String.IsNullOrEmpty(tvDept.SelectedValue.ToString()))
            {
                string deptid = tvDept.SelectedValue.ToString();

                if ((fState == FormState.List) && (deptid == txtDeptID.Text))
                    return;

                if (IsCancelModify())
                {
                    OnLoadData();
                    CtrlHelper.DisableCtrls(allCtrls);
                    fState = FormState.List;
                }
            }
        }


        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tvDept.SelectedValue.ToString()))
                {
                    OnInitData();
                    CtrlHelper.EnableCtrls(allCtrls);
                    CtrlHelper.DisableCtrls(newCtrls);

                    SysDept sd = SqlBaseProvider.GetSysDept(tvDept.SelectedValue.ToString());
                    CtrlHelper.SelectDropDownList(ddlCoID, sd.CoID);
                    if (sd.DeptID != sd.DeptPID)
                        txtDeptPID.Text = sd.DeptPID;
                    fState = FormState.New;

                    tsbSave.Visible = true;
                    tsbCancel.Visible = true;
                }
                else
                    Global.ShowSysInfo("请选择需要增加同级部门的相关部门！");
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }

        private void tsbAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tvDept.SelectedValue.ToString()))
                {
                    OnInitData();
                    CtrlHelper.EnableCtrls(allCtrls);
                    CtrlHelper.DisableCtrls(newCtrls);

                    SysDept sd = SqlBaseProvider.GetSysDept(tvDept.SelectedValue.ToString());
                    CtrlHelper.SelectDropDownList(ddlCoID, sd.CoID);
                    txtDeptPID.Text = sd.DeptID;
                    fState = FormState.New;

                    tsbSave.Visible = true;
                    tsbCancel.Visible = true;
                }
                else
                    Global.ShowSysInfo("请选择需要增加同级部门的相关部门！");
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }

        //private void btnMan_Click(object sender, EventArgs e)
        //{
        //    SelectMan sm = new SelectMan();

        //    DialogResult dr = sm.ShowDialog();
        //    if (dr == DialogResult.OK)
        //    {
        //        string[] mans = sm.SelectValue.Split('|');
        //        if (mans.Length == 2)
        //        {
        //            txtDeptMan.NameText = mans[1];
        //            txtDeptMan.CodeText = mans[0];
        //        }
        //    }
        //}

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            fState = FormState.List;

            OnLoadData();
            CtrlHelper.DisableCtrls(allCtrls);
            tsbSave.Visible = false;
            tsbCancel.Visible = false;
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDeptID.Text))
            {
                OnLoadData();
            }

            if (!String.IsNullOrEmpty(txtDeptID.Text))
            {
                CtrlHelper.EnableCtrls(allCtrls);
                CtrlHelper.DisableCtrls(editCtrls);

                fState = FormState.Edit;

                tsbSave.Visible = true;
                tsbCancel.Visible = true;
            }
        }

        protected bool OnBeforeSave()
        {
            if (String.IsNullOrEmpty(txtDeptID.Text))
            {
                Global.ShowSysInfo("部门编号不能为空！");
                return false;
            }

            if (String.IsNullOrEmpty(txtDeptName.Text))
            {
                Global.ShowSysInfo("部门名称不能为空！");
                return false;
            }

            if (ddlDeptStatus.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择部门状态！");
                return false;
            }

            if (ddlDeptLevel.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择部门级别！");
                return false;
            }

            if (ddlCoID.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择所属公司！");
                return false;
            }

            if (ddlDeptType.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择部门类型！");
                return false;
            }

            if (!Publics.CheckInt16(txtSortOrder.Text))
            {
                Global.ShowSysInfo("排序序号不能为空，且必须为数字！");
                return false;
            }

            if (String.IsNullOrEmpty(txtDeptShort.Text))
            {
                Global.ShowSysInfo("部门简称不能为空！");
                return false;
            }

            return true;
        }
        protected bool OnSaveData()
        {
            try
            {
                if (!OnBeforeSave())
                    return false;

                SysDept sd = new SysDept();

                sd.DeptID = txtDeptID.Text;
                if (!String.IsNullOrEmpty(txtDeptPID.Text))
                    sd.DeptPID = txtDeptPID.Text;
                else
                    sd.DeptPID = sd.DeptID;
                sd.DeptName = txtDeptName.Text;
                sd.DeptAddress = txtDeptAddress.Text;
                sd.CoID = ddlCoID.SelectedValue.ToString();
                sd.CrtDate = DateTime.Now;
                sd.DeptPost = txtDeptPost.Text;
                sd.DeptTele = txtDeptTele.Text;
                sd.DeptFax = txtDeptFax.Text;
                sd.DeptEMail = txtDeptEMail.Text;
                sd.DeptMan = txtDeptMan.CodeText;
                sd.DeptLevel = Convert.ToInt16(ddlDeptLevel.SelectedValue); ;
                sd.DeptType = Convert.ToInt16(ddlDeptType.SelectedValue);
                sd.DeptStatus = Convert.ToInt16(ddlDeptStatus.SelectedValue);
                sd.DeptShort = txtDeptShort.Text;

                if (sd.DeptID == sd.DeptPID)
                    sd.DeptDepth = 1;
                else
                {
                    SysDept pid = SqlBaseProvider.GetSysDept(sd.DeptPID);
                    sd.DeptDepth = Convert.ToInt16(pid.DeptDepth + 1);
                }

                sd.SortOrder = Convert.ToInt16(txtSortOrder.Text);
                sd.AuthDept = sd.DeptID;

                if (fState == FormState.New)
                    SqlBaseProvider.SaveSysDept(sd, DataProviderAction.Create);
                else
                    SqlBaseProvider.SaveSysDept(sd, DataProviderAction.Update);

                fState = FormState.List;
                isRefresh = true;
                OnBindData();
                CtrlHelper.DisableCtrls(allCtrls);
                tsbSave.Visible = false;
                tsbCancel.Visible = false;

                return true;
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }

            return false;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            OnSaveData();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvDept_Click(object sender, EventArgs e)
        {

        }

    }
}
