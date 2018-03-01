using System;
using System.Data;
using System.Reflection;
using System.IO;
using Microsoft.Office.Core;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace GuFun.Utils
{
  public class ExcelHelper
  {
    #region Variables

    private Excel.Application excelApplication = null;
    private Excel.Workbooks excelWorkBooks = null;
    private Excel.Workbook excelWorkBook = null;
    private Excel.Worksheet excelWorkSheet = null;
    private Excel.Range excelRange = null; //Excel Range Object,多种用途
    private Excel.Range excelCopySourceRange = null; //Excel Range Object
    private int excelActiveWorkSheetIndex;    //活动工作表索引
    private string excelOpenFileName = String.Empty;   //操作Excel的路径
    private string excelSaveFileName = String.Empty;   //保存Excel的路径

    #endregion

    #region Properties

    public int ActiveSheetIndex
    {
      get { return excelActiveWorkSheetIndex; }
      set { excelActiveWorkSheetIndex = value; }
    }

    public string OpenFileName
    {
      get { return excelOpenFileName; }
      set { excelOpenFileName = value; }
    }

    public string SaveFileName
    {
      get { return excelSaveFileName; }
      set { excelSaveFileName = value; }
    }

    #endregion

    public ExcelHelper()
    {
      excelApplication = null;
      excelWorkBooks = null;
      excelWorkBook = null;
      excelWorkSheet = null;
      ActiveSheetIndex = 1;
    }

    public bool OpenExcelFile()
    {
      if (excelApplication != null) 
        CloseExcelApplication();

      //检查文件是否存在
      if (String.IsNullOrEmpty(this.OpenFileName))
        throw new Exception("没有指定需要打开的EXCEL文件！");

      if (!File.Exists(this.OpenFileName))
        throw new Exception(this.OpenFileName + "文件不存在！");

      try
      {
        excelApplication = new Excel.ApplicationClass();
        excelApplication.Visible = false;
        excelApplication.ScreenUpdating = false;
        excelApplication.DisplayAlerts = false;

        excelWorkBooks = excelApplication.Workbooks;
        excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(this.OpenFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
        excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[this.ActiveSheetIndex];        

        return true;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        MessageBox.Show("(1)没有安装Excel 2003；(2)或没有安装Excel 2003 .NET 可编程性支持；\n详细信息："
            + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //throw new Exception(e.Message);
        return false;
      }
    }

    public void NewExcelFile()
    {
      try
      {
        excelApplication = new Excel.ApplicationClass();
        excelApplication.Visible = false;
        excelApplication.ScreenUpdating = false;
        excelApplication.AlertBeforeOverwriting = false;
        excelApplication.DisplayAlerts = false;

        excelWorkBook = excelApplication.Workbooks.Add(true);
        excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[this.ActiveSheetIndex];
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        MessageBox.Show("(1)没有安装Excel 2003；(2)或没有安装Excel 2003 .NET 可编程性支持；\n详细信息："
            + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //throw new Exception(e.Message);
      }
    }

    public string GetCellValue(int rowindex, int cellindex)
    {
      if (rowindex <= 0)
        throw new Exception("行索引超出范围！");

      string sValue = String.Empty; ;

      try
      {
        sValue = ((Excel.Range)excelWorkSheet.Cells[rowindex, cellindex]).Text.ToString();
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
      return (sValue);
    }

    public string[] GetCellValues(string start, string end)
    {
      string[] sValue = null;

      excelRange = (Excel.Range)excelWorkSheet.get_Range(start, end);
      sValue = new string[excelRange.Count];
      int rowStartIndex = ((Excel.Range)excelWorkSheet.get_Range(start, end)).Row;   //起始行号
      int columnStartIndex = ((Excel.Range)excelWorkSheet.get_Range(start, end)).Column; //起始列号
      int rowNum = excelRange.Rows.Count;      //行数目
      int columnNum = excelRange.Columns.Count;     //列数目
      int index = 0;
      for (int i = rowStartIndex; i < rowStartIndex + rowNum; i++)
      {
        for (int j = columnStartIndex; j < columnNum + columnStartIndex; j++)
        {
          //读到空值null和读到空串""分别处理
          sValue[index] = ((Excel.Range)excelWorkSheet.Cells[i, j]).Text.ToString();
          index++;
        }
      }

      return (sValue);
    }

    public DataTable GetAllCellValues()
    {
      int columnCount = GetColumnCount();
      int rowCount = GetRowCount();
      DataTable dt = new DataTable();
      //设置datatable列的名称
      for (int columnID = 1; columnID <= columnCount; columnID++)
      {
        dt.Columns.Add(((Excel.Range)excelWorkSheet.Cells[1, columnID]).Text.ToString());
      }

      for (int rowID = 2; rowID <= rowCount; rowID++)
      {
        DataRow dr = dt.NewRow();
        for (int columnID = 1; columnID <= columnCount; columnID++)
        {
          dr[columnID - 1] = ((Excel.Range)excelWorkSheet.Cells[rowID, columnID]).Text.ToString();
          //读到空值null和读到空串""分别处理
        }
        dt.Rows.Add(dr);
      }
      return (dt);
    }

    public int GetRowCount()
    {//当前活动工作表中有效行数(总行数)
      int rowsNumber = 0;
      try
      {
        while (true)
        {
          if (((Excel.Range)excelWorkSheet.Cells[rowsNumber + 1, 1]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[rowsNumber + 2, 1]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[rowsNumber + 3, 1]).Text.ToString().Trim() == "")
            break;
          rowsNumber++;
        }
      }
      catch
      {
        return -1;
      }
      return rowsNumber;
    }

    public int GetRowCount(int columnindex)
    {//当前活动工作表中有效行数(总行数)
      int rowsNumber = 0;
      try
      {
        while (true)
        {
          if (((Excel.Range)excelWorkSheet.Cells[rowsNumber + 1, columnindex]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[rowsNumber + 2, columnindex]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[rowsNumber + 3, columnindex]).Text.ToString().Trim() == "")
            break;
          rowsNumber++;
        }
      }
      catch
      {
        return -1;
      }
      return rowsNumber;
    }

    public int GetColumnCount()
    {
      int columnNumber = 0;
      try
      {
        while (true)
        {
          if (((Excel.Range)excelWorkSheet.Cells[1, columnNumber + 1]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[1, columnNumber + 2]).Text.ToString().Trim() == "" &&
                 ((Excel.Range)excelWorkSheet.Cells[1, columnNumber + 3]).Text.ToString().Trim() == "")
            break;
          columnNumber++;
        }
      }
      catch
      {
        return -1;
      }
      return columnNumber;
    }

    /// <summary>
    /// 向一个Cell写入数据
    /// </summary>
    /// <param name="CellRowID">CellRowID是cell的行索引</param>
    /// <param name="CellColumnID">CellColumnID是cell的列索引</param>
    ///<param name="Value">要写入该单元格的数据值</param>
    public void SetCellValue(int CellRowID, int CellColumnID, string Value)
    {
      try
      {
        excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
        excelRange.Value2 = Value;//Value2?
        //Gets or sets the value of the NamedRange control. 
        //The only difference between this property and the Value property is that Value2 is not a parameterized property. 
        excelRange = null;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// 设置活动工作表
    /// </summary>
    /// <param name="SheetIndex">要设置为活动工作表的索引值</param>
    public void SetActiveWorkSheet(int SheetIndex)
    {
      if (SheetIndex <= 0)
      {
        throw new Exception("索引超出范围！");
      }
      try
      {
        ActiveSheetIndex = SheetIndex;
        excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[ActiveSheetIndex];
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    public int GetWorkSheetCount()
    {
      try
      {
        return excelWorkBook.Worksheets.Count;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }

      return 0;
    }
    /// <summary>
    /// 向连续区域一次性写入数据；只有在区域连续和写入的值相同的情况下可以使用方法
    /// </summary>
    /// <param name="StartCell">StartCell是要写入区域的左上角单元格</param>
    /// <param name="EndCell">EndCell是要写入区域的右下角单元格</param>
    /// <param name="Value">要写入指定区域所有单元格的数据值</param>
    public void SetCellValues(string start, string end, string Value)
    {
      try
      {
        excelRange = excelWorkSheet.get_Range(start, end);
        excelRange.Value2 = Value;
        excelRange = null;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// 给一行写数据
    /// </summary>
    public void SetOneLineValues(int LineID, int StartCellColumnID, int EndCellColumnID, string[] Values)
    {
      for (int i = StartCellColumnID; i <= EndCellColumnID; i++)
      {
        SetCellValue(LineID, i, Values[i]);
      }
    }

    public void SetCellsBorder(string startCell, string endCell)
    {
      //设置某个范围内的单元格的边框
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
    }

    public void SetOneCellBorder(int CellRowID, int CellColumnID)
    {
      //设置某个单元格的边框
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];

      excelRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
      excelRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
    }

    public void SetColumnWidth(string startCell, string endCell, int size)
    {
      //设置某个范围内的单元格的列的宽度
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      excelRange.ColumnWidth = size;
    }

    public void SetOneCellFont(int CellRowID, int CellColumnID, string fontName, int fontSize)
    {
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
      excelRange.Font.Name = fontName;
      excelRange.Font.Size = fontSize;
    }

    public void SetOneCellHorizontalAlignment(int CellRowID, int CellColumnID, Excel.Constants alignment)
    {
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
      excelRange.HorizontalAlignment = alignment;

    }

    public void SetOneCellColumnWidth(int CellRowID, int CellColumnID, int size)
    {
      //设置某个单元格的列的宽度
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
      excelRange.ColumnWidth = size;

    }

    /// <summary>
    /// 设置一个Cell的数据格式
    /// </summary>
    /// <param name="CellRowID">CellRowID是cell的行索引</param>
    /// <param name="CellColumnID">CellColumnID是cell的列索引</param>
    ///<param name="Value">数据格式</param>
    public void SetOneCellNumberFormat(int CellRowID, int CellColumnID, string numberFormat)
    {
      try
      {
        excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
        excelRange.NumberFormatLocal = numberFormat;

        excelRange = null;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }
    public void SetRowHeight(string startCell, string endCell, int size)
    {
      //设置某个范围内的单元格的行的高度
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      excelRange.RowHeight = size;

    }
    public void SetRowHeight(int CellRowID, int CellColumnID, float size)
    {
      //设置某个范围内的单元格的行的高度
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
      excelRange.RowHeight = size;

    }
    public void SetOneCellRowHeight(int CellRowID, int CellColumnID, int size)
    {
      //设置某个单元格的行的高度
      excelRange = (Excel.Range)excelWorkSheet.Cells[CellRowID, CellColumnID];
      excelRange.RowHeight = size;

    }

    /// <summary>
    /// 拷贝区域.限制：在同一个工作表中复制
    /// </summary>
    /// <param name="SourceStart">源区域的左上角单元格</param>
    /// <param name="SourceEnd">源区域的右下角单元格</param> 
    /// <param name="DesStart">目标区域的左上角单元格</param> 
    /// <param name="DesEnd">目标区域的右下角单元格</param> 
    public void CopyCells(string SourceStart, string SourceEnd, string DesStart, string DesEnd)
    {
      try
      {
        excelCopySourceRange = excelWorkSheet.get_Range(SourceStart, SourceEnd);
        excelRange = excelWorkSheet.get_Range(DesStart, DesEnd);
        excelCopySourceRange.Copy(excelRange);

        excelCopySourceRange = null;
        excelRange = null;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    public void CopyWorksheet(int SourceWorksheetIndex, int DesWorksheetIndex)
    {
      try
      {
        Excel.Worksheet sheetSource = (Excel.Worksheet)excelWorkBook.Worksheets[SourceWorksheetIndex];
        sheetSource.Select(Missing.Value);
        Excel.Worksheet sheetDest = (Excel.Worksheet)excelWorkBook.Worksheets[DesWorksheetIndex];
        sheetSource.Copy(Missing.Value, sheetDest);
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// 插入一行
    /// </summary>
    /// <param name="CellRowID">要插入所在行的索引位置，插入后其原有行下移</param> 
    /// <param name="RowNum">要插入行的个数</param> 
    public void InsertRow(int CellRowID, int RowNum)//插入空行
    {
      if (CellRowID <= 0)
      {
        throw new Exception("行索引超出范围！");
      }
      if (RowNum <= 0)
      {
        throw new Exception("插入行数无效！");
      }
      try
      {
        excelRange = (Excel.Range)excelWorkSheet.Rows[CellRowID, Missing.Value];
        for (int i = 0; i < RowNum; i++)
        {
          excelRange.Insert(Excel.XlDirection.xlDown, Missing.Value);
        }
        excelRange = null;
      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// 保存Excel文件
    /// </summary>

    public Excel.Range FindFirstRange(Excel.Range xlRange, string FindText)//查找//没有测试
    {
      //查找第一个满足的区域
      //Search for the first match
      Excel.Range firstFind = null;
      firstFind = xlRange.Find(FindText, Missing.Value, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Missing.Value, Missing.Value);
      return firstFind;  //如果没找到，返回空
    }
    

    /// <summary>
    /// 判断单元格是否有数据
    /// </summary>
    public bool CellValueIsNull(int CellLineID, int CellColumnID)////已经测试
    {

      //判断单元格是否有数据
      if ((((Excel.Range)excelWorkSheet.Cells[CellLineID, CellColumnID]).Text.ToString().Trim() != ""))
        return false;
      return true;
    }



    public void NewWorkbook(string excelTemplate, string fileName)
    {
      //以excelTemplate为模板新建文件fileName
      //excelApplication.
      excelWorkBook = excelWorkBooks.Add(excelTemplate);
      SaveFileName = "";
      SaveExcel();
    }

    public ArrayList GetWorkSheetName()
    {
      ArrayList dt = new ArrayList();

      for (int i = 1; i <= excelWorkBook.Worksheets.Count; i++)
      {
        dt.Add(((Excel.Worksheet)excelWorkBook.Worksheets[i]).Name);
      }

      return dt;
    }

    public void NewWorksheet()
    {
      excelWorkBook.Worksheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
    }

    public void SetWorksheetName(int sheetIndex, string worksheetName)
    {
      // Missing.Value
      Excel._Worksheet sheet = (Excel._Worksheet)(excelWorkBook.Worksheets[(object)sheetIndex]);
      sheet.Name = worksheetName;
    }

    public void MergeOneLineCells(string startCell, string endCell)
    {
      //合并一行单元格 
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      //excelRange.Merge(true);
      excelRange.MergeCells = true;
    }

    public void HorizontalAlignmentCells(string startCell, string endCell, Excel.Constants alignment)
    {
      //水平对齐一行单元格 
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      excelRange.HorizontalAlignment = alignment;
    }

    public void VerticalAlignmentCells(string startCell, string endCell, Excel.Constants alignment)
    {
      //垂直对齐一行单元格 
      excelRange = excelWorkSheet.get_Range(startCell, endCell);
      excelRange.VerticalAlignment = alignment;
    }

    //实现列号-〉字母 (26-〉Z,27->AA)
    private string ConvertColumnIndexToChar(int columnIndex)
    {
      if (columnIndex < 1 || columnIndex > 256)
      {
        MessageBox.Show("columnIndex=" + columnIndex + ",超出了有效范围（1-256）");
        return "A";
      }
      if (columnIndex >= 1 && columnIndex <= 26)//1--26
      {
        return "AA";
      }
      if (columnIndex >= 27 && columnIndex <= 256)//27--256
      {
        return "AA";
      }
      return "A";
    }

    public void SaveExcel()
    {
      if (String.IsNullOrEmpty(this.SaveFileName))
        throw new Exception("未指定要保存的文件名");

      try
      {
        excelWorkSheet.SaveAs(this.SaveFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);

      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    //--------------------------------------------------------------------------------------------------------
    /// <summary>
    /// 保存Excel文件，格式xml.
    /// </summary>
    public void SaveExcelAsXML()
    {
      if (String.IsNullOrEmpty(this.SaveFileName))
        throw new Exception("未指定要保存的文件名");

      try
      {
        excelWorkSheet.SaveAs(this.SaveFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);

      }
      catch (Exception e)
      {
        CloseExcelApplication();
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// 关闭Excel文件，释放对象；最后一定要调用此函数，否则会引起异常
    /// </summary>
    /// <param></param> 
    public void CloseExcelApplication()
    {
      try
      {
        excelWorkBooks = null;
        excelWorkBook = null;
        excelWorkSheet = null;
        excelRange = null;
        if (excelApplication != null)
        {
          excelApplication.Workbooks.Close();
          excelApplication.Quit();
          excelApplication = null;
        }
      }
      finally
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }

    private void ReleaseAllRef(Object obj)
    {
      //ReleaseComObject()方法可以使RCW减少一个对COM组件的引用，并返回减少一个引用后RCW对COM组件的剩余引用数量。
      //我们用一个循环，就可以让RCW将所有对COM组件的引用全部去掉。
      try
      {
        while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 1) ;
      }
      finally
      {
        obj = null;
      }
    }

  }
}


