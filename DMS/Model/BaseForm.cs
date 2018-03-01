using GuFun.Utils;
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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));

            ChangeImeMode();

            // 设计期间不运行
            if (!DesignMode)
                this.BackColor = StringHelper.GetColor(ConfigurationManager.AppSettings[PublicConsts.PC_MdiBackColor]);

            this.ImeMode = ImeMode.OnHalf;
        }
        
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
        public const int IME_CMODE_FULLSHAPE = 0x8;
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

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

        private void BaseForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            if (e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals(""))
            {

            }
        }

        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BaseForm_ImeModeChanged(object sender, EventArgs e)
        {
            ChangeImeMode();
        }

        public void ControlEnter(object sender, EventArgs e)
        {
            ChangeImeMode((Control)sender);
        }

        public void ControlKeyEnter(object sender, KeyPressEventArgs e)
        {
            ChangeImeMode((Control)sender);
        }

        private void ChangeImeMode(Control ctl)
        {
            IntPtr HIme = ImmGetContext(ctl.Handle);
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

        private void ChangeImeMode()
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

    }
}
