using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace GuFun.WinControls
{
  partial class VistaButton
  {
    /// <summary> 
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region 组件设计器生成的代码

    /// <summary> 
    /// 设计器支持所需的方法 - 不要
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      // 
      // VistaButton
      // 
      this.Name = "VistaButton";
      this.Size = new System.Drawing.Size(75, 75);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.VistaButton_Paint);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyUp);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyDown);
      this.MouseEnter += new System.EventHandler(this.VistaButton_MouseEnter);
      this.MouseLeave += new System.EventHandler(this.VistaButton_MouseLeave);
      this.MouseUp += new MouseEventHandler(VistaButton_MouseUp);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VistaButton_MouseDown);
      this.GotFocus += new EventHandler(VistaButton_MouseEnter);
      this.LostFocus += new EventHandler(VistaButton_MouseLeave);
      this.mFadeIn.Tick += new EventHandler(mFadeIn_Tick);
      this.mFadeOut.Tick += new EventHandler(mFadeOut_Tick);
      this.Resize += new EventHandler(VistaButton_Resize);
    }

    #endregion
  }
}
