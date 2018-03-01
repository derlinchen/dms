using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public partial class ExTabControl : TabControl
  {
    public ExTabControl()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

      this.UpdateStyles();
    }

    private bool m_HideTabs = false;

    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.All)]
    public bool HideTabs
    {
      get { return m_HideTabs; }
      set
      {
        if (m_HideTabs == value) return;

        m_HideTabs = value;

        this.UpdateStyles();
      }
    }

    private Color m_CustomBackColor = SystemColors.Control;

    [Browsable(true)]
    public Color CustomBackColor
    {
      get { return m_CustomBackColor; }
      set { m_CustomBackColor = value; this.Invalidate(); }
    }

    private Color m_CustomBorderColor = SystemColors.Control;

    [Browsable(true)]
    public Color CustomBorderColor
    {
      get { return m_CustomBorderColor; }
      set { m_CustomBorderColor = value; this.Invalidate(); }
    }

    private Color m_CustomFontColor = Color.White;

    [Browsable(true)]
    public Color CustomFontColor
    {
      get { return m_CustomFontColor; }
      set { m_CustomFontColor = value; this.Invalidate(); }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        if (this.HideTabs)
          return new Rectangle(0, 0, Width, Height);

        return base.DisplayRectangle;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      DrawControl(e.Graphics);
    }

    internal void DrawControl(Graphics g)
    {
      if (!Visible)
        return;

      Rectangle TabControlArea = this.ClientRectangle;
      Rectangle TabArea = this.DisplayRectangle;

      Rectangle a = new Rectangle(TabControlArea.Left - 2, TabControlArea.Top, TabControlArea.Width, TabControlArea.Height);
      Brush br = new SolidBrush(this.CustomBackColor);
      g.FillRectangle(br, a);
      br.Dispose();

      int nDelta = 1;

      Pen border = new Pen(this.CustomBorderColor);
      TabArea.Inflate(nDelta, nDelta);
      g.DrawRectangle(border, TabArea);
      border.Dispose();
      
      Region rsaved = g.Clip;
      Rectangle rreg;

      rreg = new Rectangle(TabArea.Left, TabControlArea.Top, TabArea.Width, TabControlArea.Height);

      g.SetClip(rreg);

      for (int i = 0; i < this.TabCount; i++)
        DrawTab(g, this.TabPages[i], i);

      g.Clip = rsaved;

      if (this.SelectedTab != null)
      {
        TabPage tabPage = this.SelectedTab;
        border = new Pen(tabPage.BackColor);

        TabArea.Offset(1, 1);
        TabArea.Width -= 2;
        TabArea.Height -= 2;

        g.DrawRectangle(border, TabArea);
        TabArea.Width -= 1;
        TabArea.Height -= 1;
        g.DrawRectangle(border, TabArea);

        border.Dispose();
      }
    }

    internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
    {
      Rectangle recBounds = this.GetTabRect(nIndex);
      RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);

      bool bSelected = (this.SelectedIndex == nIndex);

      Point[] pt = new Point[7];
      if (this.Alignment == TabAlignment.Top)
      {
        pt[0] = new Point(recBounds.Left + 1, recBounds.Bottom + 1);
        pt[1] = new Point(recBounds.Left + 1, recBounds.Top + 3);
        pt[2] = new Point(recBounds.Left + 4, recBounds.Top);
        pt[3] = new Point(recBounds.Right - 4, recBounds.Top);
        pt[4] = new Point(recBounds.Right -1, recBounds.Top + 3);
        pt[5] = new Point(recBounds.Right - 1, recBounds.Bottom + 1);
        pt[6] = new Point(recBounds.Left + 1, recBounds.Bottom + 1);
      }
      else
      {
        pt[0] = new Point(recBounds.Left, recBounds.Top);
        pt[1] = new Point(recBounds.Right, recBounds.Top);
        pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
        pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
        pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
        pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
        pt[6] = new Point(recBounds.Left, recBounds.Top);
      }

      Brush br = new SolidBrush(tabPage.BackColor);
      g.FillPolygon(br, pt);
      br.Dispose();
      
      //g.DrawRectangle(SystemPens.ControlDark, recBounds);

      Pen poly = new Pen(this.CustomBorderColor);
      g.DrawPolygon(poly, pt);
      poly.Dispose();

      if (bSelected)
      {
        Pen pen = new Pen(tabPage.BackColor);

        switch (this.Alignment)
        {
          case TabAlignment.Top:
            //g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
            g.DrawLine(pen, recBounds.Left + 2, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
            break;

          case TabAlignment.Bottom:
            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
            break;
        }

        pen.Dispose();
      }

      StringFormat stringFormat = new StringFormat();
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Far;

      br = new SolidBrush(this.CustomFontColor);

      g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);      
    }
  }
}
