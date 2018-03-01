using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Drawing.Drawing2D;

namespace GuFun.WinControls
{
  public class ExDataGridViewTextBoxCell : DataGridViewTextBoxCell
  {
    #region Fields

    private int _columnSpan = 1;
    private int _rowSpan = 1;
    private ExDataGridViewTextBoxCell _ownerCell;

    #endregion

    #region Properties

    public int ColumnSpan
    {
      get { return _columnSpan; }
      set
      {
        if (this.DataGridView == null || _ownerCell != null)
          return;

        if (value < 1 || this.ColumnIndex + value - 1 >= this.DataGridView.ColumnCount)
          throw new System.ArgumentOutOfRangeException("value");

        if (_columnSpan != value)
          SetSpan(value, _rowSpan);
      }
    }
    public int RowSpan
    {
      get { return _rowSpan; }
      set
      {
        if (this.DataGridView == null || _ownerCell != null)
          return;

        if (value < 1 || this.RowIndex + value - 1 >= this.DataGridView.RowCount)
          throw new System.ArgumentOutOfRangeException("value");

        if (_rowSpan != value)
          SetSpan(_columnSpan, value);
      }
    }

    public ExDataGridViewTextBoxCell OwnerCell
    {
      get { return _ownerCell; }
      private set { _ownerCell = value; }
    }

    public override bool ReadOnly
    {
      get
      {
        return base.ReadOnly;
      }
      set
      {
        base.ReadOnly = value;

        if (_ownerCell == null && (_columnSpan > 1 || _rowSpan > 1) && this.DataGridView != null)
        {
          for (int col = this.ColumnIndex; col < this.ColumnIndex + _columnSpan; col++)
          {
            for (int row = this.RowIndex; row < this.RowIndex + _rowSpan; row++)
            {
              if (col != this.ColumnIndex || row != this.RowIndex)
              {
                this.DataGridView[col, row].ReadOnly = value;
              }
            }
          }
        }
      }
    }

    #endregion

    #region .ctor

    public ExDataGridViewTextBoxCell()
    {

    } 

    #endregion

    #region Painting

    private void InternalPaint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
      base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    }

    protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
      if (_ownerCell != null && _ownerCell.DataGridView == null)
        _ownerCell = null; //owner cell was removed.

      if (this.DataGridView == null || (_ownerCell == null && _columnSpan == 1 && _rowSpan == 1))
      {
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        return;
      }

        ExDataGridViewTextBoxCell ownerCell = this;
        int columnIndex = this.ColumnIndex;
        int columnSpan = _columnSpan;
        int rowSpan = _rowSpan;
        if (_ownerCell != null)
        {
          ownerCell = _ownerCell;
          columnIndex = _ownerCell.ColumnIndex;
          rowIndex = _ownerCell.RowIndex;
          columnSpan = _ownerCell.ColumnSpan;
          rowSpan = _ownerCell.RowSpan;
          value = _ownerCell.GetValue(rowIndex);
          errorText = _ownerCell.GetErrorText(rowIndex);
          cellState = _ownerCell.State;
          cellStyle = _ownerCell.GetInheritedStyle(null, rowIndex, true);
          formattedValue = _ownerCell.GetFormattedValue(value, rowIndex, ref cellStyle, null, null, DataGridViewDataErrorContexts.Display);
        }

        if (CellsRegionContainsSelectedCell(columnIndex, rowIndex, columnSpan, rowSpan))
          cellState |= DataGridViewElementStates.Selected;

        cellBounds = GetSpannedCellBoundsFromChildCellBounds(this, cellBounds);
        clipBounds = GetSpannedCellClipBounds(ownerCell, cellBounds);

