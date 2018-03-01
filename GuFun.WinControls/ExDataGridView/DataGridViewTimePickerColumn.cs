using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace GuFun.WinControls
{
  public class DataGridViewTimePickerColumn : DataGridViewColumn
  {
    public DataGridViewTimePickerColumn()
      : base(new DataGridViewTimePickerCell())
        {
        }

    public override DataGridViewCell CellTemplate
    {
      get
      {
          return base.CellTemplate;
      }
      set
      {
          base.CellTemplate = value;
      }
    }

    [Browsable(true)]
    public string DateFormat
    {
      get { return this.CellTemplate.Style.Format; }
      set { this.CellTemplate.Style.Format = value; }
    }
  }

  public class DataGridViewTimePickerCell : DataGridViewTextBoxCell
  {
    public DataGridViewTimePickerCell()
    {
      this.Style.Format = "yyyy-MM-dd";
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
      base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

      DataGridViewTimePickerCellControl DatePicker = DataGridView.EditingControl as DataGridViewTimePickerCellControl;

      try
      {
        DatePicker.Value = Convert.ToDateTime(this.Value);
      }
      catch { }
    }

    public override void DetachEditingControl()
    {
      base.DetachEditingControl();

      DataGridViewTimePickerCellControl DatePicker = (DataGridViewTimePickerCellControl)(DataGridView.EditingControl);
      this.Value = DatePicker.Value;
    }

    public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
    {
      return Convert.ToDateTime(formattedValue);
    }

    public override Type ValueType
    {
      get
      {
        return typeof(DateTime);
      }
    }

    public override Type FormattedValueType
    {
      get
      {
        return typeof(string);
      }
    }

    public override Type EditType
    {
      get
      {
        return typeof(DataGridViewTimePickerCellControl);
      }
    }

    public override object DefaultNewRowValue
    {
      get
      {
        return DateTime.Now;
      }
    }

    public override bool KeyEntersEditMode(KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Space)
        return true;

      return false;
    }

    protected override void OnClick(DataGridViewCellEventArgs e)
    {
      base.OnClick(e);
      DataGridView.BeginEdit(true);
    }

    protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
      Rectangle cellRect = new Rectangle(cellBounds.Location, new Size(cellBounds.Width - 1, cellBounds.Height - 1));
      Color textColor = cellStyle.ForeColor;
      if ((cellState & DataGridViewElementStates.Selected) != 0)
      {
        using (SolidBrush backbrush = new SolidBrush(cellStyle.SelectionBackColor))
        {
          graphics.FillRectangle(backbrush, cellRect);
        }
        textColor = cellStyle.SelectionForeColor;
      }
      else
      {
        using (SolidBrush backbrush = new SolidBrush(cellStyle.BackColor))
        {
          graphics.FillRectangle(backbrush, cellRect);
        }
        using (Pen backpen = new Pen(this.DataGridView.GridColor))
        {
          graphics.DrawRectangle(backpen, cellBounds.Left - 1, cellBounds.Top - 1, cellBounds.Width, cellBounds.Height);
        }
      }

      StringFormat strFormat = new StringFormat();
      // Set Alignment
      switch (cellStyle.Alignment)
      {
        case DataGridViewContentAlignment.BottomCenter:
          strFormat.LineAlignment = StringAlignment.Far;
          strFormat.Alignment = StringAlignment.Center;
          break;
        case DataGridViewContentAlignment.BottomLeft:
          strFormat.LineAlignment = StringAlignment.Far;
          strFormat.Alignment = StringAlignment.Near;
          break;
        case DataGridViewContentAlignment.BottomRight:
          strFormat.LineAlignment = StringAlignment.Far;
          strFormat.Alignment = StringAlignment.Far;
          break;
        case DataGridViewContentAlignment.MiddleCenter:
          strFormat.LineAlignment = StringAlignment.Center;
          strFormat.Alignment = StringAlignment.Center;
          break;
        case DataGridViewContentAlignment.MiddleLeft:
          strFormat.LineAlignment = StringAlignment.Center;
          strFormat.Alignment = StringAlignment.Near;
          break;
        case DataGridViewContentAlignment.MiddleRight:
          strFormat.LineAlignment = StringAlignment.Center;
          strFormat.Alignment = StringAlignment.Far;
          break;
        case DataGridViewContentAlignment.TopCenter:
          strFormat.LineAlignment = StringAlignment.Near;
          strFormat.Alignment = StringAlignment.Center;
          break;
        case DataGridViewContentAlignment.TopLeft:
          strFormat.LineAlignment = StringAlignment.Near;
          strFormat.Alignment = StringAlignment.Near;
          break;
        case DataGridViewContentAlignment.TopRight:
          strFormat.LineAlignment = StringAlignment.Near;
          strFormat.Alignment = StringAlignment.Far;
          break;
      }

      graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      string outString;
      try
      {
        outString = "";
      }
      catch
      {
        outString = "";
      }

      using (SolidBrush textbrush = new SolidBrush(textColor))
      {
        graphics.DrawString(outString, cellStyle.Font, textbrush, cellBounds, strFormat);
      }

      base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    }
  }

  public class DataGridViewTimePickerCellControl : DateTimePicker, IDataGridViewEditingControl
  {
    // Fields
    private DataGridView dataGridView;
    private int rowIndex;
    private bool valueChanged;

    public DataGridViewTimePickerCellControl()
    {
      base.TabStop = false;
    }

    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
      this.Font = dataGridViewCellStyle.Font;
      if (dataGridViewCellStyle.BackColor.A < 0xff)
      {
        Color color = Color.FromArgb(0xff, dataGridViewCellStyle.BackColor);
        this.BackColor = color;
        this.dataGridView.EditingPanel.BackColor = color;
      }
      else
      {
        this.BackColor = dataGridViewCellStyle.BackColor;
      }
      this.ForeColor = dataGridViewCellStyle.ForeColor;
    }

    private void NotifyDataGridViewOfValueChange()
    {
      this.valueChanged = true;
      this.dataGridView.NotifyCurrentCellDirty(true);
    }

    #region IDataGridViewEditingControl ³ÉÔ±

    public DataGridView EditingControlDataGridView
    {
      get
      {
        return this.dataGridView;
      }
      set
      {
        this.dataGridView = value;
      }
    }

    public object EditingControlFormattedValue
    {
      get
      {
        return this.Value;
      }
      set
      {
        this.Value = Convert.ToDateTime(value);
      }
    }

    public int EditingControlRowIndex
    {
      get
      {
        return this.rowIndex;
      }
      set
      {
        this.rowIndex = value;
      }
    }

    public bool EditingControlValueChanged
    {
      get
      {
        return this.valueChanged;
      }
      set
      {
        this.valueChanged = value;
      }
    }

    public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
    {
      switch (keyData & Keys.KeyCode)
      {
        case Keys.Left:
        case Keys.Up:
        case Keys.Down:
        case Keys.Right:
        case Keys.Home:
        case Keys.End:
        case Keys.PageDown:
        case Keys.PageUp:
          return true;
        default:
          return !dataGridViewWantsInputKey;
      }
    }

    public Cursor EditingPanelCursor
    {
      get
      {
        return Cursors.Default;
      }
    }

    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
      return EditingControlFormattedValue;
    }

    public void PrepareEditingControlForEdit(bool selectAll)
    {
      if (selectAll)
        this.Select();
    }

    public bool RepositionEditingControlOnValueChange
    {
      get
      {
        return false;
      }
    }

    #endregion
  }
}
