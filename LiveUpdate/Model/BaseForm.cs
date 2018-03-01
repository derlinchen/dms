using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace LiveUpdate
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
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

      this.ImeMode = ImeMode.OnHalf;
    }

    private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((this.ActiveControl != null) && !this.ActiveControl.GetType().ToString().Contains("Button")  && !this.ActiveControl.GetType().ToString().Contains("DataGridView") && (e.KeyChar == (char)13))
      {
        if (this.ActiveControl is TextBox)
        {
          if (((TextBox)this.ActiveControl).Multiline)
            return;
        }

        SendKeys.Send("{TAB}");        
      }
    }
  }
}