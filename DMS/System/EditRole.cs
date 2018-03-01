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
    public partial class EditRole : DMS.BaseEditForm
    {
        public short id = 0;
        public ManRole parentForm;
        private DataTable menudt;
        private DataTable authdt;
        private DataTable navdt;

        public EditRole()
        {
            InitializeComponent();

            this.Text = "角色管理";
            this.mCode = "0604";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            tpMenu.BackColor = this.BackColor;
            tpNav.BackColor = this.BackColor;
            scEdit.BackColor = this.BackColor;
            scEdit.Panel1.BackColor = this.BackColor;
            scEdit.Panel2.BackColor = this.BackColor;
            plEdit.BackColor = this.BackColor;

            CtrlHelper.SetDropDownList(ddlData, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Auth_Bound order by Auth_Bound", SqlTextType.Text, "Auth_Bound_Name,Auth_Bound"), DropAddType.New, DropAddFlag.Select);

            this.allCtrls = new object[] { txtRoleName, ddlData, txtRoleDesc, clNav, clMenu, clAuth };

            OnInitData();
        }

        protected override void OnInitData()
        {
            base.OnInitData();

            clNav.Items.Clear();
            clMenu.Items.Clear();
            clAuth.Items.Clear();

            try
            {
                if (id == 0)
                {
                    menudt = SqlBaseProvider.GetRoleMenu();
                    navdt = SqlBaseProvider.GetRoleNav();
                }
                else
                {
                    menudt = SqlBaseProvider.GetRoleMenu(id);
                    navdt = SqlBaseProvider.GetRoleNav(id);

                    SysRole sr = SqlBaseProvider.GetSysRole(id);

                    if (sr.RoleID == 0)
                        throw new Exception("未找到编号为[" + id.ToString() + "]的角色信息！");

                    txtRoleName.Text = sr.RoleName;
                    txtRoleDesc.Text = sr.RoleDesc;
                    CtrlHelper.SelectDropDownList(ddlData, sr.AuthBound.ToString());
                }

                authdt = CoreCtrls.GetPublicProcedure("P_Get_MenuAuth");

                int i = 0;

                foreach (DataRow menudr in menudt.Rows)
                {
                    clMenu.Items.Add(menudr["M_Name"]);
                    if (Convert.ToBoolean(menudr["Is_Select"]))
                        clMenu.SetItemCheckState(clMenu.Items.Count - 1, CheckState.Checked);
                    else
                        clMenu.SetItemCheckState(clMenu.Items.Count - 1, CheckState.Unchecked);

                    i++;
                }

                i = 0;

                foreach (DataRow navdr in navdt.Rows)
                {
                    clNav.Items.Add(navdr["Rib_Btn_Name"]);
                    if (Convert.ToBoolean(navdr["Is_Select"]))
                        clNav.SetItemCheckState(clNav.Items.Count - 1, CheckState.Checked);
                    else
                        clNav.SetItemCheckState(clNav.Items.Count - 1, CheckState.Unchecked);

                    i++;
                }

                this.fState = FormState.Edit;

            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
                this.OnDisplayAllCtrls(false);
                tsbCancel.Visible = false;
                tsbSave.Visible = false;
                tsbEdit.Visible = false;
                fState = FormState.Detail;
            }
        }

        private void clMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authdt == null)
                return;

            if ((clMenu.SelectedIndex >= 0) && (clMenu.SelectedIndex < clMenu.Items.Count))
            {
                if (clMenu.GetItemChecked(clMenu.SelectedIndex))
                {
                    DataRow dr = menudt.Rows[clMenu.SelectedIndex];

                    menudt.Rows[clMenu.SelectedIndex]["Is_Select"] = 1;

                    int mauth = Convert.ToInt32(dr["M_Auth"]);
                    int auth = 0;

                    clAuth.Items.Clear();
                    foreach (DataRow authdr in authdt.Rows)
                    {
                        auth = Convert.ToInt32(authdr["Auth_ID"]);
                        auth = Convert.ToInt32(Math.Pow(2, auth - 1));

                        if (CoreCtrls.CheckAuth(mauth, (AuthType)auth))
                        {
                            clAuth.Items.Add(authdr["Auth_Name"]);

                            if (CoreCtrls.CheckAuth(Convert.ToInt32(dr["Role_Auth"]), (AuthType)auth))
                                clAuth.SetItemCheckState(clAuth.Items.Count - 1, CheckState.Checked);
                            else
                                clAuth.SetItemCheckState(clAuth.Items.Count - 1, CheckState.Unchecked);
                        }
                    }
                }
                else
                {
                    menudt.Rows[clMenu.SelectedIndex]["Is_Select"] = 0;
                    clAuth.Items.Clear();
                }
            }
        }

        private void clAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authdt == null)
            {
                return;
            }

            int i = 0;
            int auth = 0;

            if ((clMenu.SelectedIndex >= 0) && (clMenu.SelectedIndex < clMenu.Items.Count))
            {
                DataRow dr = menudt.Rows[clMenu.SelectedIndex];

                if ((clAuth.SelectedIndex >= 0) && (clAuth.SelectedIndex < clMenu.Items.Count))
                {
                    foreach (DataRow authdr in authdt.Rows)
                    {
                        if (authdr["Auth_Name"].ToString() == clAuth.Items[clAuth.SelectedIndex].ToString())
                        {
                            auth = Convert.ToInt32(Math.Pow(2, Convert.ToInt32(authdr["Auth_ID"]) - 1));
                            break;
                        }

                        i++;
                    }

                    if (clAuth.GetItemChecked(clAuth.SelectedIndex))
                    {
                        if (!CoreCtrls.CheckAuth(Convert.ToInt32(dr["Role_Auth"]), (AuthType)auth))
                            dr["Role_Auth"] = Convert.ToInt32(dr["Role_Auth"]) + auth;
                    }
                    else
                    {
                        if (CoreCtrls.CheckAuth(Convert.ToInt32(dr["Role_Auth"]), (AuthType)auth))
                            dr["Role_Auth"] = Convert.ToInt32(dr["Role_Auth"]) - auth;
                    }
                }
            }
        }

        private void clNav_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (navdt == null)
            {
                return;
            }

            if ((clNav.SelectedIndex >= 0) && (clNav.SelectedIndex < clNav.Items.Count))
            {
                if (clNav.GetItemChecked(clNav.SelectedIndex))
                {
                    navdt.Rows[clNav.SelectedIndex]["Is_Select"] = 1;
                }
                else
                {
                    navdt.Rows[clNav.SelectedIndex]["Is_Select"] = 0;
                }
            }
        }

        protected override bool OnBeforeSave()
        {
            if (String.IsNullOrEmpty(txtRoleName.Text))
            {
                Global.ShowSysInfo("角色名称不能为空！");
                return false;
            }

            if (ddlData.SelectedValue.ToString() == DropAddFlag.Select.ToString())
            {
                Global.ShowSysInfo("请选择角色的数据访问范围！");
                return false;
            }

            return true;
        }

        protected override bool OnSaveData()
        {
            if (menudt == null) return false;

            if (navdt == null) return false;

            try
            {
                SysRole item = new SysRole();

                item.RoleName = txtRoleName.Text;
                item.AuthBound = Convert.ToInt16(ddlData.SelectedValue);
                item.CrtDate = DateTime.Now;
                item.RoleMan = Program.ManInfo.Man.ManID;
                item.RoleDesc = txtRoleDesc.Text;

                if (id == 0)
                {
                    SqlBaseProvider.SaveSysRole(item, menudt, navdt, DataProviderAction.Create);
                    id = item.RoleID;
                }
                else
                {
                    item.RoleID = id;
                    SqlBaseProvider.SaveSysRole(item, menudt, navdt, DataProviderAction.Update);
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

        private void clNav_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (navdt == null)
                return;

            if ((clNav.SelectedIndex >= 0) && (clNav.SelectedIndex < clNav.Items.Count))
            {
                if (clNav.GetItemChecked(clNav.SelectedIndex))
                {
                    navdt.Rows[clNav.SelectedIndex]["Is_Select"] = 1;
                }
                else
                {
                    navdt.Rows[clNav.SelectedIndex]["Is_Select"] = 0;
                }
            }
        }


    }
}
