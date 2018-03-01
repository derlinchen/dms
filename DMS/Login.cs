using GuFun.Utils;
using GuFun.WinCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class Login : Form
    {
        private bool isCheck;

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref   int lpdw, ref   int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            IntPtr HIme = ImmGetContext(this.Handle);
            //如果输入法处于打开状态              
            if (ImmGetOpenStatus(HIme))
            {
                int iMode = 0;
                int iSentence = 0;
                //检索输入法信息                   
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);
                if (bSuccess)
                {
                    //如果是全角,转换成半角                      
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);
                }
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Publics.GetRegisterNumber(Program.CpuInfo), "查看注册码");
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((this.DialogResult != DialogResult.OK) && (this.DialogResult != DialogResult.Yes))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Login_ImeModeChanged(object sender, EventArgs e)
        {
            IntPtr HIme = ImmGetContext(this.Handle);
            //如果输入法处于打开状态              
            if (ImmGetOpenStatus(HIme))
            {
                int iMode = 0;
                int iSentence = 0;
                //检索输入法信息                   
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);
                if (bSuccess)
                {
                    //如果是全角,转换成半角                      
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            IntPtr HIme = ImmGetContext(this.Handle);
            //如果输入法处于打开状态              
            if (ImmGetOpenStatus(HIme))
            {
                int iMode = 0;
                int iSentence = 0;
                //检索输入法信息                   
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);
                if (bSuccess)
                {
                    //如果是全角,转换成半角                      
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);
                }
            }

            this.ImeMode = ImeMode.OnHalf;

            isCheck = false;

            chbRemember.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["IsRememberMe"]);

            if (chbRemember.Checked)
            {
                txtManID.Text = ConfigurationManager.AppSettings["RememberUser"];
            }

            CtrlHelper.SetEnterToTab(txtManID);
            CtrlHelper.SetEnterToTab(txtPassword);

            pLogin.Left = 0;
            pLogin.Top = 0;
            this.Width = pLogin.Width;
            this.Height = pLogin.Height;
        }

        private void chbRemember_Click(object sender, EventArgs e)
        {
            // 选择保存时候取反
            isCheck = !isCheck;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtManID.Text))
                {
                    MessageBox.Show("用户名不能为空！", PublicConsts.PC_Tip);
                    txtManID.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("密码不能为空！", PublicConsts.PC_Tip);
                    txtPassword.Focus();
                    return;
                }

                SysOnline so = SqlBaseProvider.GetSysOnline(txtManID.Text);

                if (!String.IsNullOrEmpty(so.ManID))
                {
                    MessageBox.Show("您的用户名已经登陆，不能重复登录！", PublicConsts.PC_Tip);
                    txtManID.Focus();
                    return;
                }

                UserCache uc = SqlBaseProvider.GetLoginInfo(txtManID.Text, String.Empty, String.Empty);

                if (String.IsNullOrEmpty(uc.Company.CoID) || String.IsNullOrEmpty(uc.Dept.DeptID) || String.IsNullOrEmpty(uc.Man.ManID))
                {
                    MessageBox.Show("您的员工资料不正确，不能登录本系统！", PublicConsts.PC_Tip);
                    txtManID.Focus();
                    return;
                }

                if (Crypto.MD5Crypto(txtPassword.Text) != uc.Man.OperPassword)
                {
                    MessageBox.Show("密码输入错误，请核实！", PublicConsts.PC_Tip);
                    txtPassword.Focus();
                    txtPassword.Text = String.Empty;
                    return;
                }

                //Program.ManInfo = uc;

                if (uc.Man.IsFirst)
                {
                    MessageBox.Show("您的用户名第一次登录本系统，请修改原始密码后重新登录！", PublicConsts.PC_Tip);
                    txtPassword.Text = String.Empty;
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    SysRegister sr = SqlBaseProvider.GetSysRegister(Publics.GetRegisterNumber(Program.CpuInfo));

                    short ml = SqlBaseProvider.GetSetManLevel();

                    if (uc.Man.IsLock)
                    {
                        Global.ShowSysInfo("您的用户名被锁定，不能登录系统！" + StringHelper.WriteEnter(1) + "请与部门负责人或者系统管理员联系进行解锁！");
                        txtManID.Focus();
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    so.ManID = txtManID.Text;
                    so.RegID = sr.RegID;

                    SqlBaseProvider.LoginSysOnline(so, DataProviderAction.Create);


                    Publics.UpdateConfig(Application.ExecutablePath, "IsRememberMe", chbRemember.Checked.ToString());
                    Publics.UpdateConfig(Application.ExecutablePath, "RememberUser", txtManID.Text);
                    ConfigurationManager.RefreshSection("appSettings");

                    uc.Register = sr;
                    Program.ManInfo = uc;

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PublicConsts.PC_Tip);
                return;
            }
        }

    }
}
