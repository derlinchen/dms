using GuFun.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class DBConfig : Form
    {
        public DBConfig()
        {
            InitializeComponent();

            this.Text = "数据库配置";
            btnCancel.BackColor = SystemColors.Control;
            btnSave.BackColor = SystemColors.Control;
            btnTest.BackColor = SystemColors.Control;
        }

        public string ConnetionString = DBUtils.GetConnectionString();

        private void DBConfig_Load(object sender, EventArgs e)
        {
            string connstr = ConnetionString.Substring(0, ConnetionString.IndexOf(';')).Replace("Data Source=", "");

            if (connstr.ToLower() == "(local)")
            {
                txtIp.Text = "127.0.0.1";
                txtPort.Text = "1433";
            }
            else
            {
                if (connstr.IndexOf(',') > 0)
                {
                    txtIp.Text = connstr.Substring(0, connstr.IndexOf(','));
                    txtPort.Text = connstr.Substring(connstr.IndexOf(',') + 1);
                }
                else
                {
                    txtIp.Text = connstr;
                    txtPort.Text = "1433";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt32(txtPort.Text);
            }
            catch (Exception)
            {
                Global.ShowSysInfo("端口号必须为整数！");
                return;
            }

            string ip = txtIp.Text.Replace(" ", "");

            if (ip == "127.0.0.1")
            {
                ip = "(local)";
            }
            else
            {
                if (txtPort.Text != "1433")
                    ip += "," + txtPort.Text;
            }

            string newconn = ConnetionString.Substring(0, ConnetionString.IndexOf('=') + 1) + ip + ConnetionString.Substring(ConnetionString.IndexOf(';'));

            string sConnection = ConfigurationManager.AppSettings["ConnectionString"];

            Publics.UpdateConfig(Application.ExecutablePath, sConnection, Crypto.EncryptString(newconn));
            ConfigurationManager.RefreshSection("appSettings");

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt32(txtPort.Text);
            }
            catch (Exception)
            {
                Global.ShowSysInfo("端口号必须为整数！");
                return;
            }
            string ip = txtIp.Text.Replace(" ", "");

            if (ip == "127.0.0.1")
            {
                ip = "(local)";
            }
            else
            {
                if (txtPort.Text != "1433")
                    ip += "," + txtPort.Text;
            }
            string newconn = ConnetionString.Substring(0, ConnetionString.IndexOf('=') + 1) + ip + ConnetionString.Substring(ConnetionString.IndexOf(';'));

            try
            {
                SqlConnection conn = DBUtils.GetConnection(newconn, DBUtils.GetDatabaseType());

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    Global.ShowSysInfo("指定的数据库连接成功！");
                }
                else
                    throw new Exception("指定的数据库不存在或者数据库配置错误！");
            }
            catch (Exception)
            {
                Global.ShowSysInfo("指定的数据库不存在或者数据库配置错误！");
            }
        }
    }
}
