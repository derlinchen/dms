using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LiveUpdate
{
  public class LocalFileUpdater
  {
    private string path = String.Empty;

    [XmlAttribute("Path")]
    public string Path
    {
      get 
      {
        return path; 
      }
      set { path = value; }
    }

    private string lastversion = String.Empty;

    [XmlAttribute("LastVersion")]
    public string LastVersion
    {
      get { return lastversion; }
      set { lastversion = value; }
    }

    private int size = 0;

    [XmlAttribute("Size")]
    public int Size
    {
      get { return size; }
      set { size = value; }
    }

    public LocalFileUpdater(string path, string ver, int size)
    {
      this.path = path;
      this.lastversion = ver;
      this.size = size;
    }

    public LocalFileUpdater()
    {

    }
  }
}
