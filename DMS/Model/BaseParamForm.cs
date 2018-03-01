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
    public partial class BaseParamForm : DMS.BaseDialogForm
    {
        public FormState fState = FormState.List;
        protected InitSimpleParas iParas;
        public string mCode = String.Empty;
        public int mAuth = 0;

        public BaseParamForm()
        {
            InitializeComponent();

            tsMain.Renderer = new Office2007Renderer();
            tsMain.ImageList = ilTools;
            tsbExit.ImageIndex = 0;
            tsbAdd.ImageIndex = 7;
            tsbEdit.ImageIndex = 8;
            tsbSave.ImageIndex = 11;
            tsbCancel.ImageIndex = 12;
            tsbExport.ImageIndex = 14;
            tsbDel.ImageIndex = 9;

            CtrlHelper.InitDataGridView(dgvMain, true);
            colID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tsbCancel.Enabled = false;
            tsbSave.Enabled = false;

            iParas = new InitSimpleParas();
            OnInitForm();
        }

        private void BaseParamForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                OnInitAuth();

            fState = FormState.List;

            if (!String.IsNullOrEmpty(iParas.Title))
                OnBindData();

            txtID.Text = String.Empty;
            CtrlHelper.DisableTextBox(txtID);
            txtName.Text = String.Empty;
            CtrlHelper.DisableTextBox(txtName);  
        }

        private void OnInitAuth()
        {
            mAuth = Program.ManInfo.Auths.FindAuthByCode(this.mCode);

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.New))
                tsbAdd.Visible = false;

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Edit))
                tsbEdit.Visible = false;

            if (!(CoreCtrls.CheckAuth(mAuth, AuthType.New) || CoreCtrls.CheckAuth(mAuth, AuthType.Edit)))
            {
                tssModify.Visible = false;
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
                tssSave.Visible = false;
            }

            if (!CoreCtrls.CheckAuth(mAuth, AuthType.Export))
                tsbExport.Visible = false;
        }

        private void OnBindData()
        {
            if (!String.IsNullOrEmpty(iParas.Title))
            {
                dgvMain.DataSource = iParas.GetList();
            }
        }

        protected virtual void OnInitForm()
        {
            if (!String.IsNullOrEmpty(iParas.Title))
            {
                this.Text = iParas.Title;
                this.lblID.Text = iParas.DisplayName + this.lblID.Text;
                this.txtID.Left = this.lblID.Left + this.lblID.Width + 4;
                this.lblName.Text = iParas.DisplayName + this.lblName.Text;
                this.lblName.Left = this.txtID.Left + this.txtID.Width + 4;
                this.txtName.Left = this.lblName.Left + this.lblName.Width;
                this.txtID.MaxLength = iParas.ColLen;
                this.txtName.MaxLength = iParas.NameLen;
                this.colID.HeaderText = iParas.DisplayName + this.colID.HeaderText;
                this.colName.HeaderText = iParas.DisplayName + this.colName.HeaderText;
                this.colID.DataPropertyName = iParas.IdCode;
                this.colName.DataPropertyName = iParas.NameCode;
            }
        }

        private void BaseParamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((fState == FormState.Edit) || (fState == FormState.New))
            {
                DialogResult dr = MessageBox.Show("您正在编辑数据，是否继续退出？", PublicConsts.PC_Tip, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dr == DialogResult.No) || (dr == DialogResult.Cancel))
                    e.Cancel = true;
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = String.Empty;
            CtrlHelper.DisableTextBox(txtID);
            txtName.Text = String.Empty;
            CtrlHelper.DisableTextBox(txtName);
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;

            fState = FormState.List;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(iParas.Title))
            {
                if (!iParas.IsIdentity)
                    CtrlHelper.EnableTextBox(txtID);

                CtrlHelper.EnableTextBox(txtName);
                txtID.Text = String.Empty;
                txtName.Text = String.Empty;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                fState = FormState.New;
                tsbAdd.Enabled = false;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(iParas.Title))
            {
                if (String.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("您没有选择需要修改的数据。" + StringHelper.WriteEnter() + "请双击列表中的数据再进行修改操作！", PublicConsts.PC_Tip);
                    return;
                }

                CtrlHelper.EnableTextBox(txtID);
                CtrlHelper.EnableTextBox(txtName);
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                fState = FormState.Edit;
                tsbEdit.Enabled = false;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(iParas.Title))
            {
                if ((fState == FormState.Edit) && (String.IsNullOrEmpty(txtID.Text)))
                {
                    MessageBox.Show(iParas.DisplayName + "编号不能为空！", PublicConsts.PC_Tip);
                    return;
                }

                if (String.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(iParas.DisplayName + "名称不能为空！", PublicConsts.PC_Tip);
                    return;
                }

                iParas.NameValue = txtName.Text;
                if ((!iParas.IsIdentity) || (fState == FormState.Edit))
                    iParas.IdValue = txtID.Text;

                try
                {
                    if (fState == FormState.New)
                    {
                        iParas.Add();
                        tsbAdd.Enabled = true;
                    }
                    else
                    {
                        iParas.Edit();
                        tsbEdit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("系统错误：" + ex.Message, PublicConsts.PC_Tip);
                    return;
                }

                txtID.Text = String.Empty;
                CtrlHelper.DisableTextBox(txtID);
                txtName.Text = String.Empty;
                CtrlHelper.DisableTextBox(txtName);
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                fState = FormState.List;

                OnBindData();
            }
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(iParas.Title))
                return;

            try
            {
                FileHelper.InitSaveExcelDialog(sfdExcel, iParas.Title);
                if (sfdExcel.ShowDialog() == DialogResult.OK)
                {
                    FileHelper.ExportToExcel(dgvMain, sfdExcel.FileName);
                    MessageBox.Show("导出成功！", PublicConsts.PC_Tip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出错误：" + ex.Message, PublicConsts.PC_Tip);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvMain.SelectedRows)
            {
                iParas.IdValue = item.Cells[0].Value.ToString();
                dgvMain.Rows.RemoveAt(item.Index);
                iParas.Del();
            }
        }

    }
}
