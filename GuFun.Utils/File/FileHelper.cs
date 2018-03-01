using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GuFun.Utils
{
  public class FileHelper
  {
    public static void InitSaveExcelDialog(SaveFileDialog sfd, string filename)
    {
      if (!String.IsNullOrEmpty(filename))
        sfd.FileName = filename + ".xls";
      sfd.Filter = "Excel (*.xls)|*.xls";
      sfd.FilterIndex = 1;
      sfd.RestoreDirectory = true;
    }

    public static void ExportToExcel(DataGridView dgv, string filename)
    {
      //反射取得类型
      Type ObjExcel = Type.GetTypeFromProgID("Excel.Application");
      if (ObjExcel == null)
      {
        MessageBox.Show("请检查Office/Excel软件是否已经正确安装！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      //创建Excel实例
      Object ObjApp = Activator.CreateInstance(ObjExcel);

      try
      {
        ObjApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, Type.DefaultBinder, ObjApp, new object[] { "False" });
        ObjApp.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, Type.DefaultBinder, ObjApp, new object[] { "False" });
        ObjApp.GetType().InvokeMember("AlertBeforeOverwriting", BindingFlags.SetProperty, Type.DefaultBinder, ObjApp, new object[] { "False" });

        object workBooks = ObjApp.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty, null, ObjApp, null);
        object workBook = workBooks.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, workBooks, null);
        object workSheets = workBook.GetType().InvokeMember("Worksheets", System.Reflection.BindingFlags.GetProperty, null, workBook, new object[] { 1 });

        int i = 0;
        int j = 0;
        object cells;

        for (i = 0; i < dgv.Columns.Count; i++)
        {
          if (!dgv.Columns[i].Visible) continue;

          cells = workSheets.GetType().InvokeMember("Cells", System.Reflection.BindingFlags.GetProperty, null, workSheets, new object[] { 1, i + 1 });
          cells.GetType().InvokeMember("Value", System.Reflection.BindingFlags.SetProperty, null, cells, new object[] { dgv.Columns[i].HeaderText });
        }

        for (i = 0; i < dgv.Rows.Count; i++)
        {
          for (j = 0; j < dgv.Columns.Count; j++)
          {
            if (!dgv.Columns[j].Visible) continue;

            cells = workSheets.GetType().InvokeMember("Cells", System.Reflection.BindingFlags.GetProperty, null, workSheets, new object[] { i + 2, j + 1 });
            cells.GetType().InvokeMember("Value", System.Reflection.BindingFlags.SetProperty, null, cells, new object[] { dgv.Rows[i].Cells[j].Value != null ? dgv.Rows[i].Cells[j].Value.ToString() : "" });
          }
        }

        workBook.GetType().InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, workBook, new object[] { filename });

        GC.Collect(); 
      }
      finally
      {
        ObjApp.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, Type.DefaultBinder, ObjApp, null);
      }
    }
  }
}
