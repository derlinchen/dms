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
    public partial class ResetMan : DMS.BaseDialogForm
    {
        public ResetMan()
        {
            InitializeComponent();
            btnReset.BackColor = SystemColors.Control;
            btnExit.BackColor = SystemColors.Control;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtManID.Text))
            {
                Global.ShowSysInfo("需要进行重置密码的员工工号不能为空！");
                return;
            }

            try
            {
                SysMan item = SqlBaseProvider.GetSysMan(txtManID.Text);

                if (String.IsNullOrEmpty(item.ManID))
                    throw new Exception("未找到编号为[" + txtManID.Text + "]的员工信息！");

                short ml = SqlBaseProvider.GetSetManLevel();

                if (Program.ManInfo.Man.ManLevel >= ml)
                {
                    if (Program.ManInfo.Man.DeptID != item.DeptID)
                        throw new Exception("只能对本部门的员工进行重置密码！");
                }

                SqlBaseProvider.ResetMan(txtManID.Text);

                Global.ShowSysInfo("员工[" + item.ManID + "：" + item.ManName + "]密码重置成功！" + StringHelper.WriteEnter(1) + "新密码为该员工的工号。");
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
            }
        }
    }
}
