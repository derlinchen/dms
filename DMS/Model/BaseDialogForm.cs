using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class BaseDialogForm : DMS.BaseForm
    {
        public BaseDialogForm()
        {
            InitializeComponent();
        }

        //private void BaseDialogForm_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((this.ActiveControl != null) && !this.ActiveControl.GetType().ToString().Contains("Button") && !this.ActiveControl.GetType().ToString().Contains("DataGridView") && (e.KeyChar == (char)13))
        //    {
        //        if (this.ActiveControl is TextBox)
        //        {
        //            if (((TextBox)this.ActiveControl).Multiline)
        //                return;
        //        }

        //        SendKeys.Send("{TAB}");
        //    }
        //}
    }
}
