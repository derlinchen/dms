using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Data;
using System.Text;

namespace GuFun.WinControls
{
  public class PrintGridItem
  {
    private ExDataGridView _grid;

    /// <summary>
    /// 需要打印的GRID
    /// </summary>
    public ExDataGridView Grid
    {
      get 
      {
        if (_grid == null)
          _grid = new ExDataGridView();

        return _grid;
      }
      set { _grid = value; }
    }

    /// <summary>
    /// 是否新页
    /// </summary>
    private bool _newPage;

    public bool NewPage
    {
      get { return _newPage; }
      set { _newPage = value; }
    }

    /// <summary>
    /// 是否充满页面
    /// </summary>
    private bool _fitToPageWidth;

    public bool FitToPageWidth
    {
      get { return _fitToPageWidth; }
      set { _fitToPageWidth = value; }
    }

    /// <summary>
    /// 当前页数
    /// </summary>
    private int _pageNo;

    public int PageNo
    {
      get { return _pageNo; }
      set { _pageNo = value; }
    }

    /// <summary>
    /// 打印标题
    /// </summary>
    private string _headerTitle;

    public string HeaderTitle
    {
      get { return _headerTitle; }
      set { _headerTitle = value; }
    }

    /// <summary>
    /// 打印人
    /// </summary>
    private string _headerPrinter;

    public string HeaderPrinter
    {
      get { return _headerPrinter; }
      set { _headerPrinter = value; }
    }

    /// <summary>
    /// Grid的总宽度
    /// </summary>
    private int _totalWidth;

    public int TotalWidth
    {
      get { return _totalWidth; }
      set { _totalWidth = value; }
    }

    private int _headerHeight;

    public int HeaderHeight
    {
      get { return _headerHeight; }
      set { _headerHeight = value; }
    }    

    private int _rowPos;

    public int RowPos
    {
      get { return _rowPos; }
      set { _rowPos = value; }
    }

    private int _rowsPerPage;

    public int RowsPerPage
    {
      get { return _rowsPerPage; }
      set { _rowsPerPage = value; }
    }

    private ArrayList _columnLefts;

    public ArrayList ColumnLefts
    {
      get
      {
        if (_columnLefts == null)
          _columnLefts = new ArrayList();

        return _columnLefts;
      }
    }

    private ArrayList _columnWidths;

    public ArrayList ColumnWidths
    {
      get
      {
        if (_columnWidths == null)
          _columnWidths = new ArrayList();

        return _columnWidths;
      }
    }

    private ArrayList _columnTypes;

    public ArrayList ColumnTypes
    {
      get
      {
        if (_columnTypes == null)
          _columnTypes = new ArrayList();

        return _columnTypes;
      }
    }

    private StringFormat _stringFormat;

    public StringFormat StringFormat
    {
      get
      {
        if (_stringFormat == null)
          _stringFormat = new StringFormat();
        _stringFormat.Alignment = StringAlignment.Center;
        _stringFormat.LineAlignment = StringAlignment.Center;
        _stringFormat.Trimming = StringTrimming.None;

        return _stringFormat;
      }
    }

    public PrintGridItem()
    {
      _newPage = true;
      _fitToPageWidth = true;
      _pageNo = 1;
      _headerTitle = String.Empty;
      _headerPrinter = String.Empty;
      _rowPos = 0;
      _rowsPerPage = 0;
      _totalWidth = 0;
    }


