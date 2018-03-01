using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExComboBox : ComboBox
  {
    public ExComboBox()
    {
      InitializeComponent();
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
      if (Enabled == false)
      {
        this.OldStyle = this.DropDownStyle;
        string txt = this.Text;
        this.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Text = txt;
      }
      else
      {
        this.DropDownStyle = this.OldStyle;

        if (this.OldStyle == ComboBoxStyle.DropDown)
        {
          if (this.OldItems.Count > 0)
          {
            this.Items.Clear();

            foreach (object item in this.OldItems)
              this.Items.Add(item);

            //this.OldItems.Clear();
          }
        }
      }

      base.OnEnabledChanged(e);
    }

    private ComboBoxStyle _oldStyle = ComboBoxStyle.DropDown;

    public ComboBoxStyle OldStyle
    {
      get { return _oldStyle; }
      set { _oldStyle = value; }
    }

    private ObjectCollection _oldItems;

    public ObjectCollection OldItems
    {
      get
      {
        if (_oldItems == null)
          _oldItems = new ObjectCollection(this);

        return _oldItems;
      }
    }

    private bool _isClearItems = true;

    public bool IsClearItems
    {
      get { return _isClearItems; }
      set { _isClearItems = value; }
    }

    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        if ((!this.Enabled) && (this.OldStyle == ComboBoxStyle.DropDown))
        {
          string a = this.Name;
          if (this.OldItems.Count == 0)
          {
            foreach (object item in this.Items)
              this.OldItems.Add(item);

            this.Items.Clear();
          }
          
          this.Items.Add(value);
        }

        base.Text = value;
      }
    }
  }
}
