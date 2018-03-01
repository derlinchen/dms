using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 数据刷新方式
  /// </summary>
  public enum DataChangeType
  {
    /// <summary>
    /// 手动刷新
    /// </summary>
    Custom = 0,
    /// <summary>
    /// 立即刷新
    /// </summary>
    Now,
    /// <summary>
    /// 离开后自动刷新
    /// </summary>
    Leave
  }
}
