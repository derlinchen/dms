using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExTextBox : TextBox
  {
    public ExTextBox()
    {
      InitializeComponent();
    }

    public ExTextBox(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }

    private string _codeText;

    public string CodeText
    {
      get { return _codeText; }
      set { _codeText = value; }
    }

    private string _nameText;

    public string NameText
    {
      get { return _nameText; }
      set 
      { 
        _nameText = value;
        if (String.IsNullOrEmpty(this.Text))
          this.Text = value;
      }
    }

    protected override void OnLostFocus(EventArgs e)
    {
      this.Text = this.NameText;
      base.OnLostFocus(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      this.Text = this.CodeText;
      base.OnGotFocus(e);
    }
  }
}
