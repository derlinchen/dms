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
    public partial class BaseListEditForm : DMS.BaseForm
    {
        public FormState fState = FormState.List;
        public string mCode = String.Empty;
        public int mAuth = 0;
        public object[] allCtrls;
        public object[] editCtrls;
        public object[] newCtrls;

        public BaseListEditForm()
        {
            InitializeComponent();
            tsMain.Renderer = new Office2007Renderer();
            tsMain.ImageList = ilTools;
            tsbExit.ImageIndex = 0;
            tsbFirst.ImageIndex = 1;
            tsbPrev.ImageIndex = 2;
            tsbNext.ImageIndex = 3;
            tsbLast.ImageIndex = 4;
            tsbSearch.ImageIndex = 5;
            tsbDetail.ImageIndex = 6;
            tsbAdd.ImageIndex = 7;
            tsbEdit.ImageIndex = 8;
            tsbDelete.ImageIndex = 9;
            tsbCopy.ImageIndex = 10;
            tsbSave.ImageIndex = 11;
            tsbCancel.ImageIndex = 12;
            tsbPrint.ImageIndex = 13;
            tsbExport.ImageIndex = 14;

            plSearch.Visible = false;
            OnChoiceSave(false);
        }

        #region Private Methods

        private void BaseListEditForm_Load(object sender, EventArgs e)
        {
            //if (mAuth == 0)
            //{
            //  MessageBox.Show("您没有操作该功能的权限！", PublicConsts.PC_Tip);
            //  this.Close();
            //}

            tpEdit.BackColor = this.BackColor;
            tpList.BackColor = this.BackColor;
            plEdit.BackColor = this.BackColor;
            plSearch.BackColor = this.BackColor;

            if (!DesignMode)
                OnInitAuth();

            if (!DesignMode)
                etcMain.HideTabs = true;

            OnInitData();
        }

        private void BaseListEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((fState == FormState.Edit) || (fState == FormState.New))
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，是否继续退出？", PublicConsts.PC_Tip, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    e.Cancel = true;
            }
        }

        private void OnInitAuth()
        {
            mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            //mAuth = (int)AuthType.All;

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
                tsbSearch.Visible = false;

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

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDetailClick();
        }

        private void OnDetailClick()
        {
            if (etcMain.SelectedIndex == 0)
            {
                // 显示数据
                if (!OnLoadData(false))
                    return;

                OnDisplayAllCtrls(false);

                this.FState = FormState.Detail;
                etcMain.SelectedIndex = 1;
            }
            else
            {
                if (!IsCancelModify())
                    return;

                OnInitData();

                this.FState = FormState.List;
            }
        }

        #endregion Private Methods

        #region Protected Methods

        protected void OnChoiceSave(bool isVisible)
        {
            tsbSave.Visible = isVisible;
            tsbCancel.Visible = isVisible;
            tssSave.Visible = isVisible;
        }

        protected void OnDisplayAllCtrls(bool isEnable)
        {
            if (allCtrls != null)
            {
                if (isEnable)
                    CtrlHelper.EnableCtrls(allCtrls);
                else
                    CtrlHelper.DisableCtrls(allCtrls);
            }
        }

        protected void OnDisplayEditCtrls(bool isEnable)
        {
            if (editCtrls != null)
            {
                if (isEnable)
                    CtrlHelper.EnableCtrls(editCtrls);
                else
                    CtrlHelper.DisableCtrls(editCtrls);
            }
        }

        protected void OnDisplayNewCtrls(bool isEnable)
        {
            if (newCtrls != null)
            {
                if (isEnable)
                    CtrlHelper.EnableCtrls(newCtrls);
                else
                    CtrlHelper.DisableCtrls(newCtrls);
            }
        }

        protected void OnPageInit(bool isPage)
        {
            if (isPage)
            {
                tsbFirst.Text = "首页";
                tsbPrev.Text = "上页";
                tsbNext.Text = "下页";
                tsbLast.Text = "末页";
            }
            else
            {
                tsbFirst.Text = "首条";
                tsbPrev.Text = "上条";
                tsbNext.Text = "下条";
                tsbLast.Text = "末条";
            }
        }

        #endregion Protected Methods

        #region Virtual Methods 可被继承的窗体重写

        /// <summary>
        /// 编辑状态数据初始化
        /// </summary>
        protected virtual void OnInitData()
        {

        }

        /// <summary>
        /// 加载数据时处理
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnLoadData(bool isLoad)
        {
            return true;
        }

        /// <summary>
        /// 列表数据绑定处理
        /// </summary>
        /// <param name="nav"></param>
        protected virtual void OnBindData(NavType nav)
        {

        }

        /// <summary>
        /// 数据保存前有效性判断
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnBeforeSave()
        {
            return true;
        }

        /// <summary>
        /// 数据保存处理
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnSaveData()
        {
            return true;
        }

        /// <summary>
        /// 数据删除处理
        /// </summary>
        protected virtual void OnDeleteData()
        {

        }

        /// <summary>
        /// 窗体状态发生变化时处理，一般不重写
        /// </summary>
        /// <param name="old"></param>
        /// <param name="now"></param>
        protected virtual void OnFormStateChanged(FormState old, FormState now)
        {
            if (old == now) return;

            // 如果是分页进入明细后为按条检索
            if (PageOrRow)
            {
                if (etcMain.SelectedIndex == 0)
                    OnPageInit(true);
                else
                    OnPageInit(false);
            }

            switch (old)
            {
                case FormState.List:
                    if (etcMain.SelectedIndex == 0)
                    {
                        etcMain.SelectedIndex = 1;
                        tsbDetail.Text = "列表";
                    }

                    switch (now)
                    {
                        case FormState.New:
                            tsbEdit.Visible = false;
                            tsbDelete.Visible = false;
                            OnChoiceSave(true);
                            break;

                        case FormState.Edit:
                            OnChoiceSave(true);
                            break;
                    }

                    break;

                case FormState.Edit:
                    switch (now)
                    {
                        case FormState.New:
                            tsbEdit.Visible = false;
                            tsbDelete.Visible = false;
                            OnChoiceSave(true);
                            break;

                        case FormState.List:
                            if (etcMain.SelectedIndex == 1)
                            {
                                etcMain.SelectedIndex = 0;
                                tsbDetail.Text = "明细";
                            }
                            OnChoiceSave(false);
                            break;

                        case FormState.Detail:
                            OnChoiceSave(false);
                            break;
                    }

                    break;

                case FormState.Detail:
                    switch (now)
                    {
                        case FormState.New:
                            tsbEdit.Visible = false;
                            tsbDelete.Visible = false;
                            OnChoiceSave(true);
                            break;

                        case FormState.List:
                            if (etcMain.SelectedIndex == 1)
                            {
                                etcMain.SelectedIndex = 0;
                                tsbDetail.Text = "明细";
                            }
                            OnChoiceSave(false);
                            break;

                        case FormState.Edit:
                            OnChoiceSave(true);
                            break;
                    }

                    break;

                case FormState.New:
                    OnChoiceSave(false);
                    tsbEdit.Visible = CoreCtrls.CheckAuth(mAuth, AuthType.Edit);
                    tsbDelete.Visible = CoreCtrls.CheckAuth(mAuth, AuthType.Delete);

                    if (now == FormState.List)
                    {
                        if (etcMain.SelectedIndex == 1)
                        {
                            etcMain.SelectedIndex = 0;
                            tsbDetail.Text = "明细";
                        }
                    }

                    break;
            }
        }

        #endregion Virtual Methods

        #region Properties

        private bool _pageOrRow = false;

        public bool PageOrRow
        {
            get { return _pageOrRow; }
            set { _pageOrRow = value; }
        }

        private int _pageCnt = 0;

        public int PageCnt
        {
            get { return _pageCnt; }
            set { _pageCnt = value; }
        }

        public FormState FState
        {
            get { return fState; }
            set
            {
                this.OnFormStateChanged(fState, value);

                fState = value;
            }
        }

        #endregion Properties

        #region Buttons Clicl Events

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            OnDetailClick();
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

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (etcMain.SelectedIndex == 0)
                this.FState = FormState.List;
            else
                this.FState = FormState.Detail;

            if ((this.PageOrRow) && (fState == FormState.List))
            {
                OnBindData(NavType.First);
                return;
            }

            bsList.MoveFirst();

            if (this.FState == FormState.Detail)
            {
                OnLoadData(false);
            }
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (etcMain.SelectedIndex == 0)
                this.FState = FormState.List;
            else
                this.FState = FormState.Detail;

            if ((this.PageOrRow) && (fState == FormState.List))
            {
                OnBindData(NavType.Prev);
                return;
            }

            bsList.MovePrevious();

            if (this.FState == FormState.Detail)
            {
                OnLoadData(false);
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (etcMain.SelectedIndex == 0)
                this.FState = FormState.List;
            else
                this.FState = FormState.Detail;

            if ((this.PageOrRow) && (fState == FormState.List))
            {
                OnBindData(NavType.Next);
                return;
            }

            bsList.MoveNext();

            if (this.FState == FormState.Detail)
            {
                OnLoadData(false);
            }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (etcMain.SelectedIndex == 0)
                this.FState = FormState.List;
            else
                this.FState = FormState.Detail;

            if ((this.PageOrRow) && (fState == FormState.List))
            {
                OnBindData(NavType.Last);
                return;
            }

            bsList.MoveLast();

            if (this.FState == FormState.Detail)
            {
                OnLoadData(false);
            }
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
                    FileHelper.ExportToExcel(dgvList, sfdExport.FileName);
                    MessageBox.Show("导出成功！", PublicConsts.PC_Tip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出错误：" + ex.Message, PublicConsts.PC_Tip);
                return;
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (this.FState == FormState.New)
                OnInitData();

            if (this.FState == FormState.Edit)
                OnLoadData(true);

            // 更改窗体状态
            this.FState = FormState.Detail;

            OnDisplayAllCtrls(false);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (!OnBeforeSave())
                return;

            if (OnSaveData())
            {
                this.FState = FormState.Detail;
                OnDisplayAllCtrls(false);
                OnBindData(NavType.None);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            // 更改窗体状态
            this.FState = FormState.New;

            // 初始化编辑状态的控件
            OnInitData();
            OnDisplayAllCtrls(true);
            OnDisplayNewCtrls(false);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            if (!OnLoadData(false))
                return;

            // 更改窗体状态
            this.FState = FormState.Edit;

            OnDisplayAllCtrls(true);
            OnDisplayEditCtrls(false);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            OnDeleteData();
        }

        private void tsbSearch_ButtonClick(object sender, EventArgs e)
        {
            if (!IsCancelModify())
                return;

            this.FState = FormState.List;
            OnBindData(NavType.None);
        }

        #endregion Buttons Clicl Events

        private bool IsCancelModify()
        {
            if ((fState == FormState.Edit) || (fState == FormState.New))
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，取消操作将会放弃正在编辑的数据？", "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    return false;
            }

            return true;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (FState == FormState.List)
                OnPrintClick();
        }

        protected virtual void OnPrintClick()
        {

        }

        private void BaseListEditForm_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
