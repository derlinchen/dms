using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiveUpdate
{
  public partial class DownloadConfirm : LiveUpdate.BaseDialogForm
  {
    List<DownloadFileInfo> downloadFileList = null;

    public DownloadConfirm(List<DownloadFileInfo> downloadfileinfo)
    {
      InitializeComponent();
      btnOk.BackColor = SystemColors.Control;
      btnCancel.BackColor = SystemColors.Control;

      downloadFileList = downloadfileinfo;
    }

    private void DownloadConfirm_Load(object sender, EventArgs e)
    {
      foreach (DownloadFileInfo file in this.downloadFileList)
      {
        ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVersion, file.Size.ToString() });
        this.listDownloadFile.Items.Add(item);
      }

      //this.Activate();
      //this.Focus();
      this.BringToFront();
      this.btnOk.Select();
      this.TopLevel = true;
    }
  }
}

