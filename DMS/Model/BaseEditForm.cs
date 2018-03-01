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
    public partial class BaseEditForm : DMS.BaseDialogForm
    {
        public FormState fState = FormState.Detail;
        public string mCode = String.Empty;
        public int mAuth = 0;
        public object[] allCtrls;
        public object[] editCtrls;
        public object[] newCtrls;

        public BaseEditForm()
        {
            InitializeComponent();
            tsMain.Renderer = new GuFun.WinControls.Office2007Renderer();
            tsMain.ImageList = ilTools;
            tsbExit.ImageIndex = 0;
            tsbSave.ImageIndex = 11;
            tsbEdit.ImageIndex = 8;
            tsbCancel.ImageIndex = 12;
            tsbPreview.ImageIndex = 5;
            tsbPrint.ImageIndex = 13;

            tssEdit.Visible = false;
            tsbEdit.Visible = false;
        }

        #region Button Click Methods

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (!OnBeforeSave())
                return;

            if (OnSaveData())
            {
                tsbEdit.Visible = true;
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
            }

            OnAfterSave();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (fState != FormState.Detail)
            {
                DialogResult dr = MessageBox.Show("取消操作将会取消您刚才所编辑的数据？", "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    return;

                OnInitData();
            }
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            OnPrintPreview();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            OnPrint();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            OnInitData();
            this.fState = FormState.Edit;
            if (this.fState == FormState.Edit)
            {
                tsbEdit.Visible = false;
                tsbSave.Visible = true;
                tsbCancel.Visible = true;

                OnDisplayAllCtrls(true);
                OnDisplayEditCtrls(false);
            }
        }

        #endregion Button Click Methods

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            plEdit.BackColor = this.BackColor;

            if (!DesignMode)
                OnInitAuth();

            // OnInitData();

            if (this.allCtrls != null)
            {
                foreach (object obj in this.allCtrls)
                {
                    ((Control)obj).Enter += new EventHandler(this.ControlEnter);
                }
            }
        }

        private void OnInitAuth()
        {
            if (String.IsNullOrEmpty(this.mCode))
                return;

            mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            if (!(CoreCtrls.CheckAuth(mAuth, AuthType.New) || CoreCtrls.CheckAuth(mAuth, AuthType.Edit) || CoreCtrls.CheckAuth(mAuth, AuthType.Delete)))
            {
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
                tssPrint.Visible = false;
            }

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Print))
            {
                tssPrint.Visible = false;
                tsbPreview.Visible = false;
                tsbPrint.Visible = false;
            }
        }


        #region Virtual Methods

        protected virtual bool OnBeforeSave()
        {
            return true;
        }

        protected virtual bool OnSaveData()
        {
            return true;
        }

        protected virtual void OnAfterSave()
        {

        }

        protected virtual void OnInitData()
        {

        }

        protected virtual void OnPrintPreview()
        {

        }

        protected virtual void OnPrint()
        {

        }

        #endregion Virtual Methods

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

        private bool IsCancelModify()
        {
            if (fState != FormState.Detail)
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，该操作将会放弃正在编辑的数据？", "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    return false;
            }

            return true;
        }  

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsCancelModify())
            {
                DialogResult = DialogResult.Cancel;
            }
        }


    }
}
