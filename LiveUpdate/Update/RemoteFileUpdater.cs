using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LiveUpdate
{
  public class RemoteFileUpdater
  {
    private string path = String.Empty;

    public string Path 
    { 
      get { return path; } 
    }

    private string url = String.Empty;

    public string Url 
    { 
      get { return url; } 
    }

    private string lastversion = String.Empty;

    public string LastVersion 
    {
      get { return lastversion; } 
    }
    
    private int size = 0;

    public int Size 
    { 
      get { return size; } 
    }

    private bool needRestart = false;
    
    public bool NeedRestart 
    { 
      get { return needRestart; } 
    }

    public RemoteFileUpdater(XmlNode node)
    {
      System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");

      string val = System.Text.Encoding.UTF8.GetString(GB2312.GetBytes(node.Attributes["Path"].Value));

      this.path = node.Attributes["Path"].Value;
      this.url = node.Attributes["Url"].Value;
      this.lastversion = node.Attributes["LastVersion"].Value;
      this.size = Convert.ToInt32(node.Attributes["Size"].Value);
      this.needRestart = Convert.ToBoolean(node.Attributes["NeedRestart"].Value);
    }
  }
}
