using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 数据库数据操作
  /// </summary>
  public enum DataProviderAction
  {
    /// <summary>
    /// 新建
    /// </summary> 
    Create = 0,
    /// <summary>
    /// 修改
    /// </summary> 
    Update = 1,
    /// <summary>
    /// 删除
    /// </summary>
    Delete = 2,
    /// <summary>
    /// 无动作
    /// </summary>
    NotSet = 3
  }
}
