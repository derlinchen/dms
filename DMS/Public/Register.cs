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
    public partial class Register : DMS.BaseDialogForm
    {
        public Register()
        {
            InitializeComponent();

            ectDept.Tree.ComboTreeType = GuFun.WinControls.ComboTreeType.None;
            ectDept.Tree.TypeText = "";
            ectDept.Tree.DataSource = SqlBaseProvider.GetSimpleValidDept();
            ectDept.Tree.DisplayMember = "Dept_Name";
            ectDept.Tree.ValueMember = "Dept_ID";
            ectDept.Tree.ParentMember = "Dept_PID";
            ectDept.Tree.Height = 200;
            ectDept.AbsoluteChildrenSelectableOnly = false;

            ctbInfo.BackColor = Color.FromArgb(255, 250, 205);

            btnClose.BackColor = SystemColors.Control;
            btnRegister.BackColor = SystemColors.Control;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ectDept.SelectValue.ToString()))
            {
                MessageBox.Show("您没有选择需要注册的部门，请重新选择！");
                return;
            }

            try
            {
                SysRegister rg = SqlBaseProvider.GetSysRegister(Publics.GetRegisterNumber(Program.CpuInfo));

                if (String.IsNullOrEmpty(rg.DeptID))
                {
                    rg.DeptID = ectDept.SelectValue.ToString();
                    rg.CpuCode = Program.CpuInfo;
                    rg.CrtDate = DateTime.Now;
                    rg.RegNumber = Publics.GetRegisterNumber(Program.CpuInfo);
                    rg.RegCode = rg.RegNumber;

                    SqlBaseProvider.SaveSysRegister(rg, DataProviderAction.Create);

                    if (rg.RegID > 0)
                    {
                        MessageBox.Show("该终端已经在系统里注册成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        throw new Exception("注册时数据库发生错误！");
                }
                else
                {
                    if (rg.DeptID != ectDept.SelectValue.ToString())
                    {
                        MessageBox.Show("该终端已经在系统里被其它部门注册完成，不能被重复注册！");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("该终端已经在系统里注册完成，不需要再次注册，确认后直接进入系统！");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册时产生错误，请与系统管理员联系！" + ex.Message);
                return;
            }    
        }

        private void Register_Load(object sender, EventArgs e)
        {
            lblRegNumber.Text = Publics.GetRegisterNumber(Program.CpuInfo);
        }
    }
}
