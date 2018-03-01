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
    public partial class ManMan : DMS.BaseListForm
    {
        private short ml = 0;

        public ManMan()
        {
            InitializeComponent();
            tsbFirst.Visible = false;
            tsbLast.Visible = false;
            tsbPrev.Visible = false;
            tsbNext.Visible = false;
            tssNav.Visible = false;
            this.Text = "员工管理";
            this.mCode = "0603";

            CoreCtrls.SetDataGridView(dgvList, "P_Get_SysMan", Program.ManInfo);
            ectDept.Tree.ComboTreeType = GuFun.WinControls.ComboTreeType.All;
            ectDept.Tree.TypeText = "所有部门";
            ectDept.Tree.DataSource = SqlBaseProvider.GetSimpleValidDept();
            ectDept.Tree.DisplayMember = "Dept_Name";
            ectDept.Tree.ValueMember = "Dept_ID";
            ectDept.Tree.ParentMember = "Dept_PID";
            ectDept.Tree.Height = 200;
            ectDept.AbsoluteChildrenSelectableOnly = false;

            ml = SqlBaseProvider.GetSetManLevel();

            if (Program.ManInfo.Man.ManLevel >= ml)
            {
                ectDept.Visible = false;
                lblDept.Text = "属于部门：" + Program.ManInfo.Man.DeptName;
            }

        }

        protected override void OnBindData()
        {
            string sql = String.Empty;
            string deptid = String.Empty;

            if (Program.ManInfo.Man.ManLevel >= ml)
            {
                sql += " and i.Dept_PID = '" + Program.ManInfo.Man.DeptID + "' ";
            }
            else
            {
                if (!String.IsNullOrEmpty(ectDept.Text))
                {
                    if (ectDept.Tree.SelectedValue.ToString() != ComboTreeType.All.ToString())
                    {
                        sql += " and i.Dept_PID = '" + ectDept.Tree.SelectedValue.ToString() + "' ";
                    }
                }
            }

            if (!String.IsNullOrEmpty(txtManName.Text))
            {
                if (miExact.Checked)
                    sql += " and a.Man_Name = '" + txtManName.Text + "' ";
                else if (miLeft.Checked)
                    sql += " and a.Man_Name like '%" + txtManName.Text + "' ";
                else
                    sql += " and a.Man_Name like '%" + txtManName.Text + "%' ";
            }

            dgvList.DataSource = SqlBaseProvider.SearchSysMan(sql);
        }

        private void ManMan_Load(object sender, EventArgs e)
        {
            OnBindData();
        }

        protected override void OnAddData()
        {
            base.OnAddData();

            EditMan edit = new EditMan();

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

            EditMan edit = new EditMan();

            edit.id = dgvList.SelectedRows[0].Cells["Man_ID"].Value.ToString();
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
