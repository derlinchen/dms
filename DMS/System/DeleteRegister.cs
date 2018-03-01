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
    public partial class DeleteRegister : DMS.BaseDialogForm
    {
        public DeleteRegister()
        {
            InitializeComponent();
            btnDelReg.BackColor = SystemColors.Control;
            btnExit.BackColor = SystemColors.Control;

            this.Text = "删除注册信息";
        }

        private void btnDelReg_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRegNum.Text))
            {
                Global.ShowSysInfo("注册号不能为空！");
                return;
            }

            try
            {
                SysRegister rg = SqlBaseProvider.GetSysRegister(txtRegNum.Text);

                if (rg.RegID <= 0)
                    throw new Exception("未找到注册号为[" + txtRegNum.Text + "]的注册信息！");

                short ml = SqlBaseProvider.GetSetManLevel();

                if (Program.ManInfo.Man.ManLevel >= ml)
                {
                    if (Program.ManInfo.Man.DeptID != rg.DeptID)
                        throw new Exception("只能对本部门的注册终端进行注销！");
                }

                SqlBaseProvider.SaveSysRegister(rg, DataProviderAction.Delete);

                Global.ShowSysInfo("注册号为[" + txtRegNum.Text + "]的注册信息删除成功！");
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
