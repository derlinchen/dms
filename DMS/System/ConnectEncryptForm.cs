using GuFun.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class ConnectEncryptForm : DMS.BaseDialogForm
    {
        public ConnectEncryptForm()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtServer.Text))
                {
                    Global.ShowSysInfo("请输入服务器地址");
                    return;
                }

                if (String.IsNullOrEmpty(txtDBName.Text))
                {
                    Global.ShowSysInfo("请输入数据库名称");
                    return;
                }

                if (String.IsNullOrEmpty(txtDBUser.Text))
                {
                    Global.ShowSysInfo("请输入用户名");
                    return;
                }

                if (String.IsNullOrEmpty(txtDBPassword.Text))
                {
                    Global.ShowSysInfo("请输入密码");
                    return;
                }

                txtResult.Text = CryptoHelper.EncryptString("Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDBName.Text + ";User Id=" + txtDBUser.Text + ";Password=" + txtDBPassword.Text + ";");

                txtResult.Focus();
                txtResult.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
			{
                if (String.IsNullOrEmpty(txtResult.Text))
                {
                    Global.ShowSysInfo("请输入加密结果进行解密");
                    return;
                }

				String[] results = CryptoHelper.DecryptoString(txtResult.Text).Split(';');

				if ((results.Length > 0) && (results[0].IndexOf("=") >= 0))
					txtServer.Text = results[0].Substring(results[0].IndexOf("=") + 1);

				if ((results.Length > 1) && (results[1].IndexOf("=") >= 0))
					txtDBName.Text = results[1].Substring(results[1].IndexOf("=") + 1);

				if ((results.Length > 2) && (results[2].IndexOf("=") >= 0))
					txtDBUser.Text = results[2].Substring(results[2].IndexOf("=") + 1);

				if ((results.Length > 3) && (results[3].IndexOf("=") >= 0))
					txtDBPassword.Text = results[3].Substring(results[3].IndexOf("=") + 1);
			}
            catch (Exception)
            {

                throw;
            }  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
