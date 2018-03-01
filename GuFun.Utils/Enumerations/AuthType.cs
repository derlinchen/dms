using System;

namespace GuFun.Utils
{
  [Flags]
  public enum AuthType
  {
    Browse = 1,
    Search = 2,
    New = 4,
    Edit = 8,
    Delete = 16,
    Save = 32,
    Print = 64,
    Export = 128,
    Tran = 256,
    Set = 512,
    Audit = 1024,
    All = Browse | Search | New | Edit | Delete | Print | Export | Tran | Save | Set | Audit
  }
}
