using System;
using System.Data;

namespace GuFun.WinCore
{
  public class CacheParameter
  {
    private string _name;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    private DataTable _data;

    public DataTable Data
    {
      get
      {
        if (_data == null)
          _data = new DataTable();

        return _data;
      }
      set { _data = value; }
    }

    private string _display;

    public string Display
    {
      get { return _display; }
      set { _display = value; }
    }

    public CacheParameter()
    {
      _name = String.Empty;
      _display = String.Empty;
    }
  }
}
