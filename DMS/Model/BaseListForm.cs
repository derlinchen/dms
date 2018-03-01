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
    public partial class BaseListForm : DMS.BaseForm
    {
        public string mCode = String.Empty;
        public int mAuth = 0;
        public int CurrentPage = 0;
        public int AllCount = 0;
        public int PageRows = 50;

        public BaseListForm()
        {
            InitializeComponent();
            tsMain.Renderer = new GuFun.WinControls.Office2007Renderer();
            tsMain.ImageList = this.ilTools;
            tsbExit.ImageIndex = 0;
            tsbFirst.ImageIndex = 1;
            tsbPrev.ImageIndex = 2;
            tsbNext.ImageIndex = 3;
            tsbLast.ImageIndex = 4;
            tsbSearch.ImageIndex = 5;
            tsbAdd.ImageIndex = 7;
            tsbEdit.ImageIndex = 8;
            tsbDelete.ImageIndex = 9;
            tsbCopy.ImageIndex = 10;
            tsbPrint.ImageIndex = 13;
            tsbExport.ImageIndex = 14;
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 0)
                return;

            if (PageRows >= AllCount)
                return;

            CurrentPage = 0;

            OnMoveFirst();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            OnMovePrevious();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            OnMoveNext();
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            if ((CurrentPage + 1) * PageRows >= AllCount)
                return;

            if (PageRows >= AllCount)
                return;

            CurrentPage = (AllCount - 1) / PageRows + 1;

            OnMoveLast();
        }

        protected virtual void OnMoveFirst()
        {
            OnBindData();
        }

        protected virtual void OnMovePrevious()
        {
            if (CurrentPage <= 0)
                return;

            if (PageRows >= AllCount)
                return;

            CurrentPage--;

            OnBindData();
        }

        protected virtual void OnMoveNext()
        {
            if ((CurrentPage + 1) * PageRows >= AllCount)
                return;

            if (PageRows >= AllCount)
                return;

            CurrentPage++;

            OnBindData();
        }

        protected virtual void OnMoveLast()
        {
            OnBindData();
        }

        protected virtual void OnBindData()
        {

        }

        private void miBlur_Click(object sender, EventArgs e)
        {
            miBlur.Checked = true;
            miExact.Checked = false;
            miLeft.Checked = false;
        }

        private void miExact_Click(object sender, EventArgs e)
        {
            miBlur.Checked = false;
            miExact.Checked = true;
            miLeft.Checked = false;
        }

        private void miLeft_Click(object sender, EventArgs e)
        {
            miBlur.Checked = false;
            miExact.Checked = false;
            miLeft.Checked = true;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            OnAddData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            OnEditData();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            OnDeleteData();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            OnCopyData();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            OnPrintClick();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            string filename = "数据";
            if (!String.IsNullOrEmpty(this.Text))
                filename = this.Text;

            try
            {
                FileHelper.InitSaveExcelDialog(sfdExport, filename);
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string file = sfdExport.FileName;
                    sfdExport.Dispose();
                    //FileHelper.ExportToExcel(dgvList, file);

                    ExcelHelper excel = new ExcelHelper();
                    excel.NewExcelFile();
                    excel.SaveFileName = file;

                    excel.SetWorksheetName(1, OnExportExcel());

                    int i = 0;
                    int j = 0;
                    int k = 0;
                    for (i = 0; i < dgvList.Columns.Count; i++)
                    {
                        if (!dgvList.Columns[i].Visible) continue;

                        k++;

                        excel.SetCellValue(1, k, dgvList.Columns[i].HeaderText);
                    }

                    for (i = 0; i < dgvList.Rows.Count; i++)
                    {
                        k = 0;
                        for (j = 0; j < dgvList.Columns.Count; j++)
                        {
                            if (!dgvList.Columns[j].Visible) continue;

                            k++;
                            excel.SetCellValue(i + 2, k, dgvList.Rows[i].Cells[j].Value != null ? dgvList.Rows[i].Cells[j].Value.ToString() : "");
                        }
                    }

                    excel.SaveExcel();
                    excel.CloseExcelApplication();

                    MessageBox.Show("导出成功！", PublicConsts.PC_Tip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出错误：" + ex.Message, PublicConsts.PC_Tip);
                return;
            }
        }


        protected virtual void OnAddData()
        {

        }

        protected virtual void OnEditData()
        {

        }

        protected virtual void OnDeleteData()
        {

        }

        protected virtual void OnCopyData()
        {

        }

        protected virtual void OnPrintClick()
        {

        }
        protected virtual string OnExportExcel()
        {
            return "结果";
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            plSearch.BackColor = this.BackColor;

            if (!DesignMode)
                OnInitAuth();

            CurrentPage = 0;
            AllCount = 0;
            PageRows = 50;
        }

        protected virtual void OnInitAuth()
        {
            mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Browse))
            {
                tsbFirst.Visible = false;
                tsbPrev.Visible = false;
                tsbNext.Visible = false;
                tsbLast.Visible = false;
                tssNav.Visible = false;
            }

            tsbCopy.Visible = false;

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Search))
            {
                tsbSearch.Visible = false;
                tssSearch.Visible = false;
            }

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.New))
                tsbAdd.Visible = false;

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Edit))
                tsbEdit.Visible = false;

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Delete))
                tsbDelete.Visible = false;

            if (!(CoreCtrls.CheckAuth(mAuth, AuthType.New) || CoreCtrls.CheckAuth(mAuth, AuthType.Edit) || CoreCtrls.CheckAuth(mAuth, AuthType.Delete)))
            {
                tssModify.Visible = false;
            }

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Print))
                tsbPrint.Visible = false;

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Export))
                tsbExport.Visible = false;
        }

        protected virtual bool OnBeforeDoubleClick()
        {
            return true;
        }

        private void dgvList_CellDoubleClick(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0 && this.OnBeforeDoubleClick())
                OnEditData();
        }

        private void dgvList_Sorted(object sender, EventArgs e)
        {
            OnSorted();
        }

        protected virtual void OnSorted()
        {

        }


        protected virtual bool OnSortCompare(DataGridViewRow dr)
        {
            return false;
        }

        private void dgvList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (OnSortCompare(dgvList.Rows[e.RowIndex2]))
                e.SortResult = 1;

            e.Handled = true;
        }

        private void BaseListForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.ActiveControl != null) && !this.ActiveControl.GetType().ToString().Contains("Button") && !this.ActiveControl.GetType().ToString().Contains("DataGridView") && (e.KeyChar == (char)13))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (((TextBox)this.ActiveControl).Multiline)
                        return;
                }

                SendKeys.Send("{TAB}");
            }
        }

        protected virtual void OnSortedLast()
        {

        }

        private void dgvList_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            OnSortedLast();
        }

        private void tsbSearch_ButtonClick(object sender, EventArgs e)
        {
            OnSearch();
        }

        protected virtual void OnSearch()
        {

        }
       
    }
}
