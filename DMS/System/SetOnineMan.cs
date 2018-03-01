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
    public partial class SetOnineMan : DMS.BaseDialogForm
    {
        public SetOnineMan()
        {
            InitializeComponent();
            btnDelOnlineMan.BackColor = SystemColors.Control;
            btnExit.BackColor = SystemColors.Control;
            this.Text = "删除在线状态";
        }

        private void btnDelOnlineMan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtManID.Text))
            {
                Global.ShowSysInfo("需要进行删除在线状态的员工工号不能为空！");
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
                        throw new Exception("只能对本部门的员工进行在线状态解除！");
                }

                SqlBaseProvider.DeleteOnlineMan(txtManID.Text, Program.ManInfo.Man.ManID);

                Global.ShowSysInfo("员工[" + item.ManID + "：" + item.ManName + "]在线状态解除成功！");
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