        using (Graphics g = this.DataGridView.CreateGraphics())
        {
            g.SetClip(clipBounds);
            //Paint the content.
            ownerCell.InternalPaint(g, clipBounds, cellBounds, rowIndex, cellState,
                value, formattedValue, errorText,
                cellStyle, advancedBorderStyle,
                paintParts & ~DataGridViewPaintParts.Border);
            //Paint the borders.
            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                ExDataGridViewTextBoxCell leftTopCell = ownerCell;
                DataGridViewAdvancedBorderStyle advancedBorderStyle2 = new DataGridViewAdvancedBorderStyle();
                advancedBorderStyle2.Left = advancedBorderStyle.Left;
                advancedBorderStyle2.Top = advancedBorderStyle.Top;
                advancedBorderStyle2.Right = DataGridViewAdvancedCellBorderStyle.None;
                advancedBorderStyle2.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                leftTopCell.PaintBorder(g, clipBounds, cellBounds, cellStyle, advancedBorderStyle2);

                ExDataGridViewTextBoxCell rightBottomCell = DataGridView[columnIndex + columnSpan - 1, rowIndex + rowSpan - 1] as ExDataGridViewTextBoxCell;
                if (rightBottomCell == null)
                    rightBottomCell = this;

                DataGridViewAdvancedBorderStyle advancedBorderStyle3 = new DataGridViewAdvancedBorderStyle();
                advancedBorderStyle3.Left = DataGridViewAdvancedCellBorderStyle.None;
                advancedBorderStyle3.Top = DataGridViewAdvancedCellBorderStyle.None;
                advancedBorderStyle3.Right = advancedBorderStyle.Right;
                advancedBorderStyle3.Bottom = advancedBorderStyle.Bottom;

                rightBottomCell.PaintBorder(g, clipBounds, cellBounds, cellStyle, advancedBorderStyle3);
            }
        }
    }

    #endregion

    #region Spanning

    private void SetSpan(int columnSpan, int rowSpan)
    {
      int prevColumnSpan = _columnSpan;
      int prevRowSpan = _rowSpan;
      _columnSpan = columnSpan;
      _rowSpan = rowSpan;

      int rowIndex = 0; int columnIndex = 0;
      if (this.DataGridView != null)
      {
        #region clearing

        for (rowIndex = this.RowIndex; rowIndex < this.RowIndex + prevRowSpan; rowIndex++)
        {
          for (columnIndex = this.ColumnIndex; columnIndex < this.ColumnIndex + prevColumnSpan; columnIndex++)
          {
            ExDataGridViewTextBoxCell cell = this.DataGridView[columnIndex, rowIndex] as ExDataGridViewTextBoxCell;
            if (cell != null)
              cell.OwnerCell = null;
          }
        }

        #endregion

        #region setting

        for (rowIndex = this.RowIndex; rowIndex < this.RowIndex + _rowSpan; rowIndex++)
        {
          for (columnIndex = this.ColumnIndex; columnIndex < this.ColumnIndex + _columnSpan; columnIndex++)
          {
            ExDataGridViewTextBoxCell cell = this.DataGridView[columnIndex, rowIndex] as ExDataGridViewTextBoxCell;
            if (cell != null)
              cell.OwnerCell = this;
          }
        }

        OwnerCell = null;

        #endregion

        this.DataGridView.Invalidate();
      }
    }

    #endregion

    #region Editing

    protected override object GetValue(int rowIndex)
    {
      if (_ownerCell != null)
        return _ownerCell.GetValue(_ownerCell.RowIndex);
      return base.GetValue(rowIndex);
    }

    protected override bool SetValue(int rowIndex, object value)
    {
      if (_ownerCell != null)
        return _ownerCell.SetValue(_ownerCell.RowIndex, value);
      return base.SetValue(rowIndex, value);
    }

    public override Rectangle PositionEditingPanel(Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
    {
      if (_ownerCell == null && _columnSpan == 1 && _rowSpan == 1)
      {
        return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
      }

      int rowIndex = RowIndex;
      ExDataGridViewTextBoxCell ownerCell = this;

      if (_ownerCell != null)
      {
        rowIndex = _ownerCell.RowIndex;
        cellStyle = _ownerCell.GetInheritedStyle(null, rowIndex, true);
        _ownerCell.GetFormattedValue(_ownerCell.Value, rowIndex, ref cellStyle, null, null, DataGridViewDataErrorContexts.Formatting);
        IDataGridViewEditingControl editingControl = this.DataGridView.EditingControl as IDataGridViewEditingControl;
        if (editingControl != null)
        {
          editingControl.ApplyCellStyleToEditingControl(cellStyle);
          Control editingPanel = this.DataGridView.EditingControl.Parent;
          if (editingPanel != null)
            editingPanel.BackColor = cellStyle.BackColor;
        }
        ownerCell = _ownerCell;
      }
      cellBounds = GetSpannedCellBoundsFromChildCellBounds(this, cellBounds);
      cellClip = GetSpannedCellClipBounds(ownerCell, cellBounds);
      return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
    }

    #endregion

    #region Other overridden

    protected override void OnDataGridViewChanged()
    {
      base.OnDataGridViewChanged();

      if (DataGridView == null)
      {
        _columnSpan = 1;
        _rowSpan = 1;
      }
    }
    protected override Rectangle BorderWidths(DataGridViewAdvancedBorderStyle advancedBorderStyle)
    {
      if (_ownerCell == null
          && _columnSpan == 1 && _rowSpan == 1)
      {
        return base.BorderWidths(advancedBorderStyle);
      }

      if (_ownerCell != null)
        return _ownerCell.BorderWidths(advancedBorderStyle);

      Rectangle leftTop = base.BorderWidths(advancedBorderStyle);
      ExDataGridViewTextBoxCell rightBottomCell = this.DataGridView[this.ColumnIndex + ColumnSpan - 1, this.RowIndex + RowSpan - 1] as ExDataGridViewTextBoxCell;
      Rectangle rightBottom = rightBottomCell != null ? rightBottomCell.InternalBorderWidths(advancedBorderStyle) : leftTop;
      return new Rectangle(leftTop.X, leftTop.Y, rightBottom.Width, rightBottom.Height);
    }

    #endregion

    #region Private Methods

    private bool CellsRegionContainsSelectedCell(int columnIndex, int rowIndex, int columnSpan, int rowSpan)
    {
      if (DataGridView == null)
        return false;

      for (int col = columnIndex; col < columnIndex + columnSpan; col++)
      {
        for (int row = rowIndex; row < rowIndex + rowSpan; row++)
        {
          if (this.DataGridView[col, row].Selected)
            return true;
        }
      }

      return false;
    }

    private Rectangle InternalBorderWidths(DataGridViewAdvancedBorderStyle advancedBorderStyle)
    {
      return base.BorderWidths(advancedBorderStyle);
    }

    private static Rectangle GetSpannedCellClipBounds(ExDataGridViewTextBoxCell ownerCell, Rectangle cellBounds)
    {
      DataGridView dataGridView = ownerCell.DataGridView;
      Rectangle clipBounds = cellBounds;

      //Setting X.
      int i = 0;
      for (i = ownerCell.ColumnIndex; i < ownerCell.ColumnIndex + ownerCell._columnSpan; i++)
      {
        DataGridViewColumn columnItem = dataGridView.Columns[i];
        if (!columnItem.Visible)
          continue;

        if (columnItem.Frozen || i > dataGridView.FirstDisplayedScrollingColumnIndex)
        {
          clipBounds.Width += columnItem.Width;
          break;
        }

        if (i == dataGridView.FirstDisplayedScrollingColumnIndex)
        {
          clipBounds.X += dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
          clipBounds.Width += columnItem.Width - dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
          break;
        }
        clipBounds.X += columnItem.Width;
      }
            
      //Setting Y.
      for (i = ownerCell.RowIndex; i < ownerCell.RowIndex + ownerCell._rowSpan; i++)
      {
        DataGridViewRow rowItem = dataGridView.Rows[i];
        if (!rowItem.Visible)
            continue;

        if (rowItem.Frozen || i >= dataGridView.FirstDisplayedScrollingRowIndex)
        {
          clipBounds.Height += dataGridView.Rows[i].Height;
          break;
        }
        
        clipBounds.Y += rowItem.Height;
      }

      //exclude borders.
      if (dataGridView.BorderStyle != BorderStyle.None)
      {
          Rectangle clientRectangle = dataGridView.ClientRectangle;
          clientRectangle.Width--;
          clientRectangle.Height--;
          clipBounds.Intersect(clientRectangle);
      }

      return clipBounds;
    }
        
    private static Rectangle GetSpannedCellBoundsFromChildCellBounds(ExDataGridViewTextBoxCell childCell, Rectangle childCellBounds)
    {
      DataGridView dataGridView = childCell.DataGridView;
      ExDataGridViewTextBoxCell ownerCell = childCell.OwnerCell == null ? childCell : childCell.OwnerCell;
      Rectangle spannedCellBounds = childCellBounds;

      int i = 0;
      int firstVisibleColumnIndex = 0;
      for (firstVisibleColumnIndex = ownerCell.ColumnIndex; firstVisibleColumnIndex < ownerCell.ColumnIndex + ownerCell.ColumnSpan; firstVisibleColumnIndex++)
      {
        if (dataGridView.Columns[firstVisibleColumnIndex].Visible)
          break;
      }

      if (dataGridView.Columns[firstVisibleColumnIndex].Frozen)
      {
        spannedCellBounds.X = dataGridView.GetColumnDisplayRectangle(firstVisibleColumnIndex, false).X;
      }
      else
      {
        for (i = firstVisibleColumnIndex; i < childCell.ColumnIndex; i++)
        {
          DataGridViewColumn columnItem = dataGridView.Columns[i];
          if (columnItem.Visible)
            spannedCellBounds.X += columnItem.Width;
        }
      }
      //
      int firstVisibleRowIndex = 0;
      for (firstVisibleRowIndex = ownerCell.RowIndex; firstVisibleRowIndex < ownerCell.RowIndex + ownerCell.RowSpan; firstVisibleRowIndex++)
      {
        if (dataGridView.Rows[firstVisibleRowIndex].Visible)
          break;
      }

      if (dataGridView.Rows[firstVisibleRowIndex].Frozen)
      {
          spannedCellBounds.Y = dataGridView.GetRowDisplayRectangle(firstVisibleRowIndex, false).Y;
      }
      else
      {
        for (i = firstVisibleRowIndex; i < childCell.RowIndex; i++)
        {
          DataGridViewRow rowItem = dataGridView.Rows[i];
          if (rowItem.Visible)
            spannedCellBounds.Y += rowItem.Height;
        }
      }

      for (i = ownerCell.ColumnIndex; i < ownerCell.ColumnSpan + ownerCell.ColumnSpan; i++)
      {
        DataGridViewColumn columnItem = dataGridView.Columns[i];
        if (columnItem.Visible)
          spannedCellBounds.Width += columnItem.Width;
      }

      for (i = ownerCell.RowIndex; i < ownerCell.RowIndex + ownerCell.RowSpan; i++)
      {
        DataGridViewRow rowItem = dataGridView.Rows[i];
          if (rowItem.Visible)
            spannedCellBounds.Height += rowItem.Height;
      }

      return spannedCellBounds;
    }

    #endregion
  }

  public class ExDataGridViewTextBoxColumn : DataGridViewColumn
  {
    #region ctor
    public ExDataGridViewTextBoxColumn()
      : base(new ExDataGridViewTextBoxCell())
    {
    }
    #endregion
  }
}
