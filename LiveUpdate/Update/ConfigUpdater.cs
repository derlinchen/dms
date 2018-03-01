using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LiveUpdate
{
  [Serializable]
  public class ConfigUpdater
  {
    private bool enabled = true;

    public bool Enabled 
    { 
      get { return enabled; } 
      set { enabled = value; } 
    }

    private string serverUrl = String.Empty;

    public string ServerUrl 
    { 
      get { return serverUrl; } 
      set { serverUrl = value; } 
    }

    private UpdateFileList updateFileList = new UpdateFileList();

    public UpdateFileList UpdateFileList
    {
      get { return updateFileList; }
      set { updateFileList = value; }
    }

    public ConfigUpdater()
    {

    }

    public static ConfigUpdater LoadConfig(string file)
    {
      XmlSerializer xs = new XmlSerializer(typeof(ConfigUpdater));
      StreamReader sr = new StreamReader(file);
      ConfigUpdater config = xs.Deserialize(sr) as ConfigUpdater;
      sr.Close();

      return config;
    }

    public void SaveConfig(string file)
    {
      XmlSerializer xs = new XmlSerializer(typeof(ConfigUpdater));
      StreamWriter sw = new StreamWriter(file);
      xs.Serialize(sw, this);
      sw.Close();
    }
  }

  [Serializable]
  public class UpdateFileList : List<LocalFileUpdater>
  {

  }
}