    public PrintGridItem(ExDataGridView dgv, bool isFit, PrintPageEventArgs e)
    {
      _grid = dgv;
      _newPage = true;
      _fitToPageWidth = true;
      _pageNo = 1;
      _headerTitle = String.Empty;
      _headerPrinter = String.Empty;
      _rowPos = 0;
      _rowsPerPage = 0;
      _totalWidth = 0;

      int CellWidth = 0;
      int PageLeft = e.MarginBounds.Left;

      foreach (DataGridViewColumn GridCol in dgv.Columns)
      {
        if (!GridCol.Visible) continue;

        _totalWidth += GridCol.Width;
      }

      foreach (DataGridViewColumn GridCol in dgv.Columns)
      {
        if (!GridCol.Visible) continue;

        if (isFit)
          CellWidth = (int)(Math.Floor((double)((double)GridCol.Width / (double)TotalWidth * (double)TotalWidth * ((double)e.MarginBounds.Width / (double)TotalWidth))));
        else
          CellWidth = GridCol.Width;

        HeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, CellWidth).Height) + 11;

        ColumnLefts.Add(PageLeft);
        ColumnWidths.Add(CellWidth);
        ColumnTypes.Add(GridCol.GetType());
        PageLeft += CellWidth;
      }
    }
  }

  public class PrintGrid
  {

    public static void PrintDataGridView(PrintGridItem pg, PrintPageEventArgs e)
    {
      if (pg == null) return;

      int CellHeight;      
      int NowTop = e.MarginBounds.Top;      
      int TitleHeight = (int)e.Graphics.MeasureString(pg.HeaderPrinter, new Font(pg.Grid.Font, FontStyle.Bold), e.MarginBounds.Width).Height;
      int PrinterHeight = (int)e.Graphics.MeasureString(pg.HeaderPrinter, new Font(pg.Grid.Font, FontStyle.Bold), e.MarginBounds.Width).Height;
      int i = 0;

      try
      {
        while (pg.RowPos <= pg.Grid.Rows.Count - 1)
        {
          DataGridViewRow GridRow = pg.Grid.Rows[pg.RowPos];

          CellHeight = GridRow.Height;

          if (NowTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
          {
            DrawFooter(pg, e);
            pg.NewPage = true;
            pg.PageNo++;

            e.HasMorePages = true;            
            return;
          }
          else
          {
            if (pg.NewPage)
            {
              // Draw Header
              e.Graphics.DrawString(pg.HeaderTitle, new Font(pg.Grid.Font, FontStyle.Bold), Brushes.Black,
                (int)(e.MarginBounds.Left + e.MarginBounds.Width) / 2,
                e.MarginBounds.Top - TitleHeight - PrinterHeight - 26);

              e.Graphics.DrawString(pg.HeaderPrinter, new Font(pg.Grid.Font, FontStyle.Bold), Brushes.Black, 
                e.MarginBounds.Left + 5,
                e.MarginBounds.Top - PrinterHeight - 13);

              String HeaderDate = "打印日期：" + DateTime.Now.ToString("yyyy年MM月dd日 hh:mm");

              e.Graphics.DrawString(HeaderDate, new Font(pg.Grid.Font, FontStyle.Bold), Brushes.Black,
                e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(HeaderDate, new Font(pg.Grid.Font, FontStyle.Bold), e.MarginBounds.Width).Width - 5),
                e.MarginBounds.Top - PrinterHeight - 13);

              // Draw Columns
              NowTop = e.MarginBounds.Top;

              i = 0;

              foreach (DataGridViewColumn GridCol in pg.Grid.Columns)
              {
                if (!GridCol.Visible) continue;

                e.Graphics.DrawRectangle(Pens.Black,
                    new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], pg.HeaderHeight));

                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                    new RectangleF((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], pg.HeaderHeight), pg.StringFormat);

                i++;
              }

              pg.NewPage = false;
              NowTop += pg.HeaderHeight;
            }

            // Draw Columns Contents
            i = 0;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.None;

            foreach (DataGridViewCell Cel in GridRow.Cells)
            {
              if (!Cel.OwningColumn.Visible) continue;

              switch (((Type)pg.ColumnTypes[i]).Name)
              {
                case "DataGridViewCheckBoxColumn":
                  e.Graphics.DrawString((bool)Cel.Value ? "√" : "×", Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor),
                        new RectangleF((int)pg.ColumnLefts[i] + 3, (float)NowTop, (int)pg.ColumnWidths[i] -3, (float)CellHeight), sf);
                  break;

                case "DataGridViewImageColumn":
                  Rectangle CelSize = new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], CellHeight);
                  Size ImgSize = ((Image)(Cel.FormattedValue)).Size;
                  e.Graphics.DrawImage((Image)Cel.FormattedValue,
                        new Rectangle((int)pg.ColumnLefts[i] + (int)((CelSize.Width - ImgSize.Width) / 2),
                        NowTop + (int)((CelSize.Height - ImgSize.Height) / 2),
                        ((Image)(Cel.FormattedValue)).Width, ((Image)(Cel.FormattedValue)).Height));
                  break;

                default:
                  e.Graphics.DrawString(Cel.Value != null ? Cel.Value.ToString() : String.Empty, Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor),
                        new RectangleF((int)pg.ColumnLefts[i] + 3, (float)NowTop, (int)pg.ColumnWidths[i] - 3, (float)CellHeight), sf);
                  break;
              }

              // Drawing Cells Borders 
              e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], CellHeight));

              i++;
            }

            NowTop += CellHeight;
          }

          pg.RowPos++;
          
          if (pg.PageNo == 1) pg.RowsPerPage++;
        }

        if (pg.RowsPerPage == 0) return;

        DrawFooter(pg, e);

        e.HasMorePages = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);        		
      }      
    }

    private static void DrawFooter(PrintGridItem pg, PrintPageEventArgs e)
    {
      double cnt = 0;

      if (pg.Grid.Rows[pg.Grid.Rows.Count - 1].IsNewRow)
        cnt = pg.Grid.Rows.Count - 1; 
      else
        cnt = pg.Grid.Rows.Count; 

      string PageNum = "第 " + pg.PageNo.ToString() + " 页/共 " + Math.Ceiling((double)(cnt / pg.RowsPerPage)).ToString() + " 页";

      e.Graphics.DrawString(PageNum, pg.Grid.Font, Brushes.Black,
          e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(PageNum, pg.Grid.Font, e.MarginBounds.Width).Width) / 2, 
          e.MarginBounds.Top + e.MarginBounds.Height + 31);
    }

    public static void PrintBankCash(PrintGridItem pg, PrintPageEventArgs e)
    {
      if (pg == null) return;

      int CellHeight;
      int NowTop = e.MarginBounds.Top;
      Font headerfont = new Font("宋体", 16.0F, FontStyle.Bold, GraphicsUnit.Point);
      int TitleHeight = (int)e.Graphics.MeasureString(pg.HeaderPrinter, headerfont, e.MarginBounds.Width).Height;
      int TitleWidth = (int)e.Graphics.MeasureString(pg.HeaderPrinter, headerfont, e.MarginBounds.Width).Width;
      int PrinterHeight = (int)e.Graphics.MeasureString(pg.HeaderPrinter, new Font(pg.Grid.Font, FontStyle.Bold), e.MarginBounds.Width).Height;
      int i = 0;      

      try
      {
        while (pg.RowPos <= pg.Grid.Rows.Count - 1)
        {
          DataGridViewRow GridRow = pg.Grid.Rows[pg.RowPos];

          CellHeight = GridRow.Height;

          if (NowTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
          {
            DrawFooter(pg, e);
            pg.NewPage = true;
            pg.PageNo++;

            e.HasMorePages = true;
            return;
          }
          else
          {
            if (pg.NewPage)
            {
              // Draw Header
              e.Graphics.DrawString(pg.HeaderTitle, headerfont, Brushes.Black,
                (int)(e.MarginBounds.Left + e.MarginBounds.Width - TitleWidth) / 2,
                e.MarginBounds.Top - TitleHeight - PrinterHeight - 26);

              e.Graphics.DrawString(pg.HeaderPrinter, new Font(pg.Grid.Font, FontStyle.Bold), Brushes.Black,
                e.MarginBounds.Left + 5,
                e.MarginBounds.Top - PrinterHeight - 13);

              String HeaderDate = "打印日期：" + DateTime.Now.ToString("yyyy年MM月dd日 hh:mm");

              e.Graphics.DrawString(HeaderDate, new Font(pg.Grid.Font, FontStyle.Bold), Brushes.Black,
                e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(HeaderDate, new Font(pg.Grid.Font, FontStyle.Bold), e.MarginBounds.Width).Width - 5),
                e.MarginBounds.Top - PrinterHeight - 13);

              // Draw Columns
              NowTop = e.MarginBounds.Top;

              i = 0;

              foreach (DataGridViewColumn GridCol in pg.Grid.Columns)
              {
                if (!GridCol.Visible) continue;

                e.Graphics.DrawRectangle(Pens.Black,
                    new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], pg.HeaderHeight));

                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                    new RectangleF((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], pg.HeaderHeight), pg.StringFormat);

                i++;
              }

              pg.NewPage = false;
              NowTop += pg.HeaderHeight;
            }

            // Draw Columns Contents
            i = 0;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.None;

            foreach (DataGridViewCell Cel in GridRow.Cells)
            {
              if (!Cel.OwningColumn.Visible) continue;

              switch (((Type)pg.ColumnTypes[i]).Name)
              {
                case "DataGridViewCheckBoxColumn":
                  e.Graphics.DrawString((bool)Cel.Value ? "√" : "×", Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor),
                        new RectangleF((int)pg.ColumnLefts[i] + 3, (float)NowTop, (int)pg.ColumnWidths[i] - 3, (float)CellHeight), sf);
                  break;

                case "DataGridViewImageColumn":
                  Rectangle CelSize = new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], CellHeight);
                  Size ImgSize = ((Image)(Cel.FormattedValue)).Size;
                  e.Graphics.DrawImage((Image)Cel.FormattedValue,
                        new Rectangle((int)pg.ColumnLefts[i] + (int)((CelSize.Width - ImgSize.Width) / 2),
                        NowTop + (int)((CelSize.Height - ImgSize.Height) / 2),
                        ((Image)(Cel.FormattedValue)).Width, ((Image)(Cel.FormattedValue)).Height));
                  break;

                default:
                  e.Graphics.DrawString(Cel.Value != null ? Cel.Value.ToString() : String.Empty, Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor),
                        new RectangleF((int)pg.ColumnLefts[i] + 3, (float)NowTop, (int)pg.ColumnWidths[i] - 3, (float)CellHeight), sf);
                  break;
              }

              // Drawing Cells Borders 
              e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)pg.ColumnLefts[i], NowTop, (int)pg.ColumnWidths[i], CellHeight));

              i++;
            }

            NowTop += CellHeight;
          }

          pg.RowPos++;

          if (pg.PageNo == 1) pg.RowsPerPage++;
        }

        if (pg.RowsPerPage == 0) return;

        DrawFooterBank(pg, e);

        e.HasMorePages = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static void DrawFooterBank(PrintGridItem pg, PrintPageEventArgs e)
    {
      double cnt = 0;

      if (pg.Grid.Rows[pg.Grid.Rows.Count - 1].IsNewRow)
        cnt = pg.Grid.Rows.Count - 2;
      else
        cnt = pg.Grid.Rows.Count - 1;

      string PageNum = "第 " + pg.PageNo.ToString() + " 页/共 " + Math.Ceiling((double)(cnt / pg.RowsPerPage)).ToString() + " 页";

      e.Graphics.DrawString(PageNum, pg.Grid.Font, Brushes.Black,
          e.MarginBounds.Left + 5,
          e.MarginBounds.Top + e.MarginBounds.Height + 31);

      e.Graphics.DrawString("签收人：________________________", pg.Grid.Font, Brushes.Black,
          e.MarginBounds.Left + e.MarginBounds.Width - 200,
          e.MarginBounds.Top + e.MarginBounds.Height + 31);
    }

  }
}
