using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;

namespace GuFun.WinControls
{
  public partial class ShortcutButton : System.Windows.Forms.Button
  {
    private Timer display = new Timer();

    private Image _sOver;
    private Image _sDisable;
    private Image _sBack;
    private Image _sNormal;
    private Image _sClick;
    private Image _sFade;

    int fade = 0;
    int transparence = 255;
    bool bfade = true;

    // 构造函数
    public ShortcutButton()
    {
      this.BackColor = Color.Transparent;
      this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.FlatAppearance.BorderSize = 0;
      this.TextAlign = ContentAlignment.BottomCenter;
      this.ImageAlign = ContentAlignment.TopCenter;
      display.Interval = 10;
      display.Tick += new EventHandler(Time_Tick);
      this.BackgroundImage = this.SNormal;
    }

    // 公共属性
    [Category("外观")]
    public Image SOver
    {
      get {
        if (_sOver == null)
          _sOver = Image.FromStream(typeof(ShortcutButton).Assembly.GetManifestResourceStream("GuFun.WinControls.ShortcutButton.Resources.SB_Over.png"));

        return _sOver; 
      }

      set { _sOver = value; }
    }

    [Category("外观")]
    public Image SNormal
    {
      get
      {
        if (_sNormal == null)
          _sNormal = Image.FromStream(typeof(ShortcutButton).Assembly.GetManifestResourceStream("GuFun.WinControls.ShortcutButton.Resources.SB_Normal.png"));

        return _sNormal;
      }

      set { _sNormal = value; }
    }

    [Category("外观")]
    public Image SBack
    {
      get
      {
        if (_sBack == null)
          _sBack = Image.FromStream(typeof(ShortcutButton).Assembly.GetManifestResourceStream("GuFun.WinControls.ShortcutButton.Resources.SB_Back.png"));

        return _sBack;
      }

      set { _sBack = value; }
    }

    [Category("外观")]
    public Image SDisable
    {
      get
      {
        if (_sDisable == null)
          _sDisable = Image.FromStream(typeof(ShortcutButton).Assembly.GetManifestResourceStream("GuFun.WinControls.ShortcutButton.Resources.SB_Disable.png"));

        return _sDisable;
      }

      set { _sDisable = value; }
    }

    [Category("外观")]
    public Image SClick
    {
      get
      {
        if (_sClick == null)
          _sClick = Image.FromStream(typeof(ShortcutButton).Assembly.GetManifestResourceStream("GuFun.WinControls.ShortcutButton.Resources.SB_Click.png"));

        return _sClick;
      }

      set { _sClick = value; }
    }

    // 方法
    private void Time_Tick(object sender, EventArgs e)
    {
      switch (fade)
      {
        case 1:
          {
            if (transparence == 0)
            {
              transparence = 255;
            }
            if (transparence > -1)
            {
              PaintBackground();
              transparence -= 10;
            }
            else
            {
              transparence = 0;
              PaintBackground();
              display.Stop();
            }
            break;
          }
        case 2:
          {
            if (transparence == 0)
            {
              transparence = 255;
            }
            if (transparence > -1)
            {
              PaintBackground();
              transparence -= 10;
            }
            else
            {
              transparence = 0;
              PaintBackground();
              display.Stop();
            }
            break;

          }
      }
    }

    public void PaintBackground()
    {
      Object temp = new object();
      if (fade == 1)
      {
        temp = this.SOver.Clone();
      }
      else if (fade == 2)
      {
        temp = this.SNormal.Clone();
      }

      _sFade = (Image)temp;
      Graphics graph = Graphics.FromImage(_sFade);
      SolidBrush brush = new SolidBrush(Color.FromArgb(transparence, 255, 255, 255));
      graph.FillRectangle(brush, 0, 0, _sFade.Width, _sFade.Height);
      this.BackgroundImage = _sFade;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      if (bfade)
      {
        fade = 1;
        display.Start();
      }
      else
      {
        this.BackgroundImage = this.SOver;
      }
      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      if (bfade) 
      { 
        fade = 2; 
        display.Start(); 
      }
      else
      {
        this.BackgroundImage = this.SNormal;
      }
      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
    {

      this.BackgroundImage = this.SClick;
      base.OnMouseDown(mevent);
    }
    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
    {
      this.BackgroundImage = this.SOver;
      base.OnMouseUp(mevent);
    }
  }
}
