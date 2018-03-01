using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LiveUpdate
{
  public class DownloadFileInfo
  {    
    
    string downloadUrl = String.Empty;
    
    /// <summary>
    /// 要从哪里下载文件
    /// </summary>
    public string DownloadUrl 
    { 
      get { return downloadUrl; } 
    }

    string fileName = String.Empty;

    /// <summary>
    /// 下载完成后要放到哪里去
    /// </summary>
    public string FileFullName 
    { 
      get { return fileName; } 
    }

    public string FileName 
    { 
      get { return Path.GetFileName(FileFullName); } 
    }

    string lastversion = String.Empty;
    
    public string LastVersion 
    {
      get { return lastversion; }
      set { lastversion = value; } 
    }

    int size = 0;

    public int Size 
    { 
      get { return size; } 
    }

    public DownloadFileInfo(string url, string name, string ver, int size)
    {
      this.downloadUrl = url;
      this.fileName = name;
      this.lastversion = ver;
      this.size = size;
    }
  }
}
