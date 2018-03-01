using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public delegate void NodeSelectEventHandler();

  public class ExComboTree : UserControl
  {
    #region Private Fields

    private Panel pnlBack;
    private Panel pnlTree;
    private TextBox tbSelectedValue;
    private ComboTreeButton btnSelect;
    private TreeViewBound tvTreeView;
    private ComboTreeLabel lblSizingGrip;
    private Form frmTreeView;

    private string _branchSeparator;
    private bool _absoluteChildrenSelectableOnly;
    private System.Drawing.Point DragOffset;    

    #endregion

    #region Handler Methods

    public event EventHandler TreeClickChange;

    protected void OnTreeClickChange(EventArgs e)
    {
      if (TreeClickChange != null)
      {
        TreeClickChange(this, e);
      }
    }

    #endregion

    #region Public Properties

    [Browsable(true), 
      Description("Gets the TreeView Nodes Collection"), 
      Category("TreeView"), 
      DesignerSerializationVisibility(DesignerSerializationVisibility.Content), 
      Editor(typeof(TreeNodeCollection), typeof(TreeNodeCollection))]
    public TreeNodeCollection Nodes
    {
      get
      {
        return this.tvTreeView.Nodes;
      }
    }

    [Browsable(true),
      Description("Gets or Sets the TreeView's TextBox"),
      Category("TreeView")]
    public TextBox Box
    {
      get
      {
        return this.tbSelectedValue;
      }
    }

    [Browsable(true),
      Description("Gets or Sets the TreeView's TreeView"),
      Category("TreeView")]
    public TreeViewBound Tree
    {
      get
      {
        return this.tvTreeView;
      }
    }

    [Browsable(true), 
      Description("Gets or Sets The TreeView's Selected Node"), 
      Category("TreeView")]
    public TreeNode SelectedNode
    {
      set
      {
        this.tvTreeView.SelectedNode = value;
      }
    }

    [Browsable(true), 
      Description("Gets or Sets the TreeView's ImageList"), 
      Category("TreeView")]
    public ImageList Imagelist
    {
      get { return this.tvTreeView.ImageList; }
      set { this.tvTreeView.ImageList = value; }
    }

    [Browsable(true), 
      Description("The Text in The ExComboTree Control"), 
      Category("Appearance")]
    public override string Text
    {
      get { return this.tbSelectedValue.Text; }
      set { this.tbSelectedValue.Text = value; }
    }

    [Browsable(true), 
      Description("Gets or Sets the Separator for The Selected Node's Value"), 
      Category("Appearance")]
    public string BranchSeparator
    {
      get { return this._branchSeparator; }
      set
      {
        if (!String.IsNullOrEmpty(value))
        {
          if (value.Length > 0)
            this._branchSeparator = value.Substring(0, 1);
        }
      }
    }

    [Browsable(true),
      Description("Gets or Sets the Absolute Children Selectable Only"), 
      Category("Behavior")]
    public bool AbsoluteChildrenSelectableOnly
    {
      get { return this._absoluteChildrenSelectableOnly; }
      set { this._absoluteChildrenSelectableOnly = value; }
    }

    public Color DisableBackColor
    {
      get
      {
        return pnlBack.BackColor;
      }
      set
      {
        pnlBack.BackColor = value;
        tbSelectedValue.BackColor = pnlBack.BackColor;
      }
    }


    public string SelectValue
    {
      get
      {
        if (this.Tree.SelectedNode != null)
          return ((TreeNodeBound)this.Tree.SelectedNode).Value.ToString();

        return String.Empty;
      }

      set
      {
        TreeNode[] nodes = this.Tree.Nodes.Find(value, true);

        if (nodes.Length > 0)
        {
          this.SelectedNode = nodes[0];
          this.tbSelectedValue.Text = nodes[0].Text;
        }
      }
    }

    #endregion

    #region .ctor

    public ExComboTree()
    {
      InitializeComponent();

      // Initializing Controls
      this.pnlBack = new Panel();
      this.pnlBack.BorderStyle = BorderStyle.Fixed3D;
      this.pnlBack.BackColor = Color.White;
      this.pnlBack.AutoScroll = false;

      this.tbSelectedValue = new TextBox();
      this.tbSelectedValue.BorderStyle = System.Windows.Forms.BorderStyle.None;

      this.btnSelect = new ComboTreeButton();
      this.btnSelect.Click += new EventHandler(ToggleTreeView);
      this.btnSelect.FlatStyle = FlatStyle.Flat;

      this.lblSizingGrip = new ComboTreeLabel();
      this.lblSizingGrip.Size = new Size(9, 9);
      this.lblSizingGrip.BackColor = Color.Transparent;
      this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
      this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
      this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

      this.tvTreeView = new TreeViewBound();
      this.tvTreeView.BorderStyle = BorderStyle.None;
      this.tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
      this.tvTreeView.Location = new Point(0, 0);
      this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
      //this.tvTreeView.Scrollable = false;

      this.frmTreeView = new Form();
      this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
      this.frmTreeView.StartPosition = FormStartPosition.Manual;
      this.frmTreeView.ShowInTaskbar = false;
      this.frmTreeView.BackColor = System.Drawing.SystemColors.Control;

      this.pnlTree = new Panel();
      this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
      this.pnlTree.BackColor = Color.White;

      SetStyle(ControlStyles.DoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw, true);

      tbSelectedValue.ReadOnly = true;
      tbSelectedValue.Cursor = Cursors.Arrow;

      // Adding Controls to UserControl
      this.pnlTree.Controls.Add(this.lblSizingGrip);
      this.pnlTree.Controls.Add(this.tvTreeView);
      this.frmTreeView.Controls.Add(this.pnlTree);
      this.pnlBack.Controls.AddRange(new Control[] { btnSelect, tbSelectedValue });
      this.Controls.Add(this.pnlBack);

      this.DisableBackColor = Color.White;
    }

    #endregion .ctor

    #region Private Methods

    private void RelocateGrip()
    {
      this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
      this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
    }

    private void ToggleTreeView(object sender, EventArgs e)
    {
      if (!this.frmTreeView.Visible)
      {
        Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
        this.frmTreeView.Location = new System.Drawing.Point(CBRect.X, CBRect.Y + this.pnlBack.Height);

        this.frmTreeView.Show();
        this.frmTreeView.BringToFront();

        this.RelocateGrip();
        //this.tbSelectedValue.Text = "";
      }
      else
      {
        this.frmTreeView.Hide();
      }
    }

    public bool ValidateText()
    {
      string ValidatorText = this.Text;
      TreeNodeCollection TNC = this.tvTreeView.Nodes;

      for (int i = 0; i < ValidatorText.Split(this._branchSeparator.ToCharArray()[0]).Length; i++)
      {
        bool NodeFound = false;
        string NodeToFind = ValidatorText.Split(this._branchSeparator.ToCharArray()[0])[i];
        for (int j = 0; j < TNC.Count; j++)
        {
          if (TNC[j].Text == NodeToFind)
          {
            NodeFound = true;
            TNC = TNC[j].Nodes;
            break;
          }
        }

        if (!NodeFound)
          return false;
      }

      return true;
    }

    #endregion Private Methods

    #region Events

    private void SizingGripMouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        int TvWidth, TvHeight;
        TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
        TvWidth = TvWidth + this.DragOffset.X;
        TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
        TvHeight = TvHeight + this.DragOffset.Y;

        if (TvWidth < 50)
          TvWidth = 50;
        if (TvHeight < 50)
          TvHeight = 50;

        this.frmTreeView.Size = new System.Drawing.Size(TvWidth, TvHeight);
        this.pnlTree.Size = this.frmTreeView.Size;
        this.tvTreeView.Size = new System.Drawing.Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width); ;
        RelocateGrip();
      }
    }

    private void SizingGripMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        int OffsetX = System.Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
        int OffsetY = System.Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

        this.DragOffset = new Point(OffsetX, OffsetY);
      }
    }

    private void TreeViewLostFocus(object sender, EventArgs e)
    {
      if (!this.btnSelect.RectangleToScreen(this.btnSelect.ClientRectangle).Contains(Cursor.Position))
        this.frmTreeView.Hide();
    }

    private void TreeViewNodeSelect(object sender, EventArgs e)
    {
      if (this._absoluteChildrenSelectableOnly)
      {
        if (this.tvTreeView.SelectedNode.Nodes.Count == 0)
        {
          //tbSelectedValue.Text = this.tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator);
          if (this.tvTreeView.SelectedValue.ToString() == ComboTreeType.Null.ToString())
            tbSelectedValue.Text = String.Empty;
          else
            tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;
          this.ToggleTreeView(sender, null);
        }
      }
      else
      {
        //tbSelectedValue.Text = this.tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator);
        if (this.tvTreeView.SelectedValue.ToString() == ComboTreeType.Null.ToString())
          tbSelectedValue.Text = String.Empty;
        else
          tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;
        this.ToggleTreeView(sender, null);
      }

      OnTreeClickChange(e);
    }

    private void InitializeComponent()
    {
      this.Name = "ExComboTree";
      this._absoluteChildrenSelectableOnly = true;
      this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);

    }

    private void ComboBoxTree_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
    {
      this.Height = this.tbSelectedValue.Height + 8;
      this.pnlBack.Size = new Size(this.Width, this.Height - 2);

      this.btnSelect.Size = new Size(16, this.Height - 6);
      this.btnSelect.Location = new Point(this.Width - this.btnSelect.Width - 4, 0);

      this.tbSelectedValue.Location = new Point(2, 2);
      this.tbSelectedValue.Width = this.Width - this.btnSelect.Width - 4;

      this.frmTreeView.Size = new Size(this.Width, this.tvTreeView.Height);
      this.pnlTree.Size = this.frmTreeView.Size;
      this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
      this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
      this.RelocateGrip();
    }

    #endregion

    #region ComboTreeLabel

    private class ComboTreeLabel : Label
    {
      /// <summary>
      /// 
      /// </summary>
      public ComboTreeLabel()
      {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="e"></param>
      protected override void OnPaint(PaintEventArgs e)
      {
        base.OnPaint(e);
        System.Windows.Forms.ControlPaint.DrawSizeGrip(e.Graphics, System.Drawing.Color.Black, 1, 0, this.Size.Width, this.Size.Height);
      }
    }

    #endregion

    #region ComboTreeButton

    private class ComboTreeButton : Button
    {
      ButtonState state;

      /// <summary>
      /// 
      /// </summary>
      public ComboTreeButton()
      {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="e"></param>
      protected override void OnMouseDown(MouseEventArgs e)
      {
        state = ButtonState.Pushed;
        base.OnMouseDown(e);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="e"></param>
      protected override void OnMouseUp(MouseEventArgs e)
      {
        state = ButtonState.Normal;
        base.OnMouseUp(e);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="e"></param>
      protected override void OnPaint(PaintEventArgs e)
      {
        base.OnPaint(e);
        System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, 0, 0, this.Width, this.Height, state);
      }
    }

    #endregion

    
  }  
}
