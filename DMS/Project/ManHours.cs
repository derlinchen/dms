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
    public partial class ManHours : DMS.BaseListForm
    {
        public ManHours()
        {
            InitializeComponent();

            tsbFirst.Visible = false;
            tsbLast.Visible = false;
            tssNav.Visible = false;
            this.Text = "工时管理";
            this.mCode = "0403";

            CoreCtrls.SetDataGridView(dgvList, "P_Search_BusHours", Program.ManInfo);
        }

        private void ManHours_Load(object sender, EventArgs e)
        {
            OnBindData();
        }

        protected override void OnBindData()
        {
            PageBusHours page = new PageBusHours();
            string sql = String.Empty;
            string projectname = String.Empty;
            bool isSearch = false;

            page.Start = this.CurrentPage * this.PageRows + 1;
            page.End = (this.CurrentPage + 1) * this.PageRows;

            if (!String.IsNullOrEmpty(txtProjectCode.Text))
            {
                page.Search += ToolUtils.GetAndSearch(page.Search) + "b.ProjectCode like '%" + txtProjectCode.Text + "%' ";
                isSearch = true;
            }

            if (!String.IsNullOrEmpty(txtManName.Text))
            {
                page.Search += ToolUtils.GetAndSearch(page.Search) + "c.Man_Name like '%" + txtManName.Text + "%' ";
                isSearch = true;
            }

            if (isSearch)
            {
                page.GetAction = Convert.ToString(ActionType.Full);
            }

            DataTable dt = SqlBaseProvider.SearchBusHours(page);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                if (isSearch)
                {
                    DataRow dr = dt.NewRow();
                    dr["ProjectCode"] = "合计："+ dt.Compute("Count(WorkCount)", null) + "人/日";
                    dr["WorkCount"] = dt.Compute("Sum(WorkCount)", null);
                    dt.Rows.Add(dr.ItemArray);
                }
                dgvList.DataSource = dt;
                this.AllCount = page.Total;
            }

        }

        protected override void OnSearch()
        {
            OnBindData();
        }

        //protected override void OnAddData()
        //{
        //    base.OnAddData();

        //    EditHours edit = new EditHours();
        //    edit.id = String.Empty;
        //    edit.parentForm = this;

        //    if (edit.ShowDialog() == DialogResult.OK)
        //    {

        //    }
        //}

        //protected override void OnEditData()
        //{
        //    base.OnEditData();
        //    if (dgvList.SelectedRows.Count != 1)
        //    {
        //        Global.ShowSysInfo("请选择需要修改的数据行！");
        //        return;
        //    }

        //    EditHours edit = new EditHours();
        //    edit.id = dgvList.SelectedRows[0].Cells["HoursID"].Value.ToString();
        //    edit.parentForm = this;
        //    if (edit.ShowDialog() == DialogResult.OK)
        //    {

        //    }
        //}

        public void RefreshForm()
        {
            OnBindData();
        }

    }
}
