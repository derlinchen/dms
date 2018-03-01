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
    public partial class ManCompany : DMS.BaseListEditForm
    {
        public ManCompany()
        {
            InitializeComponent();

            this.Text = "公司管理";
            CoreCtrls.SetDataGridView(dgvList, "P_Get_Company", Program.ManInfo);
            btnMan.BackColor = SystemColors.Control;

            this.allCtrls = new object[] { txtCoName, txtCoID, txtCoFax, txtCoEMail, txtCoAddress, txtCoMan, txtCoOrder, txtCoPost, txtCoTele, ddlCoStatus, btnMan };
            this.editCtrls = new object[] { txtCoID };
            txtCoMan.ReadOnly = true;
            this.mCode = "0601";
        }

        private void ManCompany_Load(object sender, EventArgs e)
        {
            this.PageOrRow = false;
            CtrlHelper.SetDropDownList(ddlCoStatus, CoreCtrls.GetComboBoxItems("Select * from T_Pmt_Co_Status order by Co_Status", SqlTextType.Text, "Co_Status_Name,Co_Status"), DropAddType.New, DropAddFlag.Select); 
    
        }

        protected override void OnBindData(NavType nav)
        {
            this.bsList.DataSource = SqlBaseProvider.GetSysCompanyList();
            this.dgvList.DataSource = this.bsList;
            base.OnBindData(nav);
        }

        protected override void OnInitData()
        {
            OnBindData(NavType.None);

            txtCoAddress.Text = String.Empty;
            txtCoEMail.Text = String.Empty;
            txtCoFax.Text = String.Empty;
            txtCoID.Text = String.Empty;
            txtCoMan.CodeText = String.Empty;
            txtCoMan.NameText = String.Empty;
            txtCoName.Text = String.Empty;
            txtCoOrder.Text = String.Empty;
            txtCoPost.Text = String.Empty;
            txtCoTele.Text = String.Empty;
            CtrlHelper.SelectDropDownList(ddlCoStatus, DropAddFlag.Select.ToString()); 
            base.OnInitData();
        }

        protected override bool OnLoadData(bool isLoad)
        {
            if ((etcMain.SelectedIndex == 1) && (String.IsNullOrEmpty(txtCoID.Text)))
            {
                MessageBox.Show("请返回列表选择需要进行修改的数据！", PublicConsts.PC_Tip);
                return false;
            }

            if (dgvList.SelectedRows.Count != 1)
                return false;

            try
            {
                txtCoID.Text = dgvList.SelectedRows[0].Cells["Co_ID"].Value.ToString();

                SysCompany sc = SqlBaseProvider.GetSysCompany(txtCoID.Text);

                txtCoName.Text = sc.CoName;
                txtCoAddress.Text = sc.CoAddress;
                txtCoFax.Text = sc.CoFax;
                txtCoTele.Text = sc.CoTele;
                txtCoFax.Text = sc.CoFax;
                txtCoEMail.Text = sc.CoEMail;
                txtCoOrder.Text = sc.SortOrder.ToString();
                txtCoPost.Text = sc.CoPost;
                txtCoMan.CodeText = sc.CoMan;

                if (!String.IsNullOrEmpty(txtCoMan.CodeText))
                {
                    txtCoMan.NameText = SqlBaseProvider.GetManName(txtCoMan.CodeText);
                }

                CtrlHelper.SelectDropDownList(ddlCoStatus, sc.CoStatus.ToString());
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }

            return true;
        }

        protected override bool OnSaveData()
        {
            try
            {
                SysCompany sc = new SysCompany();
                sc.CoID = txtCoID.Text;
                sc.CoName = txtCoName.Text;
                sc.CoAddress = txtCoAddress.Text;
                sc.CoPost = txtCoPost.Text;
                sc.CoTele = txtCoTele.Text;
                sc.CoFax = txtCoFax.Text;
                sc.CoEMail = txtCoEMail.Text;
                sc.SortOrder = Convert.ToInt16(txtCoOrder.Text);
                sc.CoMan = txtCoMan.Text;
                sc.CoStatus = Convert.ToInt16(ddlCoStatus.SelectedValue);
                if (this.FState == FormState.New)
                    SqlBaseProvider.SaveSysCompany(sc, DataProviderAction.Create);
                else
                    SqlBaseProvider.SaveSysCompany(sc, DataProviderAction.Update);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
