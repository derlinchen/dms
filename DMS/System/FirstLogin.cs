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
    public partial class FirstLogin : DMS.BaseDialogForm
    {
        public FirstLogin()
        {
            InitializeComponent();
            btnOk.BackColor = SystemColors.Control;
            btnCancel.BackColor = SystemColors.Control;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Program.NowLoginMan))
            {
                Global.ShowSysInfo("密码修改人未知！");
                return;
            }

            if (String.IsNullOrEmpty(txtOld.Text))
            {
                Global.ShowSysInfo("原密码不能为空！");
                return;
            }

            if (String.IsNullOrEmpty(txtNew.Text))
            {
                Global.ShowSysInfo("新密码不能为空！");
                return;
            }

            if (String.IsNullOrEmpty(txtReNew.Text))
            {
                Global.ShowSysInfo("确认新密码不能为空！");
                return;
            }

            if (txtOld.Text == txtNew.Text)
            {
                Global.ShowSysInfo("新密码和旧密码不能重复！");
                return;
            }

            if (txtNew.Text != txtReNew.Text)
            {
                Global.ShowSysInfo("新密码和确认新密码不一致！");
                return;
            }

            if (!SqlBaseProvider.ValidPassword(Program.NowLoginMan, txtOld.Text))
            {
                Global.ShowSysInfo("原密码输入错误！");
                return;
            }

            try
            {
                SqlBaseProvider.FirstLogin(Program.NowLoginMan, Crypto.MD5Crypto(txtNew.Text));

                Global.ShowSysInfo("密码修改成功！");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }
    }
}
