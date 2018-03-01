using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace GuFun.WinControls
{
  /// <summary>
  /// A replacement for the Windows Button Control.
  /// </summary>
  [DefaultEvent("Click")]
  public partial class VistaButton : System.Windows.Forms.UserControl
  {

    #region -设计-

    /// <summary>
    /// 根据默认值进行初始化
    /// </summary>
    public VistaButton()
    {
      InitializeComponent();

      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.Transparent;
      mFadeIn.Interval = 30;
      mFadeOut.Interval = 30;
    }

    #endregion    

    #region -枚举对象-

    /// <summary>
    /// 私有枚举对象，和当前控件实例相关的鼠标状态
    /// </summary>
    enum State { None, Hover, Pressed };

    /// <summary>
    /// 鼠标不在有效的客户区域里按钮的重画样式
    /// </summary>
    public enum Style
    {
      /// <summary>
      /// Draw the button as normal
      /// </summary>
      Default,
      /// <summary>
      /// Only draw the background on mouse over.
      /// </summary>
      Flat
    };

    #endregion

    #region -属性-

    #region -私有属性-

    private bool calledbykey = false;
    private State mButtonState = State.None;
    private Timer mFadeIn = new Timer();
    private Timer mFadeOut = new Timer();
    private int mGlowAlpha = 0;

    #endregion

    #region -文字属性-

    private string mText;
    /// <summary>
    /// 按钮显示的文字
    /// </summary>
    [Category("Text"),
    Description("按钮显示的文字.")]
    public string ButtonText
    {
      get { return mText; }
      set { mText = value; this.Invalidate(); }
    }

    private Color mForeColor = Color.White;
    /// <summary>
    /// 文字显示的色彩
    /// </summary>
    [Category("Text"),
     Browsable(true),
     DefaultValue(typeof(Color), "White"),
    Description("文字显示的色彩.")]
    public override Color ForeColor
    {
      get { return mForeColor; }
      set { mForeColor = value; this.Invalidate(); }
    }

    private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;
    /// <summary>
    /// 文字的对齐方式
    /// </summary>
    [Category("Text"),
     DefaultValue(typeof(ContentAlignment), "MiddleCenter"),
    Description("文字的对齐方式.")]
    public ContentAlignment TextAlign
    {
      get { return mTextAlign; }
      set { mTextAlign = value; this.Invalidate(); }
    }

    #endregion

    #region -图象属性-

    private Image mImage;
    /// <summary>
    /// 按钮显示的图象
    /// </summary>
    [Category("Image"),
     DefaultValue(null),
    Description("按钮显示的图象.")]
    public Image Image
    {
      get { return mImage; }
      set { mImage = value; this.Invalidate(); }
    }

    private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
    /// <summary>
    /// 图象的对齐方式
    /// </summary>
    [Category("Image"),
     DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
    Description("图象的对齐方式.")]
    public ContentAlignment ImageAlign
    {
      get { return mImageAlign; }
      set { mImageAlign = value; this.Invalidate(); }
    }

    private Size mImageSize = new Size(24, 24);
    /// <summary>
    /// 图象显示的大小
    /// </summary>
    [Category("Image"),
     DefaultValue(typeof(Size), "24, 24"),
    Description("图象显示的大小,默认为24X24.")]
    public Size ImageSize
    {
      get { return mImageSize; }
      set { mImageSize = value; this.Invalidate(); }
    }

    #endregion

    #region -外观-

    private Style mButtonStyle = Style.Default;
    /// <summary>
    /// 按钮的显示样式
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(Style), "Default"),
    Description("按钮的显示样式.")]
    public Style ButtonStyle
    {
      get { return mButtonStyle; }
      set { mButtonStyle = value; this.Invalidate(); }
    }

    private int mCornerRadius = 8;
    /// <summary>
    /// 按钮四边显示的弧度
    /// </summary>
    [Category("Appearance"),
     DefaultValue(8),
    Description("按钮四边显示的弧度.")]
    public int CornerRadius
    {
      get { return mCornerRadius; }
      set { mCornerRadius = value; this.Invalidate(); }
    }

    private Color mHighlightColor = Color.White;
    /// <summary>
    /// 高亮显示的色彩
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "White"),
    Description("高亮显示的色彩.")]
    public Color HighlightColor
    {
      get { return mHighlightColor; }
      set { mHighlightColor = value; this.Invalidate(); }
    }

    private Color mButtonColor = Color.Black;
    /// <summary>
    /// 底部显示的色彩
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "Black"),
    Description("底部显示的色彩.")]
    public Color ButtonColor
    {
      get { return mButtonColor; }
      set { mButtonColor = value; this.Invalidate(); }
    }

    private Color mGlowColor = Color.FromArgb(141, 189, 255);
    /// <summary>
    /// 发光显示的色彩
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "141,189,255"),
    Description("发光显示的色彩.")]
    public Color GlowColor
    {
      get { return mGlowColor; }
      set { mGlowColor = value; this.Invalidate(); }
    }

    private Image mBackImage;
    /// <summary>
    /// 按钮的背景图片
    /// </summary>
    [Category("Appearance"),
     DefaultValue(null),
    Description("按钮的背景图片.")]
    public Image BackImage
    {
      get { return mBackImage; }
      set { mBackImage = value; this.Invalidate(); }
    }

    private Color mBaseColor = Color.Black;
    /// <summary>
    /// 透明效果的底色
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "Black"),
    Description("透明效果的底色.")]
    public Color BaseColor
    {
      get { return mBaseColor; }
      set { mBaseColor = value; this.Invalidate(); }
    }

    private TextImageRelation mTextImageRelation = TextImageRelation.Overlay;
    /// <summary>
    /// 图片和文字的显示方式
    /// </summary>
    [Category("Appearance"),
     DefaultValue(typeof(TextImageRelation), "Overlay"),
     Description("图片和文字的显示方式。")]
    public TextImageRelation TextImageRelation
    {
      get { return mTextImageRelation; }
      set { mTextImageRelation = value; this.Invalidate(); }
    }

    #endregion

    #endregion

    #region -函数-

    private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
    {
      float x = r.X, y = r.Y, w = r.Width, h = r.Height;
      GraphicsPath rr = new GraphicsPath();
      rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
      rr.AddLine(x + r1, y, x + w - r2, y);
      rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
      rr.AddLine(x + w, y + r2, x + w, y + h - r3);
      rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
      rr.AddLine(x + w - r3, y + h, x + r4, y + h);
      rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
      rr.AddLine(x, y + h - r4, x, y + r1);
      return rr;
    }

    private StringFormat StringFormatAlignment(ContentAlignment textalign)
    {
      StringFormat sf = new StringFormat();
      switch (textalign)
      {
        case ContentAlignment.TopLeft:
        case ContentAlignment.TopCenter:
        case ContentAlignment.TopRight:
          sf.LineAlignment = StringAlignment.Near;
          break;
        case ContentAlignment.MiddleLeft:
        case ContentAlignment.MiddleCenter:
        case ContentAlignment.MiddleRight:
          sf.LineAlignment = StringAlignment.Center;
          break;
        case ContentAlignment.BottomLeft:
        case ContentAlignment.BottomCenter:
        case ContentAlignment.BottomRight:
          sf.LineAlignment = StringAlignment.Far;
          break;
      }
      switch (textalign)
      {
        case ContentAlignment.TopLeft:
        case ContentAlignment.MiddleLeft:
        case ContentAlignment.BottomLeft:
          sf.Alignment = StringAlignment.Near;
          break;
        case ContentAlignment.TopCenter:
        case ContentAlignment.MiddleCenter:
        case ContentAlignment.BottomCenter:
          sf.Alignment = StringAlignment.Center;
          break;
        case ContentAlignment.TopRight:
        case ContentAlignment.MiddleRight:
        case ContentAlignment.BottomRight:
          sf.Alignment = StringAlignment.Far;
          break;
      }
      return sf;
    }

    #endregion

    #region -绘制按钮-

    /// <summary>
    /// Draws the outer border for the control
    /// using the ButtonColor property.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawOuterStroke(Graphics g)
    {
      if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
      Rectangle r = this.ClientRectangle;
      r.Width -= 1; r.Height -= 1;
      using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
      {
        using (Pen p = new Pen(this.ButtonColor))
        {
          g.DrawPath(p, rr);
        }
      }
    }

    /// <summary>
    /// Draws the inner border for the control
    /// using the HighlightColor property.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawInnerStroke(Graphics g)
    {
      if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
      Rectangle r = this.ClientRectangle;
      r.X++; r.Y++;
      r.Width -= 3; r.Height -= 3;
      using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
      {
        using (Pen p = new Pen(this.HighlightColor))
        {
          g.DrawPath(p, rr);
        }
      }
    }

    /// <summary>
    /// Draws the background for the control
    /// using the background image and the 
    /// BaseColor.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawBackground(Graphics g)
    {
      if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
      int alpha = (mButtonState == State.Pressed) ? 204 : 127;
      Rectangle r = this.ClientRectangle;
      r.Width--; r.Height--;
      using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
      {
        using (SolidBrush sb = new SolidBrush(this.BaseColor))
        {
          g.FillPath(sb, rr);
        }
        SetClip(g);
        if (this.BackImage != null) { g.DrawImage(this.BackImage, this.ClientRectangle); }
        g.ResetClip();
        using (SolidBrush sb = new SolidBrush(Color.FromArgb(alpha, this.ButtonColor)))
        {
          g.FillPath(sb, rr);
        }
      }
    }

    /// <summary>
    /// Draws the Highlight over the top of the
    /// control using the HightlightColor.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawHighlight(Graphics g)
    {
      if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
      int alpha = (mButtonState == State.Pressed) ? 60 : 150;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height / 2);
      using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
      {
        using (LinearGradientBrush lg = new LinearGradientBrush(r.GetBounds(),
                      Color.FromArgb(alpha, this.HighlightColor),
                      Color.FromArgb(alpha / 3, this.HighlightColor),
                      LinearGradientMode.Vertical))
        {
          g.FillPath(lg, r);
        }
      }
    }

    /// <summary>
    /// Draws the glow for the button when the
    /// mouse is inside the client area using
    /// the GlowColor property.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawGlow(Graphics g)
    {
      if (this.mButtonState == State.Pressed) { return; }
      SetClip(g);
      using (GraphicsPath glow = new GraphicsPath())
      {
        glow.AddEllipse(-5, this.Height / 2 - 10, this.Width + 11, this.Height + 11);
        using (PathGradientBrush gl = new PathGradientBrush(glow))
        {
          gl.CenterColor = Color.FromArgb(mGlowAlpha, this.GlowColor);
          gl.SurroundColors = new Color[] { Color.FromArgb(0, this.GlowColor) };
          g.FillPath(gl, glow);
        }
      }
      g.ResetClip();
    }

    /// <summary>
    /// Draws the text for the button.
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawText(Graphics g)
    {
      StringFormat sf = StringFormatAlignment(this.TextAlign);
      Rectangle r = new Rectangle(8, 8, this.Width - 17, this.Height - 17);
      g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
    }

    /// <summary>
    /// Draws the image for the button
    /// </summary>
    /// <param name="g">The graphics object used in the paint event.</param>
    private void DrawImage(Graphics g)
    {
      if (this.Image == null) { return; }
      Rectangle r = new Rectangle(8, 8, this.ImageSize.Width, this.ImageSize.Height);
      switch (this.ImageAlign)
      {
        case ContentAlignment.TopCenter:
          r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, 8, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.TopRight:
          r = new Rectangle(this.Width - 8 - this.ImageSize.Width, 8, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.MiddleLeft:
          r = new Rectangle(8, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.MiddleCenter:
          r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.MiddleRight:
          r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.BottomLeft:
          r = new Rectangle(8, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.BottomCenter:
          r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
          break;
        case ContentAlignment.BottomRight:
          r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
          break;
      }
      g.DrawImage(this.Image, r);
    }

    private void DrawButton(Graphics g)
    {
      Size btnSize = Size.Empty;
      Size txtSize = TextRenderer.MeasureText(this.ButtonText, this.Font);
      Size imgSize = this.Image != null ? this.Image.Size : Size.Empty;

      if (!String.IsNullOrEmpty(this.ButtonText) && (this.ButtonText.Length > 0))
      {
        txtSize.Height += 4;
        txtSize.Width += 4;
      }

      StringFormat sf = StringFormatAlignment(ContentAlignment.MiddleCenter);
      Rectangle r = new Rectangle(8, 8, btnSize.Width, btnSize.Height);

      switch (this.TextImageRelation)
      {
        case TextImageRelation.Overlay:
          DrawImage(g);
          DrawText(g);
          break;

        // 当样式选为考虑图形和文字共同处理时，我们只在中间区域进行显示
        case TextImageRelation.ImageAboveText:
        case TextImageRelation.TextAboveImage:
          btnSize.Height = txtSize.Height + imgSize.Height;
          btnSize.Width = Math.Max(txtSize.Width, imgSize.Width);

          if (this.Image == null)
          {
            r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, btnSize.Width, btnSize.Height);
            g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
          }
          else
          {
            if (this.TextImageRelation == TextImageRelation.ImageAboveText)
            {
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, btnSize.Width, imgSize.Height);
              g.DrawImage(this.Image, r);
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2 + imgSize.Height, btnSize.Width, txtSize.Height);
              g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
            }
            else
            {
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, btnSize.Width, txtSize.Height);
              g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2 + txtSize.Height, btnSize.Width, imgSize.Height);
              g.DrawImage(this.Image, r);
            }
          }
          break;

        case TextImageRelation.ImageBeforeText:
        case TextImageRelation.TextBeforeImage:
          btnSize.Height = Math.Max(txtSize.Height, imgSize.Height);
          btnSize.Width = txtSize.Width + imgSize.Width;

          if (this.Image == null)
          {
            r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, btnSize.Width, btnSize.Height);
            g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
          }
          else
          {
            if (this.TextImageRelation == TextImageRelation.ImageBeforeText)
            {
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, imgSize.Width, btnSize.Height);
              g.DrawImage(this.Image, r);
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2 + imgSize.Width, this.Height / 2 - btnSize.Height / 2, txtSize.Width, btnSize.Height);
              g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
            }
            else
            {
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2, this.Height / 2 - btnSize.Height / 2, txtSize.Width, btnSize.Height);
              g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
              r = new Rectangle(this.Width / 2 - btnSize.Width / 2 + txtSize.Width, this.Height / 2 - btnSize.Height / 2, imgSize.Width, btnSize.Height);
              g.DrawImage(this.Image, r);
            }
          }

          break;
      }
    }

    private void SetClip(Graphics g)
    {
      Rectangle r = this.ClientRectangle;
      r.X++; r.Y++; r.Width -= 3; r.Height -= 3;
      using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
      {
        g.SetClip(rr);
      }
    }

    #endregion

    #region -私有方法-

    private void VistaButton_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      DrawBackground(e.Graphics);
      DrawHighlight(e.Graphics);
      DrawButton(e.Graphics);
      DrawGlow(e.Graphics);
      DrawOuterStroke(e.Graphics);
      DrawInnerStroke(e.Graphics);
    }

    private void VistaButton_Resize(object sender, EventArgs e)
    {
      Rectangle r = this.ClientRectangle;
      r.X -= 1; r.Y -= 1;
      r.Width += 2; r.Height += 2;
      using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
      {
        this.Region = new Region(rr);
      }
    }

    #region -  Mouse and Keyboard Events  -

    private void VistaButton_MouseEnter(object sender, EventArgs e)
    {
      mButtonState = State.Hover;
      mFadeOut.Stop();
      mFadeIn.Start();
    }
    private void VistaButton_MouseLeave(object sender, EventArgs e)
    {
      mButtonState = State.None;
      if (this.mButtonStyle == Style.Flat) { mGlowAlpha = 0; }
      mFadeIn.Stop();
      mFadeOut.Start();
    }

    private void VistaButton_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        mButtonState = State.Pressed;
        if (this.mButtonStyle != Style.Flat) { mGlowAlpha = 255; }
        mFadeIn.Stop();
        mFadeOut.Stop();
        this.Invalidate();
      }
    }

    private void mFadeIn_Tick(object sender, EventArgs e)
    {
      if (this.ButtonStyle == Style.Flat) { mGlowAlpha = 0; }
      if (mGlowAlpha + 30 >= 255)
      {
        mGlowAlpha = 255;
        mFadeIn.Stop();
      }
      else
      {
        mGlowAlpha += 30;
      }
      this.Invalidate();
    }

    private void mFadeOut_Tick(object sender, EventArgs e)
    {
      if (this.ButtonStyle == Style.Flat) { mGlowAlpha = 0; }
      if (mGlowAlpha - 30 <= 0)
      {
        mGlowAlpha = 0;
        mFadeOut.Stop();
      }
      else
      {
        mGlowAlpha -= 30;
      }
      this.Invalidate();
    }

    private void VistaButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Space)
      {
        MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
        VistaButton_MouseDown(sender, m);
      }
    }

    private void VistaButton_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Space)
      {
        MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
        calledbykey = true;
        VistaButton_MouseUp(sender, m);
      }
    }

    private void VistaButton_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        mButtonState = State.Hover;
        mFadeIn.Stop();
        mFadeOut.Stop();
        this.Invalidate();
        if (calledbykey == true) { this.OnClick(EventArgs.Empty); calledbykey = false; }
      }
    }

    #endregion

    #endregion

  }
}
