using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace LiveUpdate
{
  public delegate void ShowHandler();

  public class AutoUpdater
  {
    const string Default_Config_File = "liveupdate.config";
    private ConfigUpdater config = null;
    private bool bNeedRestart = false;

    public AutoUpdater()
    {
      config = ConfigUpdater.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Default_Config_File));
    }


    /// <summary>
    /// 检查新版本
    /// </summary>
    /// <exception cref="System.Net.WebException">无法找到指定资源</exception>
    /// <exception cref="System.NotSupportException">升级地址配置错误</exception>
    /// <exception cref="System.Xml.XmlException">下载的升级文件有错误</exception>
    /// <exception cref="System.ArgumentException">下载的升级文件有错误</exception>
    /// <exception cref="System.Excpetion">未知错误</exception>
    /// <returns></returns>
    public void Update()
    {
      if (!config.Enabled)
        return;

      /// 请求Web服务器，得到当前最新版本的文件列表，格式同本地的FileList.xml。
      /// 与本地的FileList.xml比较，找到不同版本的文件
      /// 生成一个更新文件列表，开始DownloadProgress
      /// <UpdateFile>
      /// <File Path="" Url="" LastVersion="" Size=""></File>
      /// </UpdateFile>
      /// path为相对于应用程序根目录的相对目录位置，包括文件名

      WebClient client = new WebClient();
      client.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
      string strXml = client.DownloadString(config.ServerUrl);

      Dictionary<string, RemoteFileUpdater> listRemotFile = ParseRemoteXml(strXml.Trim());

      List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

      //暂时不删除
      List<LocalFileUpdater> preDeleteFile = new List<LocalFileUpdater>();

      foreach (LocalFileUpdater file in config.UpdateFileList)
      {
        if (listRemotFile.ContainsKey(file.Path))
        {
          RemoteFileUpdater rf = listRemotFile[file.Path];
          if ((rf.LastVersion != file.LastVersion)  || (rf.Size != file.Size))
          {
            downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVersion, rf.Size));
            file.LastVersion = rf.LastVersion;
            file.Size = rf.Size;

            if (rf.NeedRestart)
              bNeedRestart = true;
          }

          listRemotFile.Remove(file.Path);
        }
        else
        {
          //preDeleteFile.Add(file);
        }
      }

      foreach (RemoteFileUpdater file in listRemotFile.Values)
      {
        downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVersion, file.Size));
        config.UpdateFileList.Add(new LocalFileUpdater(file.Path, file.LastVersion, file.Size));

        if (file.NeedRestart)
          bNeedRestart = true;
      }

      if (downloadList.Count > 0)
      {
        DownloadConfirm dc = new DownloadConfirm(downloadList);

        if (this.OnShow != null)
          this.OnShow();

        if (DialogResult.OK == dc.ShowDialog())
        {
          //foreach (LocalFileUpdater file in preDeleteFile)
          //{
          //  string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Path);
          //  if (File.Exists(filePath))
          //    File.Delete(filePath);

          //  config.UpdateFileList.Remove(file);
          //}

          StartDownload(downloadList);
        }
        else
        {
          // 已经在主程序里进行了是否需要更新的判断
          //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\票据管理.exe");

          //if (File.Exists(path))
          //  Process.Start(path);

          //Environment.Exit(0);
        }
      }
    }

    private void StartDownload(List<DownloadFileInfo> downloadList)
    {
      DownloadProgress dp = new DownloadProgress(downloadList);

      if (dp.ShowDialog() == DialogResult.OK)
      {
        //更新成功
        config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Default_Config_File));

        if (bNeedRestart)
        {
          MessageBox.Show("自动更新完成，请点击确定重新启动程序。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);

          string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"票据管理.exe");          

          if (File.Exists(path))
          {
            ProcessStartInfo process = new ProcessStartInfo();
            process.WindowStyle = ProcessWindowStyle.Normal;
            process.FileName = path;

            Process.Start(process);
          }

          Environment.Exit(0);
        }
      }
    }

    private Dictionary<string, RemoteFileUpdater> ParseRemoteXml(string xml)
    {
      XmlDocument document = new XmlDocument();
      document.LoadXml(xml);

      Dictionary<string, RemoteFileUpdater> list = new Dictionary<string, RemoteFileUpdater>();
      foreach (XmlNode node in document.DocumentElement.ChildNodes)
      {
        //System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");

        //string val = System.Text.Encoding.UTF8.GetString(GB2312.GetBytes(node.Attributes["Path"].Value));

        string val = node.Attributes["Path"].Value;

        list.Add(val, new RemoteFileUpdater(node));
      }

      return list;
    }

    public event ShowHandler OnShow;
  }
}

