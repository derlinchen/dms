using GuFun.Utils;
using GuFun.WinControls;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DMS
{
    public static class Global
    {
        public static Form GetForm(string classname, params object[] createParams)
        {
            Type formType = Type.GetType(classname);
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == formType)
                {
                    return (Form)item;
                }
            }
            return (Form)Activator.CreateInstance(formType, createParams);
        }

        public static void ShowSysError(Exception ex)
        {
            if (ex is SqlException)
            {
                if ((((SqlException)ex).Number == 2601) || (((SqlException)ex).Number == 2627))
                {
                    MessageBox.Show("系统出错：存在重复数据，请核实！", PublicConsts.PC_Tip);
                    return;
                }
            }

            MessageBox.Show("系统出错：" + StringHelper.WriteEnter(1) + ex.Message, PublicConsts.PC_Tip);
        }

        public static void ShowSysInfo(string info)
        {
            MessageBox.Show(info, PublicConsts.PC_Tip);
        }


        public static void DisableComboxTree(ExComboTree ect)
        {
            ect.DisableBackColor = Color.FromArgb(225, 192, 116);
            ect.ForeColor = Color.FromArgb(0, 0, 0);
            ect.Enabled = false;
        }

        public static void EnableComboxTree(ExComboTree ect)
        {
            ect.DisableBackColor = Color.FromArgb(255, 255, 255);
            ect.ForeColor = Color.FromArgb(0, 0, 0);
            ect.Enabled = true;
        }

    }
}
