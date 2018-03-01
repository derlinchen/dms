using System;

namespace GuFun.WinCore
{
  public class MenuAuth
  {
    private short _mid;

    public short MID
    {
      get { return _mid; }
      set { _mid = value; }
    }

    private string _mCode;

    public string MCode
    {
      get { return _mCode; }
      set { _mCode = value; }
    }

    private int _auth;

    public int Auth
    {
      get { return _auth; }
      set { _auth = value; }
    }

    private string _mShortcut;

    public string MShortcut
    {
      get { return _mShortcut; }
      set { _mShortcut = value; }
    }

    private string _mFunction;

    public string MFunction
    {
      get { return _mFunction; }
      set { _mFunction = value; }
    }

    public MenuAuth()
    {
      _mid = 0;
      _mCode = String.Empty;
      _auth = 0;
      _mShortcut = String.Empty;
      _mFunction = String.Empty;
    }
  }
}
