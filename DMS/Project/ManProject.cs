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
    public partial class ManProject : DMS.BaseListForm
    {
        public ManProject()
        {
            InitializeComponent();
            tsbFirst.Visible = false;
            tsbLast.Visible = false;
            tssNav.Visible = false;
            this.Text = "项目管理";
            this.mCode = "0401";
            tsbNext.Text = "下一天";
            tsbPrev.Text = "上一天";

            CoreCtrls.SetDataGridView(dgvList, "P_Search_BusProject", Program.ManInfo);
        }

        private void ProjectManage_Load(object sender, EventArgs e)
        {
            OnBindData();
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

        protected override void OnAddData()
        {
            base.OnAddData();

            EditProject edit = new EditProject();
            edit.id = String.Empty;
            edit.parentForm = this;

            if (edit.ShowDialog() == DialogResult.OK)
            {

            }
        }

        protected override void OnEditData()
        {
            base.OnEditData();
            if (dgvList.SelectedRows.Count != 1)
            {
                Global.ShowSysInfo("请选择需要修改的数据行！");
                return;
            }

            EditProject edit = new EditProject();
            edit.id = dgvList.SelectedRows[0].Cells["ProjectID"].Value.ToString();
            edit.parentForm = this;
            if (edit.ShowDialog() == DialogResult.OK)
            {

            }
        }

        public void RefreshForm()
        {
            OnBindData();
        }
    }
}
