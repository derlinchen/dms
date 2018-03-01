using System;
using System.Collections;

namespace GuFun.WinCore
{
  public class UserCache
  {
    private SysCompany _company;

    public SysCompany Company
    {
      get
      {
        if (_company == null)
          _company = new SysCompany();

        return _company;
      }
      set { _company = value; }
    }

    private SysDept _dept;

    public SysDept Dept
    {
      get
      {
        if (_dept == null)
          _dept = new SysDept();

        return _dept;
      }
      set { _dept = value; }
    }

    private SysMan _man;

    public SysMan Man
    {
      get
      {
        if (_man == null)
          _man = new SysMan();

        return _man;
      }
      set { _man = value; }
    }

    private SysRegister _register;

    public SysRegister Register
    {
      get
      {
        if (_register == null)
          _register = new SysRegister();

        return _register;
      }
      set { _register = value; }
    }

    private SysMenuGroups _menus;

    public SysMenuGroups Menus
    {
      get
      {
        if (_menus == null)
          _menus = new SysMenuGroups();

        return _menus;
      }
      set { _menus = value; }
    }

    private RibTabs _ribbons;

    public RibTabs Ribbons
    {
      get
      {
        if (_ribbons == null)
          _ribbons = new RibTabs();

        return _ribbons;
      }
      set { _ribbons = value; }
    }

    private MenuAuths _auths;

    public MenuAuths Auths
    {
      get
      {
        if (_auths == null)
          _auths = new MenuAuths();

        return _auths;
      }
      set { _auths = value; }
    }
  }
}
