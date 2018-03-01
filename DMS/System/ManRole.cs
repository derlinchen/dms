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
    public partial class ManRole : DMS.BaseListForm
    {
        public ManRole()
        {
            InitializeComponent();

            tsbFirst.Visible = false;
            tsbLast.Visible = false;
            tsbPrev.Visible = false;
            tsbNext.Visible = false;
            tssNav.Visible = false;
            plSearch.Visible = false;
            this.Text = "角色管理";
            this.mCode = "0604";

            CoreCtrls.SetDataGridView(dgvList, "P_Get_SysRole", Program.ManInfo);
        }

        protected override void OnBindData()
        {
            base.OnBindData();

            dgvList.DataSource = SqlBaseProvider.GetSysRoleList();
        }

        public void RefreshForm()
        {
            OnBindData();
        }

        private void ManRole_Load(object sender, EventArgs e)
        {
            OnBindData();
        }

        protected override void OnAddData()
        {
            base.OnAddData();

            EditRole edit = new EditRole();

            edit.id = 0;
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

            EditRole edit = new EditRole();

            edit.id = Convert.ToInt16(dgvList.SelectedRows[0].Cells["Role_ID"].Value);
            edit.parentForm = this;

            if (edit.ShowDialog() == DialogResult.OK)
            {

            }
        }

    }
}
