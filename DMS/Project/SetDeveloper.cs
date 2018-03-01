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
    public partial class SetDeveloper : DMS.BaseListForm
    {
        public SetDeveloper()
        {
            InitializeComponent();

            tsbFirst.Visible = false;
            tsbLast.Visible = false;
            tsbPrev.Visible = false;
            tsbNext.Visible = false;
            tssNav.Visible = false;

            tsbAdd.Visible = false;
            tsbCopy.Visible = false;
            tsbDelete.Visible = false;
            tsbEdit.Text = "分配人员";
            tssModify.Visible = false;
            tsbPrint.Visible = false;
            tsbExport.Visible = false;

            this.Text = "分配人员";
            this.mCode = "0402";

            CoreCtrls.SetDataGridView(dgvList, "P_Search_BusProject", Program.ManInfo);
        }

        protected override void OnInitAuth()
        {
            base.OnInitAuth();

            int mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            if (CoreCtrls.CheckAuth(mAuth, AuthType.Set))
                tsbEdit.Visible = true;
        }

        protected override void OnBindData()
        {
            string sql = String.Empty;
            string projectname = String.Empty;
            string projectManager = Program.ManInfo.Man.ManID;

            if (!String.IsNullOrEmpty(txtProjectName.Text))
            {
                sql += " and a.ProjectName like '%" + txtProjectName.Text + "%' ";
            }

            if (!String.IsNullOrEmpty(projectManager))
            {
                sql += " and a.ProjectManager = '" + projectManager + "' ";
            }

            dgvList.DataSource = SqlBaseProvider.SearchBusProject(sql);
        }

        protected override void OnEditData()
        {
            base.OnEditData();
            if (dgvList.SelectedRows.Count != 1)
            {
                Global.ShowSysInfo("请选择需要修改的数据行！");
                return;
            }

            EditDeveloper edit = new EditDeveloper();
            edit.id = dgvList.SelectedRows[0].Cells["ProjectID"].Value.ToString();
            edit.lbInfo.Text = "为" + dgvList.SelectedRows[0].Cells["ProjectName"].Value.ToString() + "项目分配开发人员";
            edit.parentForm = this;

            if (edit.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void SetDeveloper_Load(object sender, EventArgs e)
        {
            OnBindData();
        }

        public void RefreshForm()
        {
            OnBindData();
        }
    }
}
